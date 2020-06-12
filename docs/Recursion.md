
<ul>
<li><a href="#recursion">Recursion</a>
<ul>
<li><a href="#all-permutations-no-map">All Permutations (no map)</a>
<ul>
<li><a href="#problems">Problems</a></li>
<li><a href="#recursive">Recursive</a></li>
</ul>
</li>
<li><a href="#all-permutations-with-duplicates-with-map">All permutations with duplicates (with map)</a>
<ul>
<li><a href="#problems-1">Problems</a></li>
<li><a href="#recursive-1">Recursive</a></li>
</ul>
</li>
<li><a href="#palindrome-permutations">Palindrome Permutations</a>
<ul>
<li><a href="#problems-2">Problems</a></li>
<li><a href="#recursive-2">Recursive</a></li>
</ul>
</li>
<li><a href="#all-combinations-subsets-without-map">All Combinations (subsets) without map</a>
<ul>
<li><a href="#problems-3">Problems</a></li>
<li><a href="#recursive-3">Recursive</a></li>
<li><a href="#recursive-variation-without-using-seen-array">Recursive (variation without using seen array)</a></li>
</ul>
</li>
<li><a href="#all-combinations-subsets-with-duplicates-with-map">All Combinations (subsets) with duplicates (with map)</a>
<ul>
<li><a href="#problems-4">Problems</a></li>
<li><a href="#recursive-4">Recursive</a></li>
</ul>
</li>
<li><a href="#combinations-no-arrays-1-to-n">Combinations (no arrays, 1 to n)</a>
<ul>
<li><a href="#problems-5">Problems</a></li>
<li><a href="#recursive-5">Recursive</a></li>
</ul>
</li>
<li><a href="#combinations-of-phone-numberletters">Combinations of phone number/letters</a>
<ul>
<li><a href="#problems-6">Problems</a></li>
<li><a href="#recursive-6">Recursive</a></li>
<li><a href="#combinations-to-find-if-a-sequence-can-be-split-into-two-sub-sequences-with-equal-sum">Combinations to find if a sequence can be split into two sub sequences with equal sum</a></li>
<li><a href="#problems-7">Problems</a></li>
<li><a href="#recursive-7">Recursive</a></li>
</ul>
</li>
<li><a href="#fibonacci">Fibonacci</a>
<ul>
<li><a href="#problems-8">Problems</a></li>
<li><a href="#recursive-8">Recursive</a></li>
<li><a href="#iterative-dynamic-programming">Iterative (Dynamic Programming)</a></li>
</ul>
</li>
</ul>
</li>
</ul>

# Recursion #
## All Permutations (no map) ##
### Problems ###
- [https://leetcode.com/problems/permutations/](https://leetcode.com/problems/permutations/)
-
### Recursive ###
```
public class Solution {
    // O(n * n!), O(n * n!)
    public IList<IList<int>> Permute(int[] nums) {
        var list = new List<IList<int>>();
        if ((nums?.Length ?? 0) == 0) return list;
        Rec(nums, new bool[nums.Length], new List<int>(), list);
        return list;
    }
    // O(n * n!), O(n * n!)
    private void Rec(
        int[] nums, bool[] seen, IList<int> current, IList<IList<int>> list) {
        if (nums.Length == current.Count) {
            list.Add(current.ToList()); // O(n)
            return;
        }
        for (int i = 0; i < nums.Length; i++) { 
            if (seen[i]) continue;
            seen[i] = true;
            current.Add(nums[i]);
            Rec(nums, seen, current, list);
            current.RemoveAt(current.Count - 1);
            seen[i] = false;
        }
    }
}
```
## All permutations with duplicates (with map) ##
### Problems ###
- [https://leetcode.com/problems/permutations-ii/](https://leetcode.com/problems/permutations-ii/)
-
### Recursive ###
```
public class Solution {
    // O(n * n!), O(n * n!)
    public IList<IList<int>> PermuteUnique(int[] nums) {
        var list = new List<IList<int>>();
        var map = new Dictionary<int, int>();
        if ((nums?.Length ?? 0) == 0) return list;
        foreach (int num in nums)
            if (map.ContainsKey(num)) map[num]++;
            else map.Add(num, 1);
        Rec(map.Keys.ToArray(), map.Values.ToArray(), new List<int>(), list, nums.Length);
        return list;
    }
    // O(n * n!), O(n * n!)
    private void Rec(
        int[] choices, int[] counts, IList<int> current, IList<IList<int>> list, int target) {
        if (current.Count == target) {
            list.Add(current.ToList());
            return;
        }
        for (int i = 0; i < choices.Length; i++) {
            if (counts[i] == 0) continue;
            counts[i]--;
            current.Add(choices[i]);
            Rec(choices, counts, current, list, target);
            current.RemoveAt(current.Count - 1);
            counts[i]++;
        }
    }
}
```
## Palindrome Permutations ##
### Problems ###
- [https://leetcode.com/problems/palindrome-permutation-ii/](https://leetcode.com/problems/palindrome-permutation-ii/)
-
### Recursive ###
```
public class Solution {
    // Let's define m as n / 2
    // O(m * m! + n)
    public IList<string> GeneratePalindromes(string s) {
        if (string.IsNullOrWhiteSpace(s)) return Array.Empty<string>().ToList();
        int[] chars = new int[128];
        char? oddChar = null;
        var list = new List<string>();
        foreach (char c in s) chars[c]++;
        if (chars.Select(x => x % 2).Sum() > 1) return Array.Empty<string>().ToList();
        for (int i = 0; i < chars.Length; i++) {
            if (chars[i] % 2 == 1) {
                oddChar = (char)i;
                chars[i]--;
            }
            chars[i] /= 2;
        }
        Rec(chars, oddChar, s.Length / 2, new List<char>(), list);
        return list;
    }
    // Let's define m as n / 2
    // O(m * m!)
    private void Rec(
        int[] chars, char? oddChar, int len, IList<char> current, IList<string> list) {
        if (current.Count == len) {
            var sb = new StringBuilder();
            sb.Append(current.ToArray());
            if (oddChar != null) sb.Append(oddChar.Value);
            sb.Append(current.Reverse().ToArray());
            list.Add(sb.ToString());
            return;
        }
        for (int i = 0; i < chars.Length; i++) {
            if (chars[i] == 0) continue;
            chars[i]--;
            current.Add((char)i);
            Rec(chars, oddChar, len, current, list);
            current.RemoveAt(current.Count - 1);
            chars[i]++;
        }
    }
}
```
## All Combinations (subsets) without map ##
### Problems ###
- [https://leetcode.com/problems/subsets/](https://leetcode.com/problems/subsets/)
-
### Recursive ###
```
public class Solution {
    // O(n * 2^n), O(n * 2^n)
    public IList<IList<int>> Subsets(int[] nums) {
        var list = new List<IList<int>>();
        if ((nums?.Length ?? 0) == 0) return list;
        Rec(nums, new bool[nums.Length], 0, new List<int>(), list);
        return list;
    }
    // O(n * 2^n), O(n * 2^n)
    private void Rec(
        int[] nums, bool[] seen, int index, IList<int> current, IList<IList<int>> list) {
        if (nums.Length == index) return;
        list.Add(current.ToList());
        for (int i = index; i < nums.Length; i++) {
            if (seen[i]) continue;
            seen[i] = true;
            current.Add(nums[i]);
            Rec(nums, seen, i, current, list);
            current.RemoveAt(current.Count - 1);
            seen[i] = false;
        }
    }
}
```
### Recursive (variation without using _seen array_) ###
```
public class Solution {
    // O(n * 2^n), O(n * 2^n)
    public IList<IList<int>> Subsets(int[] nums) {
        var list = new List<IList<int>>();
        if ((nums?.Length ?? 0) == 0) return list;
        Rec(nums, 0, new List<int>(), list);
        return list;
    }
    // O(n * 2^n), O(n * 2^n)
    private void Rec(
        int[] nums, int index, IList<int> current, IList<IList<int>> list) {
        list.Add(current.ToList());
        for (int i = index; i < nums.Length; i++) {
            current.Add(nums[i]);
            Rec(nums, i + 1, current, list);
            current.RemoveAt(current.Count - 1);
        }
    }
}
```
## All Combinations (subsets) with duplicates (with map) ##
### Problems ###
- [https://leetcode.com/problems/subsets-ii/](https://leetcode.com/problems/subsets-ii/)
-
### Recursive ###
```
public class Solution {
    // O(n * 2^n), O(n * 2^n)
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        var list = new List<IList<int>>();
        var map = new Dictionary<int, int>();
        if ((nums?.Length ?? 0) == 0) return list;
        foreach (int num in nums) 
            if (map.ContainsKey(num)) map[num]++;
            else map.Add(num, 1);
        Rec(map.Keys.ToArray(), map.Values.ToArray(), 0, new List<int>(), list);
        return list;
    }
    // O(n * 2^n), O(n * 2^n)
    private void Rec(
        int[] choices, int[] counts, int index, IList<int> current, IList<IList<int>> list) {
        if (index == choices.Length) return;
        list.Add(current.ToList());
        for (int i = index; i < choices.Length; i++) {
            if (counts[i] == 0) continue;
            counts[i]--;
            current.Add(choices[i]);
            Rec(choices, counts, i, current, list);
            current.RemoveAt(current.Count - 1);
            counts[i]++;
        }
    }
}
```
## Combinations (no arrays, 1 to n) ##
### Problems ###
- [https://leetcode.com/problems/combinations/](https://leetcode.com/problems/combinations/)
-
### Recursive ###
```
public class Solution {
    // O(n * 2^n), O(n * 2^n)
    public IList<IList<int>> Combine(int n, int k) {
        var list = new List<IList<int>>();
        Rec(n, 1, k, new List<int>(), list);
        return list;
    }
    // O(k * 2^k), O(k * 2^k)
    // O(k * (n!/((n-k)!n!))), O(k * (n!/((n-k)!n!)))
    private void Rec(
        int n, int index, int k, IList<int> current, IList<IList<int>> list) {
        if (current.Count == k) list.Add(current.ToList());
        for (int i = index; i <= n; i++) {
            current.Add(i);
            if (current.Count <= k)
                Rec(n, i + 1, k, current, list);
            current.RemoveAt(current.Count - 1);
        }
    }
}
```
## Combinations of phone number/letters ##
### Problems ###
- [https://leetcode.com/problems/letter-combinations-of-a-phone-number/](https://leetcode.com/problems/letter-combinations-of-a-phone-number/)
-
### Recursive ###
```
public class Solution {
    // O((3^n) * (4^m)), O((3^n) * (4^m))
    public IList<string> LetterCombinations(string digits) {
        var list = new List<string>();
        if (string.IsNullOrWhiteSpace(digits)) return list;
        var map = new Dictionary<char, char[]>
        {
            { '2', new[] { 'a', 'b', 'c' } },
            { '3', new[] { 'd', 'e', 'f' } },
            { '4', new[] { 'g', 'h', 'i' } },
            { '5', new[] { 'j', 'k', 'l' } },
            { '6', new[] { 'm', 'n', 'o' } },
            { '7', new[] { 'p', 'q', 'r', 's' } },
            { '8', new[] { 't', 'u', 'v' } },
            { '9', new[] { 'w', 'x', 'y', 'z' } },
        };
        Rec(digits, map, 0, new List<char>(), list);
        return list;
    }
    /*
    Let's define n as the number of char numbers that contain 3 characters
    Let's define m as the number of char numbers that contain 4 characters
    O((3^n) * (4^m)), O((3^n) * (4^m))
    */
    private void Rec(
        string digits, IDictionary<char, char[]> map, int index, IList<char> current, IList<string> list) {
        if (digits.Length == current.Count) list.Add(new string(current.ToArray()));
        for (int i = index; i < digits.Length; i++) {
            char c = digits[i];
            if (c == '0' || c == '1') continue;
            for (int j = 0; j < map[c].Length; j++) {
                current.Add(map[c][j]);
                Rec(digits, map, i + 1, current, list);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
```
### Combinations to find if a sequence can be split into two sub sequences with equal sum ###
### Problems ###
- [https://leetcode.com/problems/partition-equal-subset-sum/](https://leetcode.com/problems/partition-equal-subset-sum/)
-
### Recursive ###
```
public class Solution {
    // O(2^n + n), O(n * 2^n)
    public bool CanPartition(int[] nums) {
        if((nums?.Length ?? 0) == 0) return true;
        int sum = nums.Sum();
        if (sum % 2 != 0) return false;
        return Combo(nums, 0, sum / 2, 0, new Dictionary<string, bool>());
    }
    // O(2^n + n), O(n * 2^n)
    private bool Combo(
        int[] nums, int index, int target, int runningSum, IDictionary<string, bool> memo) {
        if (target == runningSum) return true;
        if (index == nums.Length) return false;
        if (runningSum > target) return false;
        for (int i = index; i < nums.Length; i++) {
            string key = i + "#" + runningSum;
            if (memo.ContainsKey(key)) return memo[key];
            bool res = Combo(nums, i + 1, target, runningSum + nums[i], memo);
            if (res) return true;
            if (!memo.ContainsKey(key)) memo.Add(key, res);
        }
        return false;
    }
}
```
## Fibonacci ##
### Problems ###
- [https://leetcode.com/problems/fibonacci-number/](https://leetcode.com/problems/fibonacci-number/)
-
### Recursive ###
```
// O(2^n)
private int FibRec(int n) {
	if (n == 0) return 0;
	if (n == 1) return 1;
	return Fib(n - 1) + Fib(n - 2);
}
```
### Iterative (Dynamic Programming) ###
```
// O(n), O(n)
public int Fib(int N) {
	if (N <= 1) return N;
	int[] dp = new int[N + 1];
	dp[0] = 0;
	dp[1] = 1;
	for (int i = 2; i <= N; i++) dp[i] = dp[i - 1] + dp[i - 2];
	return dp[N];
}
```


