namespace ParseTree;

/// <summary>
/// 
/// </summary>
public abstract class Operator : Node
{
    public abstract char OperationChar { get; }

    internal Node left;
    internal Node right;

    public abstract float Operate(float a, float b);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override float Evaluate()
    {
        return this.Operate(this.left.Evaluate(), this.right.Evaluate());
    }
}