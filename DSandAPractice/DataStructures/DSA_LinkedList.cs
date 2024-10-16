﻿using System.Text;

namespace DSandAPractice.Structures;

/// <summary>
/// Practice implementation of a LinkedList of integers
/// </summary>
public class DSA_LinkedList<T>
{
    public DSA_LinkedListNode<T>? Head = null;
    public DSA_LinkedListNode<T>? Tail = null;
    public DSA_LinkedList()
    {
        
    }
    
    public DSA_LinkedList(List<T> starterValues)
    {
        foreach (var value in starterValues) {
            Add(value);
        }
    }

    /// <summary>
    /// Creates a new linked list woven together from runners on a linkedList iterating at different "speeds"
    /// </summary>
    /// <param name="firstList"></param>
    /// <param name="runner1"></param>
    /// <param name="runner2"></param>
    public DSA_LinkedList(DSA_LinkedList<T> firstList, int runner1, int runner2)
    {
        DSA_LinkedListNode<T>? root = firstList.Head;
        int iter1 = runner1;
        int iter2 = runner2;
        while (root != null) {
            iter1--;
            iter2--;
            if (iter1 == 0) {
                Add(root.value);
                iter1 = runner1;
            }
            if (iter2 == 0) {
                Add(root.value);
                iter2 = runner2;
            }
            root = root.next;
        }
    }
    
    public void Add(T value)
    {
        if (Head == null) {
            Head = new DSA_LinkedListNode<T>(value);
            Tail = Head;
            return;
        }
        DSA_LinkedListNode<T> currentRef = Head;
        while (currentRef.next != null) {
            currentRef = currentRef.next;
        }
        currentRef.next = new DSA_LinkedListNode<T>(value);
        Tail = currentRef.next;

    }
    
    /// <summary>
    /// Inserts node with value = v at index i if length is supported
    /// </summary>
    /// <param name="value"></param>
    public void Insert(T v, int i)
    {
        if (Head == null)
        {
            if (i == 0)
                Head = new DSA_LinkedListNode<T>(v);
        }
        else if (i == 0)
        {
            DSA_LinkedListNode<T> temp = Head;
            Head = new DSA_LinkedListNode<T>(v);
            Head.next = temp;
        }
        else
        {
            int count = 0;
            DSA_LinkedListNode<T> current = Head;
            while (current.next != null && count <= i)
            {
                if (count+1 == i)
                {
                    DSA_LinkedListNode<T> temp = current.next;
                    current.next = new DSA_LinkedListNode<T>(v);
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
    public void RemoveElementWithValue(T value)
    {
        if (Head == null) {
            Console.WriteLine("Head is null. Cannot perform remove on LinkedList with no elements");
        }
        else if (Head.value.Equals(value))
        {
            if (Head.next != null) {
                Head = Head.next;
            }
        }
        else {
            DSA_LinkedListNode<T> current = Head;

            while (current.next != null)
            {
                if (current.next.value.Equals(value)) {
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
    
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        DSA_LinkedListNode<T>? current = Head;
        while (current != null)
        {
            sb.Append(current.value);
            if (current.next != null)
                sb.Append("-");
            current = current.next;
        }
        
        return sb.ToString();
    }

    public T? Get(T value)
    {
        DSA_LinkedListNode<T?> node = Head;
        while (node != null) {
            if (node.value.Equals(value)) break;
            node = node.next;
        }
        return node.value;
    }
    
    
}

public class DSA_LinkedListNode<T> : DSA_Node<T>
{
    public DSA_LinkedListNode<T> next;
    public DSA_LinkedListNode(T v)
    {
        value = v;
    }
}