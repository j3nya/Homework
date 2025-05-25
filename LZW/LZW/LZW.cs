namespace LZW;
using Trie;

/// <summary>
/// Сlass containing methods encoding and decoding information using Lempel–Ziv–Welch algorithm.
/// </summary>
public class LZW
{
/// <summary>
/// Encodes input string using Lempel–Ziv–Welch algorithm.
/// </summary>
/// <param name="input">A string to encode.</param>
/// <returns>Encoded string.</returns>
    public static List<byte> Encode(string input)
    {
        const int alphabetLength = 256;
        Trie dict = new ();
        for (int i = 0; i < alphabetLength; i++)
        {
            dict.Add($"{Convert.ToChar(i)}", $"{i}");
        }

        string currString = string.Empty;
        List<byte> output = new ();
        foreach (char c in input)
        {
            string combined = currString + c;

            if (!dict.Contains(combined))
            {
                int wordsKey = Convert.ToInt16(dict.GetWordsKey(currString));
                output.AddRange(BitConverter.GetBytes((ushort)wordsKey));
                dict.Add(combined, $"{dict.Size}");
                currString = Convert.ToString(c);
            }
            else
            {
                currString = combined;
            }
        }

        if (!string.IsNullOrEmpty(currString))
        {
            int wordsKey = Convert.ToInt16(dict.GetWordsKey(currString));
            output.AddRange(BitConverter.GetBytes((ushort)wordsKey));
        }

        return output;
    }

/// <summary>
/// Decodes a string encoded by the Lempel-Ziv-Welch algorithm.
/// </summary>
/// <param name="input">Encoded string.</param>
/// <returns>Decoded string.</returns>
    public static string Decode(byte[] input)
    {
        const int alphabetLength = 256;
        Trie dict = new ();
        for (int i = 0; i < alphabetLength; i++)
        {
            dict.Add($"{i}", $"{Convert.ToChar(i)}");
        }

        string currString = $"{BitConverter.ToInt16(input, 0)}";
        string output = string.Empty;
        for (int i = 2; i <= input.Length; i += 2)
        {
            if (i == input.Length)
            {
                output += dict.GetWordsKey(currString);
                break;
            }

            string tempString = currString + $"{BitConverter.ToInt16(input, i)}";
            if (!dict.Contains(tempString))
            {
                output += dict.GetWordsKey(currString);
                dict.Add($"{dict.Size}", tempString);
                currString = $"{BitConverter.ToInt16(input, i)}";
            }
            else
            {
                currString = tempString;
            }
        }

        return output;
    }

/// <summary>
/// Reads and encodes the file contents of the specified path.
/// </summary>
/// <param name="filePath">File path.</param>
    public static void ReadAndEncode(string filePath)
    {
        string fileText = File.ReadAllText(filePath);
        byte[] encodedText = LZW.Encode(fileText).ToArray();
        string encodedFilePath = filePath + ".zipped";
        File.WriteAllBytes(encodedFilePath, encodedText);
    }

/// <summary>
/// Reads and decodes the file contents of the specified path.
/// </summary>
/// <param name="filePath">file path.</param>
    public static void ReadAndDecode(string filePath)
    {
        byte[] fileText = File.ReadAllBytes(filePath);
        string decodedText = LZW.Decode(fileText);
        string decodedFilePath = filePath.Remove(filePath.Length - ".zipped".Length);
        File.WriteAllText(decodedFilePath, decodedText);
    }
}