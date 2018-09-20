# Quebra cabeça 3x3
## Introdução
O objetivo desta atividade é a prática na construção de uma solução para problemas com o emprego da busca em espaço de estados com informação. Os alunos devem construir um programa que implemente o problema do quebra-cabeça de blocos deslizantes 3x3 e uma função de busca baseada em alguma heurística. Então, descrever e avaliar os resultados.

## Estrutura
Para desenvolvimento desse algoritmo, foi utilizado algumas estruturas de dados, delas:
- Arvore com valor heurístico
- Dicionários
- Listas

## Desenvolvimento
Inicialmente, foi utilizado um método recursivo para solucionar o quebra cabeça, então começamos criando uma classe chamada `HardCodeRecursiveBuilder`

#### Algoritmo busca sem informação recursivo
```csharp
private IDictionary<string, IPuzzle> puzzleRepeatControl;
...
private PuzzleTreeNode<IPuzzle> StartToBuildPuzzleTree(PuzzleEvents events, PuzzleTreeNode<IPuzzle> parent)
{
    var parentPuzzle = parent.Data;

    if (IsARepeatedPuzzle(parentPuzzle))
    {
        return null;
    }

    AddToPuzzleRepeatedListIfNeed(parentPuzzle);

    foreach (var allowedMovement in parentPuzzle.AllowedMovements())
    {
        var puzzleChild = (Puzzle)parentPuzzle.Clone();

        Console.WriteLine($"allowedMovement: {allowedMovement}");
        puzzleChild.Move(allowedMovement);

        if (!IsARepeatedPuzzle(puzzleChild))
        {
            var puzzleChildNode = tree.Insert(puzzleChild, parent);

            if (puzzleChild.IsDone())
            {
                return puzzleChildNode;
            }

            events.onStateChange.Invoke(puzzleChild);
            var childrenResolution = StartToBuildPuzzleTree(events, puzzleChildNode);

            if (childrenResolution != null)
            {
                return childrenResolution;
            }
        }
    }

    return null;
}
...
```

**Apesar** do [algoritmo acima](#algoritmo-busca-sem-informação-recursivo) ter a **logica correta**, ele **nunca funcionou** devido a limite de chamadas na `stackTrace`

Então, a partir do momento que identificamos esse problema, começamos a buscar uma solução alterativa a qual resultou na classe `HardCodeBuilder` e da abstração da classe `HardCodeRecursiveBuilder` para uma interface `IPuzzleBuilder` onde todos os builders deveriam seguir o padrão imposto por ela

#### Algoritmo busca sem informação não recursivo
```csharp
private PuzzleTreeNode<IPuzzle> StartToBuildPuzzleTree(PuzzleEvents events, PuzzleTreeNode<IPuzzle> parent)
{
    PuzzleTreeNode<IPuzzle> nodeSolution = null;
    var hasMoreItems = true;
    var foundSolution = false;
    var openedParents = new Dictionary<string, PuzzleTreeNode<IPuzzle>>();
    var closedParents = new Dictionary<string, PuzzleTreeNode<IPuzzle>>();
    var parentPuzzle = parent.Data;

    if (parentPuzzle.IsDone())
    {
        foundSolution = true;
        return parent;
    }

    openedParents.Add(parentPuzzle.ToString(), parent);

    while (hasMoreItems && !foundSolution)
    {
        foreach (var allowedMovement in parentPuzzle.AllowedMovements())
        {
            var puzzleChild = (Puzzle)parentPuzzle.Clone();

            puzzleChild.Move(allowedMovement);

            if (!IsARepeatedPuzzle(puzzleChild))
            {
                var puzzleChildNode = tree.Insert(puzzleChild, parent);

                if (puzzleChild.IsDone())
                {
                    foundSolution = true;
                    return puzzleChildNode;
                }

                events.onStateChange.Invoke(puzzleChild);
                openedParents.Add(puzzleChild.ToString(), puzzleChildNode);
                AddToPuzzleRepeatedListIfNeed(puzzleChild);
            }
        }

        var parentPuzzleString = parentPuzzle.ToString();

        openedParents.Remove(parentPuzzleString);

        if (!closedParents.ContainsKey(parentPuzzleString))
        {
            closedParents.Add(parentPuzzleString, parent);
        }

        if (openedParents.Count == 0)
        {
            hasMoreItems = false;
            break;
        }

        AddToPuzzleRepeatedListIfNeed(parentPuzzle);
        parent = openedParents.First().Value;
        parentPuzzle = parent.Data;
    }

    return nodeSolution;
}
```

O algoritmo [desenvolvido acima](#algoritmo-busca-sem-informação-não-recursivo), diferente do [algoritmo anterior](#algoritmo-busca-sem-informação-recursivo) ele entrega a solução quando a mesma existia!

Devido a não recursividade foi adicionado 3 novas variáveis de controle:
- `hasMoreItems` para controle do loop se existe estados que não foram visitados
- `foundSolution` para controle do loop se foi encontrado alguma solução ou não
- `openedParents` para controle de quais estados já foram visitados para não repetir os mesmos

```diff
+++ var hasMoreItems = true;
+++ var foundSolution = false;
+++ var openedParents = new Dictionary<string, PuzzleTreeNode<IPuzzle>>();

+++ while (hasMoreItems && !foundSolution)
...
+++        if (!IsARepeatedPuzzle(puzzleChild))
...
# apos vermos que o novo estado não existe
+++            openedParents.Add(puzzleChild.ToString(), puzzleChildNode);

# nesse ponto, nos verificamos se ainda existe estados a ser verificados pelo algoritmo
+++ if (openedParents.Count == 0)
...
+++    hasMoreItems = false;
...
```