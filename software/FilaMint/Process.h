//This file is part of the Fila-Mint control software, written by Matt Middleton

#ifndef PROCESS_PARAMETERS_H
#define PROCESS_PARAMETERS_H

#include "Arduino.h"

#define NUM_HEATER_ZONES  4
#define SET_TEMPS_EEPROM_START_ADDR 10

typedef enum 
{
  ZONE1 = 0,
  ZONE2,
  ZONE3,
  ZONE4,
  
}Zones;

typedef struct
{
  uint16_t currentTemps[NUM_HEATER_ZONES];
  uint16_t setTemps[NUM_HEATER_ZONES];
  uint8_t currentHeaterStatuses[NUM_HEATER_ZONES];
  
}CurrentStatusParams;
/*
typedef struct
{
  uint16_t setTemps[NUM_HEATER_ZONES];
}SetTempsParams;
*/
extern CurrentStatusParams gCurrentStatus;
//extern SetTempsParams gSetTemps;

void InitSetPoints();
void SetTemps(uint16_t setTemps[], uint8_t saveToEEPROM);
void DemoAdjustTemps();

#endif
