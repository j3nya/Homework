if (CheckInputArgs(args))
{
    string[] input = File.ReadAllLines(args[0]);
    if (!NetworkOptimizer.NetworkOptimizer.CheckInput(input))
    {
        Console.WriteLine("Provide text consisting of lines of the following form: " +
        "{router1 number}: {router2 number} ({bandwidth}), ..., {routerN number} ({bandwidth})");
    }
    else
    {
        Graph.Graph graph = NetworkOptimizer.NetworkOptimizer.BuildGraph(input);
        if (!graph.CheckIfConnected())
        {
            throw new Exception("Graph is not connected");
        }
        else
        {
            Graph.Graph maximalSpanningTree = NetworkOptimizer.NetworkOptimizer.BuildMST(graph);
            string[] output = NetworkOptimizer.NetworkOptimizer.GraphToStringArray(maximalSpanningTree);
            output = output.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            File.WriteAllLines(args[1], output);
        }
    }
}

bool CheckInputArgs(string[] args)
{
    if (args.Length != 2)
    {
        Console.WriteLine("Provide 2 arguments");
        return false;
    }

    if (!(File.Exists(args[0]) && File.Exists(args[1])))
    {
        Console.WriteLine("Provide existing files paths");
        return false;
    }

    return true;
}