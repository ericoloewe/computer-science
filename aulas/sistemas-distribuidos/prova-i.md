# Prova I

## Exercicios para prova

**Instruções:**
Responda cada uma das questões nas folhas anexas. Não esqueça de numerar suas respostas! Cada resposta vale K ponto.

### 1. Diferencie Computação Paralela e Computação Distribuída.

#### Computação paralela (calculos)

Forma de computação que possibilita varios calculos serem realizados ao mesmo tempo

#### Computação Distribuída

Sistema que possui partes localizadas em diferentes computadores interligados em rede, as quais se comunicam e coordenam suas ações realizando a troca de mensagem entre as partes.

### 2. Utilizando suas palavras, defina o que são Sistemas Distribuídos.

Sistemas Distribuídos=Computação distribuida

Sistemas Distribuídos **é o contrario de** Mainframe

--------------------

Sistema que possui parter localizadas em diferentes computadores interligados em rede, as quais se comunicam e cordenam suas ações realizando a troca de mensagem entre as partes.

### 3. Comente escalabilidade em um contexto de Sistemas Distribuídos.

O sistema deve apresentar **comportamento eficiente** em varias escalas.

O sistema deve-se **manter efetivo**, mesmo com um grande incremento no numero de recursos e usuarios envolvidos.

### 4. Cite e comente pelo menos 4 transparências necessárias aos Sistemas Distribuídos.

O padrão ISO ODP (Open Distributed Processing) identifica as
seguintes formas de transparência:

- Transparência de **Acesso**
- Transparência de **Localização**
- Transparência de **Falhas**
- Transparência de Replicação
- Transparência de **Migração**
- Transparência de Concorrência
- Transparência de Performance
- Escalabilidade Transparente
- Transparências em Nível de Aplicação

### 5. O que é um Middleware de Comunicação? Cite uma tecnologia que utiliza este tipo de dispositivo.

Camada de software com o proposito de mascarar a heterogeneidade presente em sistemas distribuidos.

- Microsoft .NET
- Java RMI

### 6. Diferencie comunicação por Serialização de Objetos e comunicação por Objetos Distribuídos.

#### Serialização de Objetos

**Modelo de comunicação** baseado em **trocas de bytes** que representam estados de objetos em memória

> Cada objeto é transformado em uma sequência de bytes por um processo A, copiando estes bytes para um processo B. O processo B reconstrói o objeto em memória e acessa seus parâmetros.

#### Objetos Distribuídos

São objetos (instâncias de classes) distribuídos através de diferentes endereços em um espaço de endereçamento.

> Utiliza da serialização de objetos

### 7. Em uma implementação de Sistemas Distribuídos utilizando sockets, quais os protocolos de transporte disponíveis? Cite duas características básicas de cada um deles.

#### TCP (Transmission Control Protocol)

- Garantia de entrega
- Mais devagar
- Garantia de ordem de chegada dos dados

#### UDP (User Datagram Protocol)

- Sem garantia de entrega
- Mais rapido
- Sem garantia da ordem que o dado ira chegar

### 8. Comente Web Services. Quais são suas principais aplicações?

>  É diferente de web server

Consiste de um **conjunto de operações** que pode ser utilizado por um cliente **através da Internet**.

Pode ser utilizado para **troca de mensagem** entre aplicações de **diferente liguagem**.

Permitem reutilizar sistemas já existentes numa organização e acrescentar-lhes novas funcionalidades sem que seja necessário criar um sistema a partir do zero. 

### 9. Relacione Web Services SOAP e REST. Como eles se diferenciam com relação aos protocolos utilizados para sua efetiva comunicação? :warning:

| SOAP                                                     | REST                                                        |
| -------------------------------------------------------- | ----------------------------------------------------------- |
| Padrão de protocolo com regras pré-definidas a se seguir | Estilo de arquitetura                                       |
| Suporta XML                                              | Suporta diversos tipos de comunicação, como xml, hmtl, json |
| Não pode ser cacheado                                    | Pode ser cacheado                                           |
| Sem estado por padrão, mas permite criar sessão          | Sem estado do lado do servidor                              |

### 10. Comente RMI. Quais são suas principais aplicações?

Utiliza dos objetos distribuidos para facilitar o desenvolvimento de aplicações entre processos

É utilizado para realizar a comunicação de aplicações de um mesmo sistema

### 11. Diferencie Computação Móvel e Computação Ubíqua. Como elas se complementam?

#### Computação movel

É o acesso a informação de diferentes lugares.

#### Computação ubiqua

Computação ubíqua é onde a computação move-se para **fora** das estações de trabalho e computadores pessoais e torna-se **pervasiva na nossa vida** quotidiana aonde quer que estejamos. 

>  É o termo utilizado para descrever a onipresença da TI no codiano das pessoas

### 12. Comente, com base em suas próprias concepções, a relação entre Objetos Distribuídos, Web Services e Computação Móvel. Que cenário você vislumbra para médio e longo prazo?



### 13. Explique o método de roteamento Chord para redes P2P. Qual o número máximo de passos para n=4?

No maximo 4 passos.

### 14 .Em uma rede Chord com n=4, qual a distância entre os nós GUID 14 e 2?

![image-20191126200649121](C:\Users\Erico\AppData\Roaming\Typora\typora-user-images\image-20191126200649121.png)

14 + 2^2 = 18

18 - 15 = 3

1 passo	