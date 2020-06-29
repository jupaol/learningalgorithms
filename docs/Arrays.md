
<ul>
<li><a href="#arrays">Arrays</a>
<ul>
<li><a href="#rotate-array">Rotate Array</a>
<ul>
<li><a href="#problems">Problems</a></li>
<li><a href="#iterative">Iterative</a></li>
</ul>
</li>
<li><a href="#merge-intervals">Merge Intervals</a>
<ul>
<li><a href="#problems-1">Problems</a></li>
<li><a href="#notes">Notes:</a></li>
<li><a href="#iterative--sorting">Iterative / Sorting</a></li>
</ul>
</li>
<li><a href="#insert-interval">Insert Interval</a>
<ul>
<li><a href="#problems-2">Problems</a></li>
<li><a href="#iterative-1">Iterative</a></li>
</ul>
</li>
</ul>
</li>
</ul>

# Arrays #
## Rotate Array ##
### Problems ###
- [https://leetcode.com/problems/rotate-array/](https://leetcode.com/problems/rotate-array/)
-
### Iterative ###
```
public class Solution {
    public void Rotate(int[] nums, int k) {
        if ((nums?.Length ?? 0) == 0) {
            return;
        }
        int offset = k % nums.Length;
        if (offset == 0) {
            return;
        }
        if (offset < 0) {
            offset += len;
        }
        Reverse(nums, 0, nums.Length - 1);
        Reverse(nums, 0, offset - 1);
        Reverse(nums, offset, nums.Length - 1);
    }
    private void Reverse(int[] nums, int min, int max) {
        while (min < max) {
            Swap(nums, min++, max--);
        }
    }
    private void Swap(int[] nums, int i1, int i2) {
        int tmp = nums[i1];
        nums[i1] = nums[i2];
        nums[i2] = tmp;
    }
}
```
## Merge Intervals ##
### Problems ###
- [https://leetcode.com/problems/merge-intervals/](https://leetcode.com/problems/merge-intervals/)
-
### Notes: ###
How to check if two intervals overlap: (took it from the leetcode solution)
(A, B) and (C, D) (it doesn't matter the order)
A <= D && C <= B
### Iterative / Sorting ###
```
public class Interval
{
	public int Start;
	public int End;
	public Interval(int start, int end) {
		Start = start;
		End = end;
	}
	public override string ToString() {
		return string.Format("({0}, {1})", Start, End);
	}
}
public class Solution {
    public int[][] Merge(int[][] intervals) {
        var list = new List<Interval>();
        var sorted = intervals
            .Select(x => new Interval(x[0], x[1]))
            .OrderBy(x => x.Start)
            .ThenBy(x => x.End);
        foreach (Interval curr in sorted) {
            if (list.Count == 0) {
                list.Add(curr);
                continue;
            }
            Interval last = list.Last();
            if (curr.Start <= last.End && last.Start <= curr.End) {
                last.Start = Math.Min(last.Start, curr.Start);
                last.End = Math.Max(last.End, curr.End);
            }
            else {
                list.Add(curr);
            }
        }
        return list.Select(x => new[] { x.Start, x.End }).ToArray();
    }
}
```
## Insert Interval ##
### Problems ###
- [https://leetcode.com/problems/insert-interval/](https://leetcode.com/problems/insert-interval/)
-
### Iterative ###
```
public class Interval
{
    public int Start { get; set; }
    public int End { get; set; }
    public Interval(int start, int end) {
        Start = start;
        End = end;
    }
    public override string ToString() => $"({Start}, {End})";
}
public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        var list = new List<Interval>();
        var toInsert = new Interval(newInterval[0], newInterval[1]);
        bool merged = false;
        foreach (Interval curr in intervals.Select(x => new Interval(x[0], x[1]))) {
            if (!merged) {
                if (toInsert.Start <= curr.End && curr.Start <= toInsert.End) {
                    curr.Start = Math.Min(toInsert.Start, curr.Start);
                    curr.End = Math.Max(toInsert.End, curr.End);
                    merged = true;
                }
                else if (toInsert.End < curr.Start) {
                    list.Add(toInsert);
                    merged = true;
                }
            }
            if (list.Count == 0) {
                list.Add(curr);
                continue;
            }
            Interval last = list.Last();
            if (curr.Start <= last.End && last.Start <= curr.End) {
                last.Start = Math.Min(curr.Start, last.Start);
                last.End = Math.Max(curr.End, last.End);
            }
            else {
                list.Add(curr);
            }
        }
        if (!merged) {
            list.Add(toInsert);
        }
        return list.Select(x => new[] { x.Start, x.End }).ToArray();
    }
}
```


