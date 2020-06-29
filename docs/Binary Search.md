
<ul>
<li><a href="#binary-search">Binary Search</a>
<ul>
<li><a href="#templates">Templates</a>
<ul>
<li><a href="#template-1">Template 1</a></li>
<li><a href="#template-2">Template 2</a></li>
<li><a href="#template-3">Template 3</a></li>
<li><a href="#search-minimum-or-maximum">Search minimum or maximum</a></li>
<li><a href="#search-in-rotated-array">Search in rotated array</a></li>
</ul>
</li>
<li><a href="#regular-binary-search">Regular Binary Search</a>
<ul>
<li><a href="#problems">Problems</a></li>
<li><a href="#iterative">Iterative</a></li>
<li><a href="#recursive">Recursive</a></li>
</ul>
</li>
<li><a href="#find-peek-element">Find Peek element</a>
<ul>
<li><a href="#problems-1">Problems</a></li>
<li><a href="#recursive-1">Recursive</a></li>
<li><a href="#iterative-1">Iterative</a></li>
</ul>
</li>
<li><a href="#search-in-rotated-array-1">Search in rotated array</a>
<ul>
<li><a href="#problems-2">Problems</a></li>
<li><a href="#iterative-2">Iterative</a></li>
</ul>
</li>
<li><a href="#minimum-in-rotated-array-no-duplicates">Minimum in rotated array (no duplicates)</a>
<ul>
<li><a href="#problems-3">Problems</a></li>
<li><a href="#iterative-3">Iterative</a></li>
</ul>
</li>
<li><a href="#find-first-and-last-position">Find first and last position</a>
<ul>
<li><a href="#problems-4">Problems</a></li>
<li><a href="#iterative-4">Iterative</a></li>
</ul>
</li>
</ul>
</li>
</ul>

# Binary Search #
## Templates ##
![enter image description here](https://leetcode.com/explore/learn/card/binary-search/136/template-analysis/Figures/binary_search/Template_Diagram.png)
### Template 1 ###
```
public int Search(int[] nums, int target) {
	int min = 0;
	int max = nums.Length - 1;
	while (min <= max) {
		int mid = min + (max - min) / 2;
		if (target < nums[mid]) {
			max = mid - 1;
		}
		else if (target > nums[mid]) {
			min = mid + 1;
		}
		else {
			return mid;
		};
	}
	return -1;
}
```
### Template 2 ###
```
public int FirstBadVersion(int n) {
	int min = 1;
	int max = n;
	while (min < max) {
		int mid = min + (max - min) / 2;
		if (!IsBadVersion(mid)) {
			min = mid + 1;
		}
		else {
			max = mid;
		}
	}
	return min;
}
```
### Template 3 ###
```
int binarySearch(int[] nums, int target) {
    if (nums == null || nums.length == 0)
        return -1;

    int left = 0, right = nums.length - 1;
    while (left + 1 < right){
        // Prevent (left + right) overflow
        int mid = left + (right - left) / 2;
        if (nums[mid] == target) {
            return mid;
        } else if (nums[mid] < target) {
            left = mid;
        } else {
            right = mid;
        }
    }

    // Post-processing:
    // End Condition: left + 1 == right
    if(nums[left] == target) return left;
    if(nums[right] == target) return right;
    return -1;
}
```
### Search minimum or maximum ###
```
private int Find(int[] nums, int target, bool first) {
	int min = 0;
	int max = nums.Length - 1;
	int index = -1;
	while (min <= max) {
		int mid = min + (max - min) / 2;
		if (target < nums[mid]) {
			max = mid - 1;
		}
		else if (target > nums[mid]) {
			min = mid + 1;
		}
		else {
			index = mid;
			if (first) {
				max = mid - 1;
			}
			else {
				min = mid + 1;
			}
		}
	}
	return index;
}
```
### Search in rotated array ###
```
public class Solution {
    public int Search(int[] nums, int target) {
        int min = 0;
        int max = nums.Length - 1;
        while (min <= max) {
            int mid = min + (max - min) / 2;
            if (nums[mid] == target) {
                return mid;
            }
            if (nums[min] == target) {
                return min;
            }
            if (nums[max] == target) {
                return max;
            }
            bool isLeftSorted = nums[min] <= nums[mid];
            bool isRightSorted = nums[mid] <= nums[max];
            bool isNumberOnLeft = target >= nums[min] && target <= nums[mid];
            bool isNumberOnRight = target >= nums[mid] && target <= nums[max];
            if (isLeftSorted && isNumberOnLeft) {
                max = mid - 1;
            }
            else if (isRightSorted && isNumberOnRight) {
                min = mid + 1;
            }
            else if (!isLeftSorted && isRightSorted) {
                max = mid - 1;
            }
            else if (isLeftSorted && !isRightSorted) {
                min = mid + 1;
            }
            else {
                min++;
                max--;
            }
	    }
	    return -1;
    }
}
```
## Regular Binary Search ##
### Problems ###
- [https://leetcode.com/problems/binary-search/](https://leetcode.com/problems/binary-search/)
-
### Iterative ###
```
public class Solution {
    public int Search(int[] nums, int target) {
        int min = 0;
        int max = nums.Length - 1;
        while (min <= max) {
            int mid = min + (max - min) / 2;
            if (target < nums[mid]) {
                max = mid - 1;
            }
            else if (target > nums[mid]) {
                min = mid + 1;
            }
            else {
                return mid;
            };
        }
        return -1;
    }
}
```
### Recursive ###
```
public class Solution {
    public int Search(int[] nums, int target) {
        return Rec(nums, target, 0, nums.Length - 1);
    }
    private int Rec(int[] nums, int target, int min, int max) {
        if (min > max) {
            return -1;
        }
        int mid = min + (max - min) / 2;
        if (target < nums[mid]) {
            return Rec(nums, target, min, mid - 1);
        }
        if (target > nums[mid]) {
            return Rec(nums, target, mid + 1, max);
        }
        return mid;
    }
}
```
## Find Peek element ##
### Problems ###
- [https://leetcode.com/problems/find-peak-element/](https://leetcode.com/problems/find-peak-element/)
-
### Recursive ###
```
public class Solution {
    public int FindPeakElement(int[] nums) {
        return Search(nums, 0, nums.Length - 1);
    }
    private int Search(int[] nums, int min, int max) {
        if (min >= max) {
            return min;
        }
        int mid = min + (max - min) / 2;
        int middle = nums[mid];
        int left = mid - 1 >= 0 ? nums[mid - 1] : int.MinValue;
        int right = mid + 1 < nums.Length ? nums[mid + 1] : int.MinValue;
        if (left < middle && right < middle) {
            return mid;
        }
        // both conditions work
        // if (middle <= right) {
        //     return Search(nums, mid + 1, max);
        // }
        // return Search(nums, min, mid);
        if (left > middle) {
            return Search(nums, min, mid - 1);
        }
        return Search(nums, mid + 1, max);
    }
}
```
### Iterative ###
```
public class Solution {
    public int FindPeakElement(int[] nums) {
        int min = 0;
        int max = nums.Length - 1;
        while (min < max) {
            int mid = min + (max - min) / 2;
            int middle = nums[mid];
            int left = mid - 1 >= 0 ? nums[mid - 1] : int.MinValue;
            int right = mid + 1 < nums.Length ? nums[mid + 1] : int.MinValue;
            if (left < middle && right < middle) {
                return mid;
            }
            if (left > middle) {
                max = mid - 1;
            }
            else {
                min = mid + 1;
            }
        }
        return min;
    }
}
```
## Search in rotated array ##
### Problems ###
- [https://leetcode.com/problems/search-in-rotated-sorted-array/](https://leetcode.com/problems/search-in-rotated-sorted-array/)
- [https://leetcode.com/problems/search-in-rotated-sorted-array-ii/](https://leetcode.com/problems/search-in-rotated-sorted-array-ii/)
- 
### Iterative ###
```
public class Solution {
    public int Search(int[] nums, int target) {
        int min = 0;
        int max = nums.Length - 1;
        while (min <= max) {
            int mid = min + (max - min) / 2;
            if (nums[mid] == target) {
                return mid;
            }
            if (nums[min] == target) {
                return min;
            }
            if (nums[max] == target) {
                return max;
            }
            bool isLeftSorted = nums[min] <= nums[mid];
            bool isRightSorted = nums[mid] <= nums[max];
            bool isNumberOnLeft = target >= nums[min] && target <= nums[mid];
            bool isNumberOnRight = target >= nums[mid] && target <= nums[max];
            if (isLeftSorted && isNumberOnLeft) {
                max = mid - 1;
            }
            else if (isRightSorted && isNumberOnRight) {
                min = mid + 1;
            }
            else if (!isLeftSorted && isRightSorted) {
                max = mid - 1;
            }
            else if (isLeftSorted && !isRightSorted) {
                min = mid + 1;
            }
            else {
                min++;
                max--;
            }
	    }
	    return -1;
    }
}
```
## Minimum in rotated array (no duplicates) ##
### Problems ###
- [https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/](https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/)
-
### Iterative ###
```
public int FindMin(int[] nums) {
	if (nums.Length == 1) {
		return nums[0];
	}
	int min = 0;
	int max = nums.Length - 1;
	if (nums[max] > nums[0]) {
		return nums[0];
	}
	while (min <= max) {
		int mid = min + (max - min) / 2;
		if (mid + 1 < nums.Length && nums[mid] > nums[mid + 1]) {
			return nums[mid + 1];
		}
		if (mid - 1 >= 0 && nums[mid - 1] > nums[mid]) {
			return nums[mid];
		}
		if (nums[mid] > nums[0]) {
			min = mid + 1;
		}
		else {
			max = mid - 1;
		}
	}
	return -1;
}
```
## Find first and last position ##
### Problems ###
- [https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/](https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/)
-
### Iterative ###
```
public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        return new[] { Find(nums, target, true), Find(nums, target, false) };
    }
    private int Find(int[] nums, int target, bool first) {
        int min = 0;
        int max = nums.Length - 1;
        int index = -1;
        while (min <= max) {
            int mid = min + (max - min) / 2;
            if (target < nums[mid]) {
                max = mid - 1;
            }
            else if (target > nums[mid]) {
                min = mid + 1;
            }
            else {
                index = mid;
                if (first) {
                    max = mid - 1;
                }
                else {
                    min = mid + 1;
                }
            }
        }
        return index;
    }
}
```


