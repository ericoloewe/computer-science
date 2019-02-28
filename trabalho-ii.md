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
- [Educação - Ensino Médio - Taxa de Distorção Idade Série - Total](https://dados.rs.gov.br/dataset/fee-taxa-de-distorcao-idade-serie-total-102524)
- [Educação - Ensino Médio - Taxa de Abandono - Total](https://dados.rs.gov.br/dataset/fee-taxa-de-abandono-total-102596)
- [Educação - Ensino Médio - Taxa de Reprovação - Total](https://dados.rs.gov.br/dataset/fee-taxa-de-reprovacao-total-102572)
- [Educação - Ensino Médio - Número de Concluintes - Total](https://dados.rs.gov.br/dataset/fee-numero-de-concluintes-total-100826)
- [Educação - Ensino Médio - Matrícula Inicial - Total](https://dados.rs.gov.br/dataset/fee-matricula-inicial-total-100808)
- [Educação - Ensino Médio - Funções Docentes - Total](https://dados.rs.gov.br/dataset/fee-funcoes-docentes-total-100802)

### 2) Proposito do *dataset*

O contempla a taxa de aprovação por cidade dos alunos do ensino médio. No cenário do dataset, uma opção de predição é de `ensino_medio_aprovacao_total` onde verificamos se a mesma é maior ou igual a 80%.

### 3) Analise algoritmos

#### J48 (C4.5)

Algoritmo que usa alvore de decisões para vasculhar os dados e encontrar a melhor classificação para os mesmos.

[Weka: Decision Trees – J48](http://stp.lingfil.uu.se/~santinim/ml/2016/Lect_03/Lab02_DecisionTrees.pdf)

#### Multilayer Perceptron

[More Data Mining with Weka (Class 5) - 2014](https://www.cs.waikato.ac.nz/ml/weka/mooc/moredataminingwithweka/slides/Class5-MoreDataMiningWithWeka-2014.pdf)

#### NaiveBayes



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

​	**Tamanho:** 496 instancias, 5 atributos

### Procedimentos e proposta de pre-processamento:

​	Todas as bases utilizadas nessa analise foram baixadas do site: https://dados.rs.gov.br/. Para cada uma delas foi necessário abri-lá no Excel excluir a primeira linha (a que continha `ç`) e converte-lá para csv com `;`, para garantir que a base estava sem problemas.

​	Após padronizar as bases, foi pego cada uma delas e foi unificado em uma por um script feito em R. Esse script garantia a união das bases, sem a perda e mistura de dados, pois o mesmo vinculava cada linhas por sua cidade e garantia que a conversão de números do padrão brasileiro para o padrão utilizado no Weka iria ocorrer sem a perda de dados.

### Tabela:

|                            | J48     | Multilayer Perceptron | NaiveBayes |
| -------------------------- | ------- | --------------------- | ---------- |
| **Taxa de acerto**         | 77.621% | 70.5645%              | 77.4194%   |
| **Taxa de erro**           | 22.379% | 29.4355%              | 22.5806 %  |
| **Tempo de processamento** | 0.01 s  | 1.29 s                | 0.02s      |

### Desenvolvimento:

​	Inicialmente foi pego as bases colocadas no artigo unido as mesmas em um *CSV* e colocado no *Weka*. Nesse momento, acabamos tendo um péssimo resultado, pois, devido a base ter varias falhas e não estar preparada para analise. Então, partimos para a analise dos dados para um pré-processamento. Essa analise nos fez verificar que os dados estavam com problemas, deles:

- Problemas com o padrão de números utilizado
- Quantidade de cidades diferentes entre bases
- Caractere especial (`ç`) em cada arquivo de base
- Padrão de *encoding* diferente entre arquivos

​	A partir disso, verificamos que teríamos que trabalhar sobre as bases. Então, iniciamos o pre-processamento das bases com *R scripts*. Esse processamento foi essencial para nossa analise dos dados, pois a partir dele, conseguimos trabalhar coisas que não conseguiríamos fazer de outra maneira.

​	Voltando a analise, iniciamos tentando colocar todos os valores gerados das tabelas nos testes, mas logo vimos que isso seria um problema, devido ao J48 só aceitar valores nominais para a analise e não valores numéricos. Então, pre-processamos o valor como falamos no item [4) Analise de pré-processamento](#4 Analise de pré-processamento).

#### Atributos gerados a partir da pre-analise

1. ibge
2. Município
3. latitude
4. longitude
5. ensino_medio_aprovacao_total
6. ensino_medio_aprovacao_fundamental_2010_total
7. ensino_medio_distorcao_idade
8. ensino_medio_matricula_inicial
9. ensino_medio_funcoes_docentes
10. numero_de_vinculo_empregaticio_ativo
11. numero_de_vinculo_empregaticio_ativo_2012
12. criminal_entorpecentes
13. criminal_furto_de_veiculo
14. criminal_furto
15. criminal_roubos
16. criminal_entorpecentes_2012
17. criminal_furto_de_veiculo_2012
18. criminal_furto_2012
19. criminal_roubos_2012
20. **ensino_medio_aprovacao_total_desejada**
21. ensino_medio_quantidade_de_professores_por_aluno
22. vinculo_empregaticio_2012_2013
23. criminal_entorpecentes_2012_2013
24. criminal_furto_2012_2013
25. criminal_furto_de_carro_2012_2013
26. criminal_roubo_2012_2013

O atributo `ensino_medio_aprovacao_total_desejada` foi o atributo escolhido para a analise.

## Links

- [More Data Mining with Weka](https://www.cs.waikato.ac.nz/ml/weka/mooc/moredataminingwithweka/slides/Class5-MoreDataMiningWithWeka-2014.pdf)

### Links de bases

- http://dados.gov.br/
- https://dados.rs.gov.br/
- http://www.portaltransparencia.gov.br/download-de-dados
- https://www.kaggle.com/