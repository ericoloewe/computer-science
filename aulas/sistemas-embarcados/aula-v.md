# Aula V

## Exercicios

Inicialmente responda as seguintes perguntas:

### a-) O que são GPIOs?

General Purpose Input/Output (GPIO) são portas de entrada e saída programáveis

### b-) O_ que_é/para_que_serve interface SCI?

Serial communications interface (SCI) é um porta que permite a troca serial de dados entre o microprocessador e outros periféricos.

### c-) Defina o_ que_é/para_que_serve I2C.

I2C é um protocolo que descreve o funcionamento de um barramento de comunicação serial que utiliza apenas dois fios.

Serve para realizar a comunicação entre dois dispositivos.

#### d-) Defina o_ que_é/para_que_serve SPI.

Serial Peripheral Interface ou SPI é um protocolo que permite a comunicação do microcontrolador com diversos outros componentes, formando uma rede. É uma especificação de interface de comunicação série síncrona usada para comunicação de curta distância, principalmente em sistemas embarcados.

### Sobre o ESP32 responda

![img](https://uploads.filipeflop.com/2017/11/myESP32-DevKitC-pinout.png)

#### 1-) Quantos núcleos possui?

Possui um microprocessador Tensilica Xtensa LX6 com duas variações dual-core e single-core

#### 2-) Trabalha com palavras de quantos bits?

32-bit

#### 3-) Qual(is) é(são) a(s) sua(s)  tensão(ões) de alimentação?

Interface USB e/ou sinais externos, e conversor USB-Serial para comunicação com o módulo usando PC.

Default: 3,3v

#### 4-) Qual o tamanho de sua Flash?

memórias Flash de até 16 MBytes

#### 5-) Qual o tamanho de sua RAM?

SRAM: 520 KiB – Usada para dados e instruções (programas)

#### 6-) Possui entradas e saídas analógicas? Quantas?

- 16 canais de conversor SAR ADCs (conversor analógico-digital) de 12-bits.
- 2 canais de 8 bits DACs (conversor digital-analógico).

#### 7-) Possui entradas e saídas digitais? Quantas?

Sim, 36 GPIO

#### 8-) Possui GPIOs? Quantas?

Sim, 36 GPIO

#### 9-) Qual é a sua freqüência de clock?

até 240 MHz

#### 10-) Possui interface USB? Quantas?

Sim, para alimentação

#### 11-) Possui interface de rede(WIFI, BLUETOOTH, BLE,LORA...)?

Sim