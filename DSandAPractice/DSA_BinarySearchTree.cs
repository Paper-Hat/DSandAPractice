using System.Text;

namespace DSandAPractice;

/// <summary>
/// Simple implementation of BST containing integer values
/// Assumes duplicate elements are not allowed
/// </summary>
public class DSA_BinarySearchTree
{
    //defined root
    public DSA_BinaryTreeNode? Root;

    //empty constructor
    public DSA_BinarySearchTree()
    {
        
    }
    /// <summary>
    /// Allows for creating a BST sequentially with a list
    /// </summary>
    /// <param name="treeValues"></param>
    public DSA_BinarySearchTree(List<int> treeValues)
    {
        treeValues = treeValues.Distinct().ToList();
        foreach (int v in treeValues)
        {
            Insert(Root, v);
        }
    }

    public DSA_BinaryTreeNode? Search(int value)
    {
        return Search(Root, value);
    }
    
    private DSA_BinaryTreeNode? Search(DSA_BinaryTreeNode? node, int value)
    {
        //base case is if the node's value is equal to the search value, or if our node is null
        if (node == null || node.value == value)
            return node;
        if (value < node.value)
            node = Search(node.LeftChild, value);
        else if (value > node.value)
            node = Search(node.RightChild, value);
        return node;
    }

    public DSA_BinaryTreeNode? FindParentToNode(int v)
    {
        return FindParentToNode(Root, v);
    }
    
    /// <summary>
    /// Returns node parent of node with value = v
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public DSA_BinaryTreeNode? FindParentToNode(DSA_BinaryTreeNode? node, int v)
    {
        if (node == null || node.ChildCount() == 0 || node.LeftChild?.value == v || node.RightChild?.value == v) {
            return node;
        }
        if (v < node.value)
            node = FindParentToNode(node.LeftChild, v);
        else if (v > node.value)
            node = FindParentToNode(node.RightChild, v);
        return node;
    }
    public DSA_BinaryTreeNode Insert(DSA_BinaryTreeNode? node, int value)
    {
        if (Root == null) {
            Root = new DSA_BinaryTreeNode(value);
            return Root;
        }
        
        if (node == null)
        {
            return new DSA_BinaryTreeNode(value);
        }
        //need to set up references to children to "connect" the tree
        if (value < node.value)
        {
            node.LeftChild = Insert(node.LeftChild, value);
        }
        else if (value > node.value)
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

    public DSA_BinaryTreeNode Delete(int value)
    {
        //returns modified root of BST
        return Delete(Root, value);
    }

    public DSA_BinaryTreeNode Delete(DSA_BinaryTreeNode? node, int v)
    {
        if (node == null)
            return node;
        if (v < node.value)
            node.LeftChild = Delete(node.LeftChild, v);
        else if (v > node.value)
            node.RightChild = Delete(node.RightChild, v);
        else{
            if (node.LeftChild == null)
                return node.RightChild;
            if (node.RightChild == null)
                return node.LeftChild;
            DSA_BinaryTreeNode min = MinValue(node.RightChild);
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
    public DSA_BinaryTreeNode MinValue(DSA_BinaryTreeNode? node)
    {
        if (node != null && node.LeftChild == null)
            return node;
        node = MinValue(node.LeftChild);
        return node;
    }

    public DSA_BinaryTreeNode MaxValue(DSA_BinaryTreeNode node)
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
    private void PrintInOrderTraversal(DSA_BinaryTreeNode? node)
    {
        if (node != null)
        {
            PrintInOrderTraversal(node.LeftChild);
            Console.WriteLine(node.value+" ");
            PrintInOrderTraversal(node.RightChild);
        }
    }
    
}

public class DSA_BinaryTreeNode
{
    public int value;
    public DSA_BinaryTreeNode? LeftChild, RightChild;
    
    public DSA_BinaryTreeNode(int v)
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