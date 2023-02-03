# 1 "D:\\chip_library\\Chip-Library-Project\\Program Files\\arduino-code\\arduino-code.ino"

void setup() {
  pinMode(13, 0x1);
}

void loop() {
  digitalWrite(13, 0x1);
  delay(100);
  digitalWrite(13, 0x0);
  delay(100);
}
