`<cmd_while> ::= 'while' <condicao> 'do' <comando>`

```
cmdWhile() {
	if (TOKEN == T_WHILE) {
		buscaProximoToken();
		condicao();
		
		if (TOKEN == T_DO) {
			buscaProximoToken();
			comando();
		} else {
			erro("do esperado");
		}
	} else {
		erro("while esperado");
	}
}
```

`<cmd_for> ::= 'for' <variavel> ':=' <exp> 'to' <exp> 'do' <comando>`

```
cmdFor() {
	if (TOKEN == T_FOR) {
		buscaProximoToken();
		variavel();
		
		if (TOKEN == T_ATTRIB) {
			buscaProximoToken();
			expressao();
			
			if (TOKEN == T_TO) {
				buscaProximoToken();
				expressao();
				
				if (TOKEN == T_DO) {
					buscaProximoToken();
					comando();
				} else {
					erro("do esperado");
				}
			} else {
				erro("to esperado");
			}
		} else {
			erro(":= esperado");
		}
	} else {
		erro("for esperado");
	}
}
```

`<decl> ::= <tipo> <lista_var> ';'`

```
cmdDecl() {
	tipo();
	buscaProximoToken();
	listVar();

	if (TOKEN == T_SEMICOLON) {
		buscaProximoToken();
	} else {
		erro("decl esperado");
	}
}
```

`<list_var> ::= <var>`
`<list_var> ::= <var> ',' <list_var>`

```
cmdListVar() {
	var();
	buscaProximoToken();

	if (TOKEN == T_COMMA) {
		buscaProximoToken();
		listVar();
	} else {
		erro("decl esperado");
	}
}
```