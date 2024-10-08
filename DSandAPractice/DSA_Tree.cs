using System.Text;

namespace DSandAPractice.Structures;

public class DSA_Tree<T>
{
    public DSA_TreeNode<T>? Root;
    
    public DSA_Tree()
    {
        
    }

    public DSA_Tree(T value)
    {
        Root = new DSA_TreeNode<T>(value);
    }

    /// <summary>
    /// Adds a node to the next available location, searching for furthest depth, then left->right
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public DSA_TreeNode<T> Add(T value)
    {
        DSA_TreeNode<T> newNode = new DSA_TreeNode<T>(value);
        if (Root == null) {
            Root = newNode;
        }
        else
        {
            DSA_Queue<DSA_TreeNode<T>> q = new DSA_Queue<DSA_TreeNode<T>>();
            q.Enqueue(Root);
            //Enqueue each of the children as we traverse the graph from left to right
            while (!q.IsEmpty()) {
                DSA_TreeNode<T> node = q.Dequeue();
                //If either node is null, set it then break and return
                if (node.Left == null)
                {
                    node.Left = newNode;
                    break;
                }
                else if (node.Right == null)
                {
                    node.Right = newNode;
                    break;
                }
                q.Enqueue(node.Left);
                q.Enqueue(node.Right);
            }
        }
        return newNode;
    }

    public void Add(List<T> values)
    {
        foreach (var v in values)
            Add(v);
    }

    public void PrintInOrderTraversal(DSA_TreeNode<T>? root)
    {
        if (root == null) return;
        PrintInOrderTraversal(root.Left);
        Console.Write(root.value + " ");
        PrintInOrderTraversal(root.Right);
    }

    public override string ToString()
    {
        return string.Empty;
    }
}

public class DSA_TreeNode<T> : DSA_Node<T>
{
    public DSA_TreeNode<T>? Left, Right;

    public DSA_TreeNode(T v)
    {
        value = v;
    }
    
}