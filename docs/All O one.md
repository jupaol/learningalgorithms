
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
    private readonly IDictionary<int, LinkedListNode<HashSet<string>>> _valueMap;
    private readonly LinkedList<HashSet<string>> _list;
    public AllOne() {
        _keyMap = new Dictionary<string, int>();
        _valueMap = new Dictionary<int, LinkedListNode<HashSet<string>>>();
        _list = new LinkedList<HashSet<string>>();
    }
    public void Inc(string key) {
        if (_keyMap.ContainsKey(key)) {
            Change(key, 1);
        }
        else {
            Add(key);
        }
    }
    public void Dec(string key) {
        if (!_keyMap.ContainsKey(key)) {
            return;
        }
        Change(key, -1);
    }
    public string GetMaxKey() {
        if (_list.Count == 0) return string.Empty;
        return _list.Last.Value.First();
    }
    public string GetMinKey() {
        if (_list.Count == 0) return string.Empty;
        return _list.First.Value.First();

    }
    private void Change(string key, int offset) {
        int oldVal = _keyMap[key];
        int newVal = oldVal + offset;
        if (newVal == 0) {
            _keyMap.Remove(key);
        }
        else {
            _keyMap[key] = newVal;
            AddKeyValue(key, newVal, oldVal);
        }
        CleanNodeValue(key, oldVal);
    }
    private void CleanNodeValue(string key, int oldValue) {
        _valueMap[oldValue].Value.Remove(key);
        if (_valueMap[oldValue].Value.Count == 0) {
            _list.Remove(_valueMap[oldValue]);
            _valueMap.Remove(oldValue);
        }
    }
    private void Add(string key) {
        AddKeyValue(key, 1, null);
        _keyMap.Add(key, 1);
    }
    private void AddKeyValue(string key, int value, int? oldValue) {
        if (!_valueMap.ContainsKey(value)) {
            _valueMap.Add(value, new LinkedListNode<HashSet<string>>(new HashSet<string>()));
            if (oldValue == null) {
                _list.AddFirst(_valueMap[value]);
            }
            else {
                if (value > oldValue.Value) {
                    _list.AddAfter(_valueMap[oldValue.Value], _valueMap[value]);
                }
                else {
                    _list.AddBefore(_valueMap[oldValue.Value], _valueMap[value]);
                }
            }
        }
        _valueMap[value].Value.Add(key);
    }
}

```


