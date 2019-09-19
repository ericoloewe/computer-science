int motionSensorPort = 27;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  
  while (!Serial) {
    ; // wait for serial port to connect. Needed for native USB port only
  }
  
  establishContact();
  attachInterrupt(digitalPinToInterrupt(motionSensorPort), detectsMovement, RISING);
}

void loop() {
  Serial.print("VALOR ATUAL: ");
  Serial.print(digitalRead(motionSensorPort));
  Serial.print("\n");
  delay(1000);
}

void establishContact() {
  int count = 0;

  while (Serial.available() <= 0) {
    Serial.print("Carregando ");
    Serial.print(count++);
    Serial.print("\n");
    delay(300);
  }
}

void detectsMovement() {
  Serial.println("Movimento detectado!!!");
}
