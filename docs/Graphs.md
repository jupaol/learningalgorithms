
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
<li><a href="#iterative-disjtra-alternate-version-easier-heap">Iterative Disjtra (alternate version: easier heap)</a></li>
</ul>
</li>
<li><a href="#cheapest-flights-within-k-stops">Cheapest flights within k stops</a>
<ul>
<li><a href="#problems-5">Problems</a></li>
<li><a href="#iterative-dijstra-1">Iterative: Dijstra</a></li>
</ul>
</li>
<li><a href="#course-schedule-if-a-graph-has-a-cycle-then-the-topological-view-cannot-be-generated">Course Schedule (if a graph has a cycle then the topological view cannot be generated)</a>
<ul>
<li><a href="#problems-6">Problems</a></li>
<li><a href="#iterativerecursive">Iterative/Recursive</a></li>
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
### Iterative Disjtra (alternate version: easier heap) ###
```
public class MinHeap<TItem, TPriority> where TPriority : IComparable<TPriority> {
    private readonly Func<TItem, TPriority> _priority;
    private readonly SortedDictionary<TPriority, Queue<TItem>> _queue;
    public MinHeap(Func<TItem, TPriority> priority) : this(priority, Comparer<TPriority>.Default) {}
    public MinHeap(Func<TItem, TPriority> priority, IComparer<TPriority> comparer) {
        _priority = priority;
        _queue = new SortedDictionary<TPriority, Queue<TItem>>(comparer);
    }
    public int Count => _queue.Count;
    public void Enqueue(TItem item) {
        TPriority priority = _priority(item);
        if (!_queue.ContainsKey(priority)) _queue.Add(priority, new Queue<TItem>());
        _queue[priority].Enqueue(item);
    }
    public TItem Dequeue() {
        if (_queue.Count == 0) throw new Exception("Queue is empty");
        TItem item = _queue.First().Value.Dequeue();
        TPriority priority = _priority(item);
        if (_queue[priority].Count == 0) _queue.Remove(priority);
        return item;
    }
}
public class Vertex
{
    public int Key { get; set; }
    public ICollection<Edge> Edges { get; }
    public Vertex(int key) {
        Key = key;
        Edges = new List<Edge>();
    }
    public override int GetHashCode() => HashCode.Combine(Key);
    public override bool Equals(object obj) => Equals(obj as Vertex);
    public override string ToString() => $"({Key})";
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
        Vertex[] graph = InitGraph(times, N);
        FillGraph(times, graph);
        int[] delayTimes = GetDelayTimes(K, graph);
        int max = delayTimes.Max();
        return max == int.MaxValue ? -1 : max;
    }
    private int[] GetDelayTimes(int initialVertex, Vertex[] graph) {
        initialVertex--;
        int[] distances = new int[graph.Length];
        Vertex[] parents = new Vertex[graph.Length];
        bool[] seen = new bool[graph.Length];
        var heap = new MinHeap<(Vertex vertex, int distance, Vertex parent), int>(x => x.distance);
        Array.Fill(distances, int.MaxValue);
        heap.Enqueue((graph[initialVertex], 0, null));
        distances[initialVertex] = 0;
        while (heap.Count > 0) {
            (Vertex vertex, int distance, Vertex parent) current = heap.Dequeue();
            if (seen[current.vertex.Key]) continue;
            seen[current.vertex.Key] = true;
            distances[current.vertex.Key] = current.distance;
            parents[current.vertex.Key] = current.parent;
            foreach (Edge edge in current.vertex.Edges) {
                if (seen[edge.Vertex]) continue;
                int weight = distances[current.vertex.Key] + edge.Weight;
                heap.Enqueue((graph[edge.Vertex], weight, current.vertex));
            }
        }
        /*
        EXAMPLE TO GET THE PATH
        Console.WriteLine(string.Join(",", distances));
        Console.WriteLine(string.Join(",", parents.Select((x, i) => $"({i}: {x?.Key})")));
        int max = distances.Where(x => x != int.MaxValue).Max();
        int maxId = Array.FindIndex(distances, x => x == max);
        Console.WriteLine(maxId);
        while (parents[maxId] != null) {
            Console.WriteLine(parents[maxId].Key);
            maxId = parents[maxId].Key;
        }
        */
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
    private Vertex[] InitGraph(int[][] times, int N) {
        Vertex[] graph = new Vertex[N];
        for (int i = 0; i < graph.Length; i++) {
            graph[i] = new Vertex(i);
        }
        return graph;
    }
}
```
## Cheapest flights within k stops ##
### Problems ###
- [https://leetcode.com/problems/cheapest-flights-within-k-stops/](https://leetcode.com/problems/cheapest-flights-within-k-stops/)
-
### Iterative: Dijstra ###
```
public class PriorityQueue<TItem, TPriority> where TPriority : IComparable<TPriority> {
    private readonly Func<TItem, TPriority> _priority;
    private readonly SortedDictionary<TPriority, Queue<TItem>> _queue;
    public PriorityQueue(Func<TItem, TPriority> priority) : this(priority, Comparer<TPriority>.Default) {}
    public PriorityQueue(Func<TItem, TPriority> priority, IComparer<TPriority> comparer) {
        _priority = priority;
        _queue = new SortedDictionary<TPriority, Queue<TItem>>(comparer);
    }
    public int Count { get => _queue.Count; }
    public void Enqueue(TItem item) {
        TPriority priority = _priority(item);
        if (!_queue.ContainsKey(priority)) _queue.Add(priority, new Queue<TItem>());
        _queue[priority].Enqueue(item);
    }
    public TItem Dequeue() {
        if (_queue.Count == 0) throw new Exception("Queue is empty");
        TItem item = _queue.First().Value.Dequeue();
        TPriority priority = _priority(item);
        if (_queue[priority].Count == 0) _queue.Remove(priority);
        return item;
    }
    public void Print() {
        Console.WriteLine(string.Join("\n", _queue.Select(x => x.Key + " " + string.Join(",", x.Value))));
        Console.WriteLine("**");
    }
}
public class Vertex {
    public int VertexId { get; }
    public ICollection<Edge> Edges { get; }
    public Vertex(int vertexId) {
        VertexId = vertexId;
        Edges = new List<Edge>();
    }
    public override int GetHashCode() => HashCode.Combine(VertexId);
    public override bool Equals(object obj) => Equals(obj as Vertex);
    public bool Equals(Vertex vertex) => vertex != null && vertex.VertexId == VertexId;
    public override string ToString() => $"({VertexId})";
}
public class Edge {
    public int VertexId { get; }
    public int Weight { get; }
    public Edge(int vertexId, int weight) {
        VertexId = vertexId;
        Weight = weight;
    }
    public override string ToString() => $"({VertexId}:{Weight})";
}
public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K) {
        // Console.WriteLine("from: " + src + " to: " + dst + " max stops: " + K);
        var queue = new PriorityQueue<(Vertex vertex, int distance, int stops), int>(x => x.distance);
        Vertex[] graph = InitGraph(n, flights);
        queue.Enqueue((graph[src], 0, 0));
        while (queue.Count > 0) {
            (Vertex vertex, int distance, int stops) current = queue.Dequeue();
            // Console.WriteLine("Current: " + current);
            int vertexId = current.vertex.VertexId;
            if (current.stops > K + 1) continue;
            if (vertexId == dst) return current.distance;
            foreach (Edge edge in current.vertex.Edges) {
                queue.Enqueue((graph[edge.VertexId], edge.Weight + current.distance, current.stops + 1));
            }
            // queue.Print();
        }
        return -1;
    }
    private Vertex[] InitGraph(int n, int[][] flights) {
        Vertex[] graph = new Vertex[n];
        for (int i = 0; i < n; i++) graph[i] = new Vertex(i);
        foreach (int[] flight in flights) {
            int source = flight[0];
            int dest = flight[1];
            int price = flight[2];
            
            graph[source].Edges.Add(new Edge(dest, price));
        }
        return graph;
    }
}
```
## Course Schedule (if a graph has a cycle then the topological view cannot be generated) ##
### Problems ###
- [https://leetcode.com/problems/course-schedule/](https://leetcode.com/problems/course-schedule/)
-
### Iterative/Recursive ###
```
public class Vertex
{
    public int VertexId { get; set; }
    public ICollection<Edge> Edges { get; }
    public Vertex(int vertexId) {
        VertexId = vertexId;
        Edges = new List<Edge>();
    }
    public override int GetHashCode() => HashCode.Combine(VertexId);
    public override bool Equals(object obj) => Equals(obj as Vertex);
    public override string ToString() => $"{VertexId}: {string.Join(",", Edges)}";
    public bool Equals(Vertex vertex) => vertex != null && vertex.VertexId == VertexId;
}
public class Edge
{
    public Vertex Vertex { get; set; }
    public Edge(Vertex vertex) {
        Vertex = vertex;
    }
    public override string ToString() => $"{Vertex.VertexId}";
}
public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        Vertex[] graph = CreateGraph(numCourses, prerequisites);
        int[] seen = new int[graph.Length];
        for (int i = 0; i < graph.Length; i++)
            if (seen[i] == 0)
                if (HasCycle(graph, i, seen)) return false;
        return true;
    }
    private bool HasCycle(Vertex[] graph, int index, int[] seen) {
        if (seen[index] == 2) return true;
        seen[index] = 2;
        Vertex current = graph[index];
        for (int i = 0; i < current.Edges.Count; i++) {
            Edge edge = current.Edges.ElementAt(i);
            if (seen[edge.Vertex.VertexId] != 1)
                if (HasCycle(graph, edge.Vertex.VertexId, seen)) return true;
        }
        seen[index] = 1;
        return false;
    }
    private Vertex[] CreateGraph(int n, int[][] prerequisites) {
        Vertex[] graph = new Vertex[n];
        for (int i = 0; i < n; i++) graph[i] = new Vertex(i);
        foreach (int[] pre in prerequisites) {
            int child = pre[0];
            int parent = pre[1];
            graph[parent].Edges.Add(new Edge(graph[child]));
        }
        return graph;
    }
}

```


