//This file is part of the Fila-Mint control software, written by Matt Middleton

#ifndef COMMUNICATIONS_H
#define COMMUNICATIONS_H 

#include "Arduino.h"
#include "Process.h"


#define START_CHAR '$'

// Data Types


typedef enum
{
  WAIT_FOR_START,
  READ_DATA,
  VERIFY_CRC,
  PROCESS_VALID_PACKET
}ParseState;


typedef union
{
  uint8_t resultStatus;
  CurrentStatusParams currentStatus;
  uint16_t setTemps[NUM_HEATER_ZONES];
  
}Cmd_Params;

typedef enum
{
  // Receive Types
  CMD_GET_STATUS = 30,
  RSP_GET_STATUS = 31,
  
  CMD_SET_TEMPS = 32,
  RSP_SET_TEMPS = 33,
 
  CMD_STORE_SETTEMPS = 36,
  RSP_STORE_SETTEMPS = 37
  
}MessageType;

//may need to be byte aligned/packed to one byte via PRAGMA of some sort
typedef struct
{
  uint8_t startChar;
  uint8_t messageType;
  Cmd_Params params;
  uint8_t checksum;
} CommStruct;

typedef union
{
  CommStruct commStruct;
  uint8_t bytes[sizeof(CommStruct)];
}CommPacket;



// Shared Global Varaibles
extern CommPacket gCommPacketRX;
extern CommPacket gCommPacketTX;
extern Cmd_Params gCmdParams;


// Function Prototypes
void SetupCommPort(uint16_t baudy);
void ProcessReceivedCommands();

#endif
