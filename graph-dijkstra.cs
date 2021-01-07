public class Node {
    public int val;
    public HashSet<Node> neighbours;
    public Node(int _val) {
        val = _val;
        neighbours = new HashSet<Node>();
    }
}

public class WeightedGraph
{
    public Dictionary<int, HashSet<KeyValuePair<int, int>>> adjacencyList;
    public WeightedGraph()
    {
        adjacencyList = new Dictionary<int, HashSet<KeyValuePair<int, int>>>();
    }

    public void AddVertex(int vertex)
    {
        if(!adjacencyList.ContainsKey(vertex))
        {
            adjacencyList.Add(vertex, new HashSet<KeyValuePair<int, int>>());
        }
    }

    public void AddEdge(int vertex1, int vertex2, int weight)
    {
        if(adjacencyList.ContainsKey(vertex1))
        {
            adjacencyList[vertex1].Add(new KeyValuePair<int, int>(vertex2, weight));
        }
        if(adjacencyList.ContainsKey(vertex2))
        {
            adjacencyList[vertex2].Add(new KeyValuePair<int, int>(vertex1, weight));
        }
    }
}