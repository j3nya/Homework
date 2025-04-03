namespace ParseTree;

public class Substraction : Operator
{
    /// <summary>
    /// Gets a character representing substract operation.
    /// </summary>
    public override char OperationChar { get; } = '/';

    public override float Operate(float a, float b)
    {
        return a - b;
    }

    public override string Print()
    {
        return string.Empty; //
    }
}