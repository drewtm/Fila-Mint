//This file is part of the Fila-Mint control software, written by Matt Middleton

#include "Communications.h"

// Shared Global Variables
CommPacket gCommPacketTX;
CommPacket gCommPacketRX;
Cmd_Params gCmdParams;

// Local Global Variables
//uint8_t buffer[sizeof(CommPacket)];
ParseState currentState;

// Functions

void SetupCommPort(uint16_t baudy)
{
  Serial.begin(baudy);
  currentState = WAIT_FOR_START;
}

void SendCommand(MessageType type, Cmd_Params *params)
{
  uint8_t checksum = 0;
  uint8_t idx;
  
  // Assign data to communications struct
  gCommPacketTX.commStruct.startChar = START_CHAR;
  gCommPacketTX.commStruct.messageType = type;
  gCommPacketTX.commStruct.params = *params;
  
  // Calculate checksum (up through last byte which will store the checksum itself)
  for(idx = 0; idx < sizeof(CommPacket) - 1; idx++)
  {
    checksum |= gCommPacketTX.bytes[idx];
  }
  
  // Store checksum in communications struct
  gCommPacketTX.commStruct.checksum = checksum;
  
  Serial.WRITE(gCommPacketTX.bytes, sizeof(CommPacket));

}

void SendStatusUpdate()
{
  int idx = 0;
  
  gCmdParams.currentStatus = gCurrentStatus;
  //this for-loop may be redundant
  for(idx = 0; idx < NUM_HEATER_ZONES; idx++)
  {
    gCmdParams.currentStatus.setTemps[idx] = gCurrentStatus.setTemps[idx];
  }
  
  SendCommand(RSP_GET_STATUS, &gCmdParams);
}


void SendOK()
{
  gCmdParams.resultStatus = 1;
  SendCommand(RSP_SET_TEMPS, &gCmdParams);
}

void ProcessReceivedCommands()
{
  uint8_t currentChar;
  uint8_t idx;
  uint8_t cksum;
  

    switch(currentState)
    {
      case WAIT_FOR_START:
        
        // Read Port
        currentChar = Serial.read();
        
        // Go to Next State
        if(currentChar == START_CHAR)
        {
          //Serial.println("Got Start Char");
          gCommPacketRX.bytes[0] = currentChar;
          currentState = READ_DATA;
        }
        // Stay Here
        else
        {
          gCommPacketRX.bytes[0] = 0;
          currentState = WAIT_FOR_START;
        }
      
      break;
      
      case READ_DATA:
      
        // Read 1 less byte since start char already in struct
        if(Serial.available() >= sizeof(CommPacket) - 1)
        {
          //Serial.println("Read Data");
          Serial.readBytes((char *)&gCommPacketRX.bytes[1], sizeof(CommPacket) - 1);
          currentState = VERIFY_CRC;
        }
        else
          currentState = READ_DATA;
      
      break;
      
      case VERIFY_CRC:
      
        cksum = 0;
        for(idx = 0; idx < sizeof(CommPacket) - 1; idx++)
          cksum |= gCommPacketRX.bytes[idx];
        
        if(cksum == gCommPacketRX.commStruct.checksum)
        {
          currentState = PROCESS_VALID_PACKET;
          //Serial.println("Valid CRC");
        }
        else
        {
          //Serial.println("Invalid CRC");
          currentState = WAIT_FOR_START;  
        }
      
      break;
      
      case PROCESS_VALID_PACKET:
      
        //Serial.println("Processing Packet");
      
        switch(gCommPacketRX.commStruct.messageType)
        {
          case CMD_GET_STATUS:
          
            SendStatusUpdate();
          
          break;
          
          case CMD_SET_TEMPS:
            // Don't save to EEPROM, just RAM
            SetTemps(gCommPacketRX.commStruct.params.setTemps, 0);
            SendOK();
          
          break;
                   
          case CMD_STORE_SETTEMPS:
            // Save to RAM and EEPROM
            SetTemps(gCommPacketRX.commStruct.params.setTemps, 1);
            SendOK();
          
          break;
          
        }
        
        currentState = WAIT_FOR_START;
      
      break;
      
      
      default:
      
        currentState = WAIT_FOR_START;
      
      break;
    }
}


