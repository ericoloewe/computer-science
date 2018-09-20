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
+ var hasMoreItems = true;
+ var foundSolution = false;
+ var openedParents = new Dictionary<string, PuzzleTreeNode<IPuzzle>>();

# ao invés da recursão, criamos um loop para varrer todos os estados possíveis até chegar na solução
+ while (hasMoreItems && !foundSolution)
...
+        if (!IsARepeatedPuzzle(puzzleChild))
...
-            var childrenResolution = StartToBuildPuzzleTree(events, puzzleChildNode);
# agora, quando encontramos uma solução, marcamos foundSolution como true e retornamos o filho pronto
+            if (puzzleChild.IsDone())
...
+                foundSolution = true;
+                return puzzleChildNode;
...
-            if (childrenResolution != null)
-                return childrenResolution;
# agora, quando vemos um novo estado o adicionamos em openedParents
+            openedParents.Add(puzzleChild.ToString(), puzzleChildNode);

# nesse ponto, nos verificamos se ainda existe estados a ser verificados pelo algoritmo
+ if (openedParents.Count == 0)
...
+    hasMoreItems = false;
...
```

Agora, nos já tínhamos um algoritmo que funcionava. Porem, ele ainda era um grande problema devido a performance do mesmo.
Então começamos a buscar a solução a partir dos estados com informações do quão próximos os estados estão da solução

#### Algoritmo busca com informação não recursivo
```csharp
private PuzzleTreeNode<IPuzzle> StartToBuildPuzzleTree(PuzzleEvents events, PuzzleTreeNode<IPuzzle> parent)
{
    PuzzleTreeNode<IPuzzle> solution = null;
    var hasMoreItems = true;
    var foundSolution = false;
    var openedParents = new Dictionary<string, PuzzleTreeNode<IPuzzle>>();
    var closedParents = new Dictionary<string, PuzzleTreeNode<IPuzzle>>();
    var childRepeatControl = new Dictionary<string, PuzzleTreeNode<IPuzzle>>();
    var parentPuzzle = parent.Data;
    var parentPuzzleString = parentPuzzle.ToString();

    if (parentPuzzle.IsDone())
    {
        solution = parent;

        return solution;
    }

    openedParents[parentPuzzleString] = parent;

    while (hasMoreItems && !foundSolution)
    {
        foreach (var allowedMovement in parentPuzzle.AllowedMovements())
        {
            var puzzleChild = (Puzzle)parentPuzzle.Clone();

            puzzleChild.Move(allowedMovement);

            var puzzleChildString = puzzleChild.ToString();
            var isARepeatedPuzzle = childRepeatControl.ContainsKey(puzzleChildString);
            var childWasAParent = closedParents.ContainsKey(puzzleChildString);
            var childWillBeAParent = openedParents.ContainsKey(puzzleChildString);

            if (!childWasAParent || !childWillBeAParent || !isARepeatedPuzzle)
            {
                var puzzleChildNode = tree.Insert(puzzleChild, parent);

                if (!childWasAParent)
                {
                    openedParents[puzzleChildString] = puzzleChildNode;
                }

                if (!isARepeatedPuzzle)
                {
                    if (puzzleChild.IsDone())
                    {
                        solution = puzzleChildNode;
                        foundSolution = true;

                        return puzzleChildNode;
                    }

                    events.onStateChange.Invoke(puzzleChild);
                    childRepeatControl[puzzleChildString] = puzzleChildNode;
                }
            }
        }

        openedParents.Remove(parentPuzzleString);
        closedParents[parentPuzzleString] = parent;

        if (!openedParents.Any())
        {
            hasMoreItems = false;
            break;
        }

        childRepeatControl[parentPuzzleString] = parent;
        parent = GetBestNodeByHeuristic(openedParents);
        parentPuzzle = parent.Data;
        parentPuzzleString = parentPuzzle.ToString();
    }

    return solution;
}
```

Nesse algoritmo nos adicionamos mais 2 variáveis:
- `childRepeatControl`
- `closedParents`

```diff
+ var closedParents = new Dictionary<string, PuzzleTreeNode<IPuzzle>>();
+ var childRepeatControl = new Dictionary<string, PuzzleTreeNode<IPuzzle>>();
...
while (hasMoreItems && !foundSolution)
...
    foreach (var allowedMovement in parentPuzzle.AllowedMovements())
...
+    var isARepeatedPuzzle = childRepeatControl.ContainsKey(puzzleChildString);
+    var childWasAParent = closedParents.ContainsKey(puzzleChildString);
+    var childWillBeAParent = openedParents.ContainsKey(puzzleChildString);
...
# Nesse momento ao inves de verificar somente se não é um estado repetido, passamos a verificar mais 2 pontos:
# - Se o estado já foi um pai anteriormente
# - Se o estado sera um pai dentro do loop
+    if (!childWasAParent || !childWillBeAParent || !isARepeatedPuzzle)
...
# Foi adicionado mais um ponto importante onde é feito uma validação de caso o estado filho ainda não foi um pai, ele é adicionado a lista de pais
+        if (!childWasAParent)
...
+            openedParents[puzzleChildString] = puzzleChildNode;
...
+        if (!isARepeatedPuzzle)
...
# nesse ponto é feito a validação se o estado atual é o estado final
# caso não seja, adicionamos o mesmo em childRepeatControl
+                    childRepeatControl[puzzleChildString] = puzzleChildNode;
...
# Aqui é onde trocamos o proximo estado para o melhor estado, ao invés de pegarmos apenas o primeiro estado da lista
-    parent = openedParents.First().Value;
+    parent = GetBestNodeByHeuristic(openedParents);
...
```