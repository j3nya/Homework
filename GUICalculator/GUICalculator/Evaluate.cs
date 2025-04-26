// <copyright file="Evaluate.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GUICalculator
{
    /// <summary>
    /// Calculation handler.
    /// </summary>
    public class Evaluate
    {
        /// <summary>
        /// Checks if character is operator.
        /// </summary>
        /// <param name="c">Operator.</param>
        /// <returns>A value indicating that character is operator.</returns>
        public static bool IsOperator(char c) => c == '+' || c == '-' || c == '*' || c == '/';

        /// <summary>
        /// Checks divisor in provided string which represents expression.
        /// </summary>
        /// <param name="expression">string which follow view: "{operand1}{operator}{operand2}".</param>
        /// <returns>A value indicating whether divisor is zero.</returns>
        public static bool CheckInput(string expression)
        {
            try
            {
                EvaluateString(expression);
            }
            catch (DivideByZeroException)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Evaluates expression.
        /// </summary>
        /// <param name="expression">string which follow view: "{operand1}{operator}{operand2}".</param>
        /// <returns>result of calculation.</returns>
        /// <exception cref="Exception">throws if operator char is invalid.</exception>
        public static float EvaluateString(string expression)
        {
            char operator_ = '0';
            string operand1 = string.Empty;
            string operand2 = string.Empty;
            operand1 += expression[0]; // Add first charachter because number may be negative.
            int i;
            for (i = 1; !IsOperator(expression[i]); i++)
            {
                operand1 += expression[i];
            }

            operator_ = expression[i];
            i++;
            for (; i < expression.Length; i++)
            {
                operand2 += expression[i];
            }

            float num1;
            float num2;
            float.TryParse(operand1, out num1);
            float.TryParse(operand2, out num2);
            if (operator_ == '+')
            {
                return Add(num1, num2);
            }
            else if (operator_ == '-')
            {
                return Substract(num1, num2);
            }
            else if (operator_ == '*')
            {
                return Multiply(num1, num2);
            }
            else if (operator_ == '/')
            {
                return Divide(num1, num2);
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Divide method.
        /// </summary>
        /// <param name="a">operand1.</param>
        /// <param name="b">operand2.</param>
        /// <returns>result of calculation.</returns>
        /// <exception cref="DivideByZeroException">throws if divisor is 0.</exception>
        private static float Divide(float a, float b)
        {
            if (b != 0)
            {
                return a / b;
            }
            else
            {
                throw new DivideByZeroException();
            }
        }

        /// <summary>
        /// Add method.
        /// </summary>
        /// <param name="a">operand1.</param>
        /// <param name="b">operand2.</param>
        /// <returns>result of calculation.</returns>
        private static float Add(float a, float b) => a + b;

        /// <summary>
        /// Substract method.
        /// </summary>
        /// <param name="a">operand1.</param>
        /// <param name="b">operand2.</param>
        /// <returns>result of calculation.</returns>
        private static float Substract(float a, float b) => a - b;

        /// <summary>
        /// Multiply method.
        /// </summary>
        /// <param name="a">operand1.</param>
        /// <param name="b">operand2.</param>
        /// <returns>result of calculation.</returns>
        private static float Multiply(float a, float b) => a * b;

        /// <summary>
        /// Checks if char is operator.
        /// </summary>
        /// <param name="c">input character.</param>
        /// <returns>A value indicating whtether character is operator.</returns>
    }
}
