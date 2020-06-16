
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
<li><a href="#palindromic-substrings">Palindromic substrings</a>
<ul>
<li><a href="#problems-4">Problems</a></li>
<li><a href="#iterative-two-pointers-expanding">Iterative, two pointers, expanding</a></li>
</ul>
</li>
<li><a href="#longest-palindromic-substrings">Longest Palindromic substrings</a>
<ul>
<li><a href="#problems-5">Problems</a></li>
<li><a href="#iterative-two-pointers-expanding-1">Iterative, two pointers expanding</a></li>
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
## Palindromic substrings ##
### Problems ###
- [https://leetcode.com/problems/palindromic-substrings/](https://leetcode.com/problems/palindromic-substrings/)
- (DP solution): https://github.com/jupaol/learningalgorithms/blob/develop/docs/Dynamic%20Programming.md#palindromic-substrings
### Iterative, two pointers, expanding ###
```
public class Solution {
    public int CountSubstrings(string s) {
        int count = 0;
        
        for (int i = 0; i < s.Length; i++)
        {
            count++;
            count += CountPalindromeStrings(s, i - 1, i + 1);
            count += CountPalindromeStrings(s, i - 1, i);
        }
        
        return count;
    }
    private int CountPalindromeStrings(string s, int i, int j) {
        int min = i;
        int max = j;
        int count = 0;
        while (min < max && min >= 0 && min < s.Length && max >= 0 && max < s.Length) {
            if (s[min] != s[max]) {
                break;
            }
            count++;
            min--;
            max++;
        }
        return count;
    }
}
```
## Longest Palindromic substrings ##
### Problems ###
- [https://leetcode.com/problems/longest-palindromic-substring/](https://leetcode.com/problems/longest-palindromic-substring/)
- (DP version): 
### Iterative, two pointers expanding ###
```
public class Solution {
    public string LongestPalindrome(string s) {
        if (string.IsNullOrWhiteSpace(s)) return "";
        (int min, int max, int len) res = (-1, -1, int.MinValue);
        for (int i = 0; i < s.Length; i++) {
            if (1 > res.len) res = (i, i, 1);
            var tmp = GetLongestPalindrome(s, i - 1, i + 1);
            if (tmp.len > res.len) res = tmp;
            tmp = GetLongestPalindrome(s, i - 1, i);
            if (tmp.len > res.len) res = tmp;
        }
        return s.Substring(res.min, res.len);
    }
    private (int min, int max, int len) GetLongestPalindrome(string s, int i, int j) {
        int min = i;
        int max = j;
        (int min, int max, int len) res = (-1, -1, int.MinValue);
        while (min < max && min >= 0 && j >= 0 && min < s.Length && max < s.Length) {
            if (s[min] != s[max]) {
                break;
            }
            res = (min, max, max - min + 1);
            min--;
            max++;
        }
        return res;
    }
}
```


