namespace Trie;

/// <summary>
/// A specialized search tree data structure.
/// </summary>
public class Trie
{
    private List<Vertex> vertices = new () { new Vertex() };

    /// <summary>
    /// Gets a number of words in Trie.
    /// </summary>
    public int Size { get; private set; }

    /// <summary>
    /// Adds a string to trie.
    /// </summary>
    /// <param name="element"> String to add to the trie. </param>
    /// <returns> Value indicating whether such a string has already been added. </returns>
    public bool Add(string element)
    {
        if (CheckInputString(element))
        {
            return false;
        }

        int currentVertex = 0;
        for (int i = 0; i < element?.Length; i++)
        {
            if (CheckInputStringsChar(element, i))
            {
                return false;
            }

            Vertex? nextVertex;
            if (!this.vertices[currentVertex].Next.TryGetValue(element[i], out nextVertex))
            {
                Vertex newVertex = new ();
                this.vertices.Add(newVertex);
                this.vertices[currentVertex].Next.Add(element[i], newVertex);
                nextVertex = newVertex;
            }

            nextVertex.TimesVisited++;

            currentVertex = this.vertices.IndexOf(nextVertex);
        }

        if (this.vertices[currentVertex].IsTerminal == true)
        {
            currentVertex = 0;
            for (int i = 0; i < element?.Length; i++)
            {
                Vertex? nextVertex;
                if (!this.vertices[currentVertex].Next.TryGetValue(element[i], out nextVertex))
                {
                    nextVertex = new ();
                    this.vertices.Add(nextVertex);
                    this.vertices[currentVertex].Next.Add(element[i], nextVertex);
                }

                nextVertex.TimesVisited--;

                currentVertex = this.vertices.IndexOf(nextVertex);
            }

            return false;
        }

        this.Size++;
        this.vertices[currentVertex].IsTerminal = true;
        return true;
    }

    /// <summary>
    /// Checks if trie contains input string.
    /// </summary>
    /// <param name="element">String whose presence in trie needs to be checked.</param>
    /// <returns>Value indicating whether the given string is contained in trie.</returns>
    public bool Contains(string element)
    {
        if (CheckInputString(element))
        {
            return false;
        }

        int currentVertex = 0;
        for (int i = 0; i < element.Length; i++)
        {
            Vertex? nextVertex;
            if (!this.vertices[currentVertex].Next.TryGetValue(element[i], out nextVertex))
            {
                return false;
            }

            currentVertex = this.vertices.IndexOf(nextVertex);
        }

        return this.vertices[currentVertex].IsTerminal;
    }

    /// <summary>
    /// Removes element from trie.
    /// </summary>
    /// <param name="element">String that needs to be removed.</param>
    /// <returns>Value indicating whether the given string was in trie.</returns>
    public bool Remove(string element)
    {
        if (CheckInputString(element))
        {
            return false;
        }

        int currentVertex = 0;
        (Vertex endOfTheMaxPrefix, int endOfTheMaxPrefixPosition) = (this.vertices[0], 0);
        for (int i = 0; i < element.Length; i++)
        {
            if (CheckInputStringsChar(element, i))
            {
                return false;
            }

            Vertex? nextVertex;
            Dictionary<char, Vertex> nextVertices = this.vertices[currentVertex].Next;
            if (!nextVertices.TryGetValue(element[i], out nextVertex))
            {
                return false;
            }
            else if (nextVertex.IsTerminal && i != element.Length - 1)
            {
                (endOfTheMaxPrefix, endOfTheMaxPrefixPosition) = (nextVertex, i);
            }

            currentVertex = this.vertices.IndexOf(nextVertex);
        }

        if (this.vertices[currentVertex].Next.Count != 0)
        {
            this.vertices[currentVertex].IsTerminal = false;
            return true;
        }
        else
        {
            endOfTheMaxPrefix.Next.Remove(element[endOfTheMaxPrefixPosition + 1]);
            return true;
        }
    }

    /// <summary>
    /// Checks how many words in trie starts with given prefix.
    /// </summary>
    /// <param name="prefix">Input prefix.</param>
    /// <returns>Number of words starting with a given prefix.</returns>
    public int HowManyStartWithPrefix(string prefix)
    {
        if (CheckInputString(prefix))
        {
            return 0;
        }

        int currentVertex = 0;
        for (int i = 0; i < prefix?.Length; i++)
        {
            if (CheckInputStringsChar(prefix, i))
            {
                return 0;
            }

            Vertex? nextVertex;
            if (!this.vertices[currentVertex].Next.TryGetValue(prefix[i], out nextVertex))
            {
                return 0;
            }

            currentVertex = this.vertices.IndexOf(nextVertex);
        }

        return this.vertices[currentVertex].TimesVisited;
    }

    /// <summary>
    /// Checks for cases too long string and empty string.
    /// </summary>
    /// <param name="element">Input string.</param>
    /// <returns>A value indicating whether a string is invalid.</returns>
    private static bool CheckInputString(string? element)
    {
        const int maxLength = 100;
        if (element == null || element.Length == 0)
        {
            Console.WriteLine("Please provide nonempty string.");
            return true;
        }

        if (element.Length > maxLength)
        {
            Console.WriteLine($"Please provide string shorter than {maxLength} letters.");
            return true;
        }

        return false;
    }

    /// <summary>
    /// Checks for cases of invalid character.
    /// </summary>
    /// <param name="element"> Input string. </param>
    /// <param name="i"> Char position. </param>
    /// <returns>A value indicating whether a string is invalid.</returns>
    private static bool CheckInputStringsChar(string element, int i)
    {
        const int alphabetLength = 256;
        if (element[i] > alphabetLength)
        {
            Console.WriteLine("Please provide words composed of the permissible alphabet.");
            return true;
        }

        return false;
    }

    /// <summary>
    /// Trie component.
    /// </summary>
    private class Vertex
    {
        /// <summary>
        /// Gets or sets next vertex for the given character character.
        /// </summary>
        public Dictionary<char, Vertex> Next { get; set; } = new (256);

        /// <summary>
        /// Gets or sets a value indicating whether the vertex is the end of the word.
        /// </summary>
        public bool IsTerminal { get; set; }

        /// <summary>
        /// Gets or sets a value showing the number of visits to the vertex.
        /// </summary>
        public int TimesVisited { get; set; }
    }
}