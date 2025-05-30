// <copyright file="NetworkOptimizer.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace NetworkOptimizer;
using Graph;

/// <summary>
/// Builder of optimal network configuration.
/// </summary>
public class NetworkOptimizer
{
    /// <summary>
    /// Checks if the string has the desired form.
    /// </summary>
    /// <param name="input">Array of file lines.</param>
    /// <returns>A value indicating whether the string is valid. </returns>
    public static bool CheckInput(string[] input)
    {
        for (int lineNumber = 0; lineNumber < input.Length; lineNumber++)
        {
            // Split into an array of routers and the bandwidth between them.
            string[] elements = input[lineNumber].Split(" ");

            // Checking first element.
            if (!elements[0].EndsWith(':'))
            {
                return false;
            }

            for (int firstElementChar = 0; firstElementChar < elements[0].Length - 1; firstElementChar++)
            {
                if (!char.IsNumber(elements[0][firstElementChar]))
                {
                    return false;
                }
            }

            // Check two types of items: router number and bandwidth in brackets.
            for (int routerNumber = 1; routerNumber < elements.Length; routerNumber += 2)
            {
                for (int charNumber = 0; charNumber < elements[routerNumber].Length; charNumber++)
                {
                    if (!char.IsNumber(elements[routerNumber][charNumber]))
                    {
                        return false;
                    }
                }
            }

            for (int bandwith = 2; bandwith < elements.Length - 1; bandwith += 2)
            {
                if (!elements[bandwith].StartsWith('(') && !elements[bandwith].EndsWith("),"))
                {
                    return false;
                }

                for (int j = 1; j < elements[bandwith].Length - 2; j++)
                {
                    if (!char.IsNumber(elements[bandwith][j]))
                    {
                        return false;
                    }
                }
            }

            string lastString = elements[elements.Length - 1];
            if (!lastString.StartsWith('(') && !lastString.EndsWith(')'))
            {
                return false;
            }

            for (int i = 1; i < lastString.Length - 1; i++)
            {
                if (!char.IsNumber(lastString[i]))
                {
                    return false;
                }
            }
        }

        return true;
    }

    /// <summary>
    /// Builds a graph according to its description in the file.
    /// </summary>
    /// <param name="lines">All lines of the file.</param>
    /// <returns>Built graph.</returns>
    public static Graph BuildGraph(string[] lines)
    {
        Graph graph = new Graph(lines.Length);
        List<bool> isAdded = new ();
        for (int lineNumber = 0; lineNumber < lines.Length; lineNumber++)
        {
            isAdded.Add(true);
            string currentVertex = string.Empty;
            string currentVertexWeight = string.Empty;
            string firstNumber = string.Empty;

            // Go down the line.
            for (int charNumber = 0; charNumber < lines[lineNumber].Length; charNumber++)
            {
                char currentChar = lines[lineNumber][charNumber];
                if (charNumber == 0)
                {
                    while (currentChar != ':')
                    {
                        firstNumber += currentChar;
                        charNumber++;
                        currentChar = lines[lineNumber][charNumber];
                    }
                }

                if (char.IsNumber(currentChar))
                {
                    while (currentChar != ' ')
                    {
                        currentVertex += currentChar;
                        charNumber++;

                        // Update the variable.
                        currentChar = lines[lineNumber][charNumber];
                    }
                }

                if (currentChar == '(')
                {
                    charNumber++;

                    // Go one character further.
                    currentChar = lines[lineNumber][charNumber];
                    while (currentChar != ')')
                    {
                        currentVertexWeight += currentChar;
                        charNumber++;

                        // Update the variable.
                        currentChar = lines[lineNumber][charNumber];
                    }

                    int vertex1 = Convert.ToInt32($"{firstNumber}");
                    int vertex2 = Convert.ToInt32(currentVertex);
                    int weight = Convert.ToInt32(currentVertexWeight);
                    int vertex2Number = vertex2 - 1;

                    // Checks if the next vertex is outside the list.
                    if (vertex2 > isAdded.Count)
                    {
                        for (int i = isAdded.Count; i < vertex2Number; i++)
                        {
                            isAdded.Add(false);
                        }

                        isAdded.Add(true);
                    }

                    if (vertex1 > graph.VertexCount)
                    {
                        for (int i = graph.VertexCount; i < vertex1; i++)
                        {
                            graph.AddVertex();
                        }
                    }

                    if (vertex2 > graph.VertexCount)
                    {
                        for (int i = graph.VertexCount; i < vertex2; i++)
                        {
                            graph.AddVertex();
                        }
                    }

                    if (!isAdded[vertex2Number])
                    {
                        isAdded[vertex2Number] = true;
                    }

                    graph.AddEdge(vertex1, vertex2, weight);

                    // Zero the rows (since we have already added an edge).
                    currentVertex = string.Empty;
                    currentVertexWeight = string.Empty;
                }
            }
        }

        return graph;
    }

    /// <summary>
    /// Constructs a maximal spanning tree in the graph using Kruskal's algorithm.
    /// </summary>
    /// <param name="graph">Input graph.</param>
    /// <returns>Maximal spanning tree.</returns>
    public static Graph BuildMST(Graph graph)
    {
        Graph maximalSpanningTree = new (graph.VertexCount);
        List<(int, int, int)> edges = new List<(int, int, int)>();
        for (int vertexNumber = 0; vertexNumber < graph.VertexCount; vertexNumber++)
        {
            for (int adjacentVertexNumber = 0; adjacentVertexNumber < graph.AdjacencyList[vertexNumber].Count; adjacentVertexNumber++)
            {
                edges.Add((vertexNumber + 1, graph.AdjacencyList[vertexNumber][adjacentVertexNumber].vertex, graph.AdjacencyList[vertexNumber][adjacentVertexNumber].weight));
            }
        }

        edges.Sort((x, y) => -x.Item3.CompareTo(y.Item3));
        for (int i = 0; i < edges.Count; i++)
        {
            int vertex1 = edges[i].Item1;
            int vertex2 = edges[i].Item2;
            int weight = edges[i].Item3;

            if (!maximalSpanningTree.CheckIfConnected(vertex1, vertex2))
            {
                maximalSpanningTree.AddEdge(vertex1, vertex2, weight);
            }
        }

        return maximalSpanningTree;
    }

    /// <summary>
    /// Converts graph to string array.
    /// </summary>
    /// <param name="graph">Input graph.</param>
    /// <returns>String array graph representation.</returns>
    public static string[] GraphToStringArray(Graph graph)
    {
        string[] output = new string[graph.VertexCount];
        for (int vertexNumber = 0; vertexNumber < graph.VertexCount; vertexNumber++)
        {
            int vertex = vertexNumber + 1;
            output[vertexNumber] += $"{vertex}: ";
            int numberOfAdjacentVertices = graph.AdjacencyList[vertexNumber].Count;
            for (int adjacentVertexNumber = 0; adjacentVertexNumber < numberOfAdjacentVertices - 1; adjacentVertexNumber++)
            {
                int adjacentVertex = graph.AdjacencyList[vertexNumber][adjacentVertexNumber].vertex;
                int weight = graph.AdjacencyList[vertexNumber][adjacentVertexNumber].weight;
                if (adjacentVertex > vertex)
                {
                    output[vertexNumber] += adjacentVertex + " (" + weight + ")" + ", ";
                }
            }

            int lastAdjacentVertex = graph.AdjacencyList[vertexNumber][numberOfAdjacentVertices - 1].vertex;
            int lastWeight = graph.AdjacencyList[vertexNumber][numberOfAdjacentVertices - 1].weight;
            if (lastAdjacentVertex > vertex)
            {
                output[vertexNumber] += lastAdjacentVertex + " (" + lastWeight + ")";
            }

            if (output[vertexNumber] == $"{vertex}: ")
            {
                output[vertexNumber] = string.Empty;
            }
        }

        return output;
    }
}