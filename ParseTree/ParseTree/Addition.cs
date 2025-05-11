// <copyright file="Addition.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ParseTree;

/// <summary>
/// Add operator.
/// </summary>
public class Addition : Operator
{
    /// <summary>
    /// Gets a character representing adding operation.
    /// </summary>
    public override char OperationChar { get; } = '+';

    /// <summary>
    /// Adds two numbers.
    /// </summary>
    /// <param name="a">Operand 1.</param>
    /// <param name="b">Operand 2.</param>
    /// <returns>Sum.</returns>
    public override float Operate(float a, float b)
    {
        return a + b;
    }
}