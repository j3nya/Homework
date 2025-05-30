namespace NetworkOptimizerTests;

public class NetworkOptimizerTests
{
    private Graph.Graph graph1;
    private Graph.Graph graph2;
    private string[] input1;
    private string[] input2;

    [SetUp]
    public void Setup()
    {
        input1 = new string[2];
        input1[0] = "1: 2 (10), 3 (5)";
        input1[1] = "2: 3 (1)";
        input2 = new string[3];
        input2[0] = "1: 2 (3), 3 (7), 7 (9)";
        input2[1] = "3: 5 (1), 7 (10), 8 (90), 9 (18), 10 (4)";
        input2[2] = "11: 6 (7), 9 (13), 10 (2)";
        graph1 = NetworkOptimizer.NetworkOptimizer.BuildGraph(input1);
        graph2 = NetworkOptimizer.NetworkOptimizer.BuildGraph(input2);
    }

    [Test]
    public void CheckIfIncorrectInputReturnsFalse()
    {
        Assert.That(NetworkOptimizer.NetworkOptimizer.CheckInput(input1));
    }

    public void CheckIfCorrectInputReturnsTrue()
    {
        input1[0] += 1;
        Assert.That(!NetworkOptimizer.NetworkOptimizer.CheckInput(input1));
    }

    public void CheckIfBuildGraphBuildsCorrectGraph()
    {
        Assert.Multiple(() =>
        {
            Assert.That(graph1.AdjacencyList[0][0], Is.EqualTo((2, 10)));
            Assert.That(graph1.AdjacencyList[0][1], Is.EqualTo((3, 5)));
            Assert.That(graph1.AdjacencyList[1][0], Is.EqualTo((3, 1)));
            Assert.That(graph2.AdjacencyList[0][0], Is.EqualTo((7, 9)));
            Assert.That(graph2.AdjacencyList[10][1], Is.EqualTo((9, 13)));
            Assert.That(graph2.AdjacencyList[4][0], Is.EqualTo((3, 1)));
        });
    }

    public void CheckIfBuildMSTReturnsTree()
    {
        graph1 = NetworkOptimizer.NetworkOptimizer.BuildMST(graph1);
        graph2 = NetworkOptimizer.NetworkOptimizer.BuildMST(graph2);
        Assert.Multiple(() =>
        {
            Assert.That(graph1.CheckIfConnected());
            Assert.That(graph2.CheckIfConnected());
        });
    }

    public void CheckIfGraphToStringArrayReturnsCorrectOutput()
    {
        string[] output1 = NetworkOptimizer.NetworkOptimizer.GraphToStringArray(graph1);
        string[] output2 = NetworkOptimizer.NetworkOptimizer.GraphToStringArray(graph2);
        graph1 = NetworkOptimizer.NetworkOptimizer.BuildMST(graph1);
        graph2 = NetworkOptimizer.NetworkOptimizer.BuildMST(graph2);
        string[] outputMST1 = NetworkOptimizer.NetworkOptimizer.GraphToStringArray(graph1);
        string[] outputMST2 = NetworkOptimizer.NetworkOptimizer.GraphToStringArray(graph2);
        Assert.Multiple(() =>
        {
            Assert.That(output1 == input1);
            Assert.That(output2 == input2);
            Assert.That(NetworkOptimizer.NetworkOptimizer.CheckInput(outputMST1));
            Assert.That(NetworkOptimizer.NetworkOptimizer.CheckInput(outputMST2));
        });
    }
}
