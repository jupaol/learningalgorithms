<!DOCTYPE html>
<html>

<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Strings</title>
  <link rel="stylesheet" href="https://stackedit.io/style.css" />
</head>

<body class="stackedit">
  <div class="stackedit__left">
    <div class="stackedit__toc">
      
<ul>
<li><a href="#strings">Strings</a>
<ul>
<li><a href="#find-anagrams">Find Anagrams</a></li>
<li><a href="#longest-substring-wo-repeating-chars">Longest Substring w/o repeating chars</a></li>
<li><a href="#longest-substring-with-at-most-2-distinct-characters">Longest substring with at most 2 distinct characters</a></li>
<li><a href="#minimum-window-substring">Minimum Window Substring</a></li>
</ul>
</li>
</ul>

    </div>
  </div>
  <div class="stackedit__right">
    <div class="stackedit__html">
      <h1 id="strings">Strings</h1>
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

    </div>
  </div>
</body>

</html>
