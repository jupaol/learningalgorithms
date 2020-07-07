
<ul>
<li><a href="#dynamic-programming">Dynamic Programming</a>
<ul>
<li><a href="#palindromic-substrings">Palindromic substrings</a>
<ul>
<li><a href="#problems">Problems</a></li>
<li><a href="#iterative-dynamic-programming">Iterative, Dynamic Programming</a></li>
</ul>
</li>
<li><a href="#longest-palindromic-substring">Longest Palindromic substring</a>
<ul>
<li><a href="#problems-1">Problems</a></li>
<li><a href="#dynamic-programming-1">Dynamic Programming</a></li>
</ul>
</li>
<li><a href="#longest-palindromic-subsequence">Longest palindromic subsequence</a>
<ul>
<li><a href="#problems-2">Problems</a></li>
<li><a href="#dynamic-programming-2">Dynamic Programming</a></li>
</ul>
</li>
<li><a href="#longest-common-subsequence">Longest Common subsequence</a>
<ul>
<li><a href="#problems-3">Problems</a></li>
<li><a href="#iterative-dynamic-programming-1">Iterative: Dynamic Programming</a></li>
</ul>
</li>
<li><a href="#longest-increasing-subsequence">Longest increasing subsequence</a>
<ul>
<li><a href="#problems-4">Problems</a></li>
<li><a href="#dynamic-programming-3">Dynamic Programming</a></li>
</ul>
</li>
<li><a href="#number-of-longest-increasing-subsequences">Number of longest increasing subsequences</a>
<ul>
<li><a href="#problems-5">Problems</a></li>
<li><a href="#dynamic-programming-4">Dynamic Programming</a></li>
</ul>
</li>
<li><a href="#minimum-delete-operations-for-two-strings">Minimum delete operations for two strings</a>
<ul>
<li><a href="#problems-6">Problems</a></li>
<li><a href="#dynamic-programming-5">Dynamic Programming</a></li>
</ul>
</li>
</ul>
</li>
</ul>

# Dynamic Programming #
## Palindromic substrings ##
### Problems ###
- [https://leetcode.com/problems/palindromic-substrings/](https://leetcode.com/problems/palindromic-substrings/)
- (two pointer solution): https://github.com/jupaol/learningalgorithms/blob/develop/docs/Strings.md#palindromic-substrings
### Iterative, Dynamic Programming ###
```
public class Solution {
    public int CountSubstrings(string s) {
        bool[][] dp = new bool[s.Length][];
        int count = 0;
        
        for (int i = 0; i < dp.Length; i++)
        {
            dp[i] = new bool[s.Length];
            dp[i][i] = true;
            count++;
        }
        
        for (int j = 1; j < dp[0].Length; j++) {
            for (int i = 0; i < j; i++) {
                if (i + 1 == j && s[i] == s[j]){
                    dp[i][j] = true;
                    count++;
                }
                else if (dp[i + 1][j - 1] && s[i] == s[j]) {
                    dp[i][j] = true;
                    count++;
                }
            }
        }
        
        
        return count;
    }
}
```
## Longest Palindromic substring ##
### Problems ###
- [https://leetcode.com/problems/longest-palindromic-substring/](https://leetcode.com/problems/longest-palindromic-substring/)
- (Two pointer solution): https://github.com/jupaol/learningalgorithms/blob/develop/docs/Strings.md#longest-palindromic-substrings
### Dynamic Programming ###
```
public class Solution {
    public string LongestPalindrome(string s) {
        if (string.IsNullOrWhiteSpace(s)) return string.Empty;
        bool[][] dp = new bool[s.Length][];
        (int min, int max, int len) max = (0, 0, 1);
        for (int i = 0; i < dp.Length; i++) {
            dp[i] = new bool[s.Length];
            dp[i][i] = true;
        }
        for (int j = 1; j < dp.Length; j++) {
            for (int i = 0; i < j; i++) {
                if (i + 1 == j && s[i] == s[j]) {
                    dp[i][j] = true;
                }
                else if (dp[i + 1][j - 1] && s[i] == s[j]) {
                    dp[i][j] = true;
                }
                if (dp[i][j]) {
                    int len = j - i + 1;
                    if (len > max.len) {
                        max = (i, j, len);
                    }
                }
            }
        }
        return s.Substring(max.min, max.len);
    }
}
```
## Longest palindromic subsequence ##
### Problems ###
- [https://leetcode.com/problems/longest-palindromic-subsequence/](https://leetcode.com/problems/longest-palindromic-subsequence/)
-
### Dynamic Programming ###
```
public class Solution {
    public int LongestPalindromeSubseq(string s) {
        if (string.IsNullOrWhiteSpace(s)) return 0;
        int[][] dp = new int[s.Length][];
        for (int i = 0; i < dp.Length; i++) {
            dp[i] = new int[s.Length];
            dp[i][i] = 1;
        }
        for (int window = 2; window <= s.Length; window++) {
            int col = window - 1;
            for (int row = 0; row <= s.Length - window; row++, col++) {
                if (window == 2) {
                    dp[row][col] = s[row] == s[col] ? 2 : 1;
                }
                else if (s[row] == s[col]) {
                    dp[row][col] = 2 + dp[row + 1][col - 1];
                }
                else {
                    dp[row][col] = Math.Max(dp[row][col - 1], dp[row + 1][col]);
                }
            }
        }
        
        return dp[0][s.Length - 1];
    }
}
```
## Longest Common subsequence ##
### Problems ###
- [https://leetcode.com/problems/longest-common-subsequence/](https://leetcode.com/problems/longest-common-subsequence/)
-
### Iterative: Dynamic Programming ###
```
public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        if (string.IsNullOrWhiteSpace(text1) || string.IsNullOrWhiteSpace(text2)) return 0;
        int[][] dp = new int[text1.Length + 1][];
        for (int i = 0; i < dp.Length; i++) dp[i] = new int[text2.Length + 1];
        for (int i = 1; i < dp.Length; i++)
            for (int j = 1; j < dp[i].Length; j++)
                if (text1[i - 1] == text2[j - 1]) dp[i][j] = 1 + dp[i - 1][j - 1];
                else dp[i][j] = Math.Max(dp[i][j - 1], dp[i - 1][j]);
        return dp[text1.Length][text2.Length];
    }
}
```
## Longest increasing subsequence ##
### Problems ###
- [https://leetcode.com/problems/longest-increasing-subsequence/](https://leetcode.com/problems/longest-increasing-subsequence/)
-
### Dynamic Programming ###
```
public class Solution {
    public int LengthOfLIS(int[] nums) {
        if ((nums?.Length ?? 0) == 0) {
            return 0;
        }
        if (nums.Length == 1) {
            return 1;
        }
        int[] dp = new int[nums.Length];
        int[] path = new int[nums.Length];
        (int len, int i) max = (1, 0);
        for (int i = 0; i < nums.Length; i++) {
            dp[i] = 1;
            path[i] = -1;
            for (int j = 0; j < i; j++) {
                if (nums[j] < nums[i]) {
                    if (1 + dp[j] > dp[i]) {
                        dp[i] = 1 + dp[j];
                        path[i] = j;
                    }
                }
            }
            max = new[] { max, (len:dp[i], i) }.Aggregate((x, y) => x.len > y.len ? x : y);
        }
        var stack = new Stack<int>();
        int k = max.i;
        stack.Push(nums[k]);
        while (k != -1 && path[k] != -1) {
            stack.Push(nums[path[k]]);
            k = path[k];
        }
        // Console.WriteLine(string.Join(",", stack));
        return stack.Count;
    }
}
```
## Number of longest increasing subsequences ##
### Problems ###
- [https://leetcode.com/problems/number-of-longest-increasing-subsequence/](https://leetcode.com/problems/number-of-longest-increasing-subsequence/)
-
### Dynamic Programming ###
```
public class Solution {
    public int FindNumberOfLIS(int[] nums) {
        if ((nums?.Length ?? 0) == 0) {
            return 0;
        }
        int[] dp = new int[nums.Length];
        int[] count = new int[nums.Length];
        int max = 0;
        int res = 0;
        for (int i = 0; i < dp.Length; i++) {
            dp[i] = 1;
            count[i] = 1;
            for (int j = 0; j < i; j++) {
                if (nums[j] < nums[i]) {
                    if (1 + dp[j] > dp[i]) {
                        dp[i] = 1 + dp[j];
                        count[i] = count[j];
                    }
                    else if (1 + dp[j] == dp[i]) {
                        count[i] += count[j];
                    }
                }
            }
            if (dp[i] > max) {
                max = dp[i];
                res = count[i];
            }
            else if (dp[i] == max) {
                res += count[i];
            }
        }
        return res;
    }
}
```
## Minimum delete operations for two strings ##
### Problems ###
- [https://leetcode.com/problems/delete-operation-for-two-strings/](https://leetcode.com/problems/delete-operation-for-two-strings/)
-
### Dynamic Programming ###
```
public class Solution {
    public int MinDistance(string word1, string word2) {
        int[][] dp = new int[word1.Length + 1][];
        for (int i = 0; i < dp.Length; i++) {
            dp[i] = new int[word2.Length + 1];
            dp[i][0] = i;
        }
        for (int i = 0; i < dp[0].Length; i++) dp[0][i] = i;
        for (int i = 1; i < dp.Length; i++) {
            for (int j = 1; j < dp[i].Length; j++) {
                if (word1[i - 1] == word2[j - 1]) {
                    dp[i][j] = dp[i - 1][j - 1];
                }
                else {
                    dp[i][j] = 1 + Math.Min(dp[i][j - 1], dp[i - 1][j]);
                }
            }
        }
        return dp[word1.Length][word2.Length];
    }
}
```


