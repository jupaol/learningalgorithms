
<ul>
<li><a href="#templates">Templates</a>
<ul>
<li><a href="#subarrays-with-exactly-something">Subarrays with exactly something</a>
<ul>
<li><a href="#links">Links</a></li>
<li><a href="#template">Template</a></li>
<li><a href="#notes">Notes</a></li>
</ul>
</li>
<li><a href="#most-substringsubarray-problems">Most Substring/Subarray problems</a>
<ul>
<li><a href="#links-1">Links</a></li>
<li><a href="#template-1">Template</a></li>
</ul>
</li>
</ul>
</li>
</ul>

# Templates #
## Subarrays with exactly something ##
### Links ###
- [https://leetcode.com/problems/subarrays-with-k-different-integers/discuss/523136/JavaC%2B%2BPython-Sliding-Window](https://leetcode.com/problems/subarrays-with-k-different-integers/discuss/523136/JavaC%2B%2BPython-Sliding-Window)
- [https://leetcode.com/problems/minimum-window-substring/discuss/26808/here-is-a-10-line-template-that-can-solve-most-substring-problems](https://leetcode.com/problems/minimum-window-substring/discuss/26808/here-is-a-10-line-template-that-can-solve-most-substring-problems)
### Template ###
```
public class Solution {
    public int SubarraysWithKDistinct(int[] A, int K) {
        if ((A?.Length ?? 0) == 0 || K <= 0) {
            return 0;
        }
        if (K >= A.Length) {
            return K;
        }
        return Count(A, K) - Count (A, K - 1);
    }
    private int Count(int[] arr, int k) {
        var map = new Dictionary<int, int>();
        int right = 0;
        int left = 0;
        int count = 0;
        while (right < arr.Length) {
            if (!map.ContainsKey(arr[right])) {
                map.Add(arr[right], 0);
            }
            map[arr[right]]++;
            while (map.Count > k) {
                map[arr[left]]--;
                if (map[arr[left]] == 0) {
                    map.Remove(arr[left]);
                }
                left++;
            }
            count += right - left + 1;
            right++;
        }
        return count;
    }
}
```
### Notes ###
The formula to get **total** number of subarrays is:
```
(n(n + 1)) / 2
```
And it's **equivalent** to run an accumulated sum of the subarrays length, for example if we have: 
```
[1, 2, 3, 4]
```
The **total** number of subarrays by applying the formula is: 
```
(4 * (4 + 1)) / 2
10
```
And if we run a sumation of the lengths we get this:
```
[1]: Len = 1
[1, 2]: Len = 2
[1, 2, 3]: Len = 3
[1, 2, 3, 4]: Len = 4
1 + 2 + 3 + 4 = 10
```
---
The reason behind this:
```
return Count(A, K) - Count (A, K - 1);
```
So when we run a _typical_ algo using this pattern: 
https://leetcode.com/problems/minimum-window-substring/discuss/26808/here-is-a-10-line-template-that-can-solve-most-substring-problems
This will give us a count of valid subarrays (by counting their lenghts) but this will contain subarrays that **do not** have exactly **k** different integers, however, it will output subarrays that have **AT MOST k** different integers, that's why we run this code:
```
return Count(A, K) - Count (A, K - 1);
```
To get **only** the subarrays with **k** different integers
In other words:
**Exactly K times = at most K times - at most K - 1 times**
## Most Substring/Subarray problems ##
### Links ###
- [https://leetcode.com/problems/minimum-window-substring/discuss/26808/here-is-a-10-line-template-that-can-solve-most-substring-problems](https://leetcode.com/problems/minimum-window-substring/discuss/26808/here-is-a-10-line-template-that-can-solve-most-substring-problems)
### Template ###
```
public class Solution {
    public int LengthOfLongestSubstringTwoDistinct(string s) {
        if (string.IsNullOrEmpty(s)) {
            return 0;
        }
        int left = 0;
        int right = 0;
        int[] chars = new int[128];
        int max = int.MinValue;
        while (right < s.Length) {
            char c = s[right];
            chars[c]++;
            while (chars.Count(x => x > 0) > 2 && left < right) {
                char l = s[left];
                chars[l]--;
                left++;
            }
            max = Math.Max(max, right - left + 1);
            right++;
        }
        return max == int.MinValue ? 0 : max;
    }
}
```


