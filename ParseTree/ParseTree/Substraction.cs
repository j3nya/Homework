// <copyright file="Substraction.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ParseTree;

/// <summary>
/// Substraction operator.
/// </summary>
public class Substraction : Operator
{
    /// <summary>
    /// Gets a character representing substract operation.
    /// </summary>
    public override char OperationChar { get; } = '-';

    /// <summary>
    /// Substracts two numbers.
    /// </summary>
    /// <param name="a">Operand 1.</param>
    /// <param name="b">Operand 2.</param>
    /// <returns>Result of substraction.</returns>
    public override float Operate(float a, float b)
    {
        return a - b;
    }
}