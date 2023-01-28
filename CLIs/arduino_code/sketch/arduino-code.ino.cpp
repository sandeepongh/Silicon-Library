#include <Arduino.h>
#line 1 "D:\\chip_library\\Chip-Library-Project\\Program Files\\arduino-code\\arduino-code.ino"

#line 2 "D:\\chip_library\\Chip-Library-Project\\Program Files\\arduino-code\\arduino-code.ino"
void setup();
#line 6 "D:\\chip_library\\Chip-Library-Project\\Program Files\\arduino-code\\arduino-code.ino"
void loop();
#line 2 "D:\\chip_library\\Chip-Library-Project\\Program Files\\arduino-code\\arduino-code.ino"
void setup() {
  pinMode(LED_BUILTIN, OUTPUT);
}

void loop() {
  digitalWrite(LED_BUILTIN, HIGH);   
  delay(100);                       
  digitalWrite(LED_BUILTIN, LOW);   
  delay(100);                       
}

