
<ul>
<li><a href="#graphs">Graphs</a>
<ul>
<li><a href="#number-of-islands">Number of Islands</a>
<ul>
<li><a href="#problems">Problems</a></li>
<li><a href="#iterative-breadth-first-search-in-a-matrix">Iterative: Breadth First Search in a Matrix</a></li>
</ul>
</li>
<li><a href="#walls-and-gates">Walls and Gates</a>
<ul>
<li><a href="#problems-1">Problems</a></li>
<li><a href="#iterative-breadth-first-search">Iterative: Breadth First Search</a></li>
<li><a href="#iterative-breadth-first-search-optimized-runs-on-rm-instead-of-krm">Iterative: Breadth First Search: Optimized, runs on rm instead of krm</a></li>
</ul>
</li>
<li><a href="#surrounded-regions">Surrounded regions</a>
<ul>
<li><a href="#problems-2">Problems</a></li>
<li><a href="#iterative-breadth-first-search-1">Iterative: Breadth First Search</a></li>
</ul>
</li>
<li><a href="#deep-clone-a-graph">Deep clone a graph</a>
<ul>
<li><a href="#problems-3">Problems</a></li>
<li><a href="#iterative-depth-first-search">Iterative Depth First Search</a></li>
</ul>
</li>
<li><a href="#network-delay-time">Network delay time</a>
<ul>
<li><a href="#problems-4">Problems</a></li>
<li><a href="#iterative-dijstra">Iterative (Dijstra)</a></li>
</ul>
</li>
</ul>
</li>
</ul>

# Graphs #
## Number of Islands ##
### Problems ###
- [https://leetcode.com/problems/number-of-islands/](https://leetcode.com/problems/number-of-islands/)
-
### Iterative: Breadth First Search in a Matrix ###
```
public class Coor
{
    public int Row { get; set; }
    public int Col { get; set; }
    public Coor(int row, int col) {
        Row = row;
        Col = col;
    }
    public override int GetHashCode() => HashCode.Combine(Row, Col);
    public override bool Equals(object obj) => Equals(obj as Coor);
    public bool Equals(Coor coor) => coor != null && coor.Row == Row && coor.Col == Col;
}
public class Solution {
    public int NumIslands(char[][] grid) {
        if ((grid?.Length ?? 0) == 0) return 0;
        return CountIslands(grid);
    }
    // O(rc), O(rc)
    private int CountIslands(char[][] graph) {
        int count = 0;
        var memo = new HashSet<Coor>();
        for (int i = 0; i < graph.Length; i++) {
            for (int j = 0; j < graph[0].Length; j++) {
                var coor = new Coor(i, j);
                if (memo.Contains(coor)) continue;
                if (graph[i][j] == '1') {
                    count++;
                    ExpandIsland(graph, coor, memo); // O(rc), O(rc)
                }
            }
        }
        return count;
    }
    // O(rc), O(rc)
    private void ExpandIsland(char[][] graph, Coor current, HashSet<Coor> memo) {
        var queue = new Queue<Coor>();
        queue.Enqueue(current);
        memo.Add(current);
        while (queue.Count > 0) { // O(rc), O(rc)
            Coor coor = queue.Dequeue();
            foreach (Coor child in FindNearby(graph, coor))
            {
                if (!memo.Contains(child)) {
                    queue.Enqueue(child);
                    memo.Add(child);
                }
            }
        }
    }
    // O(1), O(1)
    private IList<Coor> FindNearby(char[][] graph, Coor current) {
        int[] rowsMove = new[] { 1, -1, 0, 0 };
        int[] colsMove = new[] { 0, 0, 1, -1 };
        int rows = graph.Length;
        int cols = graph[0].Length;
        var list = new List<Coor>();
        for (int i = 0; i < rowsMove.Length; i++) {
            int row = current.Row + rowsMove[i];
            int col = current.Col + colsMove[i];
            if (row >= 0 && row < rows && col >= 0 && col < cols && graph[row][col] == '1') {
                list.Add(new Coor(row, col));
            }
        }
        return list;
    }
}
```
## Walls and Gates ##
### Problems ###
- [https://leetcode.com/problems/walls-and-gates/](https://leetcode.com/problems/walls-and-gates/)
-
### Iterative: Breadth First Search ###
```
public class Coor
{
    public int Row { get; set; }
    public int Col { get; set; }
    public Coor(int row, int col) {
        Row = row;
        Col = col;
    }
    public override int GetHashCode() => HashCode.Combine(Row, Col);
    public override bool Equals(object obj) => Equals(obj as Coor);
    public bool Equals(Coor coor) => coor != null && coor.Row == Row && coor.Col == Col;
}
public class Solution {
    public void WallsAndGates(int[][] rooms) {
        if ((rooms?.Length ?? 0) == 0) return;
        SetDistance(rooms);
    }
    // O(rc), O(rc)
    private void SetDistance(int[][] graph) {
        for (int i = 0; i < graph.Length; i++) {
            for (int j = 0; j < graph[0].Length; j++) {
                var coor = new Coor(i, j);
                if (graph[i][j] == 0) {
                    ExpandSearch(graph, coor, new HashSet<Coor>()); // O(rc), O(rc)
                }
            }
        }
    }
    // O(rc), O(rc)
    private void ExpandSearch(int[][] graph, Coor current, HashSet<Coor> memo) {
        var queue = new Queue<Coor>();
        int count = 0;
        queue.Enqueue(current);
        memo.Add(current);
        while (queue.Count > 0) { // O(rc), O(rc)
            int size = queue.Count;
            count++;
            while (size > 0) {
                Coor coor = queue.Dequeue();
                foreach (Coor child in FindNearby(graph, coor))
                {
                    if (!memo.Contains(child)) {
                        queue.Enqueue(child);
                        memo.Add(child);
                        graph[child.Row][child.Col] = 
                            Math.Min(count, graph[child.Row][child.Col]);
                    }
                }
                size--;
            }
        }
    }
    // O(1), O(1)
    private IList<Coor> FindNearby(int[][] graph, Coor current) {
        int[] rowsMove = new[] { 1, -1, 0, 0 };
        int[] colsMove = new[] { 0, 0, 1, -1 };
        int rows = graph.Length;
        int cols = graph[0].Length;
        var list = new List<Coor>();
        for (int i = 0; i < rowsMove.Length; i++) {
            int row = current.Row + rowsMove[i];
            int col = current.Col + colsMove[i];
            if (row >= 0 && row < rows && col >= 0 && col < cols) {
                if (graph[row][col] != -1 && graph[row][col] != 0)
                    list.Add(new Coor(row, col));
            }
        }
        return list;
    }
}
```
### Iterative: Breadth First Search: Optimized, runs on rm instead of krm ###
```
public class Coor
{
    public int Row { get; set; }
    public int Col { get; set; }
    public Coor(int row, int col) {
        Row = row;
        Col = col;
    }
    public override int GetHashCode() => HashCode.Combine(Row, Col);
    public override bool Equals(object obj) => Equals(obj as Coor);
    public bool Equals(Coor coor) => coor != null && coor.Row == Row && coor.Col == Col;
}
public class Solution {
    public void WallsAndGates(int[][] rooms) {
        if ((rooms?.Length ?? 0) == 0) return;
        SetDistance(rooms);
    }
    // Where: r: number of rows and c: number of columns
    // O(rc), O(rc)
    private void SetDistance(int[][] graph) {
        var queue = new Queue<Coor>();
        for (int i = 0; i < graph.Length; i++) {
            for (int j = 0; j < graph[0].Length; j++) {
                if (graph[i][j] == 0) {
                    queue.Enqueue(new Coor(i, j));
                }
            }
        }
        ExpandSearch(graph, queue, new HashSet<Coor>()); // O(rc), O(rc)
    }
    // O(rc), O(rc)
    private void ExpandSearch(int[][] graph, Queue<Coor> queue, HashSet<Coor> memo) {
        while (queue.Count > 0) { // O(rc), O(rc)
            Coor coor = queue.Dequeue();
            memo.Add(coor);
            foreach (Coor child in FindNearby(graph, coor))
            {
                if (!memo.Contains(child)) {
                    queue.Enqueue(child);
                    memo.Add(child);
                    graph[child.Row][child.Col] = graph[coor.Row][coor.Col] + 1;
                }
            }
        }
    }
    // O(1), O(1)
    private IList<Coor> FindNearby(int[][] graph, Coor current) {
        int[] rowsMove = new[] { 1, -1, 0, 0 };
        int[] colsMove = new[] { 0, 0, 1, -1 };
        int rows = graph.Length;
        int cols = graph[0].Length;
        var list = new List<Coor>();
        for (int i = 0; i < rowsMove.Length; i++) {
            int row = current.Row + rowsMove[i];
            int col = current.Col + colsMove[i];
            if (row >= 0 && row < rows && col >= 0 && col < cols) {
                if (graph[row][col] != -1 && graph[row][col] != 0)
                    list.Add(new Coor(row, col));
            }
        }
        return list;
    }
}
```
## Surrounded regions ##
### Problems ###
- [https://leetcode.com/problems/surrounded-regions/](https://leetcode.com/problems/surrounded-regions/)
-
### Iterative: Breadth First Search ###
```
public class Coor
{
    public int Row { get; set; }
    public int Col { get; set; }
    public Coor(int row, int col) {
        Row = row;
        Col = col;
    }
    public override int GetHashCode() => HashCode.Combine(Row, Col);
    public override bool Equals(object obj) => Equals(obj as Coor);
    public bool Equals(Coor coor) => coor != null && coor.Row == Row && coor.Col == Col;
}
public class Solution {
    // O(rc + r + c + rc), O(r + c + rc + 1)
    // O(2rc + r + c), O(r + c + rc)
    // O(rc), O(rc)
    public void Solve(char[][] board) {
        if ((board?.Length ?? 0) == 0) return;
        MarkBorderRegions(board); // O(r + c + rc), O(r + c + rc)
        ReplaceRegions(board); // O(rc), O(1)
    }
    // O(rc), O(1)
    private void ReplaceRegions(char[][] graph) {
        for (int i = 0; i < graph.Length; i++) {
            for (int j = 0; j < graph[0].Length; j++) {
                if (graph[i][j] == 'O') graph[i][j] = 'X';
                if (graph[i][j] == 'Z') graph[i][j] = 'O';
            }
        }
    }
    // O(r + c + rc), O(r + c + rc)
    private void MarkBorderRegions(char[][] graph) {
        var list = new List<Coor>();
        int lastCol = graph[0].Length - 1;
        int lastRow = graph.Length - 1;
        for (int i = 0; i < graph.Length; i++) { // O(r)
            if (graph[i][0] == 'O') list.Add(new Coor(i, 0));
            if (graph[i][lastCol] == 'O') list.Add(new Coor(i, lastCol));
        }
        for (int i = 0; i <= lastCol; i++) { // O(c)
            if (graph[0][i] == 'O') list.Add(new Coor(0, i));
            if (graph[lastRow][i] == 'O') list.Add(new Coor(lastRow, i));
        }
        foreach (Coor coor in list)
            ExpandSearch(graph, coor, new HashSet<Coor>()); // O(rc), O(rc)
    }
    // O(rc), O(rc)
    private void ExpandSearch(char[][] graph, Coor current, HashSet<Coor> memo) {
        var queue = new Queue<Coor>();
        queue.Enqueue(current);
        memo.Add(current);
        graph[current.Row][current.Col] = 'Z';
        while (queue.Count > 0) { // O(rc), O(rc)
            Coor coor = queue.Dequeue();
            foreach (Coor child in FindNearby(graph, coor))
            {
                if (!memo.Contains(child)) {
                    queue.Enqueue(child);
                    memo.Add(child);
                    graph[child.Row][child.Col] = 'Z';
                }
            }
        }
    }
    // O(1), O(1)
    private IList<Coor> FindNearby(char[][] graph, Coor current) {
        int[] rowsMove = new[] { 1, -1, 0, 0 };
        int[] colsMove = new[] { 0, 0, 1, -1 };
        int rows = graph.Length;
        int cols = graph[0].Length;
        var list = new List<Coor>();
        for (int i = 0; i < rowsMove.Length; i++) {
            int row = current.Row + rowsMove[i];
            int col = current.Col + colsMove[i];
            if (row >= 0 && row < rows && col >= 0 && col < cols) {
                if (graph[row][col] == 'O')
                    list.Add(new Coor(row, col));
            }
        }
        return list;
    }
}
```
## Deep clone a graph ##
### Problems ###
- [https://leetcode.com/problems/clone-graph/](https://leetcode.com/problems/clone-graph/)
-
### Iterative Depth First Search ###
```
// O(n), O(n)
public Node CloneGraph(Node node) {
	if (node == null) return null;
	if (node.neighbors.Count == 0) return new Node(node.val);
	var queue = new Queue<Node>();
	var map = new Dictionary<Node, Node>();
	var root = new Node(node.val);
	queue.Enqueue(node);
	map.Add(node, root);
	while (queue.Count > 0) {
		Node current = queue.Dequeue();
		foreach (Node child in current.neighbors) {
			if (!map.ContainsKey(child)) {
				var newChild = new Node(child.val);
				map.Add(child, newChild);
				queue.Enqueue(child);
			}
			map[current].neighbors.Add(map[child]);
		}
	}
	return root;
}
```
## Network delay time ##
### Problems ###
- [https://leetcode.com/problems/network-delay-time/](https://leetcode.com/problems/network-delay-time/)
-
### Iterative (Dijstra) ###
```
public class MinHeap
{
    private readonly IList<Vertex> _list = new List<Vertex>();
    public int Count { get => _list.Count; }
    public Vertex Peek() => Min();
    public void Add(Vertex vertex) => _list.Add(vertex);
    public Vertex Remove() {
        if (Count == 0) return null;
        Vertex tmp = Min();
        _list.Remove(tmp);
        return tmp;
    }
    public bool Contains(int key) => _list.Any(x => x.Key == key);
    public Vertex Find(int key) => _list.FirstOrDefault(x => x.Key == key);
    private IEnumerable<Vertex> Sort() => _list.OrderBy(x => x.Distance);
    private Vertex Min() => Sort().FirstOrDefault();
}
public class Vertex
{
    public int Key { get; set; }
    public int Distance { get; set; }
    public ICollection<Edge> Edges { get; }
    public Vertex(int key, int distance = int.MaxValue) {
        Key = key;
        Distance = distance;
        Edges = new List<Edge>();
    }
    public override int GetHashCode() => HashCode.Combine(Key);
    public override bool Equals(object obj) => Equals(obj as Vertex);
    public override string ToString() => $"({Key}, {Distance})";
    public bool Equals(Vertex vertex) => vertex != null && vertex.Key == Key;
}
public class Edge
{
    public int Vertex { get; set; }
    public int Weight { get; set; }
    public Edge(int vertex, int weight) {
        Vertex = vertex;
        Weight = weight;
    }
}
public class Solution {
    public int NetworkDelayTime(int[][] times, int N, int K) {
        var heap = new MinHeap();
        Vertex[] graph = InitGraph(times, N, heap);
        FillGraph(times, graph);
        Vertex[] delayTimes = GetDelayTimes(heap, K);
        if (delayTimes == null) return -1;
        return delayTimes.Max(x => x.Distance);
    }
    private Vertex[] GetDelayTimes(MinHeap heap, int initialVertex) {
        initialVertex--;
        Vertex[] distances = new Vertex[heap.Count];
        Vertex[] parents = new Vertex[heap.Count];
        var initial = heap.Find(initialVertex);
        initial.Distance = 0;
        distances[initialVertex] = initial;
        parents[initialVertex] = null;
        while (heap.Count > 0) {
            Vertex current = heap.Remove();
            if (current.Distance == int.MaxValue) return null;
            distances[current.Key] = current;
            foreach (Edge edge in current.Edges) {
                if (!heap.Contains(edge.Vertex)) continue;
                int weight = distances[current.Key].Distance + edge.Weight;
                if (weight < heap.Find(edge.Vertex).Distance) {
                    heap.Find(edge.Vertex).Distance = weight;
                    parents[edge.Vertex] = current;
                }
            }
        }
        return distances;
    }
    private void FillGraph(int[][] times, Vertex[] graph) {
        for (int i = 0; i < times.Length; i++) {
            int[] edge = times[i];
            int sourceNode = edge[0];
            int targetNode = edge[1];
            int weight = edge[2];
            sourceNode--;
            targetNode--;
            graph[sourceNode].Edges.Add(new Edge(targetNode, weight));
        }
    }
    private Vertex[] InitGraph(int[][] times, int N, MinHeap heap) {
        Vertex[] graph = new Vertex[N];
        for (int i = 0; i < graph.Length; i++) {
            graph[i] = new Vertex(i);
            heap.Add(graph[i]);
        }
        return graph;
    }
}
```

