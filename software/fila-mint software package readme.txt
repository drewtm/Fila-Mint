The zip file contains:

-A visual C# project that compiles into the Fila-Mint Desktop Commander program, for monitoring and adjusting the temperatures in the extruder barrel zones. It shows readings from all four of our machine's temperature zones; it can command four corresponding heaters, but our machine only has the last three.

-An Arduino sketch that runs on the Leonardo to control the temperatures. This will run with or without the PC communications.

-A couple of bug-fixes for the Arduino 1.0.1 libraries that allow Arduino's documented serial communications to work properly on the Leonardo.

The software usage is pretty simple and self-explanatory, but it is worth noting that, in the Desktop Commander, whenever the 'save setpoints' button is pressed, the current temperature setpoints are stored into EEPROM on the Arduino, and will be recalled next time the Arduino is powered on. This means that the Arduino will run with the last stored temperature profile if no PC is connected.