void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  
  while (!Serial) {
    ; // wait for serial port to connect. Needed for native USB port only
  }
  
  establishContact();
}

void loop() {
  while (Serial.available() > 0) {
    // put your main code here, to run repeatedly:
    float number1 = Serial.parseFloat();
    int operation = Serial.read();
    float number2 = Serial.parseFloat();

    if (operation == '+') {
      Serial.println(number1 + number2);
    } else if (operation == '-') {
      Serial.println(number1 - number2);
    } else if (operation == '*') {
      Serial.println(number1 * number2);
    } else if (operation == '/') {
      Serial.println(number1 / number2);
    } else {
      Serial.println("Não tem");
    }
  }
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
