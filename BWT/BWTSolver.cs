namespace burrowsWheelerTransform;

/// <summary>
/// Class containing Burrows-Wheeler transform methods.
/// </summary>
public static class BWTSolver
{
/// <summary>
/// Rearranges a string with Burrows-Wheeler transform algorithm.
/// </summary>
/// <param name="input">A string to transform.</param>
/// <returns>Transformed string.</returns>
    public static (string transformedString, int end) BurrowsWheelerTransform(string input)
    {
        var indices = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            indices[i] = i;
        }

        BWTHelper.Sort(indices, input);
        var end = Array.IndexOf(indices, 0);
        var output = new char[input.Length];
        for (int i = 0; i < output.Length; i++)
        {
            int prevIndex = indices[i] - 1;
            if (prevIndex < 0)
            {
                prevIndex = input.Length - 1;
            }

            output[i] = input[prevIndex];
        }

        return (string.Concat(output), end);
    }

/// <summary>
/// Restores the transformed string.
/// </summary>
/// <param name="input">Transformed string.</param>
/// <param name="end">Last element postition.</param>
/// <returns>String before transformation.</returns>
    public static string ReverseBurrowsWheelerTransform(string input, int end)
    {
        int alphabetLength = 256;
        int[] count = new int[alphabetLength];

        for (int i = 0; i < input.Length; i++)
        {
            count[input[i]]++;
        }

        int sum = 0;
        for (int i = 0; i < alphabetLength; i++)
        {
            sum += count[i];
            count[i] = sum - count[i];
        }

        int[] reverseTransformVector = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            reverseTransformVector[count[input[i]]] = i;
            count[input[i]]++;
        }

        int j = reverseTransformVector[end];
        char[] output = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            output[i] = input[j];
            j = reverseTransformVector[j];
        }

        return string.Concat(output);
    }
}