# TCC I

investigar o problema

para conseguir identificar tecnicas

como o pessoal esta trabalhando com o assunto

## Atividades

### Quebra dos capítulos

- Introdução (basicamente motivação anteprojeto)
  - Introdução aos sistemas de recomendação
    - Historico
    - Cases de sucesso
    - Netflix prize
  - Introdução ao mercado musical e os sistemas de streaming musical
  
- Sistemas de recomendação (não se aprofundar)
  
  - Mercado musical e a diversidade de musicas disponiveis :star:
    - Introdução ao mercado musical
    - Migração do mercado musical para o streaming
  - Tipos de sistemas de recomendação
    - Sistemas de recomendação baseado em conteudo
    - Sistemas de recomendação colaborativo
    - Sistemas de recomendação baseado em conhecimento
    - Sistemas de recomendação hibrido
  - Algoritmos de sistemas de recomendação
    - Tipos
    - Bibliotecas
    - Casos de uso
  - Classificação de dados :warning: :star2: (só se achar necessario nos trabalhos relacionados)
    - Algoritmos de classificação
    - Bibliotecas que possuam a implementação dos algoritmos
    - Casos de uso
  - Técnicas para avaliar os  resultados de um RecSys :warning:
    - Algoritmos
    - Bibliotecas
    - Casos de uso
  
- Trabalhos relacionados (se aprofundar)

  - O que eles fizeram
  - Quais tecnicas e algoritmos utilizaram
  - Que resultados chegaram
  - Como mediram o sistema de recomendação
  - Tabela com tecnicas
    - Descobrir qual tecnica irei utilizar no meu trabalho

- Modelagem do que sera feito

  > como sera feito o trabalho

  - Contexto
    - O que é o contexto comportamental?
    - O que é o contexto ambiente?
    - Como sera obtido os contextos? (plugin)
    - Conseguimos definir um peso para cada atributo do contexto? :star2:
  - Arquitetura do sistema
    - Detalhar plugin, sistema
    - Detalhar integração spotify
    - Detalhar inteligencia recsys

- APIs de Serviços de *Streamings* Musicais (**Spotify**, Dezzer, Google play music, Amazon music) :star: (tcc 2)
  - Sobre o serviço (Numero de usuarios e musicas)
  - Quais funcionalidade possui?
  - Possui suporte a aplicações web?
  - Conseguimos reproduzir a partir do plugin?
- Desenvolvimento (tcc 2)
  - Serviços de *Streamings* Musicais :star2:
    - Definição do Serviço a ser utilizado pelo plugin
    - Definição dos endpoints a serem utilizados
    - Definição dos atributos da API a serem utilizados
  - Contextos
    - Definição das variaveis utilizadas como contexto comportamental
    - Definição das variaveis utilizadas como contexto de ambiente
    - Definição do peso de cada atributo
  - **Liberação do plugin sem recomendação**
  - Sistemas de recomendação
    - Estudar dados obtidos
    - Definição dos algoritmos a serem utilizados :warning:
    - Definição das tecnicas utilizadas para avaliar os resultados
  - Desenvolvimento do prototipo do sistema
    - O Plugin :star:
    - O Servidor :star:
    - Desenvolvimento do classificador dos dados, transformando os eventos registrados em recomendação :warning:
    - Desenvolvimento da tela de avaliação para o plugin
  - **Liberação do plugin com recomendação**
  - Avaliação :warning:
    - Estudar dados obtidos
    - Definição das tecnicas de avaliações utilizadas
  - **Liberação do plugin com recomendação e avaliação das recomendações**
- Resultados (tcc 2)
  - Principais resultados obtidos (acertos, erros)
  - Avaliação da recomendação feita a partir das respostas do usuario (levantamento)
  - Avaliação da recomendação feita a partir das ações do usuario (pesquisa experimental)
  - Tendencias de comportamento (percentuais)
- Conclusão (considerações, abordar o que fiz e o que irei fazer)
  - Trabalhos futuros

#### Legenda

- :star: capitulo opcional (caso apertar, vamos remover)
- :star2: capitulo meio opcional (caso apertar muito, vamos remover)
- :warning: falta conhecimento para escrever o capitulo e subcapitulos