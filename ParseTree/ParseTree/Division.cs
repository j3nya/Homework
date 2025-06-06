// <copyright file="Division.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ParseTree;

/// <summary>
/// Division operator.
/// </summary>
public class Division : Operator
{
    /// <summary>
    /// Gets a character representing divide operation.
    /// </summary>
    public override char OperationChar { get; } = '/';

    /// <summary>
    /// Divides two numbers.
    /// </summary>
    /// <param name="a">First operand.</param>
    /// <param name="b">Second operand.</param>
    /// <returns>Division.</returns>
    public override float Operate(float a, float b)
    {
        if (b != 0)
        {
            return a / b;
        }

        throw new DivideByZeroException();
    }
}