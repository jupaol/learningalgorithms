
<ul>
<li><a href="#trie">Trie</a>
<ul>
<li><a href="#create-a-trie">Create a Trie</a>
<ul>
<li><a href="#problems">Problems</a></li>
<li><a href="#iterative-hashmap">Iterative (HashMap)</a></li>
</ul>
</li>
<li><a href="#search-with-.-wildcard">Search with ‘.’ wildcard</a>
<ul>
<li><a href="#problems-1">Problems</a></li>
<li><a href="#iterative--recursive">Iterative + Recursive</a></li>
</ul>
</li>
</ul>
</li>
</ul>

# Trie #
## Create a Trie ##
### Problems ###
- [https://leetcode.com/problems/implement-trie-prefix-tree/](https://leetcode.com/problems/implement-trie-prefix-tree/)
-
### Iterative (HashMap) ###
```
public class TrieNode
{
    public bool IsEndOfWord { get; set; }
    public IDictionary<char, TrieNode> Map { get; }
    public TrieNode() {
        Map = new Dictionary<char, TrieNode>();
    }
}
public class Trie {
    private readonly TrieNode _root;
    public Trie() {
        _root = new TrieNode();
    }
    // O(m), O(m)
    public void Insert(string word) {
        if (string.IsNullOrWhiteSpace(word)) throw new ArgumentNullException(nameof(word));
        TrieNode current = _root;
        foreach (char c in word) {
            if (!current.Map.ContainsKey(c)) current.Map.Add(c, new TrieNode());
            current = current.Map[c];
        }
        current.IsEndOfWord = true;
    }
    // O(m) O(1)
    public bool Search(string word) {
        if (string.IsNullOrWhiteSpace(word)) throw new ArgumentNullException(nameof(word));
        TrieNode current = _root;
        foreach (char c in word) {
            if (!current.Map.ContainsKey(c)) return false;
            current = current.Map[c];
        }
        return current.IsEndOfWord;
    }
    // O(m) O(1)
    public bool StartsWith(string prefix) {
        if (string.IsNullOrWhiteSpace(prefix)) throw new ArgumentNullException(nameof(prefix));
        TrieNode current = _root;
        foreach (char c in prefix) {
            if (!current.Map.ContainsKey(c)) return false;
            current = current.Map[c];
        }
        return true;
    }
}
```
## Search with '.' wildcard ##
### Problems ###
- [https://leetcode.com/problems/add-and-search-word-data-structure-design/](https://leetcode.com/problems/add-and-search-word-data-structure-design/)
-
### Iterative + Recursive ###
```
public class TrieNode
{
    public IDictionary<char, TrieNode> Map { get; }
    public bool IsEndOfWord { get; set; }
    public TrieNode() {
        Map = new Dictionary<char, TrieNode>();
    }
}
public class WordDictionary {
    private readonly TrieNode _root;
    public WordDictionary() {
        _root = new TrieNode();
    }
    // O(m), O(m)
    public void AddWord(string word) {
        if (string.IsNullOrWhiteSpace(word)) throw new ArgumentNullException(nameof(word));
        TrieNode current = _root;
        foreach (char c in word) {
            if (!current.Map.ContainsKey(c)) {
                current.Map.Add(c, new TrieNode());
            }
            current = current.Map[c];
        }
        current.IsEndOfWord = true;
    }
    public bool Search(string word) {
        if (string.IsNullOrWhiteSpace(word)) throw new ArgumentNullException(nameof(word));
        return Search(word, 0, _root);
    }
    // O(26^h) (where h is the height of the tree), O(h)
    private bool Search(string word, int index, TrieNode current) {
        if (index == word.Length) return current.IsEndOfWord;
        char c = word[index];
        if (c == '.') {
            foreach (var item in current.Map) {
                if (Search(word, index + 1, item.Value)) {
                    return true;
                }
            }
            return false;
        }
        else if (!current.Map.ContainsKey(c)) {
            return false;
        }
        else {
            return Search(word, index + 1, current.Map[c]);
        }
    }
}
```


