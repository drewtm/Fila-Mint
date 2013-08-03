using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtruderController
{
    class GetStatusCommand : ExtruderCommand
    {
        const int NUM_HEAT_ZONES = 4;
        public UInt16[] Temperatures { get; set; }
        public UInt16[] SetTemperatures { get; set; }
        public bool[] HeaterStatuses { get; set; }

        public override MessageType MessageType {get{return MessageType.CMD_GET_STATUS; }}

        public override byte[] DataBytes{
            get
            {
                // Return blank bytes as this command has no params
                return new byte[MESSAGE_DATA_LENGTH];
            }
        }

        public override void ParseReponse(byte[] responseBytes)
        {
            if (ExtruderCommand.VerifyCheckSum(responseBytes))
            {
                if (responseBytes[MESSAGE_TYPE_OFFSET] == (byte)MessageType.RSP_GET_STATUS)
                {
                    // Initialize Temperature Array
                    Temperatures = new UInt16[NUM_HEAT_ZONES];
                    SetTemperatures = new UInt16[NUM_HEAT_ZONES];
                    HeaterStatuses = new bool[NUM_HEAT_ZONES];

                    // Go through reponse and parse binary data into values and store in Temperature Array
                    int dataOffset = MESSAGE_HEADER_LENGTH;
                    
                    for (int idx = 0; idx < NUM_HEAT_ZONES; idx++)
                    {
                        Temperatures[idx] = BitConverter.ToUInt16(responseBytes, dataOffset);
                        dataOffset += sizeof(UInt16);
                    }

                    for (int idx = 0; idx < NUM_HEAT_ZONES; idx++)
                    {
                        SetTemperatures[idx] = BitConverter.ToUInt16(responseBytes, dataOffset);
                        dataOffset += sizeof(UInt16);
                    }

                    for (int idx = 0; idx < NUM_HEAT_ZONES; idx++)
                    {
                        HeaterStatuses[idx] = BitConverter.ToBoolean(responseBytes, dataOffset);
                        dataOffset += sizeof(bool);
                    }

                    // Set hasValidResponseFlag
                    hasValidResponse = true;
                }
            }
        }

        public override string GetResultString()
        {
            string ret = String.Empty;

            for (int idx = 0; idx < NUM_HEAT_ZONES; idx++)
                ret += Enum.GetName(typeof(TempZonesEnum), idx) + " : " + Temperatures[idx].ToString() + "\r\n";

            return ret;
                
        }

    }
}
