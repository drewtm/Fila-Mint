//This file is part of the Fila-Mint control software, written by Matt Middleton

#include "Communications.h"
#include "Process.h"
#include "Lookup.h"

#define num_zones NUM_HEATER_ZONES
#define num_samples 3
#define hysteresis_val 3

#define BAUD 57600

//pins///////////
#define z1_heater 2
#define z2_heater 3
#define z3_heater 4
#define z4_heater 5
#define z1_temp A0
#define z2_temp A1
#define z3_temp A2
#define z4_temp A3

const int thermistor_pins[]= {z1_temp, z2_temp, z3_temp, z4_temp};
const int heater_pins[] ={z1_heater, z2_heater, z3_heater, z4_heater};

void setup() 
{
  int thisPin;
  
  SetupCommPort(BAUD);
  pinMode(13, OUTPUT);
  digitalWrite(13, LOW);
  InitSetPoints();
  
  //set thermistor pins as inputs, explicitly
  for (int thisPin = 0; thisPin < num_zones; thisPin++)  {
    pinMode(thermistor_pins[thisPin], INPUT);  
  }
  //set heater controller pins as outputs
  for (int thisPin = 0; thisPin < num_zones; thisPin++)  {
    pinMode(heater_pins[thisPin], OUTPUT);  
  }
}

void loop()
{
  int thermistorVals[num_zones];
  int TableTempSpan;
  int MeasVoltSpan;
  int TableVoltSpan;
  int i = 0;
  int j = 0;
  int hysteresis;
  static boolean serialStarted = 0;
  static boolean loopIndicator = 0;
  
  //if the serial port wasn't successfully opened during setup, keep trying to open it
  if(!serialStarted){
    if(!Serial){
      Serial.begin(BAUD);
      serialStarted = 1;
    }
  }
  
  ProcessReceivedCommands(); //checks for comm from the PC and handles it
  
  //Get temps
  for (i=0; i<num_zones; i++) {
    thermistorVals[i]=analogRead(thermistor_pins[i]);
    for (j=0; j<(num_samples-1); j++) {
      thermistorVals[i] += analogRead(thermistor_pins[i]);
    }
    thermistorVals[i] = thermistorVals[i]/num_samples; 
  }

  //Process temps
  for (int j=0; j<num_zones; j++) {
    for (int i=1; i<numtemps; i++) {
      if (Volts2Temps[i][0]>thermistorVals[j]){
        //linear interpolation
        TableTempSpan = Volts2Temps[i][1]-Volts2Temps[i-1][1];
        MeasVoltSpan = thermistorVals[j]-Volts2Temps[i-1][0];
        TableVoltSpan = Volts2Temps[i][0]-Volts2Temps[i-1][0];
        gCurrentStatus.currentTemps[j] = Volts2Temps[i-1][1] + (MeasVoltSpan*TableTempSpan)/TableVoltSpan;
        break;  //end the search through the lookup table when we've found the current temperature
      }
    }
    
    //generate hysteresis by flipping an offset depending on whether we're heating or cooling
    //this avoids unneccessary heater flickering from possibly noisy temperature sensors
    hysteresis=hysteresis_val*(1-2*gCurrentStatus.currentHeaterStatuses[j]);
    
    //calculate a new heater status
    if((gCurrentStatus.currentTemps[j]+hysteresis)<gCurrentStatus.setTemps[j]) {
      digitalWrite(heater_pins[j],HIGH);
      gCurrentStatus.currentHeaterStatuses[j]=1;
      if(j==(NUM_HEATER_ZONES-1)) digitalWrite(13,HIGH);
    }
    else {
      digitalWrite(heater_pins[j],LOW);
      gCurrentStatus.currentHeaterStatuses[j]=0;
      if(j==(NUM_HEATER_ZONES-1)) digitalWrite(13,LOW);
    }
  }
  
}

