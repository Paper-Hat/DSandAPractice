using System.Text;

namespace DSandAPractice;

/// <summary>
/// Simple implementation of BST containing integer values
/// Assumes duplicate elements are not allowed
/// </summary>
public class DSA_BinarySearchTree<T> where T:IComparable
{
    //defined root
    public DSA_BinaryTreeNode<T>? Root;

    //empty constructor
    public DSA_BinarySearchTree()
    {
        
    }
    /// <summary>
    /// Allows for creating a BST sequentially with a list
    /// </summary>
    /// <param name="treeValues"></param>
    public DSA_BinarySearchTree(List<T> treeValues)
    {
        treeValues = treeValues.Distinct().ToList();
        foreach (var v in treeValues)
        {
            Insert(Root, v);
        }
    }

    public DSA_BinaryTreeNode<T>? Search(T value)
    {
        return Search(Root, value);
    }
    
    private DSA_BinaryTreeNode<T>? Search(DSA_BinaryTreeNode<T>? node, T value)
    {
        //base case is if the node's value is equal to the search value, or if our node is null
        if (node == null || node.value.Equals(value))
            return node;
        if (value.CompareTo(node.value) < 0)
            node = Search(node.LeftChild, value);
        else if (value.CompareTo(node.value) > 0)
            node = Search(node.RightChild, value);
        return node;
    }

    public DSA_BinaryTreeNode<T>? FindParentToNode(T v)
    {
        return FindParentToNode(Root, v);
    }
    
    /// <summary>
    /// Returns node parent of node with value = v
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public DSA_BinaryTreeNode<T>? FindParentToNode(DSA_BinaryTreeNode<T>? node, T v)
    {
        if (node == null || node.ChildCount() == 0 || node.LeftChild.value.Equals(v) || node.RightChild.value.Equals(v)) {
            return node;
        }
        if (v.CompareTo(node.value) < 0)
            node = FindParentToNode(node.LeftChild, v);
        else if (v.CompareTo(node.value) > 0)
            node = FindParentToNode(node.RightChild, v);
        return node;
    }
    public DSA_BinaryTreeNode<T> Insert(DSA_BinaryTreeNode<T>? node, T value)
    {
        if (Root == null) {
            Root = new DSA_BinaryTreeNode<T>(value);
            return Root;
        }
        
        if (node == null)
        {
            return new DSA_BinaryTreeNode<T>(value);
        }
        //need to set up references to children to "connect" the tree
        if (value.CompareTo(node.value) < 0)
        {
            node.LeftChild = Insert(node.LeftChild, value);
        }
        else if (value.CompareTo(node.value) > 0)
        {
            node.RightChild = Insert(node.RightChild, value);
        }
        else
        {
            Console.WriteLine("Attempted to insert a duplicate element. Denied insert.");
            return node;
        }

        return node;
    }

    public DSA_BinaryTreeNode<T> Delete(T value)
    {
        //returns modified root of BST
        return Delete(Root, value);
    }

    public DSA_BinaryTreeNode<T> Delete(DSA_BinaryTreeNode<T>? node, T v)
    {
        if (node == null)
            return node;
        if (v.CompareTo(node.value) < 0)
            node.LeftChild = Delete(node.LeftChild, v);
        else if (v.CompareTo(node.value) > 0)
            node.RightChild = Delete(node.RightChild, v);
        else{
            if (node.LeftChild == null)
                return node.RightChild;
            if (node.RightChild == null)
                return node.LeftChild;
            DSA_BinaryTreeNode<T> min = MinValue(node.RightChild);
            //replace current with min
            node.value = min.value;
            node.RightChild = Delete(node.RightChild, min.value);
        }
        return node;

    }

    /// <summary>
    /// InOrderSuccessor is required in order to delete a node from a tree which has two children
    /// To get which, we need the min value of a node
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public DSA_BinaryTreeNode<T> MinValue(DSA_BinaryTreeNode<T>? node)
    {
        if (node != null && node.LeftChild == null)
            return node;
        node = MinValue(node.LeftChild);
        return node;
    }

    public DSA_BinaryTreeNode<T> MaxValue(DSA_BinaryTreeNode<T> node)
    {
        if (node.RightChild == null) {
            return node;
        }
        node = MaxValue(node.RightChild);
        return node;
    }
    public void PrintInOrderTraversal()
    {
        PrintInOrderTraversal(Root);
    }
    private void PrintInOrderTraversal(DSA_BinaryTreeNode<T>? node)
    {
        if (node != null)
        {
            PrintInOrderTraversal(node.LeftChild);
            Console.WriteLine(node.value+" ");
            PrintInOrderTraversal(node.RightChild);
        }
    }
    
}

public class DSA_BinaryTreeNode<T> : DSA_Node<T>
{
    public DSA_BinaryTreeNode<T>? LeftChild, RightChild;
    
    public DSA_BinaryTreeNode(T v)
    {
        value = v;
        LeftChild = null;
        RightChild = null;
    }

    public int ChildCount()
    {
        int count = 0;
        if (LeftChild != null)
            count++;
        if (RightChild != null)
            count++;
        return count;
    }
    
}