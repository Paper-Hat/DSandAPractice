using System.Text;

namespace DSandAPractice;

/// <summary>
/// Practice implementation of a LinkedList of integers
/// </summary>
public class DSA_LinkedList
{
    private DSA_LinkedListNode? _head = null;

    public DSA_LinkedList()
    {
        
    }
    public DSA_LinkedList(List<int> starterValues)
    {
        foreach (int value in starterValues) {
            Add(value);
        }
    }
    public void Add(int value)
    {
        if (_head == null) {
            _head = new DSA_LinkedListNode(value);
            return;
        }
        DSA_LinkedListNode currentRef = _head;
        while (currentRef.next != null) {
            currentRef = currentRef.next;
        }
        currentRef.next = new DSA_LinkedListNode(value);

    }
    
    /// <summary>
    /// Inserts node with value = v at index i if length is supported
    /// </summary>
    /// <param name="value"></param>
    public void Insert(int v, int i)
    {
        if (_head == null)
        {
            if (i == 0)
                _head = new DSA_LinkedListNode(v);
        }
        else if (i == 0)
        {
            DSA_LinkedListNode temp = _head;
            _head = new DSA_LinkedListNode(v);
            _head.next = temp;
        }
        else
        {
            int count = 0;
            DSA_LinkedListNode current = _head;
            while (current.next != null && count <= i)
            {
                if (count+1 == i)
                {
                    DSA_LinkedListNode temp = current.next;
                    current.next = new DSA_LinkedListNode(v);
                    current.next.next = temp;
                    return;
                }
                current = current.next;
                count++;
            }
            Console.WriteLine("Could not reach specified index.");
        }
        
        
    }
    /// <summary>
    /// Removes the first element with value specified; if none, prints that no elements were removed.
    /// </summary>
    /// <param name="value"></param>
    public void RemoveElementWithValue(int value)
    {
        if (_head == null) {
            Console.WriteLine("Head is null. Cannot perform remove on LinkedList with no elements");
        }
        else if (_head.value == value)
        {
            if (_head.next != null) {
                _head = _head.next;
            }
        }
        else {
            DSA_LinkedListNode current = _head;

            while (current.next != null)
            {
                if (current.next.value == value) {
                    if (current.next.next != null) {
                        current.next = current.next.next;
                        break;
                    }

                    current.next = null;
                    break;
                }

                current = current.next;
            }
            Console.WriteLine("Element not found.");
        }
    }

    /// <summary>
    /// Removes the last node in the LinkedList
    /// </summary>
    public void RemoveLast()
    {
        if (_head == null) {
            Console.WriteLine("Head is null. Cannot perform remove on LinkedList with no elements");
        }
        else if(_head.next == null)
        {
            _head = null;
        }
        else
        {
            DSA_LinkedListNode current = _head;
            while (current.next != null) {
                if (current.next.next == null)
                {
                    current.next = null;
                    break;
                }
                current = current.next;
            }
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        DSA_LinkedListNode? current = _head;
        while (current != null)
        {
            sb.Append(current.value);
            if (current.next != null)
                sb.Append("-");
            current = current.next;
        }
        
        return sb.ToString();
    }
    
}

public class DSA_LinkedListNode
{
    public DSA_LinkedListNode? next = null;
    public int value;

    public DSA_LinkedListNode(int v)
    {
        value = v;
    }
}