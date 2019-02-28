# Aula II

Analise sintática

- Top-down

- - Analise sintática de precedência de operadores
  - Analise sintática SLR

Simple LR

- Analise sintática LALR

Look Ahead LR

- Analise sintática LR canônica

LR canônica

- Bottom-up

- - Analise sintática descendente recursiva

ASDR/ASRD

- Analise sintática preditiva não-recursiva

ASPNR

ASRD - Analise sintática descendente recursiva

- Não aceita regras de produção recursiva à esquerda (eliminação da recursão à esquerda)

- Terá uma função (ou método) para cada não terminal

- LL(0), LL(1), ... (fatoração da gramatica)

- O esquema básico de cada função será:

  ````
  faça enquanto há símbolos na regra {
  	se o símbolo é não terminal {
      	chama a função correspondente
      } senão {
  		vê se o token é o tipo esperado
  		se for, chama a busca proximoToken() do lexico
  		se não for, da erro!
  	}
  }
  ````
