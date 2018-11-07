# Machine Learning (Trabalho II)

## Descrição

O objetivo desta atividade é a prática na construção de um modelo de classificador supervisionado. Para isso, um *dataset* público será escolhido com o objetivo de servir a um comparativo entre algoritmos de aprendizado de máquina. Os estudantes devem implementar os experimentos e avaliar os resultados.

[Link para descrição](https://docs.google.com/document/d/1__tClh4zYZrES1shS7iw3LYH-KoAvCy6Cdygg4BOV08/edit)

## Desenvolvimento

### 1) Selecione uma base

Base: [Educação - Ensino Médio - Taxa de Aprovação - Total](https://dados.rs.gov.br/dataset/fee-taxa-de-aprovacao-total-102548)

Bases que irão auxiliar na analise:

- [Emprego - Número de Vínculos Empregatícios - Ativos - Faixa Etária - de 15 a 17 anos](https://dados.rs.gov.br/dataset/fee-faixa-etaria-de-15-a-17-anos-103859)
- [Segurança - Indicadores Criminais - Roubos](https://dados.rs.gov.br/dataset/fee-indicadores-criminais-roubos-103603)
- [Segurança - Indicadores Criminais - Entorpecentes - Tráfico](https://dados.rs.gov.br/dataset/fee-indicadores-criminais-entorpecentes-trafico-103621)
- [Segurança - Indicadores Criminais - Furtos](https://dados.rs.gov.br/dataset/fee-indicadores-criminais-furtos-103599)
- [Segurança - Indicadores Criminais - Furto de Veículo](https://dados.rs.gov.br/dataset/fee-indicadores-criminais-furto-de-veiculo-103601)

### 2) Proposito do *dataset*

O contempla a taxa de aprovação por cidade dos alunos do ensino médio. No cenário do dataset, uma opção de predição é de `ensino_medio_aprovacao_total` onde verificamos se a mesma é maior ou igual a 80%.

### 3) Analise algoritmos

#### J48 (C4.5)

Algoritmo que usa alvore de decisões para vasculhar os dados e encontrar a melhor classificação para os mesmos.

[Weka: Decision Trees – J48](http://stp.lingfil.uu.se/~santinim/ml/2016/Lect_03/Lab02_DecisionTrees.pdf)

#### Multilayer Perceptron

[More Data Mining with Weka (Class 5) - 2014](https://www.cs.waikato.ac.nz/ml/weka/mooc/moredataminingwithweka/slides/Class5-MoreDataMiningWithWeka-2014.pdf)

### 4) Analise de pré-processamento

Verificamos que para realizar a analise, seria necessário uma pre-processamento dos valores antes. Por isso, utilizamos um script criado em **R** para transformar os valores obtidos em valores que realmente auxiliem na nossa analise.

Foi classificado o atributo `ensino_medio_aprovacao_total`  como `ensino_medio_aprovacao_total_desejada` onde verificamos se a taxa de aprovação foi maior que **80%** e marcamos o atributo com os valores `ATINGIU` e `NAO_ATINGIU`

## Relatório

**Nome:** Érico de Souza Loewe

**Disciplina:** Inteligência artificial e computacional

**Data:** 07/11/2018

**Base:** 

​	**Link:** https://dados.rs.gov.br/dataset/fee-taxa-de-aprovacao-total-102548

​	**Proposito:** Educação - Ensino Médio - Taxa de Aprovação - Total

​	**Tamanho:** 496 instancias

**Procedimentos e proposta de pre-processamento:** 	

​	Todas as bases utilizadas nessa analise foram baixadas do site: https://dados.rs.gov.br/. Para cada uma delas foi necessário abri-lá no Excel excluir a primeira linha (a que continha `ç`) e converte-lá para csv com `;`, para garantir que a base estava sem problemas.

​	Após padronizar as bases, foi pego cada uma delas e foi unificado em uma por um script feito em R. Esse script garantia a união das bases, sem a perda e mistura de dados, pois o mesmo vinculava cada linhas por sua cidade e garantia que a conversão de números do padrão brasileiro para o padrão utilizado no Weka iria ocorrer sem a perda de dados.

**Tabela:**

|                            | J48     | Multilayer Perceptron | ?    |
| -------------------------- | ------- | --------------------- | ---- |
| **Taxa de acerto**         | 77.621% | 70.5645%              |      |
| **Taxa de erro**           | 22.379% | 29.4355%              |      |
| **Tempo de processamento** | 0.01 s  | 1.29 s                |      |



## Links

- [More Data Mining with Weka](https://www.cs.waikato.ac.nz/ml/weka/mooc/moredataminingwithweka/slides/Class5-MoreDataMiningWithWeka-2014.pdf)

### Links de bases

- http://dados.gov.br/
- https://dados.rs.gov.br/
- http://www.portaltransparencia.gov.br/download-de-dados
- https://www.kaggle.com/