using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace ExtruderController
{
    public partial class Form1 : Form
    {
        System.Drawing.Color color_HeaterOnBackground = System.Drawing.Color.FromArgb(255, 192, 192);
        System.Drawing.Color color_HeaterOffBackground = System.Drawing.Color.FromArgb(255, 255, 255);
        System.Drawing.Color color_ColdForeground = System.Drawing.Color.Blue;
        System.Drawing.Color color_HotForeground = System.Drawing.Color.Red;
        System.Drawing.Color color_OKForeground = System.Drawing.Color.Green;

        SetTempCommand setTempCmd;
        StoreTempCommand storeTempCmd;

        bool SetPointsBusy = false;

        const int tempdiff = 2;

        delegate void SetTextCallback(string text);
        delegate void SetTempStatusesCallback(UInt16[] temperatures, UInt16[] setTemperatures, bool[] heaterStatuses);
        delegate string GetSerialPortFromComboBoxCallback(ComboBox cb);
        delegate bool GetCheckboxValueCallback(CheckBox cb);

        ExtruderCommunicator _communicator;

        ExtruderCommunicator Communicator
        {
            get
            {
                if (_communicator == null)
                    _communicator = new ExtruderCommunicator(GetSafeComboBoxSelectedString(cbSerialPorts), LogToTextBox);
                return _communicator;
            }
        }




        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbSerialPorts.Items.AddRange(SerialPort.GetPortNames());
        }

        public void LogToTextBox(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.richTextBoxLog.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(LogToTextBox);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.richTextBoxLog.Text += text + "\r\n";
            }
            
        }

        public bool GetSafeCheckboxValue(CheckBox cb)
        {
            if (cb.InvokeRequired)
            {
                return (bool)cb.Invoke(
                                          new Func<bool>(() => GetSafeCheckboxValue(cb))
                                      );
            }
            else
            {
                return cb.Checked;
            }
        }

        public string GetSafeComboBoxSelectedString(ComboBox cb)
        {
                if(cb.InvokeRequired)
                {
                    return (string)cb.Invoke(
                                                new Func<string>(() => GetSafeComboBoxSelectedString(cb))
                                            );
                }
                else
                {
                    return (string)cb.SelectedItem; 
                }
        }

        public void  SetTemperatureStatuses(UInt16[] temperatures, UInt16[] setTemperatures, bool[] heaterStatuses)
        {
            if(this.tbTemp0Status.InvokeRequired)
            {
                SetTempStatusesCallback d = new SetTempStatusesCallback(SetTemperatureStatuses);
                this.Invoke(d, new object[] { temperatures, setTemperatures, heaterStatuses });
            }
            else
            {
                if (temperatures.Length == 4)
                {

                    
                    tbTemp0Status.Text = temperatures[0].ToString();
                    if (Math.Abs(temperatures[0] - nudTemp0.Value) <= tempdiff)
                    {
                        tbTemp0Status.ForeColor = color_OKForeground;
                    }
                    else if (temperatures[0] > nudTemp0.Value)
                        tbTemp0Status.ForeColor = color_HotForeground;
                    else
                        tbTemp0Status.ForeColor = color_ColdForeground;

                    if (heaterStatuses[0])
                        tbTemp0Status.BackColor = color_HeaterOnBackground;
                    else
                        tbTemp0Status.BackColor = color_HeaterOffBackground;

                    
                    tbTemp1Status.Text = temperatures[1].ToString();
                    if (Math.Abs(temperatures[1] - nudTemp1.Value) <= tempdiff)
                    {
                        tbTemp1Status.ForeColor = color_OKForeground;
                    }
                    else if (temperatures[1] > nudTemp1.Value)
                        tbTemp1Status.ForeColor = color_HotForeground;
                    else
                        tbTemp1Status.ForeColor = color_ColdForeground;

                    if (heaterStatuses[1])
                        tbTemp1Status.BackColor = color_HeaterOnBackground;
                    else
                        tbTemp1Status.BackColor = color_HeaterOffBackground;

                    
                    tbTemp2Status.Text = temperatures[2].ToString();
                    if (Math.Abs(temperatures[2] - nudTemp2.Value) <= tempdiff)
                    {
                        tbTemp2Status.ForeColor = color_OKForeground;
                    }
                    else if (temperatures[2] > nudTemp2.Value)
                        tbTemp2Status.ForeColor = color_HotForeground;
                    else
                        tbTemp2Status.ForeColor = color_ColdForeground;

                    if (heaterStatuses[2])
                        tbTemp2Status.BackColor = color_HeaterOnBackground;
                    else
                        tbTemp2Status.BackColor = color_HeaterOffBackground;

                    
                    tbTemp3Status.Text = temperatures[3].ToString();
                    if (Math.Abs(temperatures[3] - nudTemp3.Value) <= tempdiff)
                    {
                        tbTemp3Status.ForeColor = color_OKForeground;
                    }
                    else if (temperatures[3] > nudTemp3.Value)
                        tbTemp3Status.ForeColor = color_HotForeground;
                    else
                        tbTemp3Status.ForeColor = color_ColdForeground;

                    if (heaterStatuses[3])
                        tbTemp3Status.BackColor = color_HeaterOnBackground;
                    else
                        tbTemp3Status.BackColor = color_HeaterOffBackground;


                    if (!SetPointsBusy)
                    {
                        nudTemp0.Value = setTemperatures[0];
                        nudTemp1.Value = setTemperatures[1];
                        nudTemp2.Value = setTemperatures[2];
                        nudTemp3.Value = setTemperatures[3];
                    }
                                          
                }

            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        UInt16[] getSetTempValuesFromForm()
        {
            UInt16[] values = new UInt16[4];
            
            values[0] = (UInt16)nudTemp0.Value;
            values[1] = (UInt16)nudTemp1.Value;
            values[2] = (UInt16)nudTemp2.Value;
            values[3] = (UInt16)nudTemp3.Value;
            
            return values;
        }

        private void nudTemp_ValueChanged(object sender, EventArgs e)
        {
            setTempCmd = new SetTempCommand(getSetTempValuesFromForm());
            buttonSaveSetpoints.Enabled = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = null;
            GetStatusCommand cmd = new GetStatusCommand();
            if (Communicator.SendMessageGetReponse(cmd))
            {
                e.Result = cmd;
            }

            if (storeTempCmd != null)
            {
                Communicator.SendMessageGetReponse(storeTempCmd);
                storeTempCmd = null;
            }
            else if (setTempCmd != null)
            {
                Communicator.SendMessageGetReponse(setTempCmd);
                setTempCmd = null;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Result != null)
                SetTemperatureStatuses(((GetStatusCommand)e.Result).Temperatures, ((GetStatusCommand)e.Result).SetTemperatures, ((GetStatusCommand)e.Result).HeaterStatuses);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(checkBox1.Checked && ! backgroundWorker1.IsBusy && ! String.IsNullOrEmpty(GetSafeComboBoxSelectedString(cbSerialPorts)))
                backgroundWorker1.RunWorkerAsync();
        }

        private void buttonSaveSetpoints_Click(object sender, EventArgs e)
        {
            storeTempCmd = new StoreTempCommand(getSetTempValuesFromForm());
            buttonSaveSetpoints.Enabled = false;
        }

        private void nudTemp_Enter(object sender, EventArgs e)
        {
            SetPointsBusy = true;
        }

        private void nudTemp_Leave(object sender, EventArgs e)
        {
            SetPointsBusy = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

    }
}
