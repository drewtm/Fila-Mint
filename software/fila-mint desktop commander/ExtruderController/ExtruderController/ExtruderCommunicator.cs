using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace ExtruderController
{ 
    class ExtruderCommunicator : IDisposable
    {

        public delegate void LogSerialDataDelegate(string data);
        public LogSerialDataDelegate LogSerialData;

        const int baudRate = 57600;
        const int timeoutMS = 500;
        byte[] readBuf;

        private readonly SerialPort port;

        public ExtruderCommunicator(string portName, LogSerialDataDelegate logDelegate = null)
        {
            this.port = new SerialPort(portName, baudRate);
            this.LogSerialData += logDelegate;
            readBuf = new byte[ExtruderCommand.MESSAGE_TOTAL_LENGTH];
            //port.DataReceived += SerialReceived;
        }

        public bool SendMessageGetReponse(ExtruderCommand command)
        {
            bool ret = false;

            if (!port.IsOpen)
                port.Open();

            command.hasValidResponse = false;

            // Clear out any junk in out buffer before transmitting
            port.DiscardOutBuffer();
            this.port.Write(command.GetBytes(), 0, command.GetBytes().Length);
            
            // Log output
            if(this.LogSerialData != null)
                this.LogSerialData("\r\nTX: " + BitConverter.ToString(command.GetBytes()));
            
            // Wait here until enough bytes are avaiable or timeout
            DateTime startReceiveTime = DateTime.Now;
            while (port.BytesToRead < ExtruderCommand.MESSAGE_TOTAL_LENGTH && (DateTime.Now - startReceiveTime).TotalMilliseconds < timeoutMS);

            // If we haven't timed out
            if ((DateTime.Now - startReceiveTime).TotalMilliseconds < timeoutMS)
            {
                port.Read(readBuf, 0, ExtruderCommand.MESSAGE_TOTAL_LENGTH);


                if (this.LogSerialData != null)
                {
                    this.LogSerialData("RX: " + BitConverter.ToString(readBuf) + "\r\n");
                    //this.LogSerialData("RX(ASCII): " + System.Text.Encoding.ASCII.GetString(readBuf) + "\r\n");
                }

                // Delete any remaining junk in in buffer
                port.DiscardInBuffer();
                command.ParseReponse(readBuf);
                if(command.hasValidResponse)
                    ret = true;
            }
             

            return ret;
            
        }

        //not used anymore, was for debugging
        //public void SerialReceived(object sender, SerialDataReceivedEventArgs args)
        //{
        //    if (this.LogSerialData != null)
        //    {
        //        int bytesToRead = port.BytesToRead;
        //        readBuf = new byte[bytesToRead];
        //        port.Read(readBuf, 0, bytesToRead);

        //        this.LogSerialData("RX: " + BitConverter.ToString(readBuf) + "\r\n");
        //        this.LogSerialData("RX(ASCII): " + System.Text.Encoding.ASCII.GetString(readBuf) + "\r\n");
        //    }

        //}

        //public void SetReceiveHandler(SerialDataReceivedEventHandler handler)
        //{
        //    this.port.DataReceived += handler;
        //}


        public void Dispose()
        {
            port.Close();
        }
    }
}
