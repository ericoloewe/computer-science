# Artigo

## Programação Paralela

### O que é?

- Consiste em executar simultaneamente várias partes de uma mesma aplicação

- Tornou-se possível se possível a partir do desenvolvimento de sistemas operacionais desenvolvimento multi-tarefa, multi-thread e paralelos

### Aplicações são executadas paralelamente:

- Em um mesmo processador

- Em uma máquina multiprocessada

- Em um grupo de máquinas interligadas que se comporta como uma só máquina

### MODELOS DE PROGRAMAÇÃO PARALELA

Um programa sequencial especifica a execução de uma lista de comandos. Um processo pode ser
definido como a execução de um programa sequencial. 

A comunicação entre processos que podem ser atribuídos aos múltiplos processadores de um computador com arquitetura paralela, pode ser efetuada através de variáveis compartilhadas ou por passagem de mensagem.

#### Troca de informações entre aplicações rodando em paralelo

Modelos de programação baseados em variáveis compartilhadas permitem implementações com menor complexidade em relação aos modelos com passagem de mensagem. Entretanto, as leituras e escritas dessas variáveis devem ser feitas, considerando algumas restrições. Uma leitura e escrita ou múltiplas escritas não podem ser executadas simultaneamente. Isto exige a utilização de uma seção crítica envolvendo o acesso a variáveis compartilhadas. A exclusão mútua é um mecanismo que implementa a seção crítica, garantindo que uma sequência de comandos seja executada exclusivamente por um processo.

#### Modelos

A paralelização de um programa pode ser realizada particionando-o em múltiplos subprogramas, sendo esta paralelização denominada "multitasking" ou "macrotasking". Várias linguagens têm sido propostas oferecendo este modelo.

##### Multitasking

A paralelização de um programa pode ser realizada particionando-o em múltiplos subprogramas, sendo esta paralelização denominada “multitasking”. Várias linguagens têm sido propostas oferecendo este modelo.

![1557001173608](./1557001173608.png)

##### Microtasking

Uma paralelização do programa em uma granularidade mais fina oferecida pelo modelo que utiliza a técnica denominada “microtasking” [Tha88] que divide o trabalho a ser executado em microtarefas. Microtarefa é uma porção de código seqüencial, contida em um laço, cujas iterações são executadas paralelamente, ou em um bloco de comandos que é executado paralelamente a outros blocos.

![1557001342685](./1557001342685.png)





## Assuntos

- [ ] Programação paralela - Utilizando o paradigma no dia a dia de desenvolvimento
- [ ] Programação paralela

## Links interessantes

- [Programação paralela](http://www.ic.unicamp.br/~cortes/mo601/trabalho_mo601/ivan_freitas_cap2/artigo.pdf)

- [Programação Concorrente x Paralela x Distribuída](https://pt.stackoverflow.com/questions/75727/programa%C3%A7%C3%A3o-concorrente-x-paralela-x-distribu%C3%ADda)
- [Programação Paralela em Memória Compartilhada e Distribuída](http://www.inf.ufrgs.br/erad2015/downloads/p/mc/mc-schepke.pdf)
- [Técnicas de orientação ao objetos para computação científica paralela](http://conteudo.icmc.usp.br/pessoas/francisco/works/dissert.pdf)
- [Programação Paralela Híbrida em CPU e GPU: Uma Alternativa na Busca por Desempenho](http://www.eati.info/eati/2013/assets/anais/artigo124.pdf)

