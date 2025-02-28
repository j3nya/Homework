string? input = Console.ReadLine();
(string transformedString, int end) = Burrows_Wheeler_Transform.BWTSolver.BurrowsWheelerTransform(input);
Burrows_Wheeler_Transform.BWTSolver.ReverseBurrowsWheelerTransform(transformedString, end);