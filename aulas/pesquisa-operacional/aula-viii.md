# Aula VIII

## Algoritmo Simplex

Dantzig 1947

### 1ª versão

- Só para maximização
- Todas restrições do tipo `<=`
- Não negatividade

#### Características

- <s>Forma canônica</s>
- Forma básica
- Variáveis básicas (podem ter valor != 0)
  - Só uma vez em cada linha com coeficiente + 1 e que não listam nas outras linhas
- Não básicas (tem valor = 0)
- Para um sistema de m (**3**) equações com N (**7**) variáveis o simplex encontra uma solução ótima com m (3)  variáveis básicas com valor que pode ser != 0

### Resolver problema com algoritmo

#### Função objetivo

MAX(2x_1 + 3x_2 + 7x_3 + 9x_4)

#### Restrições

SUJ. A: 1x_1 + 1x_2 + 1x_3 + 1x_4 <= 9

SUJ. B: 1x_1 + 2x_2 + 4x_3 + 8x_4 <= 24



#### Funcionamento **algoritmo**

**x_0** - 2x_1 - 3x_2 - 7x_3 - 9x_4       = 0

1x_1 + 1x_2 + 1x_3 + 1x_4 + **1x_5** = 9

1x_1 + 1x_2 + 1x_3 + 1x_4 + 1x_6 = 24

#### 1ª Solução viável básica

| Básicas  | Não básicas |
| -------- | ----------- |
| x_0 = 0  | x_1 = 0     |
| x_5 = 9  | x_2 = 0     |
| x_6 = 24 | x_3 = 0     |
|          | x_4 = 0     |

- 1ª Quem na base
  - Var com coeficiente
  - Coeficiente + Negativo (**x_4**)
- 2ª Quem sai (**x_6**)

```flow
in=>start: Início
po=>operation: Processa
te=>condition: Tem Coeficiente Negativo (-)
fi=>end: Fim (Solução ótima)

in->po->te
te(no)->fi
te(yes)->po
```

