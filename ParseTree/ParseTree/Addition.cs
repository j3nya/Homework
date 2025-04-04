// <copyright file="Addition.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) PlaceholderCompany. All rights reserved.
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