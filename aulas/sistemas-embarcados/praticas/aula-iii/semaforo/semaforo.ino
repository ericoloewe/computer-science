int vermelho = 8;
int verde = 10;
int amarelo = 9;

void setup() {
  // put your setup code here, to run once:
  pinMode(vermelho, OUTPUT);
  pinMode(verde, OUTPUT);
  pinMode(amarelo, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  digitalWrite(verde, HIGH);
  digitalWrite(amarelo, LOW);
  digitalWrite(vermelho, LOW);
  delay(3000);
  digitalWrite(verde, LOW);
  digitalWrite(amarelo, HIGH);
  delay(1000);
  digitalWrite(amarelo, LOW);
  digitalWrite(vermelho, HIGH);
  delay(2000);
}
