
<ul>
<li><a href="#priority-queue">Priority Queue</a>
<ul>
<li><a href="#task-scheduler">Task Scheduler</a>
<ul>
<li><a href="#problems">Problems</a></li>
<li><a href="#iterative-with-priority-queue-maxheap">Iterative with Priority Queue (MaxHeap)</a></li>
</ul>
</li>
</ul>
</li>
</ul>

# Priority Queue #
## Task Scheduler ##
### Problems ###
- [https://leetcode.com/problems/task-scheduler/](https://leetcode.com/problems/task-scheduler/)
-
### Iterative with Priority Queue (MaxHeap) ###
```
public class MaxHeap
{
    private readonly List<int> _list = new List<int>();
    public int Count { get => _list.Count; }
    // O(log(n)), O(1)
    public int Remove() {
        if (_list.Count == 0) throw new Exception("Heap is empty");
        int tmp = _list[0];
        Swap(0, _list.Count - 1);
        _list.RemoveAt(_list.Count - 1);
        BubbleDown(0);
        return tmp;
    }
    // O(log(n)), O(1)
    public void Add(int num)
    {
        _list.Add(num);
        BubbleUp(_list.Count - 1);
    }
    // O(nlog(n), O(n)
    public void AddRange(IEnumerable<int> nums) {
        foreach (int num in nums) Add(num);
    }
    // O(log(n)), O(1)
    private void BubbleUp(int child) {
        int parent = (child - 1) / 2;
        while (parent >= 0 && child >= 0 && _list[parent] < _list[child]) {
            Swap(parent, child);
            child = parent;
            parent = (child - 1) / 2;
        }
    }
    // O(log(n)), O(1)
    private void BubbleDown(int parent) {
        while (parent < _list.Count) {
            int lChildInd = (2 * parent) + 1;
            int rChildInd = (2 * parent) + 2;
            int? lChild = lChildInd >= 0 && lChildInd < _list.Count ? _list[lChildInd] : (int?)null;
            int? rChild = rChildInd >= 0 && rChildInd < _list.Count ? _list[rChildInd] : (int?)null;
            int bigChildInd = -1;
            if (lChild == null && rChild == null) break;
            if (lChild != null && rChild != null) {
                bigChildInd = lChild.Value >= rChild.Value ? lChildInd : rChildInd;
            }
            else {
                bigChildInd = lChildInd;
            }
            if (_list[parent] < _list[bigChildInd]) {
                Swap(parent, bigChildInd);
            }
            parent = bigChildInd;
        }
    }
    // O(1), O(1)
    private void Swap(int i1, int i2) {
        int tmp = _list[i1];
        _list[i1] = _list[i2];
        _list[i2] = tmp;
    }
}
public class Solution {
    // O(m + m*log(m) + m*n*log(m) + m*n*log(m))
    // O(m + m*log(m) + 2(m*n*log(m)))
    // O(m*log(m) +(m*n*log(m)))
    // O(m*log(m)* (1 + n))
    // O(m*n*log(m))
    public int LeastInterval(char[] tasks, int n) {
        if ((tasks?.Length ?? 0) == 0) return 0;
        if (n == 0) return tasks.Length;
        var map = new Dictionary<char, int>();
        var heap = new MaxHeap();
        int cycles = 0;
        foreach (char c in tasks) { // O(m)
            if (map.ContainsKey(c)) map[c]++;
            else map.Add(c, 1);
        }
        heap.AddRange(map.Values); // O(m*log(m))
        while (heap.Count > 0) { // O(m)
            var list = new List<int>();
            for (int i = 0; i <= n; i++) { // O(n)
                if (heap.Count > 0){
                    int task = heap.Remove(); // O(log(m))
                    task--;
                    cycles++;
                    if (task > 0) list.Add(task);
                }
                else if (list.Count > 0) {
                    cycles++;
                }
                else { 
                    break;
                }
            }
            heap.AddRange(list); // O(n*log(m))
        }
        return cycles;
    }
}
```


