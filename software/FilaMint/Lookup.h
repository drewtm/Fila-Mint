//This file is part of the Fila-Mint control software, written by Matt Middleton

#define numtemps  20//number of elements in the thermistor table

const int Volts2Temps[numtemps][2] = {//
    {   0, 400},//
    {  68, 300},//
    {  83, 285},//
    { 125, 255},//
    { 144, 245},//
    { 192, 225},//
    { 222, 215},//
    { 276, 200},//
    { 318, 190},//
    { 341, 185},//
    { 391, 175},//
    { 535, 150},//
    { 777, 110},//
    { 828, 100},//
    { 910,  80},//
    { 964,  60},//
    {1001,  35},//
    {1009,  25},//
    {1018,   5},//
    {1023, -20}//
};
