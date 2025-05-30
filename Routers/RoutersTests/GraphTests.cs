namespace RoutersTests;
public class GraphTests
{
    private Graph.Graph graph;

    [SetUp]
    public void Setup()
    {
        graph = new Graph.Graph(5);
        graph.AddEdge(3, 1, 1);
    }

    [Test]
    public void CheckIfAddingEdgeAddsEdgeAndAddingVertexAddsVertex()
    {
        graph.AddVertex();
        graph.AddEdge(6, 2, 1);
        Assert.Multiple(() =>
        {
            Assert.That(graph.VertexCount, Is.EqualTo(6));
            Assert.That(graph.AdjacencyList[5][0], Is.EqualTo((2, 1)));
        });
    }

    public void CheckIfCheckForConnectivityReturnsTrueIfVerticesAreConnected()
    {
        Assert.Multiple(() =>
        {
            Assert.That(graph.CheckIfConnected(3, 1));
            Assert.That(graph.CheckIfConnected(1, 3));
            Assert.That(graph.CheckIfConnected(6, 2));
        });
    }

    public void CheckIfCheckForConnectivityReturnsFalseIfVerticesAreNotConnected()
    {
        Assert.Multiple(() =>
        {
            Assert.That(!graph.CheckIfConnected(1, 2));
            Assert.That(!graph.CheckIfConnected(3, 6));
        });
    }

    public void CheckIfCheckForConnectivityReturnsTrueIfGraphIsConnected()
    {
        graph.AddEdge(1, 2, 1);
        graph.AddEdge(2, 4, 1);
        graph.AddEdge(4, 5, 1);
        Assert.That(graph.CheckIfConnected());
    }

    public void CheckIfCheckForConnectivityReturnsFalseIfGraphIsNotConnected()
    {
        Assert.That(!graph.CheckIfConnected());
    }

    public void CheckIfEdgeIsNotAddedWhenVertex1AndVertex2AreTheSame()
    {
        Assert.Throws<Exception>(() => graph.AddEdge(1, 1, 1));
    }
}
