# Aula X

## Simplex 

### Maximização

com todas restrições <=

- Solução única ✔
- solução múltiplas ✔
- solução infinita
- inexistência de solução
  - método do "M grande"

#### Solução infinita

$$
MAX  x_1 + x_2 \\
Suj A x_1 - x_2 <= 1 \\
-x_1 + x_2 <= 1
x_1, x_2 >= 0
$$

#### Inexistência de solução

É dado quando o sistema possui variáveis básicas na ultima iteração

### Minimização

Restrições tipo >= ou =
$$
MIN (2x_1 + 3x_2) \\
Inverter\ sinais\ para\ minimizar \\
x_0 - 2x_1 - 3x_2 = 0 \\
Adicionar\ sinal\ ao\ x_0\ para\ lembrar\\
x_0' = -x_0 \\
resolver\ MAX \\
x_0' + 2x_1 +3x_2 = 0
$$




