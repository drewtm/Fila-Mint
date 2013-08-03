namespace ExtruderController
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cbSerialPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonSetTemps = new System.Windows.Forms.Button();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.buttonGetStatusUpdate = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSaveSetpoints = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTemp3Status = new System.Windows.Forms.TextBox();
            this.tbTemp2Status = new System.Windows.Forms.TextBox();
            this.tbTemp1Status = new System.Windows.Forms.TextBox();
            this.tbTemp0Status = new System.Windows.Forms.TextBox();
            this.nudTemp3 = new System.Windows.Forms.NumericUpDown();
            this.nudTemp2 = new System.Windows.Forms.NumericUpDown();
            this.nudTemp1 = new System.Windows.Forms.NumericUpDown();
            this.nudTemp0 = new System.Windows.Forms.NumericUpDown();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTemp3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTemp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTemp1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTemp0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbSerialPorts
            // 
            this.cbSerialPorts.FormattingEnabled = true;
            this.cbSerialPorts.Location = new System.Drawing.Point(78, 3);
            this.cbSerialPorts.Name = "cbSerialPorts";
            this.cbSerialPorts.Size = new System.Drawing.Size(158, 21);
            this.cbSerialPorts.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ComPort";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonSetTemps);
            this.tabPage2.Controls.Add(this.richTextBoxLog);
            this.tabPage2.Controls.Add(this.buttonGetStatusUpdate);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(644, 423);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Diagnostics";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // buttonSetTemps
            // 
            this.buttonSetTemps.Location = new System.Drawing.Point(17, 44);
            this.buttonSetTemps.Name = "buttonSetTemps";
            this.buttonSetTemps.Size = new System.Drawing.Size(110, 23);
            this.buttonSetTemps.TabIndex = 8;
            this.buttonSetTemps.Text = "SetTemps";
            this.buttonSetTemps.UseVisualStyleBackColor = true;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Location = new System.Drawing.Point(17, 73);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(567, 335);
            this.richTextBoxLog.TabIndex = 7;
            this.richTextBoxLog.Text = "";
            // 
            // buttonGetStatusUpdate
            // 
            this.buttonGetStatusUpdate.Location = new System.Drawing.Point(17, 15);
            this.buttonGetStatusUpdate.Name = "buttonGetStatusUpdate";
            this.buttonGetStatusUpdate.Size = new System.Drawing.Size(110, 23);
            this.buttonGetStatusUpdate.TabIndex = 6;
            this.buttonGetStatusUpdate.Text = "Get Status Update";
            this.buttonGetStatusUpdate.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.buttonSaveSetpoints);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbTemp3Status);
            this.tabPage1.Controls.Add(this.tbTemp2Status);
            this.tabPage1.Controls.Add(this.tbTemp1Status);
            this.tabPage1.Controls.Add(this.tbTemp0Status);
            this.tabPage1.Controls.Add(this.nudTemp3);
            this.tabPage1.Controls.Add(this.nudTemp2);
            this.tabPage1.Controls.Add(this.nudTemp1);
            this.tabPage1.Controls.Add(this.nudTemp0);
            this.tabPage1.Controls.Add(this.pictureBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(644, 423);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Extruder Status";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(251, 389);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(260, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Burn current setpoints into Flash memory for next time:";
            // 
            // buttonSaveSetpoints
            // 
            this.buttonSaveSetpoints.Location = new System.Drawing.Point(517, 384);
            this.buttonSaveSetpoints.Name = "buttonSaveSetpoints";
            this.buttonSaveSetpoints.Size = new System.Drawing.Size(110, 23);
            this.buttonSaveSetpoints.TabIndex = 12;
            this.buttonSaveSetpoints.Text = "Save Setpoints";
            this.buttonSaveSetpoints.UseVisualStyleBackColor = true;
            this.buttonSaveSetpoints.Click += new System.EventHandler(this.buttonSaveSetpoints_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(174, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Current Values";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(198, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Setpoints";
            // 
            // tbTemp3Status
            // 
            this.tbTemp3Status.Location = new System.Drawing.Point(495, 126);
            this.tbTemp3Status.Name = "tbTemp3Status";
            this.tbTemp3Status.ReadOnly = true;
            this.tbTemp3Status.Size = new System.Drawing.Size(66, 20);
            this.tbTemp3Status.TabIndex = 9;
            this.tbTemp3Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbTemp2Status
            // 
            this.tbTemp2Status.Location = new System.Drawing.Point(415, 126);
            this.tbTemp2Status.Name = "tbTemp2Status";
            this.tbTemp2Status.ReadOnly = true;
            this.tbTemp2Status.Size = new System.Drawing.Size(66, 20);
            this.tbTemp2Status.TabIndex = 8;
            this.tbTemp2Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbTemp1Status
            // 
            this.tbTemp1Status.Location = new System.Drawing.Point(336, 126);
            this.tbTemp1Status.Name = "tbTemp1Status";
            this.tbTemp1Status.ReadOnly = true;
            this.tbTemp1Status.Size = new System.Drawing.Size(66, 20);
            this.tbTemp1Status.TabIndex = 7;
            this.tbTemp1Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbTemp0Status
            // 
            this.tbTemp0Status.Location = new System.Drawing.Point(255, 126);
            this.tbTemp0Status.Name = "tbTemp0Status";
            this.tbTemp0Status.ReadOnly = true;
            this.tbTemp0Status.Size = new System.Drawing.Size(66, 20);
            this.tbTemp0Status.TabIndex = 6;
            this.tbTemp0Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudTemp3
            // 
            this.nudTemp3.Location = new System.Drawing.Point(495, 78);
            this.nudTemp3.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudTemp3.Name = "nudTemp3";
            this.nudTemp3.Size = new System.Drawing.Size(66, 20);
            this.nudTemp3.TabIndex = 5;
            this.nudTemp3.ValueChanged += new System.EventHandler(this.nudTemp_ValueChanged);
            this.nudTemp3.Enter += new System.EventHandler(this.nudTemp_Enter);
            this.nudTemp3.Leave += new System.EventHandler(this.nudTemp_Leave);
            // 
            // nudTemp2
            // 
            this.nudTemp2.Location = new System.Drawing.Point(415, 78);
            this.nudTemp2.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudTemp2.Name = "nudTemp2";
            this.nudTemp2.Size = new System.Drawing.Size(66, 20);
            this.nudTemp2.TabIndex = 4;
            this.nudTemp2.ValueChanged += new System.EventHandler(this.nudTemp_ValueChanged);
            this.nudTemp2.Enter += new System.EventHandler(this.nudTemp_Enter);
            this.nudTemp2.Leave += new System.EventHandler(this.nudTemp_Leave);
            // 
            // nudTemp1
            // 
            this.nudTemp1.Location = new System.Drawing.Point(336, 78);
            this.nudTemp1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudTemp1.Name = "nudTemp1";
            this.nudTemp1.Size = new System.Drawing.Size(66, 20);
            this.nudTemp1.TabIndex = 3;
            this.nudTemp1.ValueChanged += new System.EventHandler(this.nudTemp_ValueChanged);
            this.nudTemp1.Enter += new System.EventHandler(this.nudTemp_Enter);
            this.nudTemp1.Leave += new System.EventHandler(this.nudTemp_Leave);
            // 
            // nudTemp0
            // 
            this.nudTemp0.Location = new System.Drawing.Point(255, 78);
            this.nudTemp0.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudTemp0.Name = "nudTemp0";
            this.nudTemp0.Size = new System.Drawing.Size(66, 20);
            this.nudTemp0.TabIndex = 2;
            this.nudTemp0.ValueChanged += new System.EventHandler(this.nudTemp_ValueChanged);
            this.nudTemp0.Enter += new System.EventHandler(this.nudTemp_Enter);
            this.nudTemp0.Leave += new System.EventHandler(this.nudTemp_Leave);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(645, 252);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(26, 53);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(652, 449);
            this.tabControl1.TabIndex = 6;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(294, 8);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Connect:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::ExtruderController.Properties.Resources.logo_desktop_commander;
            this.pictureBox1.Location = new System.Drawing.Point(503, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 65);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 517);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSerialPorts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "fila-mint Desktop Commander";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTemp3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTemp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTemp1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTemp0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSerialPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonSetTemps;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Button buttonGetStatusUpdate;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTemp3Status;
        private System.Windows.Forms.TextBox tbTemp2Status;
        private System.Windows.Forms.TextBox tbTemp1Status;
        private System.Windows.Forms.TextBox tbTemp0Status;
        private System.Windows.Forms.NumericUpDown nudTemp3;
        private System.Windows.Forms.NumericUpDown nudTemp2;
        private System.Windows.Forms.NumericUpDown nudTemp1;
        private System.Windows.Forms.NumericUpDown nudTemp0;
        private System.Windows.Forms.TabControl tabControl1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSaveSetpoints;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;

    }
}

