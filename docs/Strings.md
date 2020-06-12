<!-- Specify your Handlebars template here.

The following JavaScript context will be passed to the template:

{
  files: [{
    name: 'The filename',
    content: {
      text: 'The file content',
      html: '<p>The file content</p>',
      yamlProperties: 'The file properties in YAML format',
      properties: {
        // Computed file properties object
      },
      toc: [
        // Table Of Contents tree
      ]
    }
  }]
}


As an example:

<html><body><h1 id="strings">Strings</h1>
<h2 id="find-anagrams">Find Anagrams</h2>
<h3 id="problems">Problems</h3>
<ul>
<li><a href="https://leetcode.com/problems/find-all-anagrams-in-a-string/">https://leetcode.com/problems/find-all-anagrams-in-a-string/</a></li>
<li></li>
</ul>
<h3 id="two-pointers">Two pointers</h3>
<pre><code>public IList&lt;int&gt; FindAnagrams(string s, string p) {
	var list = new List&lt;int&gt;();
	if (string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(p)) return list;
	int[] pCount = new int['z' - 'a' + 1];
	int[] windowCount = new int['z' - 'a' + 1];
	int windowSize = p.Length;
	foreach (char c in p) pCount[c - 'a']++;
	for (int i = 0; i &lt; s.Length; i++) {
		char c = s[i];
		windowCount[c - 'a']++;
		if (i &gt;= windowSize - 1) {
			if (pCount.SequenceEqual(windowCount)) list.Add(i + 1 - windowSize);
			windowCount[s[i + 1 - windowSize] - 'a']--;
		}
	}
	return list;
}
</code></pre>
<h2 id="longest-substring-wo-repeating-chars">Longest Substring w/o repeating chars</h2>
<h3 id="problems-1">Problems</h3>
<ul>
<li><a href="https://leetcode.com/problems/longest-substring-without-repeating-characters/">https://leetcode.com/problems/longest-substring-without-repeating-characters/</a></li>
<li></li>
</ul>
<h3 id="template">Template</h3>
<ul>
<li><a href="https://leetcode.com/problems/minimum-window-substring/discuss/26808/here-is-a-10-line-template-that-can-solve-most-substring-problems">https://leetcode.com/problems/minimum-window-substring/discuss/26808/here-is-a-10-line-template-that-can-solve-most-substring-problems</a></li>
</ul>
<h3 id="iterative-using-template">Iterative (using template</h3>
<pre><code>public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (string.IsNullOrEmpty(s)) return 0;
        int[] map = new int[129];
        int min = 0;
        int max = 0;
        int maximumSubstring = int.MinValue;
        while (max &lt; s.Length)
        {
            map[s[max]]++;
            while (map.Count(x =&gt; x &gt; 1) &gt; 0 &amp;&amp; min &lt; max) map[s[min++]]--;
            maximumSubstring = Math.Max(maximumSubstring, max - min + 1);
            max++;
        }
        return maximumSubstring;
    }
}
</code></pre>
<h2 id="longest-substring-with-at-most-2-distinct-characters">Longest substring with at most 2 distinct characters</h2>
<h3 id="problems-2">Problems</h3>
<ul>
<li><a href="https://leetcode.com/problems/longest-substring-with-at-most-two-distinct-characters/">https://leetcode.com/problems/longest-substring-with-at-most-two-distinct-characters/</a></li>
<li></li>
</ul>
<h3 id="template-1">Template</h3>
<ul>
<li><a href="https://leetcode.com/problems/minimum-window-substring/discuss/26808/here-is-a-10-line-template-that-can-solve-most-substring-problems">https://leetcode.com/problems/minimum-window-substring/discuss/26808/here-is-a-10-line-template-that-can-solve-most-substring-problems</a></li>
</ul>
<h3 id="iterative-with-template">Iterative with template</h3>
<pre><code>public class Solution {
    public int LengthOfLongestSubstringTwoDistinct(string s) {
        if (string.IsNullOrEmpty(s)) return 0;
        int[] map = new int[129];
        int min = 0;
        int max = 0;
        int maximumSubstring = int.MinValue;
        while (max &lt; s.Length)
        {
            map[s[max]]++;
            while (map.Count(x =&gt; x &gt; 0) &gt; 2 &amp;&amp; min &lt; max) map[s[min++]]--;
            maximumSubstring = Math.Max(maximumSubstring, max - min + 1);
            max++;
        }
        return maximumSubstring;
    }
}
</code></pre>
<h2 id="minimum-window-substring">Minimum Window Substring</h2>
<h3 id="problems-3">Problems</h3>
<ul>
<li><a href="https://leetcode.com/problems/minimum-window-substring/">https://leetcode.com/problems/minimum-window-substring/</a></li>
<li></li>
</ul>
<h3 id="template-2">Template</h3>
<ul>
<li><a href="https://leetcode.com/problems/minimum-window-substring/discuss/26808/here-is-a-10-line-template-that-can-solve-most-substring-problems">https://leetcode.com/problems/minimum-window-substring/discuss/26808/here-is-a-10-line-template-that-can-solve-most-substring-problems</a></li>
</ul>
<h3 id="iterative-with-template-1">Iterative with template</h3>
<pre><code>public class Solution {
    public string MinWindow(string s, string t) {
        if (string.IsNullOrEmpty(s)) return string.Empty;
        int[] map = new int[129];
        int[] tMap = new int[129];
        int min = 0;
        int max = 0;
        (int min, int max, int len) res = (-1, -1, int.MaxValue);
        foreach (char c in t) tMap[c]++;
        while (max &lt; s.Length)
        {
            map[s[max]]++;
            while (SequenceEqual(tMap, map) &amp;&amp; min &lt;= max) {
                int len = max - min + 1;
                if (len &lt; res.len) res = (min, max, len);
                map[s[min++]]--;
            }
            max++;
        }
        if (res.min == -1) return string.Empty;
        return s.Substring(res.min, res.len);
    }
    private bool SequenceEqual(int[] tMap, int[] sMap) {
        for (int i = 0; i &lt; tMap.Length; i++) {
            if (tMap[i] &lt;= 0) continue;
            if (sMap[i] &lt; tMap[i]) return false;
        }
        return true;
    }
}
</code></pre>
</body></html>

will produce:

<html><body><p>The file content</p></body></html>


You can use Handlebars built-in helpers and the custom StackEdit ones:


<ul>
<li><a href="#strings">Strings</a>
<ul>
<li><a href="#find-anagrams">Find Anagrams</a>
<ul>
<li><a href="#problems">Problems</a></li>
<li><a href="#two-pointers">Two pointers</a></li>
</ul>
</li>
<li><a href="#longest-substring-wo-repeating-chars">Longest Substring w/o repeating chars</a>
<ul>
<li><a href="#problems-1">Problems</a></li>
<li><a href="#template">Template</a></li>
<li><a href="#iterative-using-template">Iterative (using template</a></li>
</ul>
</li>
<li><a href="#longest-substring-with-at-most-2-distinct-characters">Longest substring with at most 2 distinct characters</a>
<ul>
<li><a href="#problems-2">Problems</a></li>
<li><a href="#template-1">Template</a></li>
<li><a href="#iterative-with-template">Iterative with template</a></li>
</ul>
</li>
<li><a href="#minimum-window-substring">Minimum Window Substring</a>
<ul>
<li><a href="#problems-3">Problems</a></li>
<li><a href="#template-2">Template</a></li>
<li><a href="#iterative-with-template-1">Iterative with template</a></li>
</ul>
</li>
</ul>
</li>
</ul>
 will produce a clickable TOC.


<ul>
<li><a href="#strings">Strings</a>
<ul>
<li><a href="#find-anagrams">Find Anagrams</a>
<ul>
<li><a href="#problems">Problems</a></li>
<li><a href="#two-pointers">Two pointers</a></li>
</ul>
</li>
<li><a href="#longest-substring-wo-repeating-chars">Longest Substring w/o repeating chars</a>
<ul>
<li><a href="#problems-1">Problems</a></li>
<li><a href="#template">Template</a></li>
<li><a href="#iterative-using-template">Iterative (using template</a></li>
</ul>
</li>
<li><a href="#longest-substring-with-at-most-2-distinct-characters">Longest substring with at most 2 distinct characters</a>
<ul>
<li><a href="#problems-2">Problems</a></li>
<li><a href="#template-1">Template</a></li>
<li><a href="#iterative-with-template">Iterative with template</a></li>
</ul>
</li>
<li><a href="#minimum-window-substring">Minimum Window Substring</a>
<ul>
<li><a href="#problems-3">Problems</a></li>
<li><a href="#template-2">Template</a></li>
<li><a href="#iterative-with-template-1">Iterative with template</a></li>
</ul>
</li>
</ul>
</li>
</ul>
 will limit the TOC depth to 3.
-->

<ul>
<li><a href="#strings">Strings</a>
<ul>
<li><a href="#find-anagrams">Find Anagrams</a>
<ul>
<li><a href="#problems">Problems</a></li>
<li><a href="#two-pointers">Two pointers</a></li>
</ul>
</li>
<li><a href="#longest-substring-wo-repeating-chars">Longest Substring w/o repeating chars</a>
<ul>
<li><a href="#problems-1">Problems</a></li>
<li><a href="#template">Template</a></li>
<li><a href="#iterative-using-template">Iterative (using template</a></li>
</ul>
</li>
<li><a href="#longest-substring-with-at-most-2-distinct-characters">Longest substring with at most 2 distinct characters</a>
<ul>
<li><a href="#problems-2">Problems</a></li>
<li><a href="#template-1">Template</a></li>
<li><a href="#iterative-with-template">Iterative with template</a></li>
</ul>
</li>
<li><a href="#minimum-window-substring">Minimum Window Substring</a>
<ul>
<li><a href="#problems-3">Problems</a></li>
<li><a href="#template-2">Template</a></li>
<li><a href="#iterative-with-template-1">Iterative with template</a></li>
</ul>
</li>
</ul>
</li>
</ul>

# Strings #
## Find Anagrams ##
### Problems ###
- [https://leetcode.com/problems/find-all-anagrams-in-a-string/](https://leetcode.com/problems/find-all-anagrams-in-a-string/)
-
### Two pointers ###
```
public IList<int> FindAnagrams(string s, string p) {
	var list = new List<int>();
	if (string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(p)) return list;
	int[] pCount = new int['z' - 'a' + 1];
	int[] windowCount = new int['z' - 'a' + 1];
	int windowSize = p.Length;
	foreach (char c in p) pCount[c - 'a']++;
	for (int i = 0; i < s.Length; i++) {
		char c = s[i];
		windowCount[c - 'a']++;
		if (i >= windowSize - 1) {
			if (pCount.SequenceEqual(windowCount)) list.Add(i + 1 - windowSize);
			windowCount[s[i + 1 - windowSize] - 'a']--;
		}
	}
	return list;
}
```
## Longest Substring w/o repeating chars ##
### Problems ###
- [https://leetcode.com/problems/longest-substring-without-repeating-characters/](https://leetcode.com/problems/longest-substring-without-repeating-characters/)
-
### Template ###
- [https://leetcode.com/problems/minimum-window-substring/discuss/26808/here-is-a-10-line-template-that-can-solve-most-substring-problems](https://leetcode.com/problems/minimum-window-substring/discuss/26808/here-is-a-10-line-template-that-can-solve-most-substring-problems)
###  Iterative (using template ###
```
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (string.IsNullOrEmpty(s)) return 0;
        int[] map = new int[129];
        int min = 0;
        int max = 0;
        int maximumSubstring = int.MinValue;
        while (max < s.Length)
        {
            map[s[max]]++;
            while (map.Count(x => x > 1) > 0 && min < max) map[s[min++]]--;
            maximumSubstring = Math.Max(maximumSubstring, max - min + 1);
            max++;
        }
        return maximumSubstring;
    }
}
```
## Longest substring with at most 2 distinct characters ##
### Problems ###
- [https://leetcode.com/problems/longest-substring-with-at-most-two-distinct-characters/](https://leetcode.com/problems/longest-substring-with-at-most-two-distinct-characters/)
-
### Template ###
- [https://leetcode.com/problems/minimum-window-substring/discuss/26808/here-is-a-10-line-template-that-can-solve-most-substring-problems](https://leetcode.com/problems/minimum-window-substring/discuss/26808/here-is-a-10-line-template-that-can-solve-most-substring-problems)
### Iterative with template ###
```
public class Solution {
    public int LengthOfLongestSubstringTwoDistinct(string s) {
        if (string.IsNullOrEmpty(s)) return 0;
        int[] map = new int[129];
        int min = 0;
        int max = 0;
        int maximumSubstring = int.MinValue;
        while (max < s.Length)
        {
            map[s[max]]++;
            while (map.Count(x => x > 0) > 2 && min < max) map[s[min++]]--;
            maximumSubstring = Math.Max(maximumSubstring, max - min + 1);
            max++;
        }
        return maximumSubstring;
    }
}
```
## Minimum Window Substring ##
### Problems ###
- [https://leetcode.com/problems/minimum-window-substring/](https://leetcode.com/problems/minimum-window-substring/)
-
### Template ###
- [https://leetcode.com/problems/minimum-window-substring/discuss/26808/here-is-a-10-line-template-that-can-solve-most-substring-problems](https://leetcode.com/problems/minimum-window-substring/discuss/26808/here-is-a-10-line-template-that-can-solve-most-substring-problems)
### Iterative with template ###
```
public class Solution {
    public string MinWindow(string s, string t) {
        if (string.IsNullOrEmpty(s)) return string.Empty;
        int[] map = new int[129];
        int[] tMap = new int[129];
        int min = 0;
        int max = 0;
        (int min, int max, int len) res = (-1, -1, int.MaxValue);
        foreach (char c in t) tMap[c]++;
        while (max < s.Length)
        {
            map[s[max]]++;
            while (SequenceEqual(tMap, map) && min <= max) {
                int len = max - min + 1;
                if (len < res.len) res = (min, max, len);
                map[s[min++]]--;
            }
            max++;
        }
        if (res.min == -1) return string.Empty;
        return s.Substring(res.min, res.len);
    }
    private bool SequenceEqual(int[] tMap, int[] sMap) {
        for (int i = 0; i < tMap.Length; i++) {
            if (tMap[i] <= 0) continue;
            if (sMap[i] < tMap[i]) return false;
        }
        return true;
    }
}
```


