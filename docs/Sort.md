
<ul>
<li><a href="#sort">Sort</a>
<ul>
<li><a href="#sort-an-array">Sort an array</a>
<ul>
<li><a href="#problems">Problems</a></li>
<li><a href="#multiple-sort">Multiple sort</a></li>
</ul>
</li>
</ul>
</li>
</ul>

# Sort #
## Sort an array ##
### Problems ###
- [https://leetcode.com/problems/sort-an-array/](https://leetcode.com/problems/sort-an-array/)
-
### Multiple sort ###
```
public class Solution {
    public int[] SortArray(int[] nums) {
        if ((nums?.Length ?? 0) == 0) {
            return new int[0];
        }
        // Bubble(nums);
        // Insert(nums);
        // Select(nums);
        QuickSort(nums);
        // QuickSortRec(nums, 0, nums.Length - 1);
        // nums = MergeSortRec(nums);
        // HeapSort(nums);
        return nums;
    }
    private void HeapSort(int[] nums) {
        if (nums.Length == 1) {
            return;
        }
        int len = nums.Length;
        BuildMaxHeap(nums);
        for (int i = len - 1; i >= 2; i--) {
            Swap(nums, i, 0);
            SiftDown(nums, --len, 0);
        }
        Swap(nums, 0, 1);
    }
    private void BuildMaxHeap(int[] nums) {
        int mid = nums.Length / 2;
        for (int i = mid; i >= 0; i--) {
            SiftDown(nums, nums.Length, i);
        }
    }
    private void SiftDown(int[] nums, int len, int parent) {
        while (parent >= 0 && parent < len) {
            int leftIndex = 2 * parent + 1;
            int rightIndex = 2 * parent + 2;
            int? left = leftIndex >= 0 && leftIndex < len ? nums[leftIndex] : (int?)null;
            int? right = rightIndex >= 0 && rightIndex < len ? nums[rightIndex] : (int?)null;
            int maxIndex = -1;
            if (left == null && right == null) {
                return;
            }
            if (left != null && right != null) {
                if (left.Value >= right.Value) {
                    maxIndex = leftIndex;
                }
                else {
                    maxIndex = rightIndex;
                }
            }
            else {
                maxIndex = leftIndex;
            }
            if (nums[maxIndex] > nums[parent]) {
                Swap(nums, parent, maxIndex);
            }
            parent = maxIndex;
        }
    }
    private int[] MergeSortRec(int[] nums) {
        if (nums.Length == 1) {
            return nums;
        }
        int mid = nums.Length / 2;
        int[] left = MergeSortRec(nums.Take(mid).ToArray());
        int[] right = MergeSortRec(nums.Skip(mid).ToArray());
        return Merge(left, right);
    }
    private int[] Merge(int[] left, int[] right) {
        int[] res = new int[left.Length + right.Length];
        int i = 0;
        int j = 0;
        int k = 0;
        while (i < left.Length && j < right.Length) {
            if (left[i] <= right[j]) {
                res[k++] = left[i++];
            }
            else {
                res[k++] = right[j++];
            }
        }
        while (i < left.Length) {
            res[k++] = left[i++];
        }
        while (j < right.Length) {
            res[k++] = right[j++];
        }
        return res;
    }
    private void QuickSortRec(int[] nums, int min, int max) {
        if (min < 0 || max >= nums.Length || min >= max) {
            return;
        }
        var random = new Random((int)DateTime.Now.Ticks);
        int randomIndex = random.Next(min, max);
        Swap(nums, max, randomIndex);
        int pivot = GetPivot(nums, min, max);
        QuickSortRec(nums, min, pivot - 1);
        QuickSortRec(nums, pivot + 1, max);
    }
    private void QuickSort(int[] nums) {
        var random = new Random((int)DateTime.Now.Ticks);
        var queue = new Queue<int>();
        queue.Enqueue(0);
        queue.Enqueue(nums.Length - 1);
        while (queue.Count > 0) {
            int min = queue.Dequeue();
            int max = queue.Dequeue();
            int randomIndex = random.Next(min, max);
            Swap(nums, randomIndex, max);
            int pivot = GetPivot(nums, min, max);
            if (pivot - 1 > min) {
                queue.Enqueue(min);
                queue.Enqueue(pivot - 1);
            }
            if (pivot + 1 < max) {
                queue.Enqueue(pivot + 1);
                queue.Enqueue(max);
            }
        }
    }
    private int GetPivot(int[] nums, int min, int max) {
        int hole = min;
        int pivot = nums[max];
        for (int i = min; i < max; i++) {
            if (nums[i] <= pivot) {
                Swap(nums, i, hole);
                hole++;
            }
        }
        Swap(nums, hole, max);
        return hole;
    }
    private void Select(int[] nums) {
        for (int i = 0; i < nums.Length; i++) {
            int min = i;
            for (int j = i + 1; j < nums.Length; j++) {
                if (nums[j] < nums[min]) {
                    min = j;
                }
            }
            Swap(nums, min, i);
        }
    }
    private void Insert(int[] nums) {
        for (int i = 1; i < nums.Length; i++) {
            int holeValue = nums[i];
            int hole = i;
            while (hole > 0 && nums[hole - 1] > holeValue) {
                nums[hole] = nums[hole - 1];
                hole--;
            }
            nums[hole] = holeValue;
        }
    }
    private void Bubble(int[] nums) {
        for (int i = 0; i < nums.Length - 1; i++) {
            bool swapped = false;
            for (int j = 1; j < nums.Length; j++) {
                if (nums[j - 1] > nums[j]) {
                    Swap(nums, j - 1, j);
                    swapped = true;
                }
            }
            if (!swapped) {
                break;
            }
        }
    }
    private void Swap(int[] nums, int i1, int i2) {
        int tmp = nums[i1];
        nums[i1] = nums[i2];
        nums[i2] = tmp;
    }
}
```


