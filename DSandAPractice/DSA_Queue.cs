using System.Text;

namespace DSandAPractice.Structures;

public class DSA_Queue<T>
{
    private DSA_LinkedList<T> _queue = new DSA_LinkedList<T>();
    
    public DSA_Queue()
    {
        
    }

    public DSA_Queue(T starterValue)
    {
        _queue.Add(starterValue);
    }

    public DSA_Queue(List<T> preInitList)
    {
        foreach(var v in preInitList) _queue.Add(v);
    }

    public void Enqueue(T value)
    {
        _queue.Add(value);
    }

    public T Dequeue()
    {
        DSA_LinkedListNode<T> node = _queue.Head;
        if (_queue.Head.next == null) {
            _queue.Tail = null;
        }
        _queue.Head = _queue.Head.next;
        return node.value;
    }

    public T Peek()
    {
        return _queue.Head.value;
    }

    public bool IsEmpty()
    {
        return _queue.Head == null;
    }
    
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        DSA_LinkedListNode<T>? node = _queue.Head;
        if (node == null) return "Queue is Empty.";
        sb.Append(node.value);
        while (node.next != null)
        {
            sb.Append(' ');
            sb.Append(node.next.value);
            node = node.next;
        }

        return sb.ToString();
    }
}