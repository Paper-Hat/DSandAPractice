namespace DSandAPractice.Structures;

public class DSA_HashMap<T>
{
    private DSA_LinkedList<KeyValuePair<int, T>>[] data;
    public DSA_HashMap(int size = 10)
    {
        data = new DSA_LinkedList<KeyValuePair<int,T>>[size];
        for (int i = 0; i < data.Length; i++) {
            data[i] = new DSA_LinkedList<KeyValuePair<int, T>>();
        }
    }

    private int MapToIndex(int key)
    {
        return key.GetHashCode() % (data.Length - 1);
    }
    
    public void Add(KeyValuePair<int, T> item)
    {
        data[MapToIndex(item.Key)].Add(item);
    }

    public KeyValuePair<int, T>? Get(int key)
    {
        DSA_LinkedList<KeyValuePair<int, T>> toSearch = data[MapToIndex(key)];
        DSA_LinkedListNode<KeyValuePair<int, T>>? node = toSearch.Head;
        while (node != null) {
            if (node.value.Key == key) return node.value;
            node = node.next;
        }
        return null;

    }
    
}