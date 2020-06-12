
<ul>
<li><a href="#bst">BST</a>
<ul>
<li><a href="#search">Search</a>
<ul>
<li><a href="#problems">Problems</a></li>
<li><a href="#recursive">Recursive</a></li>
<li><a href="#iterative">Iterative</a></li>
</ul>
</li>
<li><a href="#search-closest">Search Closest</a>
<ul>
<li><a href="#problems-1">Problems</a></li>
<li><a href="#recursive-1">Recursive</a></li>
</ul>
</li>
<li><a href="#search-k-closest">Search K Closest</a>
<ul>
<li><a href="#problems-2">Problems</a></li>
<li><a href="#recursive-2">Recursive</a></li>
</ul>
</li>
<li><a href="#validate-bst">Validate BST</a>
<ul>
<li><a href="#problems-3">Problems</a></li>
<li><a href="#recursive-3">Recursive</a></li>
</ul>
</li>
<li><a href="#lowest-common-ancestor-lca">Lowest Common Ancestor (LCA)</a>
<ul>
<li><a href="#problems-4">Problems</a></li>
<li><a href="#recursive-4">Recursive</a></li>
<li><a href="#iterative-1">Iterative</a></li>
</ul>
</li>
<li><a href="#insert-into-bst">Insert into BST</a>
<ul>
<li><a href="#problems-5">Problems</a></li>
<li><a href="#recursive-5">Recursive</a></li>
</ul>
</li>
<li><a href="#insert-into-avl-bst">Insert into AVL BST</a>
<ul>
<li><a href="#problems-6">Problems</a></li>
<li><a href="#recursive-6">Recursive</a></li>
</ul>
</li>
<li><a href="#delete-node-in-bst">Delete node in BST</a>
<ul>
<li><a href="#problems-7">Problems</a></li>
<li><a href="#recursive-7">Recursive</a></li>
</ul>
</li>
<li><a href="#delete-node-in-avl-bst">Delete node in AVL BST</a>
<ul>
<li><a href="#problems-8">Problems</a></li>
<li><a href="#recursive-8">Recursive</a></li>
</ul>
</li>
<li><a href="#balance-bst">Balance BST</a>
<ul>
<li><a href="#problems-9">Problems</a></li>
<li><a href="#recursive-9">Recursive</a></li>
</ul>
</li>
<li><a href="#in-order-successor">In Order Successor</a>
<ul>
<li><a href="#problems-10">Problems</a></li>
<li><a href="#iterative-2">Iterative</a></li>
<li><a href="#iterative-wo-using-val-and-with-parent-pointer">Iterative (w/o using val and with parent pointer)</a></li>
</ul>
</li>
<li><a href="#convert-bst-to-doubly-linked-list">Convert BST to Doubly Linked List</a>
<ul>
<li><a href="#problems-11">Problems</a></li>
<li><a href="#recursive-10">Recursive</a></li>
</ul>
</li>
</ul>
</li>
</ul>

# BST #
## Search ##
### Problems ###
- [https://leetcode.com/problems/search-in-a-binary-search-tree/](https://leetcode.com/problems/search-in-a-binary-search-tree/)
-
### Recursive ###
```
// O(log(n)), O(n) worst case, skewed tree
// O(log(n)), O(h) average (balance tree)
private TreeNode Rec(TreeNode root, int val) {
	if (root == null) return null;
	if (root.val == val) return root;
	if (val < root.val) return Rec(root.left, val);
	else return Rec(root.right, val);
}
```
### Iterative ###
```
// O(log(n)), O(1)
// O(log(n)), O(1)
public TreeNode SearchBST(TreeNode root, int val) {
	if (root == null) return null;
	TreeNode current = root;
	while (current != null) {
		if (current.val == val) return current;
		if (val < current.val) current = current.left;
		else current = current.right;
	}
	return null;
}
```
## Search Closest ##
### Problems ###
- [https://leetcode.com/problems/closest-binary-search-tree-value/](https://leetcode.com/problems/closest-binary-search-tree-value/)
-
### Recursive ###
```
private TreeNode _closest = null;
public int ClosestValue(TreeNode root, double target) {
	if (root == null) return -1;
	Rec(root, target);
	return _closest == null ? -1 : _closest.val;
}
// O(log(n)), O(n)
private TreeNode Rec(TreeNode root, double target) {
	if (root == null) return null;
	if (_closest == null) _closest = root;
	else if (Math.Abs(target - root.val) < Math.Abs(target - _closest.val)) _closest = root;
	if (root.val == target) return root;
	if (target < root.val) return Rec(root.left, target);
	return Rec(root.right, target);
}
```
## Search K Closest ##
### Problems ###
- [https://leetcode.com/problems/closest-binary-search-tree-value-ii/](https://leetcode.com/problems/closest-binary-search-tree-value-ii/)
-
### Recursive ###
```
// O(n) + O(n * log(n)) + O(n) , O(n)
// O(n + n + n * log(n)) , O(n)
// O(2n + n * log(n)) , O(n)
// O(n + n * log(n)) , O(n)
// O(n * log(n)) , O(n)
public IList<int> ClosestKValues(TreeNode root, double target, int k) {
	var list = new List<(double dif, int n)>();
	Rec(root, target, list);
	return list.OrderBy(x => x.dif).Select(x => x.n).Take(k).ToList(); // O(n * log(n)) + O(n)
}
// O(n), O(n)
private void Rec(TreeNode root, double target, IList<(double dif, int n)> list) {
	if (root == null) return;
	list.Add((Math.Abs(target - root.val), root.val));
	Rec(root.left, target, list);
	Rec(root.right, target, list);
}
```
## Validate BST ##
### Problems ###
- [https://leetcode.com/problems/validate-binary-search-tree/](https://leetcode.com/problems/validate-binary-search-tree/)
-
### Recursive ###
```
public bool IsValidBST(TreeNode root) {
	if (root == null) return true;
	return Rec(root, null, null);
}
// O(n), O(n)
private bool Rec(TreeNode root, int? min, int? max) {
	if (root == null) return true;
	bool isValid = false;
	if (min == null && max == null) isValid = true;
	else if (min != null && max != null) isValid = root.val > min.Value && root.val < max.Value;
	else if (min != null) isValid = root.val > min.Value;
	else isValid = root.val < max.Value;
	return isValid && Rec(root.left, min, root.val) && Rec(root.right, root.val, max);
}
```
## Lowest Common Ancestor (LCA) ##
### Problems ###
- [https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/](https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/)
-
### Recursive ###
```
// O(log(n)), O(n)
private TreeNode Rec(TreeNode root, TreeNode p, TreeNode q) {
	if (root == null) return null;
	if (Math.Min(p.val, q.val) > root.val) return Rec(root.right, p, q);
	if (Math.Max(p.val, q.val) < root.val) return Rec(root.left, p, q);
	return root;
}
```
### Iterative ###
```
// O(log(n)), O(1)
public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
	if (root == null || p == null || q == null) return null;
	if (p == q) return p;
	TreeNode current = root;
	TreeNode min = p.val <= q.val ? p : q;
	TreeNode max = q.val >= p.val ? q : p;
	while (current != null) {
		if (current.val == p.val && current.val == q.val) return current;
		if (min.val < current.val && max.val > current.val) return current;
		if (min.val == current.val || max.val == current.val) return current;
		if (min.val > current.val) current = current.right;
		else current = current.left;
	}
	return null;
}
```
## Insert into BST ##
### Problems ###
- [https://leetcode.com/problems/insert-into-a-binary-search-tree/](https://leetcode.com/problems/insert-into-a-binary-search-tree/)
-
### Recursive ###
```
private TreeNode Rec(TreeNode root, int val) {
	if (root == null) return new TreeNode(val);
	if (val < root.val) root.left = Rec(root.left, val);
	else root.right = Rec(root.right, val);
	return root;
}
```
## Insert into AVL BST ##
### Problems ###
- [https://leetcode.com/problems/insert-into-a-binary-search-tree/](https://leetcode.com/problems/insert-into-a-binary-search-tree/)
-
### Recursive ###
```
public class NodeMeta
{
    public int Height { get; set; }
    public int BalanceFactor { get; set; }
    public TreeNode Node { get; set; }
    public NodeMeta(TreeNode node, int height = 0, int balanceFactor = 0) {
        Node = node;
        Height = height;
        BalanceFactor = balanceFactor;
    }
}
public class Solution {
    // O(n), O(n)
    public TreeNode InsertIntoBST(TreeNode root, int val) {
        var map = new Dictionary<TreeNode, NodeMeta>();
        SetMetadata(root, map); // O(n), O(n)
        return Rec(root, val, map); // O(log(n)), O(n)
    }
    // O(n), O(h)
    // O(n), O(n) (skewed tree)
    private int SetMetadata(TreeNode root, IDictionary<TreeNode, NodeMeta> map) {
        if (root == null) return -1;
        int leftHeight = SetMetadata(root.left, map);
        int rightHeight = SetMetadata(root.right, map);
        int height = Math.Max(leftHeight, rightHeight) + 1;
        int balanceFactor = leftHeight - rightHeight;
        map.Add(root, new NodeMeta(root, height, balanceFactor));
        return height;
    }
    // O(log(n)), O(h)
    // O(log(n)), O(n) (skewed tree)
    private TreeNode Rec(TreeNode root, int val, IDictionary<TreeNode, NodeMeta> map) {
        if (root == null) {
            root = new TreeNode(val);
            map.Add(root, new NodeMeta(root));
        }
        else if (val <= root.val) root.left = Rec(root.left, val, map);
        else root.right = Rec(root.right, val, map);
        UpdateHeight(root, map);
        return Balance(root, map);
    }
    // O(1), O(1)
    private TreeNode Balance(TreeNode root, IDictionary<TreeNode, NodeMeta> map) {
        if (root == null) return null;
        if (map[root].BalanceFactor >= 2) { // left
            if (map[map[root].Node.left].BalanceFactor >= 0) {
                return LeftLeft(root, map); // O(1), O(1)
            }
            else {
                return LeftRight(root, map); // O(1), O(1)
            }
        }
        else if (map[root].BalanceFactor <= -2) { // right
            if (map[map[root].Node.right].BalanceFactor <= 0) {
                return RightRight(root, map); // O(1), O(1)
            }
            else {
                return RightLeft(root, map); // O(1), O(1)
            }
        }
        return root;
    }
    // O(1), O(1)
    private TreeNode RightRight(TreeNode root, IDictionary<TreeNode, NodeMeta> map) => LeftRotation(root, map);
    // O(1), O(1)
    private TreeNode LeftLeft(TreeNode root, IDictionary<TreeNode, NodeMeta> map) => RightRotation(root, map);
    private TreeNode RightLeft(TreeNode root, IDictionary<TreeNode, NodeMeta> map) {
        root.right = RightRotation(root.right, map); // O(1), O(1)
        return RightRight(root, map); // O(1), O(1)
    }
    // O(1), O(1)
    private TreeNode LeftRight(TreeNode root, IDictionary<TreeNode, NodeMeta> map) {
        root.left = LeftRotation(root.left, map); // O(1), O(1)
        return LeftLeft(root, map); // O(1), O(1)
    }
    // O(1), O(1)
    private TreeNode LeftRotation(TreeNode root, IDictionary<TreeNode, NodeMeta> map) {
        TreeNode nr = root.right;
        root.right = nr.left;
        nr.left = root;
        UpdateHeight(root, map); // O(1), O(1)
        return nr;
    }
    // O(1), O(1)
    private TreeNode RightRotation(TreeNode root, IDictionary<TreeNode, NodeMeta> map) {
        TreeNode nr = root.left;
        root.left = nr.right;
        nr.right = root;
        UpdateHeight(root, map); // O(1), O(1)
        return nr;
    }
    // O(1), O(1)
    private void UpdateHeight(TreeNode root, IDictionary<TreeNode, NodeMeta> map) {
        if (root == null) return;
        int left = map[root].Node.left == null ? 0 : map[map[root].Node.left].Height;
        int right = map[root].Node.right == null ? 0 : map[map[root].Node.right].Height;
        map[root].Height = Math.Max(left, right) + 1;
        map[root].BalanceFactor = left - right;
    }
}
```
## Delete node in BST ##
### Problems ###
- [https://leetcode.com/problems/delete-node-in-a-bst/](https://leetcode.com/problems/delete-node-in-a-bst/)
-
### Recursive ###
```
private TreeNode Delete(TreeNode root, int val) {
	if (root == null) return null;
	if (val < root.val) root.left = Delete(root.left, val);
	else if (val > root.val) root.right = Delete(root.right, val);
	else {
		if (root.left == null && root.right == null) root = null;
		else if (root.left != null && root.right == null) root = root.left;
		else if (root.right != null && root.left == null) root = root.right;
		else {
			TreeNode min = Min(root.right); // O(h), O(1)
			root.val = min.val;
			root.right = Delete(root.right, min.val);
		}
	}
	return root;
}
private TreeNode Min(TreeNode root) {
	while (root.left != null) root = root.left;
	return root;
}
```
## Delete node in AVL BST ##
### Problems ###
- [https://leetcode.com/problems/delete-node-in-a-bst/](https://leetcode.com/problems/delete-node-in-a-bst/)
-
### Recursive ###
```
public class NodeMeta
{
    public int Height { get; set; }
    public int BalanceFactor { get; set; }
    public TreeNode Node { get; set; }
    public NodeMeta(TreeNode node, int height = 0, int balanceFactor = 0) {
        Node = node;
        Height = height;
        BalanceFactor = balanceFactor;
    }
}
public class Solution {
    public TreeNode DeleteNode(TreeNode root, int key) {
        var map = new Dictionary<TreeNode, NodeMeta>();
        SetMetadata(root, map);
        return Delete(root, key, map);
    }
    private TreeNode Delete(TreeNode root, int val, IDictionary<TreeNode, NodeMeta> map) {
        if (root == null) return null;
        if (val < root.val) root.left = Delete(root.left, val, map);
        else if (val > root.val) root.right = Delete(root.right, val, map);
        else {
            if (root.left == null && root.right == null) root = null;
            else if (root.left != null && root.right == null) root = root.left;
            else if (root.right != null && root.left == null) root = root.right;
            else {
                TreeNode min = Min(root.right); // O(h), O(1)
                root.val = min.val;
                root.right = Delete(root.right, min.val, map);
            }
        }
        UpdateHeight(root, map);
        return Balance(root, map);
    }
    // O(1), O(1)
    private TreeNode Balance(TreeNode root, IDictionary<TreeNode, NodeMeta> map) {
        if (root == null) return null;
        if (map[root].BalanceFactor >= 2) { // left
            if (map[map[root].Node.left].BalanceFactor >= 0) return LeftLeft(root, map);
            else return LeftRight(root, map);
        }
        else if (map[root].BalanceFactor <= -2) { // right
            if (map[map[root].Node.right].BalanceFactor <= 0) return RightRight(root, map);
            else return RightLeft(root, map);
        }
        return root;
    }
    // O(1), O(1)
    private TreeNode LeftLeft(TreeNode root, IDictionary<TreeNode, NodeMeta> map) => RightRotation(root, map);
    // O(1), O(1)
    private TreeNode RightRight(TreeNode root, IDictionary<TreeNode, NodeMeta> map) => LeftRotation(root, map);
    private TreeNode LeftRight(TreeNode root, IDictionary<TreeNode, NodeMeta> map) {
        root.left = LeftRotation(root.left, map);
        return LeftLeft(root, map);
    }
    private TreeNode RightLeft(TreeNode root, IDictionary<TreeNode, NodeMeta> map) {
        root.right = RightRotation(root.right, map);
        return RightRight(root, map);
    }
    private TreeNode LeftRotation(TreeNode root, IDictionary<TreeNode, NodeMeta> map) {
        TreeNode nr = root.right;
        root.right = nr.left;
        nr.left = root;
        UpdateHeight(root, map);
        UpdateHeight(nr, map);
        return nr;
    }
    private TreeNode RightRotation(TreeNode root, IDictionary<TreeNode, NodeMeta> map) {
        TreeNode nr = root.left;
        root.left = nr.right;
        nr.right = root;
        UpdateHeight(root, map);
        UpdateHeight(nr, map);
        return nr;
    }
    // O(n), O(n) (skewed)
    // O(h), O(1) (balanced)
    private TreeNode Min(TreeNode root) {
        while (root.left != null) root = root.left;
        return root;
    }
    // O(n), O(h)
    // O(n), O(n) (skewed tree)
    private int SetMetadata(TreeNode root, IDictionary<TreeNode, NodeMeta> map) {
        if (root == null) return -1;
        int leftHeight = SetMetadata(root.left, map);
        int rightHeight = SetMetadata(root.right, map);
        int height = Math.Max(leftHeight, rightHeight) + 1;
        int balanceFactor = leftHeight - rightHeight;
        map.Add(root, new NodeMeta(root, height, balanceFactor));
        return height;
    }
    // O(1), O(1)
    private void UpdateHeight(TreeNode root, IDictionary<TreeNode, NodeMeta> map) {
        if (root == null) return;
        int left = map[root].Node.left == null ? 0 : map[map[root].Node.left].Height;
        int right = map[root].Node.right == null ? 0 : map[map[root].Node.right].Height;
        map[root].Height = Math.Max(left, right) + 1;
        map[root].BalanceFactor = left - right;
    }
}
```
## Balance BST ##
### Problems ###
- [https://leetcode.com/problems/balance-a-binary-search-tree/](https://leetcode.com/problems/balance-a-binary-search-tree/)
-
### Recursive ###
```
public TreeNode BalanceBST(TreeNode root) {
	if (root == null) return null;
	var list = new List<int>();
	TreeNode[] res = new TreeNode[1];
	InOrder(root, list);
	BuildBst(list, 0, list.Count - 1, res);
	return res[0];
}
private TreeNode BuildBst(IList<int> list, int min, int max, TreeNode[] res) {
	if (min < 0 || max >= list.Count || min > max) return null;
	int mid = min + (max - min) / 2;
	var node = new TreeNode(list[mid]);
	res[0] ??= node;
	node.left = BuildBst(list, min, mid - 1, res);
	node.right = BuildBst(list, mid + 1, max, res);
	return node;
}
private void InOrder(TreeNode root, IList<int> list) {
	if (root == null) return;
	InOrder(root.left, list);
	list.Add(root.val);
	InOrder(root.right, list);
}
```
## In Order Successor ##
### Problems ###
- [https://leetcode.com/problems/inorder-successor-in-bst/](https://leetcode.com/problems/inorder-successor-in-bst/)
- [https://leetcode.com/problems/inorder-successor-in-bst-ii/](https://leetcode.com/problems/inorder-successor-in-bst-ii/)
- 
### Iterative ###
```
// O(log(n) + h), O(1) (balanced)
// O(log(n) + log(n)), O(1) (balanced)
// O(2 * log(n)), O(1) (balanced)
// O(log(n)), O(1) (balanced)
// O(n), O(1) (skwed)
public TreeNode InorderSuccessor(TreeNode root, TreeNode p) {
	if (root == null || p == null) return null;
	TreeNode prev = null;
	while (root != null) {
		if (p.val < root.val) {
			prev = root;
			root = root.left;
		}
		else if (p.val > root.val) {
			root = root.right;
		}
		else {
			if (root.right != null) return Min(root.right);
			return prev;
		}
	}
	return null;
}
// O(h), O(1) (balance)
// O(n), O(1) (skewed)
private TreeNode Min(TreeNode root) {
	while (root.left != null) root = root.left;
	return root;
}
```
### Iterative (w/o using val and with parent pointer) ###
```
// O(h), O(1)
public Node InorderSuccessor(Node x) {
	if (x == null) return null;
	if (x.right != null) return Min(x.right);
	while (x.parent != null && x.parent.left != x) {
		x = x.parent;
	}
	return x.parent;
}
// O(h), O(1)
private Node Min(Node node) {
	while (node.left != null) node = node.left;
	return node;
}
```
## Convert BST to Doubly Linked List ##
### Problems ###
- [https://leetcode.com/problems/convert-binary-search-tree-to-sorted-doubly-linked-list/](https://leetcode.com/problems/convert-binary-search-tree-to-sorted-doubly-linked-list/)
-
### Recursive ###
```
// O(n), O(1)
public Node TreeToDoublyList(Node root) {
	if (root == null) return null;
	Node[] res = new Node[2];
	ToList(root, res);
	res[0].left = res[1];
	res[1].right = res[0];
	return res[0];
}
// O(n), O(1)
private void ToList(Node root, Node[] res) {
	if (root == null) return;
	ToList(root.left, res);
	res[0] ??= root;
	if (res[1] != null) {
		res[1].right = root;
		root.left = res[1];
	}
	res[1] = root;
	ToList(root.right, res);
}
```


