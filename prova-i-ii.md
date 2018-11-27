# Prova I (valendo 10 pontos)

## Questões com respostas

### 1) 

- V
- F
- V
- F

### 2)

```
<cmd_gml> ::= 'GML' <variavel> 'NEXT' <templates>

Resposta: ⬇

void comandoGML() {
	if (token === T_GML) {
		buscaProximoToken();
		variavel();
		
		if (token === T_NEXT) {
			buscaProximoToken();
			templates();
		} else registraErro(...)
	} else registraErro(...)
}
```

### 3) Elimine a recursividade à esquerda das regras:

```
<J> ::= <J> ‘%‘ ‘$‘ <T>
<J> ::= <T> ‘+‘
<J> ::= ‘#‘
        
Resposta: ⬇

<J>  ::= ‘%‘ ‘$‘ <T><J’>
<J’> ::= <T> ‘+‘ <J’>
<J’> ::= ‘#‘ <J’>
<J’> ::= ε
```

### 4)

```
'<': begin
	token:= lookahead;
    move_lookahead;

	'<': begin
		token:= lookahead;
    	move_lookahead;
        tipo_token := T_SHIFT_LEFT;
    end;
    else '=': begin
    	token:= lookahead;
    	move_lookahead;
        tipo_token := T_MENOR_IGUAL;
    end;
	else '>': begin
		token:= lookahead;
    	move_lookahead;
        tipo_token := T_DIFERENTE;
    end;    
    else '-': begin
        token:= lookahead;
        move_lookahead;
        tipo_token := T_ATRIBUICAO;
    end;
    else: begin
        tipo_token := T_MENOR;
	end;
end;
```

### 5)

```
| 2/13 | -> Id (C)
| 2/13 | -> Id (A)
| 2/13 | -> Id (B)
| 2/13 | -> Numero (5)


------------------------------------

| 2/13 | -> Id (C)
| 2/13 | -> Id (A)
| 6/11 | -> Expressão (B + 5)

------------------------------------

| 2/13 | -> Id (C)
| 6/11 | -> Expressão (A + B + 5)

------------------------------------

| 8/10 | -> Atribuicao (C = A + B + 5)

------------------------------------
| 2/13 | -> Id
| 6/11 | -> Expressão
| 2/13 | -> Id
| 6/11 | -> Expressão
| 3/13 | -> Numero
| 8/10 | -> Atribuição
```