using System.Text;

namespace DSandAPractice;

public class DSA_Graph<T>
{
    private List<DSA_GraphNode<T>> nodes = new List<DSA_GraphNode<T>>();
    
    public DSA_GraphNode<T> Add(T value, List<T>? values = null, bool directed = true)
    {
        DSA_GraphNode<T> node = new DSA_GraphNode<T>(value);
        nodes.Add(node);
        if (values != null) {
            foreach (var v in values)
            {
                DSA_GraphNode<T> nv = new DSA_GraphNode<T>(v);
                nodes.Add(nv);
                node.SetAdjacent(nv, directed);
            }
        }
        return node;
    }

    public DSA_GraphNode<T> Add(T value, List<DSA_GraphNode<T>> adjacent)
    {
        DSA_GraphNode<T> node = new DSA_GraphNode<T>(value);
        nodes.Add(node);
        foreach (var nv in adjacent) {
            node.SetAdjacent(nv);
        }

        return node;
    }
    
    public List<DSA_GraphNode<T>> AddAdjacentUndirected(List<T> values)
    {
        List<DSA_GraphNode<T>> graphNodes = new List<DSA_GraphNode<T>>();
        foreach (var v in values) {
            graphNodes.Add(Add(v));
        }
        SetAllNodesAdjacent(graphNodes);
        return graphNodes;
    }
    private void SetAllNodesAdjacent(List<DSA_GraphNode<T>> nodes)
    {
        for (int i = 0; i < nodes.Count; i++) {
            for (int j = 0; j < nodes.Count; j++) {
                if (i == j) continue;
                nodes[i].adjacent.Add(nodes[j]);
            }
        }
    }

    //iterate over list of nodes in graph, printing the node's value and its collection of adjacent values 
    public override string ToString()
    {
        StringBuilder graphString = new StringBuilder();
        if (nodes.Count > 0) {
            foreach (var node in nodes) {
                graphString.AppendFormat("{0}\n", node);
            }
        }
        else {
            graphString.Append("No nodes in graph.");
        }
        return graphString.ToString();
    }
    
}

public class DSA_GraphNode<T> : DSA_Node<T>
{
    public List<DSA_GraphNode<T>> adjacent = new List<DSA_GraphNode<T>>();
    public DSA_GraphNode(T v)
    {
        value = v;
    }

    public DSA_GraphNode(T v, List<DSA_GraphNode<T>> withAdjacents)
    {
        value = v;
        adjacent = withAdjacents;
    }
    
    public void SetAdjacent(DSA_GraphNode<T> other, bool directed = true)
    {
        if (directed) {
            if(!adjacent.Contains(other))
                adjacent.Add(other);
        }
        else {
            if(!adjacent.Contains(other))
                adjacent.Add(other);
            if(!other.adjacent.Contains(this))
                other.adjacent.Add(this);
        }
    }
    
    public void SetAdjacent(List<DSA_GraphNode<T>> others, bool directed = true)
    {
        foreach (var node in others) {
            SetAdjacent(node, directed);
        }
    }
    public override string ToString()
    {
        StringBuilder nodeString = new StringBuilder();
        if (adjacent.Count == 0) {
            nodeString.Append(value);
        }
        else {
            nodeString.AppendFormat("{0}:", value);
            foreach (var node in adjacent)
            {
                nodeString.AppendFormat(" {0}", node.value);
            }
        }

        return nodeString.ToString();
    }
}