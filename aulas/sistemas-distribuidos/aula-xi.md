# Aula XI

## P2P

Nodo ou peer são "sinonimos"

Nodo: 

SuperNodo

### Rede P2P

Protocolo Chord

Rede ad-hoc: não existe organização

#### Organização dos nodos

- Organizar num formato de anel

- Atribuir identificadores conforme anel
- Criar **n** relações entre nodos

## Prova

> Posted on: Tuesday, November 12, 2019 6:01:46 PM BRT

Prezados

Lembrem que nossa prova será no dia 26/11. A prova será teórica e contempla os seguintes conteúdos:

- Arquiteturas de Sistemas Distribuídos
- Comunicação entre Processos
- Serialização de Objetos
- Objetos Distribuídos
- Web Services
- Computação Ubíqua

Como base de estudos, utilizem os slides e o livro texto da disciplina.

Bons estudos!

## Trabalho II

Construa um Sistema Distribuído para compartilhamento de binários compatível com o modelo ilustrado pela figura a seguir. Seu sistema contará com 4 nós de armazenamento que deverão fragmentar cada conteúdo em 4 partes, mantendo um fragmento em cada nó de armazenamento. Será necessário implementar uma aplicação cliente que deverá conectar-se a pelo menos 1 dos 4 nós de armazenamento. O cliente deverá permitir o envio e a recuperação de arquivos, apresentando uma listagem dos arquivo disponíveis no sistema.

Não será necessário construir um sistema de nomeação, seus 4 nós de armazenamento poderão operar vinculados a portas estáticas e as conexões poderão ser feitas manualmente. Seu sistema deverá manipular qualquer tipo de arquivo, sempre respeitando e validando o limite máximo de 4MB por arquivo. Sua implementação deverá ser apresentada para o Professor em sala de aula. 

Data limite para apresentação: **03/12/2019** 

Formato: no máximo em dupla

### Critérios: 

- Conexão dos nós de rede 
- Upload do arquivo para a rede 
- Listagem dos arquivos disponíveis 
- Recuperação de dos arquivos 
- Distribuição dos fragmentos 
