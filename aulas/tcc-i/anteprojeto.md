# Anteprojeto

## Assuntos a se estudas

### RecSys

- [Recommender systems](https://dl.acm.org/doi/10.1145/245108.245121)

The provision of personalized recommendations, however, requires that the system knows something about every user. Every recommender system must develop and maintain a user model or user profile that, for example, contains the user’s preferences. In our bookstore example, the system could, for instance, remember which books a visitor has viewed or bought in the past to predict which other books might be of interest.

#### Machine learning

#### Deep learning

#### Redes neurais

## Trechos

### 4 tipos de sistemas de recomendação

(Dietmar et al., 2010) traz em sua obra os 4 tipos de sistemas de recomendação, sendo eles: recomendação colaborativa, recomendação baseada em conteúdo, recomendação baseada em conhecimento, e sistemas de recomendação híbridos.

A recomendação colaborativa parte da ideia de que se os usuários compartilharam dos mesmos interesses no passado, eles irão continuar tendo os mesmos interesses no futuro. Por exemplo, os usuários A e B tem um histórico de compras bem semelhante e o usuário A comprou um novo livro que o usuário B nem chegou a ver, nesse tipo de recomendação, a ideia e que o sistema sugira este livro para o usuário B. (Dietmar et al., 2010)

Na recomendação baseada em conteúdo, o sistema aprende a recomendar itens que são similares ao que o usuário gostou no passado, essa similaridade e calculada baseada na relação das características dos itens a serem comparados. Por exemplo, no caso de usuário avaliar positivamente um filme do gênero comedia, então, o sistema pode registrar essa ação e futuramente recomendar outros filmes desse mesmo gênero. (Ricci et al., 2011)

Diferente da recomendação colaborativa ou baseada em conteúdo, a recomendação baseada em aprendizado não consegue depender somente do histórico de compra de um usuário, e necessário um conteúdo mais estruturado e detalhado para ser gerado uma recomendação, geralmente nesse tipo, e utilizado um conteúdo adicional fornecido manualmente (conteúdo recente ao produto e usuário). (Dietmar et al., 2010)

E por último, e não menos importante, (Dietmar et al., 2010) traz em sua obra o modelo híbrido de recomendação, onde a ideia e combinar as diferentes técnicas, buscando gerara uma boa e mais assertiva recomendação. (Dietmar et al., 2010)

### Spotify

Fundado em 2006, Spotify em seu site se define como:

Um serviço de streaming digital de música, podcast e video que permite que seus usuários tenham acesso milhões de músicas ou outros conteúdos dos artistas ao redor do mundo. (Spotify, 2019)

### Definição do sistema

Para avaliar o estudo, será desenvolvido um sistema que permitirá ao usuário criar uma nova *playlist*, onde o sistema consultará os contextos relacionados as músicas escutadas pelo usuário, gerando uma nova lista de músicas recomendadas. A avaliação de contexto será feita enquanto o usuário estiver ouvindo as músicas e editando a *playlist*, possibilitando que o sistema identifique e altere (caso julgue necessário) as músicas no meio da edição. Ao final da edição, será enviado uma avaliação para o usuário, a qual vai permitir que o sistema tenha conhecimento dos gostos do usuário. 

## Links

<iframe width="560" height="315" src="https://www.youtube.com/embed/rYinLmOWRtM" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>

https://www.ifpi.org/news/IFPI-GLOBAL-MUSIC-REPORT-2019