# Trabalho I

## Descrição

O trabalho apresentado tem intuito de elucidar problemas clássicos no campo da programação concorrente, disputa de recursos e paralelismo. Eles servem para comparar vários formalismos provenientes de programas concorrentes. São problemas e características suficientemente simples para ser tratado, ainda que bastante desafiante.

 

Linguagens de desenvolvimento

O trabalho poderá ser desenvolvido nas seguintes linguagens:

• C

• C ++

• Java

• C#

 

O que deve ser entregue junto com o trabalho:

 

1. Apresentação em aula para o professor;
2. Redação de relatório técnico;
   1. Documentação (tais como, fluxos, diagramas de classes e estados);
   2. Descrição e apresentação dos algoritmos;
3. Código Fonte, o relatório deve conter uma seção com as explicações de como executar o projeto/fonte;
4. O Relatório deve conter um exemplo de aplicação dos problemas estudados.

 

Boa Sorte!

## O trabalho

Trabalho feito em dotnet core 2.2.

O trabalho é um perfeito caso para o estudo de concorrências, onde foi possível aprender como tratar a concorrência por dados em threads simultâneas.

Um exemplo de aplicação do problema estudado é um servidor, onde o mesmo recebe diversas requisições (Tasks) e precisa corresponder a cada uma das mesmas sem perder dados.

### Fluxogramas

#### Principal

- Papai Noel acorda apenas quando:
  - É visitado por 3 elfos
  - Ou por 9 renas

![1554934835180](C:\Users\Erico\AppData\Roaming\Typora\typora-user-images\1554934835180.png)

- Papai Noel é acordado por 9 renas então:
  1. Amarra as renas ao treno
  2. Entrega os presentes
  3. Solta as renas
  4. Volta a dormir

![1554934798761](C:\Users\Erico\AppData\Roaming\Typora\typora-user-images\1554934798761.png)

- Papai Noel é acordado por 3 elfos então:
  1. Discute brinquedos com elfos
  2. Volta a dormir

![1554934857616](C:\Users\Erico\AppData\Roaming\Typora\typora-user-images\1554934857616.png)

