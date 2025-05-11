// <copyright file="Multiplication.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ParseTree;

/// <summary>
/// Multiplication operator.
/// </summary>
public class Multiplication : Operator
{
    /// <summary>
    /// Gets a character representing multiply operation.
    /// </summary>
    public override char OperationChar { get; } = '*';

    /// <summary>
    /// Counts an expression with two numbers.
    /// </summary>
    /// <param name="a">First operand.</param>
    /// <param name="b">Second operand.</param>
    /// <returns>Multiplication result.</returns>
    public override float Operate(float a, float b)
    {
        return a * b;
    }
}