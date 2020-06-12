
<ul>
<li><a href="#binary-tree">Binary Tree</a>
<ul>
<li><a href="#in-order-traversal">In Order Traversal</a>
<ul>
<li><a href="#problems">Problems</a></li>
<li><a href="#recursive">Recursive:</a></li>
<li><a href="#iterative">Iterative:</a></li>
</ul>
</li>
<li><a href="#pre-order-traversal">Pre Order Traversal</a>
<ul>
<li><a href="#problems-1">Problems</a></li>
<li><a href="#recursive-1">Recursive:</a></li>
<li><a href="#iterative-1">Iterative:</a></li>
</ul>
</li>
<li><a href="#post-order-traversal">Post Order Traversal:</a>
<ul>
<li><a href="#problems-2">Problems</a></li>
<li><a href="#recursive-2">Recursive:</a></li>
<li><a href="#iterative-2">Iterative:</a></li>
</ul>
</li>
<li><a href="#level-order-traversal">Level Order Traversal</a>
<ul>
<li><a href="#problems-3">Problems</a></li>
<li><a href="#iterative-3">Iterative</a></li>
</ul>
</li>
<li><a href="#level-order-traversal-bottom-up">Level Order Traversal (Bottom-Up)</a>
<ul>
<li><a href="#problems-4">Problems</a></li>
<li><a href="#iterative-4">Iterative</a></li>
</ul>
</li>
<li><a href="#vertical-traversal">Vertical Traversal</a>
<ul>
<li><a href="#problems-5">Problems</a></li>
<li><a href="#iterative-5">Iterative</a></li>
</ul>
</li>
<li><a href="#n-ary-level-order-traversal">N-ary Level Order Traversal</a>
<ul>
<li><a href="#problems-6">Problems</a></li>
<li><a href="#iterative-6">Iterative</a></li>
</ul>
</li>
<li><a href="#n-ary-pre-order-traversal">N-ary Pre Order Traversal</a>
<ul>
<li><a href="#problems-7">Problems</a></li>
<li><a href="#recursive-3">Recursive</a></li>
<li><a href="#iterative-7">Iterative</a></li>
</ul>
</li>
<li><a href="#n-ary-post-order-traversal">N-ary Post Order Traversal</a>
<ul>
<li><a href="#problems-8">Problems</a></li>
<li><a href="#recursive-4">Recursive</a></li>
<li><a href="#iterative-8">Iterative</a></li>
</ul>
</li>
<li><a href="#right-tree-view">Right Tree View</a>
<ul>
<li><a href="#problems-9">Problems</a></li>
<li><a href="#iterative-9">Iterative</a></li>
</ul>
</li>
<li><a href="#height-of-the-tree-or-max-depth-of-the-tree">Height of the tree or Max Depth of the tree</a>
<ul>
<li><a href="#problems-10">Problems</a></li>
<li><a href="#recursive-5">Recursive</a></li>
</ul>
</li>
<li><a href="#is-tree-balance-tree-balance-factor">Is Tree Balance (Tree balance factor)</a>
<ul>
<li><a href="#problems-11">Problems</a></li>
<li><a href="#recursive-6">Recursive</a></li>
</ul>
</li>
<li><a href="#populate-right-pointer-in-tree">Populate right pointer in tree</a>
<ul>
<li><a href="#problems-12">Problems</a></li>
<li><a href="#iterative-10">Iterative</a></li>
</ul>
</li>
<li><a href="#lowest-common-ancestor-lca">Lowest Common Ancestor (LCA)</a>
<ul>
<li><a href="#problems-13">Problems</a></li>
<li><a href="#recursive-7">Recursive</a></li>
<li><a href="#iterative-11">Iterative</a></li>
</ul>
</li>
<li><a href="#boundary-traversal">Boundary Traversal</a>
<ul>
<li><a href="#problems-14">Problems</a></li>
<li><a href="#iterative-12">Iterative</a></li>
</ul>
</li>
<li><a href="#binary-tree-diameter">Binary Tree Diameter</a>
<ul>
<li><a href="#problems-15">Problems</a></li>
<li><a href="#recursive-8">Recursive</a></li>
</ul>
</li>
<li><a href="#check-if-string-is-valid-sequence-ex-of-searching-in-a-binary-tree-path">Check if string is Valid Sequence (ex of searching in a binary tree path</a>
<ul>
<li><a href="#problems-16">Problems</a></li>
<li><a href="#recursive-backtracking">Recursive (backtracking)</a></li>
</ul>
</li>
<li><a href="#is-binary-tree-complete">Is Binary Tree complete</a>
<ul>
<li><a href="#problems-17">Problems</a></li>
<li><a href="#iterative-13">Iterative</a></li>
</ul>
</li>
</ul>
</li>
</ul>

# Binary Tree #
## In Order Traversal ##
### Problems ###
- [https://leetcode.com/problems/binary-tree-inorder-traversal/](https://leetcode.com/problems/binary-tree-inorder-traversal/)
- 
### Recursive: ###
```
// O(n), O(2n)
// O(n), O(n)
Rec(root.left, list);
list.Add(root.val);
Rec(root.right, list);
```
### Iterative: ###
```
// O(n), O(2n)
// O(n), O(n)
TreeNode current = root;
while (stack.Count > 0 || current != null) {
	if (current != null) {
		stack.Push(current);
		current = current.left;
	}
	else {
		current = stack.Pop();
		list.Add(current.val);
		current = current.right;
	}
}
```
## Pre Order Traversal ##
### Problems ###
- [https://leetcode.com/problems/binary-tree-preorder-traversal/](https://leetcode.com/problems/binary-tree-preorder-traversal/)
- 
### Recursive: ###
```
// O(n), O(2n)
// O(n), O(n)
list.Add(root.val);
Rec(root.left, list);
Rec(root.right, list);
```
### Iterative: ###
```
// O(n), O(2n)
// O(n), O(n)
TreeNode current = root;
while (stack.Count > 0 || current != null) {
	if (current != null) {
		stack.Push(current);
		list.Add(current.val);
		current = current.left;
	}
	else {
		current = stack.Pop().right;
	}
}
```
## Post Order Traversal: ##
### Problems ###
- [https://leetcode.com/problems/binary-tree-postorder-traversal/](https://leetcode.com/problems/binary-tree-postorder-traversal/)
- 
### Recursive: ###
```
// O(n), O(2n)
// O(n), O(n)
Rec(root.left, list);
Rec(root.right, list);
list.Add(root.val);
```
### Iterative: ###
```
// O(n), O(2n)
// O(n), O(n)
TreeNode current = root;
while (stack.Count > 0 || current != null) {
	if (current != null) {
		stack.Push(current);
		current = current.left;
	}
	else {
		TreeNode right = stack.Peek().right;
		if (right != null) {
			current = right;
		}
		else {
			right = stack.Pop();
			list.Add(right.val);
			while (stack.Count > 0 && right == stack.Peek().right) {
				right = stack.Pop();
				list.Add(right.val);
			}
		}
	}
}
```
## Level Order Traversal ##
### Problems ###
- [https://leetcode.com/problems/binary-tree-level-order-traversal/](https://leetcode.com/problems/binary-tree-level-order-traversal/)
- 
### Iterative ###
```
// O(n), O(2n)
// O(n), O(n)
queue.Enqueue(root);
while (queue.Count > 0) {
	int size = queue.Count;
	var levelList = new List<int>();
	while (size > 0) {
		TreeNode current = queue.Dequeue();
		levelList.Add(current.val);
		if (current.left != null) queue.Enqueue(current.left);
		if (current.right != null) queue.Enqueue(current.right);
		size--;
	}
	list.Add(levelList);
}
```
## Level Order Traversal (Bottom-Up) ##
### Problems ###
- [https://leetcode.com/problems/binary-tree-level-order-traversal-ii/](https://leetcode.com/problems/binary-tree-level-order-traversal-ii/)
- 
### Iterative ###
```
// O(n), O(2n)
// O(n), O(n)
queue.Enqueue(root);
while (queue.Count > 0) {
	int size = queue.Count;
	var levelList = new List<int>();
	while (size > 0) {
		TreeNode current = queue.Dequeue();
		levelList.Add(current.val);
		if (current.left != null) queue.Enqueue(current.left);
		if (current.right != null) queue.Enqueue(current.right);
		size--;
	}
	list.Add(levelList);
}
list.Reverse();
```
## Vertical Traversal ##
### Problems ###
- [https://leetcode.com/problems/binary-tree-vertical-order-traversal/](https://leetcode.com/problems/binary-tree-vertical-order-traversal/)
- 
### Iterative ###
```
// O(n), O(3n)
// O(n), O(n)
var list = new List<IList<int>>();
var map = new Dictionary<int, IList<int>>();
var queue = new Queue<(TreeNode node, int margin)>();
if (root == null) return list;
queue.Enqueue((root, 0));
while (queue.Count > 0) {
	int size = queue.Count;
	while (size > 0) {
		(TreeNode node, int margin) current = queue.Dequeue();
		if (map.ContainsKey(current.margin)) {
			map[current.margin].Add(current.node.val);
		}
		else {
			map.Add(current.margin, new List<int> { current.node.val });
		}
		if (current.node.left != null) {
			queue.Enqueue((current.node.left, current.margin - 1));
		}
		if (current.node.right != null) {
			queue.Enqueue((current.node.right, current.margin + 1));
		}
		size--;
	}
}
list.AddRange(map.OrderBy(x => x.Key).Select(x => x.Value));
```
## N-ary Level Order Traversal ##
### Problems ###
- [https://leetcode.com/problems/n-ary-tree-level-order-traversal/](https://leetcode.com/problems/n-ary-tree-level-order-traversal/)
- 
### Iterative ###
```
// O(n), O(2n)
// O(n), O(n)
queue.Enqueue(root);
while (queue.Count > 0) {
	int size = queue.Count;
	var levelList = new List<int>();
	while (size > 0) {
		Node current = queue.Dequeue();
		levelList.Add(current.val);
		foreach (Node child in current.children) {
			queue.Enqueue(child);
		}
		size--;
	}
	list.Add(levelList);
}
```
## N-ary Pre Order Traversal ##
### Problems ###
- [https://leetcode.com/problems/n-ary-tree-preorder-traversal/](https://leetcode.com/problems/n-ary-tree-preorder-traversal/)
- 
### Recursive ###
```
// O(n), O(2n)
// O(n), O(n)
private void Rec(Node root, IList<int> list) {
	if (root == null) return;
	list.Add(root.val);
	foreach (Node child in root.children) {
		Rec(child, list);
	}
}
```
### Iterative ###
```
// O(n), O(2n)
// O(n), O(n)
stack.Push(root);
while (stack.Count > 0){
	Node current = stack.Pop();
	list.Add(current.val);
	for (int i = current.children.Count - 1; i >= 0; i--) {
		stack.Push(current.children[i]);
	}
}
```
## N-ary Post Order Traversal ##
### Problems ###
- [https://leetcode.com/problems/n-ary-tree-postorder-traversal/](https://leetcode.com/problems/n-ary-tree-postorder-traversal/)
- 
### Recursive ###
```
// O(n), O(2n)
// O(n), O(n)
private void Rec(Node root, IList<int> list) {
	if (root == null) return;
	foreach (Node child in root.children) {
		Rec(child, list);
	}
	list.Add(root.val);
}
```
### Iterative ###
```
// O(n), O(2n)
// O(n), O(n)
stack.Push(root);
while (stack.Count > 0) {
	Node current = stack.Peek();
	if (current.children.Count == 0 || current.children.All(x => hash.Contains(x))) {
		current = stack.Pop();
		hash.Add(current);
		list.Add(current.val);
	}
	else {
		for (int i = current.children.Count - 1; i >= 0; i--) {
			stack.Push(current.children[i]);
		}
	}
}
```
## Right Tree View ##
### Problems ###
- [https://leetcode.com/problems/binary-tree-right-side-view/](https://leetcode.com/problems/binary-tree-right-side-view/)
- 
### Iterative ###
```
// O(n), O(2n)
// O(n), O(n)
queue.Enqueue(root);
while (queue.Count > 0) {
	int size = queue.Count;
	var stack = new Stack<TreeNode>();
	while (size > 0) {
		TreeNode current = queue.Dequeue();
		stack.Push(current);
		if (current.left != null) queue.Enqueue(current.left);
		if (current.right != null) queue.Enqueue(current.right);
		size--;
	}
	list.Add(stack.Pop().val);
}
```
## Height of the tree or Max Depth of the tree ##
### Problems ###
- [https://leetcode.com/problems/maximum-depth-of-binary-tree/](https://leetcode.com/problems/maximum-depth-of-binary-tree/)
- 
### Recursive ###
```
// O(n), O(n)
private int Rec(TreeNode root) {
	if (root == null) return 0;
	int leftHeight = Rec(root.left);
	int rightHeight = Rec(root.right);
	return Math.Max(leftHeight, rightHeight) + 1;
}
```
## Is Tree Balance (Tree balance factor) ##
### Problems ###
- [https://leetcode.com/problems/balanced-binary-tree/](https://leetcode.com/problems/balanced-binary-tree/)
-
### Recursive ###
```
// O(n), O(n)
public bool IsBalanced(TreeNode root) {
	bool?[] res = new bool?[1];
	Rec(root, res);
	return res[0] == null ? true : res[0].Value;
}
private int Rec(TreeNode root, bool?[] res) {
	if (root == null) return 0;
	if (res[0] != null) return -1;
	int leftHeight = Rec(root.left, res);
	int rightHeight = Rec(root.right, res);
	int balanceFactor = Math.Abs(leftHeight - rightHeight);
	if (res[0] != null) return -1;
	if (balanceFactor > 1) res[0] = false;
	return Math.Max(leftHeight, rightHeight) + 1;
}
```
## Populate right pointer in tree ##
### Problems ###
- [https://leetcode.com/problems/populating-next-right-pointers-in-each-node/](https://leetcode.com/problems/populating-next-right-pointers-in-each-node/)
- [https://leetcode.com/problems/populating-next-right-pointers-in-each-node-ii/](https://leetcode.com/problems/populating-next-right-pointers-in-each-node-ii/)
### Iterative ###
```
// O(n), O(1)
queue.Enqueue(root);
while (queue.Count > 0) {
	int size = queue.Count;
	Node prev = null;
	while (size > 0) {
		Node current = queue.Dequeue();
		if (prev == null) {
			prev = current;
		}
		else {
			prev.next = current;
			prev = current;
		}
		if (current.left != null) queue.Enqueue(current.left);
		if (current.right != null) queue.Enqueue(current.right);
		size--;
	}
}
```
## Lowest Common Ancestor (LCA) ##
### Problems ###
- [https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/](https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/)
-
### Recursive ###
```
// O(n), O(1)
private TreeNode Lca(TreeNode root, TreeNode p, TreeNode q) {
	if (root == null) return null;
	if (root == p || root == q) return root;
	TreeNode left = Lca(root.left, p, q);
	TreeNode right = Lca(root.right, p, q);
	if (left == null && right == null) return null;
	if (left != null && right != null) return root;
	return left != null ? left : right;
}
```
### Iterative ###
```
// O(3n), O(3n)
// O(n), O(n)
public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
	if (root == null) return null;
	var queue = new Queue<TreeNode>();
	var parents = new Dictionary<TreeNode, TreeNode>();
	queue.Enqueue(root);
	parents.Add(root, null);
	while (queue.Count > 0) { // O(n), O(2n)
		int size = queue.Count;
		while (size > 0) {
			TreeNode current = queue.Dequeue();
			if (current.left != null) {
				queue.Enqueue(current.left);
				parents.Add(current.left, current);
			}
			if (current.right != null) {
				queue.Enqueue(current.right);
				parents.Add(current.right, current);
			}
			size--;
		}
	}
	var pParents = new HashSet<TreeNode>(); // Increases O(n) space
	while (p != null) { // Increases O(n) runtime
		pParents.Add(p);
		p = parents[p];
	}
	while (!pParents.Contains(q)) // Increases O(n) runtime
	{
		q = parents[q];
	}
	return q;
}
```
## Boundary Traversal ##
### Problems ###
- [https://leetcode.com/problems/boundary-of-binary-tree/](https://leetcode.com/problems/boundary-of-binary-tree/)
-
### Iterative ###
```
// O(n), O(n)
public IList<int> BoundaryOfBinaryTree(TreeNode root) {
	if (root == null) return new List<int>();
	IList<TreeNode> left = GetLeftBoundary(root.left); // O(n), O(n)
	IList<TreeNode> right = GetRightBoundary(root.right); // O(n), O(n)
	var leafs = new List<TreeNode>();
	var hash = new HashSet<TreeNode>();
	GetLeafs(root, leafs); // O(n), O(n)
	hash.Add(root);
	hash.UnionWith(left);
	hash.UnionWith(leafs);
	hash.UnionWith(right);
	return hash.Select(x => x.val).ToList();
}
// O(n), O(n) worst case (skewed tree)
// O(h), O(h) average with a balanced tree
private IList<TreeNode> GetLeftBoundary(TreeNode root) {
	var list = new List<TreeNode>();
	while (root != null) {
		list.Add(root);
		if (root.left != null) root = root.left;
		else root = root.right;
	}
	return list;
}
// O(n), O(n) worst case (skewed tree)
// O(h), O(h) average with a balanced tree
private IList<TreeNode> GetRightBoundary(TreeNode root) {
	var list = new LinkedList<TreeNode>();
	while (root != null) {
		list.AddFirst(root);
		if (root.right != null) root = root.right;
		else root = root.left;
	}
	return list.ToList();
}
// O(n), O(2^depth) worst case, full tree
// O(n), O(2^(log n))
// O(n), O(n)
private void GetLeafs(TreeNode root, IList<TreeNode> res) {
	if (root == null) return;
	if (root.left == null && root.right == null) res.Add(root);
	GetLeafs(root.left, res);
	GetLeafs(root.right, res);
}
```
## Binary Tree Diameter ##
### Problems ###
- [https://leetcode.com/problems/diameter-of-binary-tree/](https://leetcode.com/problems/diameter-of-binary-tree/)
-
### Recursive ###
```
public int DiameterOfBinaryTree(TreeNode root) {
	if (root == null) return 0;
	return GetDiameter(root) - 1;
}
// O(n), O(n)
private int GetHeight(TreeNode root) {
	if (root == null) return 0;
	return Math.Max(GetHeight(root.left), GetHeight(root.right)) + 1;
}
// O(n), O(n)
private int GetDiameter(TreeNode root) {
	if (root == null) return 0;
	int leftHeight = GetHeight(root.left); // O(n/2), O(1)
	int rightHeight = GetHeight(root.right); // O(n/2), O(1)
	int leftDiameter = GetDiameter(root.left);
	int rightDiameter = GetDiameter(root.right);
	int maxChildrenDiameter = Math.Max(leftDiameter, rightDiameter);
	return Math.Max(leftHeight + rightHeight + 1, maxChildrenDiameter);
}
```
## Check if string is Valid Sequence (ex of searching in a binary tree path ##
### Problems ###
- [https://leetcode.com/problems/check-if-a-string-is-a-valid-sequence-from-root-to-leaves-path-in-a-binary-tree/](https://leetcode.com/problems/check-if-a-string-is-a-valid-sequence-from-root-to-leaves-path-in-a-binary-tree/)
-
### Recursive (backtracking) ###
```
public bool IsValidSequence(TreeNode root, int[] arr) {
	if (root == null || (arr?.Length ?? 0) == 0) return false;
	bool[] res = new bool[1];
	Rec(root, arr, new List<int>(), res);
	return res[0];
}
// O(n), O(h) average case
// O(n), O(n) worst case
private void Rec(TreeNode root, int[] arr, IList<int> current, bool[] res) {
	if (root == null) return;
	current.Add(root.val);
	if (root.left == null && root.right == null) {
		if (arr.SequenceEqual(current)) {
			res[0] = true;
			return;
		}
	}
	Rec(root.left, arr, current, res);
	Rec(root.right, arr, current, res);
	current.RemoveAt(current.Count - 1);
}
```
## Is Binary Tree complete ##
### Problems ###
- [https://leetcode.com/problems/check-completeness-of-a-binary-tree/](https://leetcode.com/problems/check-completeness-of-a-binary-tree/)
-
### Iterative ###
```
// worst case is when we have a full tree, (space complexity)
// O(n), O(2^depth)
// O(n), O(2^log(n))
// O(n), O(n)
public bool IsCompleteTree(TreeNode root) {
	if (root == null) return true;
	var queue = new Queue<TreeNode>();
	bool nullChildDetected = false;
	queue.Enqueue(root);
	while (queue.Count > 0) {
		int size = queue.Count;
		while (size > 0) {
			TreeNode current = queue.Dequeue();
			if (current == null) {
				nullChildDetected = true;
			}
			else {
				if (nullChildDetected) return false;
				queue.Enqueue(current.left);
				queue.Enqueue(current.right);
			}
			size--;
		}
	}
	return true;
}
```


