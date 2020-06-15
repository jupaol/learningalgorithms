
<ul>
<li><a href="#dynamic-programming">Dynamic Programming</a>
<ul>
<li><a href="#palindromic-substrings">Palindromic substrings</a>
<ul>
<li><a href="#problems">Problems</a></li>
<li><a href="#iterative-dynamic-programming">Iterative, Dynamic Programming</a></li>
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


