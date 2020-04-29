# TCC I

investigar o problema

para conseguir identificar técnicas

como o pessoal esta trabalhando com o assunto

## Atividades

### Quebra dos capítulos

- Introdução (basicamente motivação anteprojeto)
  - Introdução aos sistemas de recomendação
    - Histórico
    - Cases de sucesso
    - Netflix prize
  - Introdução ao mercado musical e os sistemas de streaming musical
  
- Sistemas de recomendação (não se aprofundar)
  
  - Mercado musical e a diversidade de musicas disponíveis :star:
    - Introdução ao mercado musical
    - Migração do mercado musical para o streaming
  - Tipos de sistemas de recomendação
    - Sistemas de recomendação baseado em conteúdo
    - Sistemas de recomendação colaborativo
    - Sistemas de recomendação baseado em conhecimento
    - Sistemas de recomendação hibrido
  - Algoritmos de sistemas de recomendação
    - Tipos
    - Bibliotecas
    - Casos de uso
  - Classificação de dados :warning: :star2: (só se achar necessário nos trabalhos relacionados)
    - Algoritmos de classificação
    - Bibliotecas que possuam a implementação dos algoritmos
    - Casos de uso
  - Técnicas para avaliar os  resultados de um RecSys :warning:
    - Algoritmos
    - Bibliotecas
    - Casos de uso
  
- Trabalhos relacionados (se aprofundar)

  - O que eles fizeram
  - Quais técnicas e algoritmos utilizaram
  - Que resultados chegaram
  - Como mediram o sistema de recomendação
  - Tabela com técnicas
    - Descobrir qual técnica irei utilizar no meu trabalho

- Modelagem do que será feito

  > como será feito o trabalho

  - Contexto
    - O que é o contexto comportamental?
    - O que é o contexto ambiente?
    - Como será obtido os contextos? (plugin)
    - Conseguimos definir um peso para cada atributo do contexto? :star2:
  - Arquitetura do sistema
    - Detalhar plugin, sistema
    - Detalhar integração spotify
    - Detalhar inteligência recsys

- APIs de Serviços de *Streamings* Musicais (**Spotify**, Dezzer, Google play music, Amazon music) :star: (tcc 2)
  - Sobre o serviço (Numero de usuários e musicas)
  - Quais funcionalidade possui?
  - Possui suporte a aplicações web?
  - Conseguimos reproduzir a partir do plugin?
- Desenvolvimento (tcc 2)
  - Serviços de *Streamings* Musicais :star2:
    - Definição do Serviço a ser utilizado pelo plugin
    - Definição dos endpoints a serem utilizados
    - Definição dos atributos da API a serem utilizados
  - Contextos
    - Definição das variáveis utilizadas como contexto comportamental
    - Definição das variáveis utilizadas como contexto de ambiente
    - Definição do peso de cada atributo
  - **Liberação do plugin sem recomendação**
  - Sistemas de recomendação
    - Estudar dados obtidos
    - Definição dos algoritmos a serem utilizados :warning:
    - Definição das técnicas utilizadas para avaliar os resultados
  - Desenvolvimento do protótipo do sistema
    - O Plugin :star:
    - O Servidor :star:
    - Desenvolvimento do classificador dos dados, transformando os eventos registrados em recomendação :warning:
    - Desenvolvimento da tela de avaliação para o plugin
  - **Liberação do plugin com recomendação**
  - Avaliação :warning:
    - Estudar dados obtidos
    - Definição das técnicas de avaliações utilizadas
  - **Liberação do plugin com recomendação e avaliação das recomendações**
- Resultados (tcc 2)
  - Principais resultados obtidos (acertos, erros)
  - Avaliação da recomendação feita a partir das respostas do usuário (levantamento)
  - Avaliação da recomendação feita a partir das ações do usuário (pesquisa experimental)
  - Tendências de comportamento (percentuais)
- Conclusão (considerações, abordar o que fiz e o que irei fazer)
  
  - Trabalhos futuros

#### Legenda

- :star: capitulo opcional (caso apertar, vamos remover)
- :star2: capitulo meio opcional (caso apertar muito, vamos remover)
- :warning: falta conhecimento para escrever o capitulo e subcapítulos

### Ler artigos passados pelo avaliador

#### Recsys challenge 2018: automatic music playlist continuation. In: Proceedings of the 12th ACM Conference on Recommender Systems.

- Realizado na ACM RecSys Challenge 2018
- Automatização da *playlist continuation*
- Dado uma playlist, recomendar 500 musicas que se encaixem na características de suas musicas

#### New Paths in Music Recommender Systems Research Markus

- Particularidades da musica fez muitas contribuições aos assuntos de sistemas de recomendação, principalmente:
  - baseado em conteúdo
  - hibrido
  - user modeling
  - interfaces
  - **context-aware (cientes de contexto)**
- Foco do trabalho:
  - geração automatica de playlists
  - recomendação musical a partir de contexto
  - recomendação no processo que a musica é feita
- No mundo do recsys, musica é muitas vezes tratada como só mais um item
- Basicamente fala sobre o capitulo do livro "Music Recommender Systems. In Recommender Systems Handbook"

#### Effective Nearest-Neighbor Music Recommendations Malte

- Realizado na ACM RecSys Challenge 2018
- Automatização da *playlist continuation*
- Apresentaram uma sessão hibrida baseada em recomendação musical
  - O método é baseado no vizinho mais próximo de uma matriz fatorial

#### Towards Seed-Free Music Playlist Generation

- Apresentaram um modelo de filtragem neural hibrida colaborativa
- Focam nas playlists com pouco dados (cold start)
- Utilizaram o RNN para entender o nome da playlist
- Utilizaram WRMF para entender as características da playlist e musicas

## Recomender system handbook

### Aplicando o contexto na musica

- Contexto tem efeito sobre a preferencia do usuário
- para explorar informações sobre contexto e musica, deve-se:
  - Estabelecer um grau de relevância entre a musica e a informação contextual
    - Obter por usuário
- 4 maneiras de relacionar a musica com a informação contextual
  - Ranquear a musica no contexto
  - Mapear características de baixo nível de uma musica com o contexto
  - Caracterizar as musicas aos seus contextos (trabalho manual)
  - Predizer um contexto intermediário (precisa das outras técnicas)

## Pesquisas

- "eclectic" music recommendation context aware
- ('RecSys' OR 'recommender systems' OR 'machine learning') AND ('music' OR 'musical' OR 'song' OR 'playlist') AND ('behavioral context' OR 'environmental context' OR 'context-aware' OR 'HCI' OR 'human computer interaction' OR 'emotion' OR 'pleasure')
- [IEEE](https://ieeexplore.ieee.org/search/searchresult.jsp?newsearch=true&queryText=('RecSys' OR 'recommender systems' OR 'machine learning') AND ('music' OR 'musical' OR 'song' OR 'playlist') AND ('behavioral context' OR 'environmental context' OR 'context-aware' OR 'HCI' OR 'human computer interaction' OR 'emotion' OR 'pleasure'))
- [ACM](https://dl.acm.org/action/doSearch?AllField=('RecSys'+OR+'recommender+systems'+OR+'machine+learning')+AND+('music'+OR+'musical'+OR+'song'+OR+'playlist')+AND+('behavioral+context'+OR+'environmental+context'+OR+'context-aware'+OR+'HCI'+OR+'human+computer+interaction'+OR+'emotion'+OR+'pleasure'))
- [SCHOLAR](https://scholar.google.com/scholar?hl=en&as_sdt=0%2C5&q=('RecSys'+OR+'recommender+systems'+OR+'machine+learning')+AND+('music'+OR+'musical'+OR+'song'+OR+'playlist')+AND+('behavioral+context'+OR+'environmental+context'+OR+'context-aware'+OR+'HCI'+OR+'human+computer+interaction'+OR+'emotion'+OR+'pleasure')&btnG=)

