// <copyright file="ZerosCounter.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CountZeroElements;

/// <summary>
/// Counts zeros in lists.
/// </summary>
public class ZerosCounter
{
    /// <summary>
    /// Counts zero items in list.
    /// </summary>
    /// <typeparam name="T">Type of elements of list.</typeparam>
    /// <param name="mylist">List to find zeros in.</param>
    /// <param name="recognizeZero">Function recognizing zeros.</param>
    /// <returns>Number of zeros.</returns>
    public static int CountZeros<T>(MyList<T> mylist, Func<T, bool> recognizeZero)
    {
        int numberOfZeros = 0;
        for (int i = 0; i < mylist.Count; i++)
        {
            if (recognizeZero(mylist[i]))
            {
                numberOfZeros += 1;
            }
        }

        return numberOfZeros;
    }
}