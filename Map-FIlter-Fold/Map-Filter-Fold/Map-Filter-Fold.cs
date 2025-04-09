// <copyright file="Map-Filter-Fold.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Map_Filter_Fold;

/// <summary>
/// class containing Map, Filter and Fold methods.
/// </summary>
public class Map_Filter_Fold
{
    /// <summary>
    /// Mapping function.
    /// </summary>
    /// <param name="list">List to which elements need to apply the function.</param>
    /// <param name="Function which applies to each element."></param>
    /// <returns>The list obtained by applying the passed function to each element of the passed list.</returns>
    public static List<int> Map(List<int> list, Func<int, int> function)
    {
        List<int> result = new ();
        for (int i = 0; i < list.Count; i++)
        {
            result.Add(function(list[i]));
        }

        return result;
    }

    /// <summary>
    /// Filtering function.
    /// </summary>
    /// <param name="list">List to filter.</param>
    /// <param name="function">Filtering function.</param>
    /// <returns>List composed of those elements of the passed list for which the passed function returned true.</returns>
    public static List<int> Filter(List<int> list, Func<int, bool> function)
    {
        List<int> result = new ();
        for (int i = 0; i < list.Count; i++)
        {
            if (function(list[i]))
            {
                result.Add(list[i]);
            }
        }

        return result;
    }

    /// <summary>
    /// Folding function.
    /// </summary>
    /// <param name="list">List to bypass by function.</param>
    /// <param name="firstElement">Element to start from.</param>
    /// <param name="function">Function which takes as arguments first element, and element of the list and returns the result of applying the operation to them.</param>
    /// <returns>Folded value after bypassing the whole list.</returns>
    public static int Fold(List<int> list, int firstElement, Func<int, int, int> function)
    {
        int foldedValue = firstElement;
        for (int i = 0; i < list.Count; i++)
        {
            foldedValue = function(foldedValue, list[i]);
        }

        return foldedValue;
    }
}
