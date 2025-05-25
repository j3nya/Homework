if (args.Length > 0 && CheckInputString(args))
{
    if (args[1] == "-c")
    {
        LZW.LZW.ReadAndEncode(args[0]);
        Console.WriteLine($"Compression ratio: {File.ReadAllBytes(args[0]).Length / File.ReadAllBytes(args[0] + ".zipped").Length}");
    }
    else if (args[1] == "-u")
    {
        byte[] zippedContents = File.ReadAllBytes(args[0]);
        LZW.LZW.ReadAndDecode(args[0]);
        byte[] originalContents = File.ReadAllBytes(args[0].Remove(args[0].Length - ".zipped".Length));
        Console.WriteLine($"Compression ratio: {originalContents.Length / zippedContents.Length}");
    }
}

bool CheckInputString(string[] input)
{
    if (args.Length != 2)
    {
        Console.WriteLine("Provide two arguments");
        return false;
    }

    if (!File.Exists(input[0]))
    {
        Console.WriteLine("Provide existing file path as 1st argument");
        return false;
    }

    if (File.ReadAllText(input[0]).Length == 0)
    {
        Console.WriteLine("Provide non-empty file");
    }

    if (!(args[1] == "-c" || args[1] == "-u"))
    {
        Console.WriteLine("Provide either -c or -u key depending on whether you want to compress or uncompress the file");
        return false;
    }

    if (args[1] == "-c" && args[0].Contains(".zipped"))
    {
        Console.WriteLine("Provide uncompressed file to compress it");
        return false;
    }

    if (args[1] == "-u" && !args[0].Contains(".zipped"))
    {
        Console.WriteLine("Provide .zipped extension file to uncompress it");
        return false;
    }

    return true;
}