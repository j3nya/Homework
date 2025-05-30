string? input = Console.ReadLine();
if (string.IsNullOrEmpty(input))
{
    Console.WriteLine("EMPTYSTRING");
}

(string transformedString, int end) = burrowsWheelerTransform.BWTSolver.BurrowsWheelerTransform(input!);
Console.WriteLine(transformedString + $" {end}");
string restoredString = burrowsWheelerTransform.BWTSolver.ReverseBurrowsWheelerTransform(transformedString, end);
Console.WriteLine(restoredString);