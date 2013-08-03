using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtruderController
{
    class SetTempCommand : ExtruderCommand
    {
        public override MessageType MessageType {get{return MessageType.CMD_SET_TEMPS; }}

        public override byte[] DataBytes{
            get
            {
                byte[] bytes = new byte[MESSAGE_DATA_LENGTH];
                for(int idx = 0; idx < NUM_HEAT_ZONES; idx++)
                {
                    Array.Copy(BitConverter.GetBytes(SetTemperatures[idx]), 0, bytes, idx * sizeof(UInt16), sizeof(UInt16));
                }
                return bytes;
            }
        }

        const int NUM_HEAT_ZONES = 4;
        UInt16[] _setTemperatures;
        public UInt16[] SetTemperatures { 
            get { 
                    if(_setTemperatures == null)
                        _setTemperatures = new UInt16[NUM_HEAT_ZONES];
                        return _setTemperatures;
                }
        } 

        public SetTempCommand(UInt16[] Temperatures)
        {
            for(int idx = 0; idx < NUM_HEAT_ZONES; idx++)
            {
                if(Temperatures.Length >= idx + 1)
                    this.SetTemperatures[idx] = Temperatures[idx];
                else
                    this.SetTemperatures[idx] = 0;

            }
        }
            


        public override void ParseReponse(byte[] responseBytes)
        {
            if (ExtruderCommand.VerifyCheckSum(responseBytes))
            {
                if (responseBytes[MESSAGE_TYPE_OFFSET] == (byte)MessageType.RSP_SET_TEMPS)
                {
                    // Go through reponse and parse binary data into values and store in Temperature Array
                    int dataOffset = MESSAGE_HEADER_LENGTH;

                    if (responseBytes[dataOffset] == 1)
                        hasValidResponse = true;
                }
            }
        }

        public override string GetResultString()
        {
            if(hasValidResponse)
                return "Temperatures Properly Set";
            else
                return "Set Command Failed";
        }

    }
}
