#include <Servo.h>

Servo servomotor;
int chave = 7;
int motor = 8;
int nivelChave;

void setup() {
  // put your setup code here, to run once:
  pinMode(chave, INPUT);
  servomotor.attach(motor);
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  nivelChave = digitalRead(chave);

  if (nivelChave == LOW) {
    Serial.println("DESLIGOU");
    servomotor.writeMicroseconds(1000);
    delay(1000);
  }

  Serial.println("LIGOU");
  servomotor.writeMicroseconds(1500);
  delay(1000);
  servomotor.writeMicroseconds(2000);
  delay(1000);
}
