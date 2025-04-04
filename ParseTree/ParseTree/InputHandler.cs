// <copyright file="InputHandler.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParseTree;

/// <summary>
/// Works with strings and brings them to the desired form.
/// </summary>
public class InputHandler
{
    /// <summary>
    /// Checks input for validity.
    /// </summary>
    /// <param name="input">String to check.</param>
    /// <returns>A value indicating whether the string is valid.</returns>
    public static bool CheckInput(string input)
    {
        const string pattern = @"^\(([+\-*/]) (\S+) (\S+)\)$";

        var match = System.Text.RegularExpressions.Regex.Match(input, pattern);
        if (!match.Success)
        {
            return false;
        }

        string op = match.Groups[1].Value;
        if (!IsValidOperator(op))
        {
            return false;
        }

        // Проверяем операнды
        string operand1 = match.Groups[2].Value;
        string operand2 = match.Groups[3].Value;

        return IsValidOperand(operand1) && IsValidOperand(operand2);
    }

    /// <summary>
    /// Bypasses string and returns string array of 3 elements in which each string represents operator, operand1 or operand2.
    /// </summary>
    /// <param name="input">String to convert to nodes.</param>
    /// <returns>String array representation of nodes.</returns>
    /// <exception cref="Exception">Throws if input is incorrect.</exception>
    public static string[] ToNodes(string input)
    {
        string[] result = new string[3];
        int stringIndex = 1; // starting at second char skipping opening brace.
        while (input[stringIndex] != ' ')
        {
            if (input[stringIndex] == ')') // case when tree has one node.
            {
                return result;
            }

            result[0] += input[stringIndex];
            stringIndex++;
        }

        stringIndex++; // skip space.

        if (input[stringIndex] == '(')
        {
            result[1] += input[stringIndex];
            stringIndex++; // skip opening brace.
            int braceCount = 1;
            for (; braceCount != 0; stringIndex++)
            {
                if (input[stringIndex] == '(')
                {
                    braceCount++;
                }

                if (input[stringIndex] == ')')
                {
                    braceCount--;
                }

                result[1] += input[stringIndex];
            }
        }
        else
        {
            while (input[stringIndex] != ' ')
            {
                result[1] += input[stringIndex];
                stringIndex++;
            }
        }

        stringIndex++; // skip space.

        if (input[stringIndex] == '(')
        {
            result[2] += input[stringIndex];
            stringIndex++;
            int braceCount = 1;
            for (; braceCount != 0; stringIndex++)
            {
                if (input[stringIndex] == '(')
                {
                    braceCount++;
                }

                if (input[stringIndex] == ')')
                {
                    braceCount--;
                }

                result[2] += input[stringIndex];
            }
        }
        else
        {
            while (input[stringIndex] != ')')
            {
                result[2] += input[stringIndex];
                stringIndex++;
            }
        }

        return result;
    }

    private static bool IsValidOperator(string op) =>
        op == "+" || op == "-" || op == "*" || op == "/";

    private static bool IsValidOperand(string operand)
    {
        if (System.Text.RegularExpressions.Regex.IsMatch(operand, @"^-?\d+$"))
        {
            return true;
        }

        if (operand.StartsWith("(") && operand.EndsWith(")"))
        {
            return CheckInput(operand);
        }

        return false;
    }

    /// <summary>
    /// Throws if input is incorrect.
    /// </summary>
    public class InvalidInputException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidInputException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public InvalidInputException(string message)
            : base(message)
        {
        }
    }
}