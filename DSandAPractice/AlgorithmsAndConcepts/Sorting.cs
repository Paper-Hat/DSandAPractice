using System.Text;

namespace DSandAPractice.AlgorithmsAndConcepts;

public static class Sorting
{
    #region Sorting_Algorithms
    /// <summary>
    /// Swaps first two elements n and m if n > m
    /// Continues to swap, passing until sorted
    /// </summary>
    /// <param name="arr"></param>
    /// <typeparam name="T"></typeparam>
    public static void BubbleSort<T>(T[] arr) where T : IComparable
    {
        bool sorted = false;
        int len = arr.Length - 1;
        //iterate until sorted
        while (!sorted) {
            //assume sorted until proven otherwise
            sorted = true;
            for (int i = 0; i < len; i++) {
                if (arr[i].CompareTo(arr[i + 1]) <= 0) continue;
                sorted = false;
                //Deconstruction achieves the same result as the code below.
                (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]);
                /*T temp = arr[i];
                //arr[i] = arr[i + 1];
                arr[i + 1] = temp;*/
            }    
        }
    }

    /// <summary>
    /// Scans the array for the smallest element, picking them in ascending order
    /// </summary>
    /// <param name="arr"></param>
    /// <typeparam name="T"></typeparam>
    public static void SelectionSort<T>(T[] arr) where T : IComparable
    {
        for (int i = 0; i < arr.Length; i++) {
            //Swap the array value with the next smallest item in the array
            T temp = arr[i];
            int smallest = GetMin(arr, i);
            arr[i] = arr[smallest];
            arr[smallest] = temp;
        }
    }

    /// <summary>
    /// Takes a list of elements and "splits" it into two
    /// Using a helper, recursively sort both halves while iterating until no elements remain
    /// Marge the sorted halves by comparing elements in the left to the right and picking smaller element
    /// </summary>
    /// <param name="arr"></param>
    /// <typeparam name="T"></typeparam>
    public static void MergeSort<T>(T[] arr) where T : IComparable
    {
        T[] helper = new T[arr.Length];
        MergeSort(arr, helper, 0, arr.Length - 1);
    }
    private static void MergeSort<T>(T[] arr, T[] helper, int left, int right) where T : IComparable
    {
        if (left >= right) return;
        int mid = left + (right - left) / 2;
        MergeSort(arr, helper, left, mid);
        MergeSort(arr, helper, mid + 1, right);
        Merge(arr, helper, left, mid, right);
    }
    private static void Merge<T>(T[] arr, T[] helper, int left, int mid, int right) where T : IComparable
    {
        for(int i = left; i <= right; i++){ helper[i] = arr[i]; }

        int leftHelper = left;
        int rightHelper = mid + 1;
        int current = left;

        while (leftHelper <= mid && rightHelper <= right) {
            //If our element in the left half is smaller than the element in right half, set to smaller item
            //and increment helper on the side of smaller value
            if (helper[leftHelper].CompareTo(helper[rightHelper]) <= 0) {
                arr[current] = helper[leftHelper];
                leftHelper++;
            }
            else {
                arr[current] = helper[rightHelper];
                rightHelper++;
                
            }
            current++;
        }
        
        //copy remaining from the left side
        int remaining = mid - leftHelper;
        for (int i = 0; i <= remaining; i++) {
            arr[current + i] = helper[leftHelper + i];
        }
    }

    /// <summary>
    /// Sorting a list recursively using a pivot;
    /// Until there are no unsorted items left, pick a random pivot in the unsorted range and swap
    /// items on the left side if they are larger than items on the right side
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="useRandom"></param>
    /// <typeparam name="T"></typeparam>
    public static void QuickSort<T>(T[] arr, bool useRandom = false) where T : IComparable
    {
        QuickSort(arr, 0, arr.Length - 1, useRandom);
    }

    private static void QuickSort<T>(T[] arr, int low, int high, bool useRandom = false) where T : IComparable
    {
        int index = Partition(arr, low, high, useRandom);
        //if we still have a left range to sort, quicksort items less than pivot
        if(low < index - 1) QuickSort(arr, low, index - 1, useRandom);
        //if we still have a right range to sort, quicksort items to the right of the pivot
        if(index < high) QuickSort(arr, index, high, useRandom);
    }
    
    /// <summary>
    /// Partition by picking a pivot and incrementing and decrementing indexes on either side of it
    /// We "ignore" already-sorted items by incrementing the left index
    /// Returns the incremented left index when we've searched the current range for viable swaps
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="low"></param>
    /// <param name="high"></param>
    /// <param name="useRandom"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    private static int Partition<T>(T[] arr, int low, int high, bool useRandom = false) where T : IComparable
    {
        T pivot;
        //get pivot between low and high values (inclusive)
        if (useRandom) {
            //random is technically the best runtime
            Random random = new Random(); 
            pivot = arr[random.Next(low, high+1)];
        }
        else {
            //median pivot
            pivot = arr[low + (high - low) / 2];
        }

        //Try to find elements on one side larger than another on either side of pivot in the array
        while (low <= high) {
            while (arr[low].CompareTo(pivot) < 0) low++;
            while (arr[high].CompareTo(pivot) > 0) high--;
            //if we find them, swap them and move next
            if (low <= high) {
                (arr[low], arr[high]) = (arr[high], arr[low]);
                low++;
                high--;
            }
        }
        return low;
    }

    /// <summary>
    /// Sorts a list of integers by each individual element's digits
    /// </summary>
    /// <param name="arr"></param>
    public static void RadixSort(int[] arr)
    {
        int len = arr.Length;
        int max = GetMax(arr, len);
        for (int exp = 1; max/exp > 0; exp *= 10) {
            CountingSort(arr, len, exp);
        }
        
    }

    private static void CountingSort(int[] arr, int len, int exp)
    {
        int i;
        int[] output = new int[len];
        int[] count = new int[10];
        for (i = 0; i < 10; i++) count[i] = 0;
        //count occurrences of digit
        for (i = 0; i < len; i++) count[(arr[i] / exp) % 10]++;
        //modify count s.t. each index contains number of digits
        for (i = 1; i < 10; i++) count[i] += count[i - 1];
        //set output's index at digit position from the back to the array at index
        //Then decrement count at the index used
        for (i = len - 1; i >= 0; i--) {
            output[count[(arr[i] / exp) % 10] - 1] = arr[i];
            count[(arr[i] / exp) % 10]--;
        }
        for(i = 0; i < len;i++) arr[i] = output[i];
    }
    #endregion
    
    #region Helpers
    public static int GetMin<T>(T[] arr, int fromIndex = 0) where T : IComparable
    {
        T min = arr[fromIndex];
        int minIndex = fromIndex;
        for (int i = fromIndex; i < arr.Length; i++) {
            //if min value is greater than what we're checking against
            if (min.CompareTo(arr[i]) > 0) {
                min = arr[i];
                minIndex = i;
            }
        }
        return minIndex;
    }
    public static T GetMax<T>(T[] arr, int length = -1) where T : IComparable
    {
        if(length == -1) length = arr.Length;
        T max = arr[0];
        for (int i = 0; i < length; i++) {
            if (max.CompareTo(arr[i]) < 0)
                max = arr[i];
        }

        return max;
    }
    public static void PrintList<T>(T[] arr)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in arr) {
            sb.AppendFormat("{0} ", item);
            
        }
        Console.WriteLine(sb.ToString());
    }
    #endregion
}