# Aula VI
## Quebra cabeças
Para verificar se um quebra cabeça não tem solução, deve-se ler todos os numeros 
da esquerda para direita e contando os numeros que não estão na ordem correta (menor < maior)

| 4 | 3 | 2 |<br>
| 5 | 8 | 6 |<br>
| 7 | 1 | - |<br>

4 -> 3 -> 2 -><br>
5 -> 8 -> 6 -><br>
7 -> 1 -> -<br>

### Quebra cabeça sem solução

| 1     | 2     | 3     | 4     |<br>
| 5     | 6     | 7     | 8     |<br>
| 9     | 10    | 11    | 12    |<br>
| 13    | 15    | 14    | -     |<br>

### Função sucessora
Responsavel por retornar os estados futuros