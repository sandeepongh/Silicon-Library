void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);

}

void loop() {
  Serial.println("Running Arduino Test Program...");
  Serial.println("This Arduino Is Working!");
  Serial.end();
  exit(0);
}