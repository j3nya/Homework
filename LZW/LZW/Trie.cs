namespace Trie;

/// <summary>
/// A specialized search tree data structure.
/// </summary>
public class Trie
{
    private List<Vertex> vertices = new () { new Vertex() };

/// <summary>
/// Gets or sets number of the word in trie.
/// </summary>
    public int Size { get; set; }

/// <summary>
/// Adds a string to trie with string key.
/// </summary>
/// <param name="element">A string to add.</param>
/// <param name="key">Key associated with the string.</param>
/// <returns>Value indicates whether the word has been added.</returns>
    public bool Add(string? element, string key)
    {
        if (this.CheckInputString(element))
        {
            Console.WriteLine("Invalid input string");
            return false;
        }

        int currVer = 0;
        for (int i = 0; i < element?.Length; i++)
        {
            if (this.CheckInputStringsChar(element, i))
            {
                Console.WriteLine("Invalid input string");
                return false;
            }

            int charItem = element[i];
            Vertex? nextVer = this.vertices[currVer].GetNext(charItem);
            if (nextVer == null)
            {
                Vertex newVer = new ();
                this.vertices.Add(newVer);
                this.vertices[currVer].SetNext(charItem, newVer);
                nextVer = newVer;
            }

            nextVer.TimesVisited++;

            currVer = this.vertices.IndexOf(nextVer);
        }

        if (this.vertices[currVer].IsTerminal == true)
        {
            currVer = 0;
            for (int i = 0; i < element?.Length; i++)
            {
                int charItem = element[i];
                Vertex? nextVer = this.vertices[currVer].GetNext(charItem);
                if (nextVer == null)
                {
                    return false;
                }

                nextVer.TimesVisited--;

                currVer = this.vertices.IndexOf(nextVer);
            }

            return false;
        }

        this.Size++;
        this.vertices[currVer].IsTerminal = true;
        this.vertices[currVer].WordsKey = key;
        return true;
    }

    /// <summary>
    /// Checks if trie contains input string.
    /// </summary>
    /// <param name="element">String whose presence in trie needs to be checked.</param>
    /// <returns>Value indicating whether the given string is contained in trie.</returns>
    public bool Contains(string? element)
    {
        if (this.CheckInputString(element))
        {
            Console.WriteLine("Invalid input string.");
            return false;
        }

        int currVer = 0;
        for (int i = 0; i < element?.Length; i++)
        {
            if (this.CheckInputStringsChar(element, i))
            {
                Console.WriteLine("Invalid Input String.");
                return false;
            }

            int charItem = element[i];
            Vertex? nextVer = this.vertices[currVer].GetNext(charItem);
            if (nextVer == null)
            {
                return false;
            }

            currVer = this.vertices.IndexOf(nextVer);
        }

        return this.vertices[currVer].IsTerminal;
    }

    /// <summary>
    /// Removes element from trie.
    /// </summary>
    /// <param name="element">String that needs to be removed.</param>
    /// <returns>Value indicating whether the given string was in trie.</returns>
    public bool Remove(string? element)
    {
        if (this.Contains(element) && element != null)
        {
            this.vertices[0].SetNext(element[0], null);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Checks how many words in trie starts with given prefix.
    /// </summary>
    /// <param name="prefix">Input prefix.</param>
    /// <returns>Number of words starting with a given prefix.</returns>
    public int HowManyStartWithPrefix(string? prefix)
    {
        if (this.CheckInputString(prefix))
        {
            Console.WriteLine("Invalid Input String.");
            return 0;
        }

        int currVer = 0;
        for (int i = 0; i < prefix?.Length; i++)
        {
            if (this.CheckInputStringsChar(prefix, i))
            {
                Console.WriteLine("Invalid Input String.");
                return 0;
            }

            int charItem = prefix[i];
            Vertex? nextVer = this.vertices[currVer].GetNext(charItem);
            if (nextVer == null)
            {
                return 0;
            }

            currVer = this.vertices.IndexOf(nextVer);
        }

        return this.vertices[currVer].TimesVisited;
    }

/// <summary>
/// Finds the key of a word.
/// </summary>
/// <param name="element">The word whose key needs to be found.</param>
/// <returns>Word key.</returns>
    public string? GetWordsKey(string element)
    {
        int currVer = 0;
        for (int i = 0; i < element?.Length; i++)
        {
            if (this.CheckInputStringsChar(element, i))
            {
                Console.WriteLine("Invalid Input String.");
                return "-1";
            }

            int charItem = element[i];
            Vertex? nextVer = this.vertices[currVer].GetNext(charItem);
            if (nextVer == null)
            {
                return "0";
            }

            currVer = this.vertices.IndexOf(nextVer);
        }

        return this.vertices[currVer].WordsKey;
    }

    /// <summary>
    /// Checks for cases too long string and empty string.
    /// </summary>
    /// <param name="element">Input string.</param>
    /// <returns>A value indicating whether a string is valid.</returns>
    private bool CheckInputString(string? element)
    {
        const int maxLength = 100;
        return element == null || element.Length > maxLength || element.Length == 0;
    }

    /// <summary>
    /// Checks for cases of invalid character.
    /// </summary>
    /// <param name="element"> Input string. </param>
    /// <param name="i"> Char position. </param>
    /// <returns>A value indicating whether a string is valid.</returns>
    private bool CheckInputStringsChar(string? element, int i)
    {
        const int alphabetLength = 255;
        return element == null || element[i] > alphabetLength;
    }

    /// <summary>
    /// Trie component.
    /// </summary>
    protected class Vertex
    {
        private Vertex?[] next = new Vertex[256];

        /// <summary>
        /// Gets or sets a value indicating whether the vertex is the end of the word.
        /// </summary>
        public bool IsTerminal { get; set; }

        /// <summary>
        /// Gets or sets a value showing the number of visits to the vertex.
        /// </summary>
        public int TimesVisited { get; set; }

        /// <summary>
        /// Gets or sets a value that shows key of the word with the end at the terminal vertex.
        /// </summary>
        public string? WordsKey { get; set; }

        /// <summary>
        /// Gets the next vertex for the given character.
        /// </summary>
        /// <param name="charItem">Character to look up.</param>
        /// <returns>The next vertex.</returns>
        public Vertex? GetNext(int charItem)
        {
            return this.next[charItem];
        }

        /// <summary>
        /// Sets the next vertex for the given character.
        /// </summary>
        /// <param name="charItem">Character to set.</param>
        /// <param name="vertex">Vertex to set as next.</param>
        public void SetNext(int charItem, Vertex? vertex)
        {
            this.next[charItem] = vertex;
        }
    }
}