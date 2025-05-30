// <copyright file="Node.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) Chernoshchokaya Evgenia. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ParseTree;

/// <summary>
///  Node of a parse tree.
/// </summary>
public abstract class Node
{
    /// <summary>
    /// Prints an expression composed of a subtree where this node takes the place of the operator or if root is number prints number.
    /// </summary>
    /// <param name="root">Number or operator to print.</param>
    /// <returns>Text that output contains.</returns>
    public static string Print(Node root)
    {
        string stringToPrint = "( ";

        // case for tree containing one number.
        if (root is Number)
        {
            // For number evaluate method returns number.
            stringToPrint += root.Evaluate() + " ) ";
        }
        else
        {
            Operator operatorRoot = (Operator)root;
            stringToPrint += operatorRoot.OperationChar + " ";
            PrintRecursively(operatorRoot, ref stringToPrint);
        }

        Console.WriteLine(stringToPrint);

        // Remove space.
        return stringToPrint.Remove(stringToPrint.Length - 1);
    }

    /// <summary>
    /// Counts an expression composed of a subtree with a top at this node or if the node is a number returns a number.
    /// </summary>
    /// <returns>Result of calculation or number.</returns>
    public abstract float Evaluate();

    /// <summary>
    /// Auxiliary method for method Print which bypasess the tree.
    /// </summary>
    /// <param name="root">Operator for recursive call.</param>
    /// <param name="stringToPrint">String to print.</param>
    private static void PrintRecursively(Operator root, ref string stringToPrint)
    {
        if (root.Left == null || root.Right == null)
        {
            throw new MeaninglessExpressionException("Operands are not there");
        }

        Node operand1 = root.Left;
        if (operand1 is Operator)
        {
            Operator operatorOperand1 = (Operator)operand1;
            stringToPrint += "( " + operatorOperand1.OperationChar + " ";
            PrintRecursively(operatorOperand1, ref stringToPrint);
        }
        else
        {
            stringToPrint += operand1.Evaluate() + " ";
        }

        Node operand2 = root.Right;
        if (operand2 is Operator)
        {
            Operator operatorOperand2 = (Operator)operand2;
            stringToPrint += "( " + operatorOperand2.OperationChar + " ";
            PrintRecursively(operatorOperand2, ref stringToPrint);
        }
        else
        {
            stringToPrint += operand2.Evaluate() + " ";
        }

        // After every second operand add closing brace.
        stringToPrint += ") ";
    }
}