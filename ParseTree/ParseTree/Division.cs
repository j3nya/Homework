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
    /// Counts an expression with two numbers.
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