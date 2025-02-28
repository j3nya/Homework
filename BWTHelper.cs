namespace Burrows_Wheeler_Transform;

/// <summary>
/// Class with permutations comparing and sorting functions.
/// </summary>
public class BWTHelper
{
/// <summary>
/// Compares cyclic permutations.
/// </summary>
/// <param name="input">String which cyclic permutations is compared.</param>
/// <param name="one">Beggining of first permutation.</param>
/// <param name="two">Beggining of second permutation.</param>
/// <returns>A value indicating whether the first permutation is less than the second.</returns>
    public static bool Compare(string input, int one, int two)
    {
        for (int i = 0; i < input.Length; i++)
        {
            if (input[one] < input[two])
            {
                return true;
            }
            else if (input[one] > input[two])
            {
                return false;
            }
            else
            {
                if (one < input.Length - 1)
                {
                one++;
                }
                else
                {
                one = 0;
                }

                if (two < input.Length - 1)
                {
                    two++;
                }
                else
                {
                    two = 0;
                }
            }
        }

        return true;
    }

/// <summary>
/// Sorts permutations.
/// </summary>
/// <param name="array">Numeric array for permutations.</param>
/// <param name="input">Input string.</param>
    public static void Sort(int[] array, string input)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - 1 - i; j++)
            {
                if (!Compare(input, array[j], array[j + 1]))
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
    }
}