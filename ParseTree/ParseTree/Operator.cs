// <copyright file="Operator.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParseTree;

/// <summary>
/// Class which describes operator.
/// </summary>
public abstract class Operator : Node
{
    /// <summary>
    /// Gets a symbol representing operation.
    /// </summary>
    public abstract char OperationChar { get; }

    /// <summary>
    /// Gets or sets left operand.
    /// </summary>
    public Node? Left { get; set; }

    /// <summary>
    /// Gets or sets right operand.
    /// </summary>
    public Node? Right { get; set; }

    /// <summary>
    /// Creates certain operator according to provided string.
    /// </summary>
    /// <param name="operationChar">Operation's char in string type.</param>
    /// <returns>Operator corresponding to provided character.</returns>
    /// <exception cref="Exception">Throws if string is neither of provided operations' representasion.</exception>
    public static Operator GetOperator(string operationChar)
    {
        switch (operationChar)
        {
            case "*":
            {
                return new Multiplication();
            }

            case "/":
            {
                return new Division();
            }

            case "-":
            {
                return new Substraction();
            }

            case "+":
            {
                return new Addition();
            }
        }

        throw new IncorrectOperationCharException("Operation char is incorrect");
    }

    /// <summary>
    /// Operation rule.
    /// </summary>
    /// <param name="a">Operand 1.</param>
    /// <param name="b">Operand 2.</param>
    /// <returns>Application of the operation.</returns>
    public abstract float Operate(float a, float b);

    /// <summary>
    /// Evaluates an expression where this operation takes place of the root of the tree.
    /// </summary>
    /// <returns>Computation result.</returns>
    public override float Evaluate()
    {
        if (this.Left == null || this.Right == null)
        {
            throw new MeaninglessExpressionException("Operands are not there");
        }

        return this.Operate(this.Left.Evaluate(), this.Right.Evaluate());
    }
}

/// <summary>
/// Throws if operation char is invalid.
/// </summary>
public class IncorrectOperationCharException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IncorrectOperationCharException"/> class.
    /// </summary>
    /// <param name="message">Message.</param>
    public IncorrectOperationCharException(string message)
        : base(message)
        {
        }
}

/// <summary>
/// Throws if program tries to compute operation without operands.
/// </summary>
public class MeaninglessExpressionException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MeaninglessExpressionException"/> class.
    /// </summary>
    /// <param name="message">Message.</param>
    public MeaninglessExpressionException(string message)
        : base(message)
        {
        }
}