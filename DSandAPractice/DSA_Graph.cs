using System.Text;

namespace DSandAPractice.Structures;

public class DSA_Graph<T>
{
    public DSA_GraphNode<T> this[int index] => nodes[index];
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

    public DSA_GraphNode<T> Add(T value, List<DSA_GraphNode<T>> adjacent, bool directed = true)
    {
        DSA_GraphNode<T> node = new DSA_GraphNode<T>(value);
        nodes.Add(node);
        foreach (var nv in adjacent) {
            node.SetAdjacent(nv, directed);
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
                nodes[i].Adjacent.Add(nodes[j]);
            }
        }
    }

    public bool BreadthFirsSearch(DSA_GraphNode<T>? start, T value)
    {
        if (start == null) {
            Console.WriteLine("Starting node is invalid.");
            return false;
        }
        DSA_Queue<DSA_GraphNode<T>> q = new DSA_Queue<DSA_GraphNode<T>>();
        q.Enqueue(start);
        start.Visited = true;
        while (!q.IsEmpty())
        {
            DSA_GraphNode<T> node = q.Dequeue();
            //visit
            if (node.value.Equals(value))
                return true;
            foreach (var adjNode in node.Adjacent) {
                if (!adjNode.Visited) {
                    adjNode.Visited = true;
                    q.Enqueue(adjNode);
                }
            }
        }
        return false;
    }

    public bool DepthFirstSearch(DSA_GraphNode<T>? root, T value)
    {
        if (root == null) return false;
        root.Visited = true;
        //visit
        if (root.value.Equals(value))
            return true;
        //recursively search adjacents
        foreach (var node in root.Adjacent) {
            if (!node.Visited) {
                return DepthFirstSearch(node, value);
            }
        }
        return false;
    }

    public void MarkAllUnvisited()
    {
        foreach (var node in nodes) node.Visited = false;
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
    public List<DSA_GraphNode<T>> Adjacent = new List<DSA_GraphNode<T>>();
    public bool Visited;
    public DSA_GraphNode(T v)
    {
        value = v;
    }

    public DSA_GraphNode(T v, List<DSA_GraphNode<T>> withAdjacents)
    {
        value = v;
        Adjacent = withAdjacents;
    }
    
    public void SetAdjacent(DSA_GraphNode<T> other, bool directed = true)
    {
        if (directed) {
            if(!Adjacent.Contains(other))
                Adjacent.Add(other);
        }
        else {
            if(!Adjacent.Contains(other))
                Adjacent.Add(other);
            if(!other.Adjacent.Contains(this))
                other.Adjacent.Add(this);
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
        if (Adjacent.Count == 0) {
            nodeString.Append(value);
        }
        else {
            nodeString.AppendFormat("{0}:", value);
            foreach (var node in Adjacent)
            {
                nodeString.AppendFormat(" {0}", node.value);
            }
        }

        return nodeString.ToString();
    }
}