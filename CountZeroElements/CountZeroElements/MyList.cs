// <copyright file="MyList.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CountZeroElements;

using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Markup;

/// <summary>
/// List.
/// </summary>
/// <typeparam name="T">Type of elements.</typeparam>
public class MyList<T> : System.Collections.Generic.IEnumerable<T>
{
    /// <summary>
    /// Gets values of list.
    /// </summary>
    public T[] Values { get; private set; } = new T[1];

    /// <summary>
    /// Gets number of elements.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Indexer.
    /// </summary>
    /// <param name="index">Indes.</param>
    /// <returns>Element at specified index.</returns>
    public T this[int index]
    {
        get { return this.Values[index]; }
        set { this.Values[index] = value; }
    }

    /// <summary>
    /// Adds an element to the list.
    /// </summary>
    /// <param name="element">Element to add.</param>
    public void AddElement(T element)
    {
        int currElement = 0;

        // go through the list and look for null elements.
        for (int i = 0; i < this.Values.Length; i++)
        {
            if (this.Values[i] == null)
            {
                currElement = i;
            }
        }

        // creating new array.
        if (currElement == 0 && this.Values.Length != 1)
        {
            T[] newArray = new T[this.Values.Length * 2];
            int i = 0;
            for (; i < this.Values.Length; i++)
            {
                newArray[i] = this.Values[i];
            }

            newArray[i + 1] = element;
            this.Values = newArray;
        }
        else
        {
            this.Values[currElement] = element;
        }

        this.Count++;
    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An enumerator that iterates through the collection.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        foreach (var value in this.Values)
        {
            yield return value;
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates through a collection.
    /// </summary>
    /// <returns>An enumerator that iterates through a collection.</returns>
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}