
<ul>
<li><a href="#linq">LINQ</a>
<ul>
<li><a href="#trick-to-get-the-minimum-object">Trick to get the minimum object</a></li>
</ul>
</li>
</ul>

# LINQ #
## Trick to get the minimum object ##
```
(int val, char ind) min = tmpList.Aggregate((x, y) => x.val <= y.val ? x : y);
```


