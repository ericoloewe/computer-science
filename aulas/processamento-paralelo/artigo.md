# Artigo

## Programação Paralela

### Topicos

- O que é processamento paralelo :x:
- O que é programação paralela :heavy_check_mark:
- Dificuldades programação paralela :heavy_check_mark:
- Arquiteturas programação paralela :heavy_check_mark:
- Transferência de dados entre processos 
- Node.js e cases de programação paralela
- Suporte no Node.js
- Resultados atingidos com Node.js ❓
- Dificuldade de se utilizar no Node.js
- Conclusões

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
- [The Semantics of a Simple Language for Parallel Programming](https://pdfs.semanticscholar.org/d42a/29e6977c28f7bf23d63b00c48f2e9100403e.pdf)
- [Parallel Programming Techniques and Applications using Networked Workstations and Parallel Computers](http://140.127.182.82/homepage/ccchen/parallel/Slides1.pdf)
- [Modelo HIBRIDO DE PROGRAMAÇÃO PARALELA](http://repositorio.unb.br/bitstream/10482/2271/1/DissertacaoMestrado%20Leonardo%20Nunes%20da%20Silva.pdf)
- [Ambiente visual para programação distribuida em Java](https://www.lume.ufrgs.br/bitstream/handle/10183/3723/000342260.pdf?sequence=1&isAllowed=y)
- [Parallel Programming book](https://www.cse.unr.edu/~fredh/class/415/text/pp-2ed/parallel.pdf)
- [Programação Paralela e Distribuída em Java](https://www.researchgate.net/profile/Marinho_Barcellos/publication/264857336_Programacao_Paralela_e_Distribuida_em_Java/links/58de51c0a6fdcc3c6ac414f5/Programacao-Paralela-e-Distribuida-em-Java.pdf)
- [Node.js in Action](https://s3.amazonaws.com/academia.edu.documents/44678333/Book-12__Node.js.in.Action_-_Handsome.pdf?AWSAccessKeyId=AKIAIWOWYYGZ2Y53UL3A&Expires=1557365012&Signature=1gy6lOQ5va9aHQ%2Bn1d%2BxCwJYZVI%3D&response-content-disposition=inline%3B%20filename%3DM_A_N_N_I_N_G.pdf)
- [A horizontally-scalable multiprocessing platform
  based on Node.js](https://www.researchgate.net/publication/280034228_A_horizontally-scalable_multiprocessing_platform_based_on_Nodejs)
- [Is Parallel Programming Hard, And, If So, What Can You Do About It?](https://mirrors.edge.kernel.org/pub/linux/kernel/people/paulmck/perfbook/perfbook.2017.11.22a.pdf)
- [Introduction to Parallel Programming Concepts](https://www.cct.lsu.edu/~scheinin/Parallel/parallelTrain-v1.0.pdf)
- [Livros de programação gratuitos](https://github.com/EbookFoundation/free-programming-books/blob/master/free-programming-books.md#parallel-programming)
- [Modelos para computação paralela](http://www.urisan.tche.br/~cspm/Trabalhos_lidos/erad03.pdf)
- [Computação paralela em Javascript](https://www.researchgate.net/publication/282817272_Computacao_Paralela_em_JavaScript)

## Sandbox

Programação paralela é a divisão de uma determinada aplicação em partes, de maneira que essas partes possam ser executadas simultaneamente, por vários elementos de processamento.

-------------------------

Computação paralela é o uso simultâneo de múltiplos recursos para resolver um problema computacionais.

-------------------------

Programação paralela funciona com multiplos cores ou só multiplos processadores

-------------------------

### [Node.js Cluster - How it works](https://nodejs.org/api/cluster.html#cluster_how_it_works)

#### Comunicação entre processos

Node.js utiliza do IPC para se comunicar entre processos

#### Gerenciamento de processos

- Primeiro modelo [Windows, Linux]

Node.js utiliza do algoritmo round-robin para gerenciar processos

- Segundo modelo [Windows]

O processo principal (Master) cria escutas para o processo principal e a envia aos workers (processos) interessados

-------------------------

#### Limitações

Infelizmente os clusters do Node possuem diversas limitações. Começando com politica de agendamento utilizada na versão 0.12.0 do Node.js de "deixar a responsabilidade ao sistema operacional" o qual é conhecido por não ser muito eficiente na distribuição de cargas geradas pelo Node.js. Em segundo lugar, o cluster só consegue iniciar instancias do Node.js em uma mesma maquina,

-------------------------

O desenvolvimento de programas em paralelo é considerado muito mais complicado do que programas sequenciais, uma vez que, com o paralelismo se tem múltiplas threads para se controlar e os dados podem ser logicamente e fisicamente distribuídos. Em particular:

- Comunicação e sincronização (e.g deadlocks) são difíceis de serem rastreados
- O não determinismo em um programa paralelo faz seu comportamento difícil de se entender
- Particionamento de dados, mapeamento de processos e sincronização podem atrapalhar na performance.



-----------------------



Infelizmente não existe um modelo universal para computação paralela similar ao modelo de Von Neuman para a computação sequencial. Um bom modelo deve ter as seguintes qualidades: ser ao mesmo tempo simples e realista, sendo estas duas qualidades antagônicas. Quanto mais um modelo é simples, logo abstrato, menos ele aproxima o comportamento de uma maquina real. Por outro lado, um modelo muito realista geralmente é de difícil utilização.

--------------

Dada a diversidade de arquiteturas paralelas, diversas linguagens, compiladores e bibliotecas especiais foram propostos, visando gerenciar o paralelismo. \cite{lmsetmhs:96}

% Explicar o porque os softwares vem sido escrito de maneira serial
Tradicionalmente softwares vem sido escrito de maneira serial, mas isso vem cada vez mais se tornando um problema, pois, a cada dia o uso de tecnologia aumenta, junto com a quantidade de aplicações rodando, isso resulta em um uso gigantesco de energia e tempo. Com o paralelismo, conseguimos diminuir ambos os fatores, resultando em um ganho tanto para a aplicação quanto para o meio ambiente.

% Explicar o que é computação paralela e serial
Computação paralela é o uso simultâneo de múltiplos recursos para resolver um problema computacionais. \cite{bblln:18}