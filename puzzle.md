# Quebra cabeça 3x3
## Introdução
​	O objetivo desta atividade é a prática na construção de uma solução para problemas com o emprego da busca em espaço de estados com informação. Os alunos devem construir um programa que implemente o problema do quebra-cabeça de blocos deslizantes 3x3 e uma função de busca baseada em alguma heurística. Então, descrever e avaliar os resultados.

## Estrutura
​	Para desenvolvimento desse algoritmo, foi utilizado algumas estruturas de dados, delas:
- O próprio [Quebra cabeça](#quebra-cabeça)
- [Arvore com valor heurístico](#arvore-com-informação)
- [Arvore sem valor heurístico](#arvore-sem-informação)
- Dicionários
- Listas

### Quebra cabeça
```csharp
public class Puzzle : IPuzzle
{
    ...
    // Tamanho do quebra cabeça
    public int Size { get; private set; }
    // Estrutura criada para guardar posições das peças
    public PuzzlePiece[][] Rows { get; private set; }
    // Peça que não tem valor
    private PuzzlePiece hidePiece;
    // Estrutura criada para validar a estrutura atual com a estrutura original
    private PuzzlePiece[][] originalRows;
    // Estrutura criada para performance sua ideia é facilitar a busca pelas peças do quebra cabeça, buscando pelo index da peça
    private PuzzlePiece[] originalRowsByIndex;
    ...
    // Método utilizado para prover os próximos movimentos do quebra cabeça a partir do estado atual
    // (função sucessora)
    public IList<MovementType> AllowedMovements() {}
    ...
}
```

### Arvore sem informação
```csharp
public class PuzzleTreeWithoutInfo<T>
{
    public PuzzleTreeNode<T> Root { get; set; }

    public PuzzleTreeNode<T> Insert(T data)
    {
        return Root = new PuzzleTreeNode<T>(data);
    }

    public PuzzleTreeNode<T> Insert(T data, PuzzleTreeNode<T> parent)
    {
        var newNode = new PuzzleTreeNode<T>(data);

        newNode.Parent = parent;
        parent.Children.Add(newNode);

        return newNode;
    }

    public IList<T> GetNodePathToRoot(PuzzleTreeNode<T> puzzleNode)
    {
        IList<T> pathToRoot = new List<T>();

        do
        {
            pathToRoot.Add(puzzleNode.Data);
            puzzleNode = puzzleNode.Parent;
        } while (puzzleNode != null);

        return pathToRoot;
    }
}

public class PuzzleTreeNode<T>
{
    public IList<PuzzleTreeNode<T>> Children { get; set; }
    public PuzzleTreeNode<T> Parent { get; set; }
    public T Data { get; set; }

    public PuzzleTreeNode(T data)
    {
        this.Data = data;
        this.Children = new List<PuzzleTreeNode<T>>();
    }
}
```

​	Ao nodo, foi adicionado ao nodo as informações de `Data` - a informação armazena na arvore -, `Children` - a relação entre o nodo e seus filhos - , `Parent` - a relação entre o nodo o seu pai -. No momento, essas eram as únicas informações necessárias para realizar o algoritmo de busca sem informação.

​	Abaixo, iremos mostrar a estrutura de arvores criada (`PuzzleTreeWithInfo`) para trabalhar com informações, nela, foi adicionado um método `AddInfoTo` o qual fica responsável por adicionar as informações heurísticas ao nodo

### Arvore com informação
#### Estrutura da arvore
```csharp
public class PuzzleTreeWithInfo
{
    public PuzzleTreeNode<IPuzzle> Root { get; private set; }

    public PuzzleTreeNode<IPuzzle> Insert(IPuzzle data)
    {
        Root = new PuzzleTreeNode<IPuzzle>(data);

        AddInfoTo(Root);

        return Root;
    }

    public PuzzleTreeNode<IPuzzle> Insert(IPuzzle data, PuzzleTreeNode<IPuzzle> parent)
    {
        var newNode = new PuzzleTreeNode<IPuzzle>(data);

        AddInfoTo(newNode);
        newNode.Parent = parent;
        parent.Children.Add(newNode);

        return newNode;
    }

    public IList<IPuzzle> GetNodePathToRoot(PuzzleTreeNode<IPuzzle> puzzleNode)
    {
        ...
    }

    private void AddInfoTo(PuzzleTreeNode<IPuzzle> node)
    {
        node.AmountOfPiecesOutOfOrder = node.Data.AmountOfPiecesOutOfOrder();
        node.MovementsToFinish = node.Data.MovementsToFinishAllPieces();
    }
}
```
#### Estrutura do nodo
```diff
public class PuzzleTreeNode<T>
{
    public IList<PuzzleTreeNode<T>> Children { get; set; }
# Soma das informações heuristicas    
+    public int HeuristicValue { get { return AmountOfPiecesOutOfOrder + MovementsToFinish; } }
# Quantidade de peças fora do lugar
+    public int AmountOfPiecesOutOfOrder { get; set; }
# Quantidade de movimentos necessários para colocar cada peça em seu devido lugar
+    public int MovementsToFinish { get; set; }
    public PuzzleTreeNode<T> Parent { get; set; }
...
```

## Desenvolvimento
​	Inicialmente, foi utilizado um método recursivo para solucionar o quebra cabeça, então começamos criando um construtor do quebra cabeça - uma classe chamada `HardCodeRecursiveBuilder` - e uma estrutura em arvore `PuzzleTreeWithoutInfo` para obter o caminho que percorremos até chegar no estado desejado.

​	Essa estrutura inicialmente foi utilizada mais para salvar os caminhos percorridos pelo algoritmo sem duplicação e de fácil entendimento. Nela foi adicionado uma propriedade `Root` para guarda a referencia do inicio da arvore e dois métodos, `Insert` para inserir um nodo na arvore e `GetNodePathToRoot` para obter o caminho percorrido do nodo até a raiz. 

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

​	**Apesar** do [algoritmo acima](#algoritmo-busca-sem-informação-recursivo) ter a **logica correta**, ele **nunca funcionou** devido a limite de chamadas na `stackTrace`. Então, a partir do momento que identificamos esse problema, começamos a buscar uma solução alterativa a qual resultou na classe `HardCodeBuilder` e da abstração da classe `HardCodeRecursiveBuilder` para uma interface `IPuzzleBuilder` onde todos os builders deveriam seguir o padrão imposto por ela

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

​	O algoritmo [desenvolvido acima](#algoritmo-busca-sem-informação-não-recursivo), diferente do [algoritmo anterior](#algoritmo-busca-sem-informação-recursivo) ele entrega a solução quando a mesma existia!

​	Devido a não recursividade foi adicionado 3 novas variáveis de controle:
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

​	Agora, nos já tínhamos um [algoritmo](#algoritmo-busca-sem-informação-não-recursivo) que funcionava. Porem, ele ainda era um grande problema devido a performance do mesmo (Demorava em torno de **30s** para **encontrar uma solução**). Então começamos a buscar a solução a partir dos estados com informações do quão próximos os estados estão da solução. E criamos uma classe `PuzzleBuilder` para resolver esse problema.

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

Adicionamos mais 2 variáveis ao [algoritmo](#algoritmo-busca-com-informação-não-recursivo):

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

​	[Nesse algoritmo](#algoritmo-busca-com-informação-não-recursivo) foram adicionadas também novas propriedades ao nodo da arvore, para podermos realizar a busca com informação. Então, tivemos que visualizar o problema e definir métricas onde conseguiríamos dar uma pontuação aos estados. Essas métricas foram:
- [Quantidade de peças fora do lugar](#algoritmo-que-calcula-a-quantidade-de-peças-fora-do-lugar)
- [Quantidade de movimentos necessários para colocar cada peça em seu devido lugar](#algoritmo-que-calcula-a-quantidade-de-movimentos-necessários-para-colocar-cada-peça-em-seu-devido-lugar)

##### Algoritmo que calcula a quantidade de peças fora do lugar
```csharp
public int AmountOfPiecesOutOfOrder()
{
    var amountOfPiecesOutOfOrder = 0;

    for (int i = 0; i < Size; i++)
    {
        for (int j = 0; j < Size; j++)
        {
            if (Rows[i][j].Number != originalRows[i][j].Number)
            {
                amountOfPiecesOutOfOrder++;
            }
        }
    }

    return amountOfPiecesOutOfOrder;
}
```

##### Algoritmo que calcula a quantidade de movimentos necessários para colocar cada peça em seu devido lugar
```csharp
public int MovementsToFinishAllPieces()
{
    var movementsToFinishAllPieces = 0;

    for (int i = 0; i < Size; i++)
    {
        for (int j = 0; j < Size; j++)
        {
            if (Rows[i][j].Number != originalRows[i][j].Number)
            {
                movementsToFinishAllPieces += MovementsToFinish(Rows[i][j]);
            }
        }
    }

    return movementsToFinishAllPieces;
}

public int MovementsToFinish(PuzzlePiece piece)
{
    var originalPiece = originalRowsByIndex[piece.Number];
    
    var movementToFinish = Math.Abs(
        (originalPiece.Position.Column - piece.Position.Column) +
        (originalPiece.Position.Row - piece.Position.Row)
    );

    return movementToFinish;
}
```

## Conclusões

​	Com o algoritmo de busca com informação, a performance melhorou exponencialmente, de **30s**\* o algoritmo passou a rodar em menos de um segundo **1s**\*. Sendo assim foi possível ver que uma busca com informação agrega um grande valor a busca, pois, quando é realizado uma busca com informação se torna muito mais fácil de se encontrar o melhor caminho a se seguir.

\* Testes realizados em uma maquina com processador core i5, 8GB de ram e HD SSD