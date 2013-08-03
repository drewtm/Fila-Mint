//This file is part of the Fila-Mint control software, written by Matt Middleton

#include "Arduino.h"
#include "Process.h"
#include "EEPROM.h"

// Shared Globals
CurrentStatusParams gCurrentStatus;
//SetTempsParams gSetTemps;

void StoreOneSetTempInEEPROM(uint16_t temp, uint16_t eepromAddress)
{
    // Write LSB First
    EEPROM.write(eepromAddress, (uint8_t)temp);

    // Write MSB Second
    EEPROM.write(eepromAddress + 1, (uint8_t)(temp >> 8));
}

uint16_t GetOneSetTempInEEPROM(uint16_t eepromAddress)
{
    uint16_t ret = 0;
    
    // Read LSB First
    ret = EEPROM.read(eepromAddress);
    // Write MSB Second
    ret += (EEPROM.read(eepromAddress + 1) << 8);
  
    return ret;
}

uint8_t CalcSetTempChecksum(uint16_t setTemps[NUM_HEATER_ZONES])
{
   int idx;
   uint8_t checksum = 0;
   
   for(idx = 0; idx < NUM_HEATER_ZONES; idx++)
   {
     checksum |= (uint8_t)(setTemps[idx]);
     checksum |= (uint8_t)(setTemps[idx] >> 8);
   }
   
   return checksum;
}

void SaveSetTempsToEEPROM(uint16_t setTemps[NUM_HEATER_ZONES])
{
    int idx;
    uint16_t eepromAddress = SET_TEMPS_EEPROM_START_ADDR;
    uint8_t checksum;
    
    digitalWrite(13, HIGH);
    
    for(idx = 0; idx < NUM_HEATER_ZONES; idx++)
    {
      StoreOneSetTempInEEPROM(setTemps[idx], eepromAddress);
      eepromAddress += sizeof(uint16_t);
    }
    
    checksum = CalcSetTempChecksum(setTemps);
    EEPROM.write(eepromAddress, checksum);
}

void GetSetTempsFromEEPROM(uint16_t setTemps[NUM_HEATER_ZONES])
{
   int idx;
   uint16_t eepromAddress = SET_TEMPS_EEPROM_START_ADDR;
   uint8_t calculatedChecksum;
   uint8_t readCheckSum;
  
   for(idx = 0; idx < NUM_HEATER_ZONES; idx++)
   {
     setTemps[idx] = GetOneSetTempInEEPROM(eepromAddress);
     eepromAddress += sizeof(uint16_t);
   }
  
   readCheckSum = EEPROM.read(eepromAddress);
   calculatedChecksum = CalcSetTempChecksum(setTemps);
  
   if(readCheckSum != calculatedChecksum)
   {
      
    for(idx = 0; idx < NUM_HEATER_ZONES; idx++)
    {
      setTemps[idx] = idx * 3;
    }
         
    SaveSetTempsToEEPROM(setTemps);
      
    while(1)
    {    
      digitalWrite(13, HIGH);
      delay(500);
      digitalWrite(13, LOW);
      delay(500);
    } 
  }
  
}

void InitSetPoints()
{
  GetSetTempsFromEEPROM(gCurrentStatus.setTemps);
}

void SetTemps(uint16_t setTemps[NUM_HEATER_ZONES], uint8_t saveToEEPROM)
{
  int idx;
  
  for(idx = 0; idx < NUM_HEATER_ZONES; idx++)
  {
    // Set Values for Ram Copy
    gCurrentStatus.setTemps[idx] = setTemps[idx]; 
  }
  
  if(saveToEEPROM == 1)
    SaveSetTempsToEEPROM(gCurrentStatus.setTemps);
 
}

void DemoAdjustTemps()
{
  int idx;
  
  for(idx = 0; idx < NUM_HEATER_ZONES; idx++)
  {
    gCurrentStatus.currentTemps[idx] = random(0, 500);
    
    if(gCurrentStatus.currentTemps[idx] < gCurrentStatus.setTemps[idx])
      gCurrentStatus.currentHeaterStatuses[idx] = 1;
    else
      gCurrentStatus.currentHeaterStatuses[idx] = 0;
  }  
}


