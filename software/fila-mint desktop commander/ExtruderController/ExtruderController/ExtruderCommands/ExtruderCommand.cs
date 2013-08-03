using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtruderController
{
    abstract class ExtruderCommand
    {
        protected const char START_CHAR = '$';
        protected const int MESSAGE_HEADER_LENGTH = 2; // start char + message type
        protected const int MESSAGE_DATA_LENGTH = 20;
        protected const int MESSAGE_CHECKSUM_LENGTH = 1;
        protected const int MESSAGE_TYPE_OFFSET = 1;
        public const int MESSAGE_TOTAL_LENGTH = MESSAGE_HEADER_LENGTH + MESSAGE_DATA_LENGTH + MESSAGE_CHECKSUM_LENGTH;
        
        
        protected byte[] _commandBytes;

        public abstract MessageType MessageType { get; }
        public abstract byte[] DataBytes { get; }
        public abstract void ParseReponse(byte[] responseBytes);
        public abstract string GetResultString();
        
        public bool hasValidResponse;
     
        public ExtruderCommand()
        {
            _commandBytes = new byte[MESSAGE_TOTAL_LENGTH];
            hasValidResponse = false;
        }

        protected void CalculateAndInsertCheckSum()
        {
            int idx;
            byte checksum = 0;
            for (idx = 0; idx < MESSAGE_TOTAL_LENGTH - 1; idx++)
                checksum |= _commandBytes[idx];
            _commandBytes[idx] = checksum;
        }

        public static bool VerifyCheckSum(byte[] responseBytes)
        {
            int calcChecksum = 0;
            int idx;
            bool ret = false;

            if (responseBytes.Length == MESSAGE_TOTAL_LENGTH)
            {
                for (idx = 0; idx < responseBytes.Length - 1; idx++)
                {
                    calcChecksum |= responseBytes[idx];
                }

                if (calcChecksum == responseBytes[idx])
                    return true;
            }

            return ret;
        }

        public byte[] GetBytes()
        {
            _commandBytes[0] = (byte)START_CHAR;
            _commandBytes[1] = (byte)MessageType;
            Array.Copy(DataBytes, 0, _commandBytes, 2, MESSAGE_DATA_LENGTH);
            CalculateAndInsertCheckSum();
            return _commandBytes;

        }

    }

}
