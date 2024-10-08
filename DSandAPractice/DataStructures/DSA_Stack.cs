namespace DSandAPractice.Structures;

/// <summary>
/// Implementation of a stack using our previous DSA_LinkedList
/// </summary>
public class DSA_Stack<T>
{
    private DSA_LinkedList<T> _stack = new DSA_LinkedList<T>();
    
    public DSA_Stack()
    {
        
    }

    public DSA_Stack(T starterValue)
    {
        Push(starterValue);
    }
    
    public DSA_Stack(List<T> preInitList)
    {
        foreach(var v in preInitList)
            Push(v);
    }

    //Will always add a node to the end of the LinkedList with a given value
    public void Push(T value)
    {
        _stack.Add(value);
    }

    //Will always remove (and return) the last element in the LinkedList
    public T Pop()
    {
        DSA_LinkedListNode<T>? node = _stack.Head;
        DSA_LinkedListNode<T>? temp = null;
        if (node == null)
        {
            Console.WriteLine("No nodes to pop. Head was null.");
        }
        else
        {
            while (node.next != null) {
                if (node.next.next == null) {
                    _stack.Tail = node;
                    temp = node.next;
                    node.next = null;
                    break;
                }
                node = node.next;
            }
        }
        return temp.value;
    }

    public T? Peek()
    {
        return _stack.Tail.value;
    }
    
    public bool IsEmpty()
    {
        return _stack.Head == null;
    }
}