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

