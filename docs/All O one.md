
<ul>
<li><a href="#all-o-one">All O one</a>
<ul>
<li><a href="#create-all-o-one-data-structure">Create All O one data structure</a>
<ul>
<li><a href="#problems">Problems</a></li>
<li><a href="#iterative">Iterative</a></li>
</ul>
</li>
</ul>
</li>
</ul>

# All O one #
## Create All O one data structure ##
### Problems ###
- [https://leetcode.com/problems/all-oone-data-structure/](https://leetcode.com/problems/all-oone-data-structure/)
-
### Iterative ###
```
public class AllOne {
    private readonly IDictionary<string, int> _keyMap;
    private readonly IDictionary<int, LinkedListNode<IDictionary<string, string>>> _valueMap;
    private readonly LinkedList<IDictionary<string, string>> _list;
    public AllOne() {
        _keyMap = new Dictionary<string, int>();
        _valueMap = new Dictionary<int, LinkedListNode<IDictionary<string, string>>>();
        _list = new LinkedList<IDictionary<string, string>>();
    }
    public void Inc(string key) {
        if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
        if (_keyMap.ContainsKey(key)) {
            Change(key, 1);
            return;
        }
        _keyMap.Add(key, 1);
        if (_valueMap.ContainsKey(1)) {
            _valueMap[1].Value.Add(key, key);
        }
        else {
            var node = new LinkedListNode<IDictionary<string, string>>(
                new Dictionary<string, string> { { key, key } });
            _list.AddFirst(node);
            _valueMap.Add(1, node);
        }
    }
    public void Dec(string key) {
        if (!_keyMap.ContainsKey(key)) return;
        Change(key, -1);
    }
    public string GetMaxKey() {
        if (_list.Count == 0) return string.Empty;
        return _list.Last.Value.First().Key;
    }
    public string GetMinKey() {
        if (_list.Count == 0) return string.Empty;
        return _list.First.Value.First().Key;
    }
    private void Change(string key, int offset) {
        int oldVal = _keyMap[key];
        int newVal = oldVal + offset;
        if (newVal == 0) {
            _keyMap.Remove(key);
        }
        else {
            _keyMap[key] = newVal;
            if (_valueMap.ContainsKey(newVal)) {
                _valueMap[newVal].Value.Add(key, key);
            }
            else {
                var node = new LinkedListNode<IDictionary<string, string>>(
                    new Dictionary<string, string> { { key, key } });
                if (offset == 1) _list.AddAfter(_valueMap[oldVal], node);
                else _list.AddBefore(_valueMap[oldVal], node);
                _valueMap.Add(newVal, node);
            }
        }
        _valueMap[oldVal].Value.Remove(key);
        if (_valueMap[oldVal].Value.Count == 0) {
            _list.Remove(_valueMap[oldVal].Value);
            _valueMap.Remove(oldVal);
        }
    }
}
```


