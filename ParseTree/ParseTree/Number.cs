namespace ParseTree;

/// <summary>
/// Node corresponding to a number.
/// </summary>
public class Number : Node
{
    private float number;

    /// <summary>
    /// Initializes a new instance of the <see cref="Number"/> class.
    /// </summary>
    /// <param name="number">Number according to which the class is created.</param>
    public Number(float number)
    {
        this.number = number;
    }

    /// <summary>
    /// Returns number.
    /// </summary>
    /// <returns>Number.</returns>
    public override float Evaluate()
    {
        return this.number;
    }
}