namespace Graph;

/// <summary>
/// A structure made of vertices and edges.
/// </summary>
public class Graph
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Graph"/>  class.
    /// </summary>
    /// <param name="vertexCount">number of vertices.</param>
    public Graph(int vertexCount)
    {
        if (vertexCount < 0)
        {
            throw new Exception("Graph cannot contain negative number of vertices");
        }

        this.AdjacencyList = new List<List<(int, int)>>(vertexCount);
        for (int i = 0; i < this.AdjacencyList.Capacity; i++)
        {
            this.AdjacencyList.Add(new List<(int, int)>());
        }

        this.VertexCount = vertexCount;
    }

    /// <summary>
    /// Gets a list representing how vertices are connected.
    /// </summary>
    public List<List<(int vertex, int weight)>> AdjacencyList { get; private set; }

    /// <summary>
    /// Gets number of vertices.
    /// </summary>
    public int VertexCount { get; private set; }

    /// <summary>
    /// Add a vertex to graph.
    /// </summary>
    public void AddVertex()
    {
        this.VertexCount++;
        this.AdjacencyList.Add(new List<(int, int)>());
    }

    /// <summary>
    /// Adds an edge beetwen two vertices with given weight.
    /// </summary>
    /// <param name="vertex1">Vertex 1.</param>
    /// <param name="vertex2">Vertex 2.</param>
    /// <param name="weight">Edge weight.</param>
    public void AddEdge(int vertex1, int vertex2, int weight)
    {
        if (vertex1 == vertex2)
        {
            throw new Exception("Vertices are the same");
        }

        int vertex1Number = vertex1 - 1;
        int vertex2Number = vertex2 - 1;
        this.AdjacencyList[vertex1Number].Add((vertex2, weight));
        this.AdjacencyList[vertex2Number].Add((vertex1, weight));
    }

    /// <summary>
    /// Checks if there is a path beetwen vertices.
    /// </summary>
    /// <param name="vertex1">First vertex.</param>
    /// <param name="vertex2">Second vertex.</param>
    /// <returns>A value indicating whether there is a path beetwen first and second vertices.</returns>
    public bool CheckIfConnected(int vertex1, int vertex2)
    {
        bool[] isVisited = new bool[this.VertexCount];
        Queue<int> adjacencyQueue = new ();
        adjacencyQueue.Enqueue(vertex1);
        while (adjacencyQueue.Count != 0)
        {
            int currentVertex = adjacencyQueue.Dequeue();
            var adjacentVertices = this.AdjacencyList[currentVertex - 1];
            for (int i = 0; i < adjacentVertices.Count; i++)
            {
                int adjacentVertex = adjacentVertices[i].Item1;
                if (adjacentVertex == vertex2)
                {
                    return true;
                }

                int adjacentVertexNumber = adjacentVertices[i].Item1 - 1;
                if (!isVisited[adjacentVertexNumber])
                {
                    isVisited[adjacentVertexNumber] = true;
                    adjacencyQueue.Enqueue(adjacentVertex);
                }
            }
        }

        return false;
    }

    /// <summary>
    /// Check if graph is connected.
    /// </summary>
    /// <returns>A value indicating whether the graph is connected.</returns>
    public bool CheckIfConnected()
    {
        bool[] isVisited = new bool[this.VertexCount];
        Queue<int> adjacencyQueue = new ();
        if (this.VertexCount == 0)
        {
            return true;
        }

        adjacencyQueue.Enqueue(1);
        while (adjacencyQueue.Count != 0)
        {
            int currentVertex = adjacencyQueue.Dequeue();
            int currentVertexIndex = currentVertex - 1;
            isVisited[currentVertexIndex] = true;
            List<(int, int)> adjacentVertices = this.AdjacencyList[currentVertex - 1];
            for (int i = 0; i < adjacentVertices.Count; i++)
            {
                int adjacentVertex = adjacentVertices[i].Item1;
                if (!isVisited[adjacentVertex - 1])
                {
                    isVisited[adjacentVertex - 1] = true;
                    adjacencyQueue.Enqueue(adjacentVertex);
                }
            }
        }

        for (int i = 0; i < isVisited.Length; i++)
        {
            if (!isVisited[i])
            {
                return false;
            }
        }

        return true;
    }
}