// <copyright file="Number.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ParseTree;

/// <summary>
/// Node corresponding to a number.
/// </summary>
public class Number : Node
{
    private float number;

    /// <summary>
    /// Initializes a new instance of the <see cref="Number"/> class.
    /// </summary>
    /// <param name="number">Number according to which the class is created.</param>
    public Number(float number)
    {
        this.number = number;
    }

    /// <summary>
    /// Returns number.
    /// </summary>
    /// <returns>Number.</returns>
    public override float Evaluate()
    {
        return this.number;
    }
}