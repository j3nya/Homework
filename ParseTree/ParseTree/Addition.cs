namespace ParseTree;

public class Addition : Operator
{
    /// <summary>
    /// Gets a character representing adding operation.
    /// </summary>
    public override char OperationChar { get; } = '+';

    public override float Operate(float a, float b)
    {
        return a + b;
    }
}