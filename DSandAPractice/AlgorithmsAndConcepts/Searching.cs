namespace DSandAPractice.AlgorithmsAndConcepts;


public class Searching
{
    /// <summary>
    /// Given a sorted array, and an element to search:
    /// Split the array in half, then search halves that the element is in based on middle element comparison
    /// </summary>
    /// <param name="arr"></param>
    /// <typeparam name="T"></typeparam>
    public static int BinarySearchRecursive<T>(T[] arr, T item) where T : IComparable
    {
        return BinarySearchRecursive(arr, item, 0, arr.Length - 1);
    }

    public static int BinarySearchRecursive<T>(T[] arr, T item, int start, int end) where T : IComparable
    {
        if(start > end) return -1;
        
        int mid = start + (end - start) / 2;
        if (arr[mid].CompareTo(item) > 0) return BinarySearchRecursive(arr, item, start, mid - 1);
        else if (arr[mid].CompareTo(item) < 0) return BinarySearchRecursive(arr, item, mid + 1, end);
        else return mid;
    }

    public static int BinarySearchIterative<T>(T[] arr, T item) where T : IComparable
    {
        int low = 0;
        int high = arr.Length - 1;
        int mid;

        while (low <= high) {
            mid = low + (high - low) / 2;
            if (arr[mid].CompareTo(item) < 0) low = mid + 1;
            else if (arr[mid].CompareTo(item) > 0) high = mid - 1;
            else return mid;
        }

        return -1;
    }
}