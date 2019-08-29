int chave = 7;
int led = 8;
int nivelChave;

void setup() {
  // put your setup code here, to run once:
  pinMode(chave, INPUT);
  pinMode(led, OUTPUT);
}

void loop() {
  nivelChave = digitalRead(chave);

  if (nivelChave == HIGH) {
    digitalWrite(led, LOW);
  } else {
    digitalWrite(led, HIGH); 
  }   
}
