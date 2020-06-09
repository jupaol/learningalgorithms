# Linked Lists #
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
### With a MinHeap implementation ###
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
