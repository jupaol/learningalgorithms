
<ul>
<li><a href="#linked-lists">Linked Lists</a>
<ul>
<li><a href="#sort-a-list-using-merge-sort">Sort a list using Merge Sort</a>
<ul>
<li><a href="#problems">Problems</a></li>
<li><a href="#recursive">Recursive</a></li>
</ul>
</li>
<li><a href="#merge-two-sorted-lists">Merge two sorted lists</a>
<ul>
<li><a href="#problems-1">Problems</a></li>
<li><a href="#iterative">Iterative</a></li>
</ul>
</li>
<li><a href="#merge-k-sorted-lists">Merge k Sorted lists</a>
<ul>
<li><a href="#problems-2">Problems</a></li>
<li><a href="#iterative-simulated-minheap">Iterative (Simulated MinHeap)</a></li>
<li><a href="#with-a-minheap-custom-implementation">With a MinHeap custom implementation</a></li>
<li><a href="#iterative-with-sorteddictionary-real-heap">Iterative with SortedDictionary (real heap)</a></li>
</ul>
</li>
<li><a href="#reverse-linked-list">Reverse Linked List</a>
<ul>
<li><a href="#problems-3">Problems</a></li>
<li><a href="#iterative-1">Iterative</a></li>
</ul>
</li>
<li><a href="#reverse-linked-list-from-m-to-n">Reverse Linked List from m to n</a>
<ul>
<li><a href="#problems-4">Problems</a></li>
<li><a href="#iterative-2">Iterative</a></li>
</ul>
</li>
<li><a href="#find-middle-of-a-link-list">Find middle of a link list</a>
<ul>
<li><a href="#problems-5">Problems</a></li>
<li><a href="#iterative-3">Iterative</a></li>
</ul>
</li>
<li><a href="#detect-cycle">Detect cycle</a>
<ul>
<li><a href="#problems-6">Problems</a></li>
<li><a href="#iterative-4">Iterative</a></li>
<li><a href="#iterative-returning-the-cycle-node">Iterative, returning the cycle node</a></li>
</ul>
</li>
<li><a href="#reorder-list">Reorder list</a>
<ul>
<li><a href="#problems-7">Problems</a></li>
<li><a href="#iterative-5">Iterative</a></li>
</ul>
</li>
<li><a href="#deep-copy-with-random-pointers">Deep copy with random pointers</a>
<ul>
<li><a href="#problems-8">Problems</a></li>
<li><a href="#iterative-6">Iterative</a></li>
</ul>
</li>
<li><a href="#design-browser-history">Design Browser History</a>
<ul>
<li><a href="#problems-9">Problems</a></li>
<li><a href="#iterative-7">Iterative</a></li>
</ul>
</li>
</ul>
</li>
</ul>

# Linked Lists #
## Sort a list using Merge Sort ##
### Problems ###
- [https://leetcode.com/problems/sort-list/](https://leetcode.com/problems/sort-list/)
-
### Recursive ###
```
// O(nlog(n)), O(n)
private ListNode SortRec(ListNode head) {
	if (head == null) return null;
	if (head.next == null) return head;
	ListNode middle = FindMiddle(head);
	ListNode head2 = middle.next;
	middle.next = null;
	ListNode a = SortRec(head);
	ListNode b = SortRec(head2);
	return Merge(a, b);
}
// O(n), O(1) 
private ListNode Merge(ListNode a, ListNode b) {
	ListNode res = null;
	ListNode prev = null;
	while (a != null && b != null) {
		ListNode small = a.val <= b.val ? a : b;
		res ??= small;
		if (prev == null) prev = small;
		else {
			prev.next = small;
			prev = small;
		}
		if (a.val <= b.val) a = a.next;
		else b = b.next;
	}
	if (prev != null) prev.next = a != null ? a : b;
	return res;
}
// O(n/2), O(1)
// O(n), O(1)
private ListNode FindMiddle(ListNode head) {
	ListNode slow = head;
	ListNode fast = head;
	while (fast?.next?.next != null) {
		slow = slow.next;
		fast = fast.next.next;
	}
	return slow;
}
```
## Merge two sorted lists ##
### Problems ###
- [https://leetcode.com/problems/merge-two-sorted-lists/](https://leetcode.com/problems/merge-two-sorted-lists/)
-
### Iterative ###
```
public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
	if (l1 == null && l2 == null) return null;
	if (l1 == null && l2 != null) return l2;
	if (l1 != null && l2 == null) return l1;
	ListNode head = null;
	ListNode prev = null;
	while (l1 != null && l2 != null) {
		ListNode current = l1.val <= l2.val ? l1 : l2;
		head ??= current;
		if (prev == null) prev = current;
		else {
			prev.next = current;
			prev = current;
		}
		if (current == l1) l1 = l1.next;
		else l2 = l2.next;
	}
	prev.next = l1 != null ? l1 : l2;
	return head;
}
```
## Merge k Sorted lists ##
### Problems ###
- [https://leetcode.com/problems/merge-k-sorted-lists/](https://leetcode.com/problems/merge-k-sorted-lists/)
-
### Iterative (Simulated MinHeap) ###
```
public class MinHeap
{
    private readonly IList<ListNode> _list = new List<ListNode>();
    public int Count { get => _list.Count; }
    public void Add(ListNode item) => _list.Add(item); // O(1)
    public ListNode Remove() {
        ListNode tmp = Min(); // O(n * m)
        _list.Remove(tmp); // O(n * m)
        return tmp;
    }
    // O(n * m)
    private ListNode Min() {
        ListNode min = null;
        foreach (ListNode item in _list) {
            if (min == null || item.val < min.val) min = item;
        }
        return min;
    }
}
public class Solution {
    // O(nm + 2(n^2m^2)), O(n * m)
    // O(n^2m^2), O(n * m)
    public ListNode MergeKLists(ListNode[] lists) {
        if ((lists?.Length ?? 0) == 0) return null;
        var heap = new MinHeap();
        foreach (ListNode list in lists) { // O(n)
            ListNode tmp = list;
            while (tmp != null) { // O(m)
                heap.Add(tmp);
                tmp = tmp.next;
            }
        }
        ListNode head = null;
        ListNode prev = null;
        while (heap.Count > 0) { // O(n * m)
            var current = heap.Remove(); // O(2(n * m))
            head ??= current;
            if (prev == null) prev = current;
            else {
                prev.next = current;
                prev = current;
            }
        }
        return head;
    }
}
```
### With a MinHeap custom implementation ###
```
public class MinHeap
{
    public IList<ListNode> _list = new List<ListNode>();
    public int Count { get => _list.Count; }
    // O(log(n)), O(1)
    public void Add(ListNode item) {
        if (item == null) return;
        _list.Add(item);
        BubbleUp(_list.Count - 1);
    }
    // O(log(n)), O(1)
    public ListNode Remove() {
        if (_list.Count == 0) return null;
        ListNode tmp = _list[0];
        Swap(0, _list.Count - 1);
        _list.RemoveAt(_list.Count - 1);
        BubbleDown(0);
        return tmp;
    }
    // O(log(n)), O(1)
    private void BubbleUp(int child) {
        int parent = (child - 1) / 2;
        while (parent >= 0 && child >= 0 && _list[parent].val > _list[child].val) {
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
            int smallInd = -1;
            ListNode lChild = lChildInd >= 0 && lChildInd < _list.Count 
                ? _list[lChildInd] : null;
            ListNode rChild = rChildInd >= 0 && rChildInd < _list.Count
                ? _list[rChildInd] : null;
            if (lChild == null && rChild == null) break;
            if (lChild != null && rChild != null) {
                smallInd = lChild.val <= rChild.val ? lChildInd : rChildInd;
            }
            else { // if (lChild != null) {
                smallInd = lChildInd;
            }
            if (_list[parent].val > _list[smallInd].val) {
                Swap(parent, smallInd);
            }
            parent = smallInd;
        }
    }
    // O(1), O(1)
    private void Swap(int i1, int i2) {
        ListNode tmp = _list[i1];
        _list[i1] = _list[i2];
        _list[i2] = tmp;
    }
}
public class Solution {
    //O(nm * log(n)), O(n * m)
    public ListNode MergeKLists(ListNode[] lists) {
        if ((lists?.Length ?? 0) == 0) return null;
        var heap = new MinHeap();
        foreach (ListNode list in lists) { // O(n)
            ListNode tmp = list;
            while (tmp != null) { // O(m)
                heap.Add(tmp); // O(log(n)), O(1)
                tmp = tmp.next;
            }
        }
        ListNode head = null;
        ListNode prev = null;
        while (heap.Count > 0) { // O(n * m)
            var current = heap.Remove(); // O(log(n)), O(1)
            head ??= current;
            if (prev == null) prev = current;
            else {
                prev.next = current;
                prev = current;
            }
        }
        if (prev != null) prev.next = null;
        return head;
    }
}
```
### Iterative with SortedDictionary (real heap) ###
```
public class MinHeap<TPriority>
    where TPriority : IComparable<TPriority> {
    private readonly SortedDictionary<TPriority, Queue<TPriority>> _queue;
    public int Count { get => _queue.Count; }
    public MinHeap() {
        _queue = new SortedDictionary<TPriority, Queue<TPriority>>();
    }
    public TPriority Peek() {
        if (_queue.Count == 0) throw new Exception("Queue is empty");
        return _queue.First().Key;
    }
    public void Enqueue(TPriority priority) {
        if (!_queue.ContainsKey(priority)) _queue.Add(priority, new Queue<TPriority>());
        _queue[priority].Enqueue(priority);
    }
    public TPriority Dequeue() {
        if (_queue.Count == 0) throw new Exception("Queue is empty");
        TPriority tmp = _queue.First().Value.Dequeue();
        if (_queue.First().Value.Count == 0) _queue.Remove(tmp);
        return tmp;
    }
}
public class Solution {
    public ListNode MergeKLists(ListNode[] lists) {
        var heap = new MinHeap<int>();
        foreach (ListNode node in lists) {
            ListNode tmp = node;
            while (tmp != null) {
                heap.Enqueue(tmp.val);
                tmp = tmp.next;
            }
        }
        ListNode root = null;
        ListNode prev = null;
        while (heap.Count > 0) {
            var node = new ListNode(heap.Dequeue());
            root ??= node;
            if (prev == null) prev = node;
            else {
                prev.next = node;
                prev = node;
            }
        }
        return root;
    }
}
```
## Reverse Linked List ##
### Problems ###
- [https://leetcode.com/problems/reverse-linked-list/](https://leetcode.com/problems/reverse-linked-list/)
-
### Iterative ###
```
// O(n), O(1)
public ListNode ReverseList(ListNode head) {
	if (head == null) return null;
	ListNode prev = null;
	while (head != null) {
		ListNode tmp = head.next;
		head.next = prev;
		prev = head;
		head = tmp;
	}
	return prev;
}
```
## Reverse Linked List from m to n ##
### Problems ###
- [https://leetcode.com/problems/reverse-linked-list-ii/](https://leetcode.com/problems/reverse-linked-list-ii/)
-
### Iterative ###
```
// O(n), O(1)
public ListNode ReverseBetween(ListNode head, int m, int n) {
	if (head == null) return null;
	var dummy = new ListNode(-1) { next = head };
	ListNode current = dummy;
	for (int i = 1; i < m; i++) current = current.next;
	ListNode prev = current;
	current = current.next;
	for (int i = m; i < n; i++) {
		// 1 2 3 4 5             1 3 2 4 5
		// P C T                 P T C 4 5
		ListNode tmp = current.next;
		current.next = tmp.next;
		tmp.next = prev.next;
		prev.next = tmp;
	}
	return dummy.next;
}
```
## Find middle of a link list ##
### Problems ###
- [https://leetcode.com/problems/middle-of-the-linked-list/](https://leetcode.com/problems/middle-of-the-linked-list/)
-
### Iterative ###
```
// O(n), O(1)
public ListNode MiddleNode(ListNode head) {
	if (head == null) return null;
	ListNode slow = head;
	ListNode fast = head;
	while (fast?.next != null) {
		slow = slow.next;
		fast = fast.next.next;
	}
	return slow;
}
```
## Detect cycle ##
### Problems ###
- [https://leetcode.com/problems/linked-list-cycle/](https://leetcode.com/problems/linked-list-cycle/)
- [https://leetcode.com/problems/linked-list-cycle-ii/](https://leetcode.com/problems/linked-list-cycle-ii/)
- 
### Iterative ###
```
// O(n), O(1)
public bool HasCycle(ListNode head) {
	if (head == null) return false;
	ListNode slow = head;
	ListNode fast = head;
	while (slow != null && fast?.next != null) {
		slow = slow.next;
		fast = fast.next.next;
		if (slow == fast) return true;
	}
	return false;
}
```
### Iterative, returning the cycle node ###
```
// O(n), O(1)
public ListNode DetectCycle(ListNode head) {
	if (head == null) return null;
	ListNode slow = head;
	ListNode fast = head;
	bool found = false;
	while (fast?.next != null && slow != null) {
		slow = slow.next;
		fast = fast.next.next;
		if (slow == fast) {
			found = true;
			break;
		}
	}
	if (!found) return null;
	slow = head;
	while (slow != null && fast != null) {
		if (slow == fast) return slow;
		slow = slow.next;
		fast = fast.next;
	}
	return null;
}
```
## Reorder list ##
### Problems ###
- [https://leetcode.com/problems/reorder-list/](https://leetcode.com/problems/reorder-list/)
-
### Iterative ###
```
// O(n), O(1)
public void ReorderList(ListNode head) {
	if (head == null) return;
	ListNode middle = FindMiddle(head);
	ListNode head2 = middle.next;
	middle.next = null;
	head2 = Reverse(head2);
	Merge(head, head2);
}
// O(n), O(1)
private ListNode Reverse(ListNode head) {
	ListNode prev = null;
	while (head != null) {
		ListNode next = head.next;
		head.next = prev;
		prev = head;
		head = next;
	}
	return prev;
}
// O(n), O(1)
private ListNode FindMiddle(ListNode head) {
	ListNode slow = head;
	ListNode fast = head;
	while (fast?.next != null) {
		slow = slow.next;
		fast = fast.next.next;
	}
	return slow;
}
// O(n), O(1)
private void Merge(ListNode a, ListNode b) {
	bool fromListA = false;
	ListNode prev = a;
	a = a.next;
	while (a != null && b != null) {
		if (fromListA) {
			prev.next = a;
			prev = a;
			a = a.next;
		}
		else {
			prev.next = b;
			prev = b;
			b = b.next;
		}
		fromListA = !fromListA;
	}
	if (prev != null) prev.next = a != null ? a : b;
}
```
## Deep copy with random pointers ##
### Problems ###
- [https://leetcode.com/problems/copy-list-with-random-pointer/](https://leetcode.com/problems/copy-list-with-random-pointer/)
-
### Iterative ###
```
// O(n), O(n)
public Node CopyRandomList(Node head) {
	if (head == null) return null;
	var map = new Dictionary<Node, Node>();
	Node head2 = null;
	Node prev = null;
	Node current = head;
	while (current != null) {
		var node = new Node(current.val) { random = current.random };
		map.Add(current, node);
		head2 ??= node;
		if (prev == null) {
			prev = node;
		}
		else {
			prev.next = node;
			prev = node;
		}
		current = current.next;
	}
	current = head2;
	while (current != null) {
		if (current.random != null) {
			current.random = map[current.random];
		}
		current = current.next;
	}
	return head2;
}
```
## Design Browser History ##
### Problems ###
- [https://leetcode.com/problems/design-browser-history/](https://leetcode.com/problems/design-browser-history/)
-
### Iterative ###
```
public class BrowserHistory {
    private readonly LinkedList<string> _list;
    private LinkedListNode<string> _current;
    // O(1), O(1)
    public BrowserHistory(string homepage) {
        _list = new LinkedList<string>();
        _list.AddFirst(homepage);
        _current = _list.First;
    }
    // O(n), O(1)
    public void Visit(string url) {
        var node = new LinkedListNode<string>(url);
        _list.AddAfter(_current, node);
        _current = node;
        LinkedListNode<string> tmp = node.Next;
        while (tmp != null) {
            var next = tmp.Next;
            _list.Remove(tmp);
            tmp = next;
        }
    }
    // O(n), O(1)
    public string Back(int steps) {
        for (int i = 1; i <= steps && _current.Previous != null; i++)
            _current = _current.Previous;
        return _current.Value;
    }
    // O(n), O(1)
    public string Forward(int steps) {
        for (int i = 1; i <= steps && _current.Next != null; i++)
            _current = _current.Next;
        return _current.Value;
    }
}
```


