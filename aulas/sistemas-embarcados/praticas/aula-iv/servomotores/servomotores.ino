#include <Servo.h>

Servo servomotor;
int motor1 = 8;
int motor2 = 9;
int min = 900;
int max = 2100;
int stop = 1500;
int contador = 0;

void setup() {
  // put your setup code here, to run once:
  // servomotor.attach(motor1);
  servomotor.attach(motor2);
}

void loop() {
  // put your main code here, to run repeatedly:
  if (contador < 5) {
    servomotor.writeMicroseconds(1800); 
    delay(2000);
    servomotor.writeMicroseconds(1200);
    delay(2000);
    contador += 1;
  } else {
    servomotor.writeMicroseconds(1500);
  }
}
