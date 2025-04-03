using System.Diagnostics.Contracts;

namespace ParseTree;

/// <summary>
/// Multiplication operator.
/// </summary>
public class Multiplication : Operator
{
    /// <summary>
    /// Gets a character representing multiply operation.
    /// </summary>
    public override char OperationChar { get; } = '/';

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

    public override string Print()
    {
        return string.Empty; //
    }
}