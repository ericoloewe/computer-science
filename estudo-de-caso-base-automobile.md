# Estudo de caso: base Automobile

![carro pequeno](http://archive.ics.uci.edu/ml/assets/MLimages/Large10.jpg)

> Base [Automobile Data Set](http://archive.ics.uci.edu/ml/datasets/Automobile)

## Informações sobre a base:

*   Utilizem a base [Automobile Data Set](http://archive.ics.uci.edu/ml/datasets/Automobile) disponível no [UC Irvine Machine Learning Repository](http://archive.ics.uci.edu/ml/index.html)
*   Cada instância desta base corresponde a um carro e o risco de um sinistro em caso de uso de seguro.
*   Os atributos correspondem a informações técnicas de cada instância de carro.
*   O objetivo desta atividade é identificar quais são os conjuntos de atributos e valores que identificam carros com alto e baixo risco de sinistro.

## Para executar o estudo, façam:

*   adaptação dos arquivos:
*   *   converter para CSV;
    *   converter para ARFF.
*   Tornar nominais os valores do atributo: _symboling_;
    *   Dica: Filter -> weka -> filters -> unsupervised -> attribute -> NumericToNominal -> (selecionar attributo) -> Apply
*   Criar intervalos de valores (classes): _city-mpg_ e _highway\_mpg_;
    *   Dica: Filter -> weka -> filters -> unsupervised -> attribute -> Discretize -> (selecionar attributo) -> Apply
    *   Dica: usar Excel para estabelcer os intervalos com base em alguma heurística.
*   Aumentar a poda.

## Resultados que devem ser colhidos:

*   Tentem atingir os melhores resultados com a menor árvore possível e identificar quais atributos/valor identificam um carro com maior risco e um carro menor risco. Estabeleçam apenas um conjunto para cada.
*   Descubram quais alterações produziram melhores resultados e quais produziram piores resultados.
*   Utilizem o algoritmo J48 e o método para validação 10-fold crossfold-validation.