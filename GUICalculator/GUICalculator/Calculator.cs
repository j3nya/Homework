// <copyright file="Calculator.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GUICalculator
{
    /// <summary>
    /// calculator form.
    /// </summary>
    public partial class Calculator : Form
    {
        private Button numberOneButton = new Button();
        private Button numberTwoButton = new Button();
        private Button numberThreeButton = new Button();
        private Button numberSixButton = new Button();
        private Button numberFiveButton = new Button();
        private Button numberFourButton = new Button();
        private Button numberNineButton = new Button();
        private Button numberEightButton = new Button();
        private Button numberSevenButton = new Button();
        private Button operatorAdditionButton = new Button();
        private Button operatorSubstractionButton = new Button();
        private Button operatorDivisionButton = new Button();
        private Button operatorMultiplicationButton = new Button();
        private TextBox displayTextBox = new TextBox();

        private Button numberZeroButton = new Button();
        private Button changeSignButton = new Button();
        private Button eraseButton = new Button();
        private Button startOverButton = new Button();
        private Button fractionButton = new Button();
        private Button equalsButton = new Button();

        private bool startNewOperand;
        private bool wasTheOperandPressed;
        private string evaluateExpression = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Calculator"/> class.
        /// </summary>
        public Calculator()
        {
            this.InitializeComponent();

            foreach (var control in this.Controls)
            {
                if (control is Button)
                {
                    Button button = (Button)control;
                    if (button != this.changeSignButton && button != this.eraseButton && button != this.startOverButton && button != this.equalsButton && button != this.fractionButton)
                    {
                        button.Click += this.OperandOrOperatorButton_Click;
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // numberOneButton
            this.numberOneButton.Location = new Point(12, 41);
            this.numberOneButton.Name = "numberOneButton";
            this.numberOneButton.Size = new Size(66, 54);
            this.numberOneButton.TabIndex = 0;
            this.numberOneButton.Text = "1";
            this.numberOneButton.UseVisualStyleBackColor = true;

            // numberTwoButton
            this.numberTwoButton.Location = new Point(84, 41);
            this.numberTwoButton.Name = "numberTwoButton";
            this.numberTwoButton.Size = new Size(66, 54);
            this.numberTwoButton.TabIndex = 1;
            this.numberTwoButton.Text = "2";
            this.numberTwoButton.UseVisualStyleBackColor = true;

            // numberThreeButton
            this.numberThreeButton.Location = new Point(156, 41);
            this.numberThreeButton.Name = "numberThreeButton";
            this.numberThreeButton.Size = new Size(66, 54);
            this.numberThreeButton.TabIndex = 2;
            this.numberThreeButton.Text = "3";
            this.numberThreeButton.UseVisualStyleBackColor = true;

            // numberSixButton
            this.numberSixButton.Location = new Point(157, 101);
            this.numberSixButton.Name = "numberSixButton";
            this.numberSixButton.Size = new Size(66, 54);
            this.numberSixButton.TabIndex = 5;
            this.numberSixButton.Text = "6";
            this.numberSixButton.UseVisualStyleBackColor = true;

            // numberFiveButton
            this.numberFiveButton.Location = new Point(84, 101);
            this.numberFiveButton.Name = "numberFiveButton";
            this.numberFiveButton.Size = new Size(66, 54);
            this.numberFiveButton.TabIndex = 4;
            this.numberFiveButton.Text = "5";
            this.numberFiveButton.UseVisualStyleBackColor = true;

            // numberFourButton
            this.numberFourButton.Location = new Point(12, 101);
            this.numberFourButton.Name = "numberFourButton";
            this.numberFourButton.Size = new Size(66, 54);
            this.numberFourButton.TabIndex = 3;
            this.numberFourButton.Text = "4";
            this.numberFourButton.UseVisualStyleBackColor = true;

            // numberNineButton
            this.numberNineButton.Location = new Point(156, 161);
            this.numberNineButton.Name = "numberNineButton";
            this.numberNineButton.Size = new Size(66, 54);
            this.numberNineButton.TabIndex = 8;
            this.numberNineButton.Text = "9";
            this.numberNineButton.UseVisualStyleBackColor = true;

            // numberEightButton
            this.numberEightButton.Location = new Point(84, 161);
            this.numberEightButton.Name = "numberEightButton";
            this.numberEightButton.Size = new Size(66, 54);
            this.numberEightButton.TabIndex = 7;
            this.numberEightButton.Text = "8";
            this.numberEightButton.UseVisualStyleBackColor = true;

            // numberSevenButton
            this.numberSevenButton.Location = new Point(12, 161);
            this.numberSevenButton.Name = "numberSevenButton";
            this.numberSevenButton.Size = new Size(66, 54);
            this.numberSevenButton.TabIndex = 6;
            this.numberSevenButton.Text = "7";
            this.numberSevenButton.UseVisualStyleBackColor = true;

            // operatorAdditionButton
            this.operatorAdditionButton.Location = new Point(297, 100);
            this.operatorAdditionButton.Name = "operatorAdditionButton";
            this.operatorAdditionButton.Size = new Size(59, 55);
            this.operatorAdditionButton.TabIndex = 14;
            this.operatorAdditionButton.Text = "+";
            this.operatorAdditionButton.UseVisualStyleBackColor = true;

            // operatorSubstractionButton
            this.operatorSubstractionButton.Location = new Point(228, 41);
            this.operatorSubstractionButton.Name = "operatorSubstractionButton";
            this.operatorSubstractionButton.Size = new Size(63, 54);
            this.operatorSubstractionButton.TabIndex = 15;
            this.operatorSubstractionButton.Text = "-";
            this.operatorSubstractionButton.UseVisualStyleBackColor = true;

            // operatorDivisionButton
            this.operatorDivisionButton.Location = new Point(297, 40);
            this.operatorDivisionButton.Name = "operatorDivisionButton";
            this.operatorDivisionButton.Size = new Size(60, 54);
            this.operatorDivisionButton.TabIndex = 16;
            this.operatorDivisionButton.Text = "/";
            this.operatorDivisionButton.UseVisualStyleBackColor = true;

            // operatorMultiplicationButton
            this.operatorMultiplicationButton.Location = new Point(228, 101);
            this.operatorMultiplicationButton.Name = "operatorMultiplicationButton";
            this.operatorMultiplicationButton.Size = new Size(63, 55);
            this.operatorMultiplicationButton.TabIndex = 17;
            this.operatorMultiplicationButton.Text = "*";
            this.operatorMultiplicationButton.UseVisualStyleBackColor = true;

            // displayTextBox
            this.displayTextBox.Location = new Point(12, 12);
            this.displayTextBox.Name = "displayTextBox";
            this.displayTextBox.ReadOnly = true;
            this.displayTextBox.Size = new Size(210, 23);
            this.displayTextBox.TabIndex = 18;

            // numberZeroButton
            this.numberZeroButton.Location = new Point(228, 162);
            this.numberZeroButton.Name = "numberZeroButton";
            this.numberZeroButton.Size = new Size(66, 54);
            this.numberZeroButton.TabIndex = 19;
            this.numberZeroButton.Text = "0";
            this.numberZeroButton.UseVisualStyleBackColor = true;

            // changeSignButton
            this.changeSignButton.Location = new Point(228, 12);
            this.changeSignButton.Name = "changeSignButton";
            this.changeSignButton.Size = new Size(39, 23);
            this.changeSignButton.TabIndex = 20;
            this.changeSignButton.Text = "+/-";
            this.changeSignButton.UseVisualStyleBackColor = true;
            this.changeSignButton.Click += this.ChangeSignButton_Click;

            // eraseButton
            this.eraseButton.Location = new Point(318, 11);
            this.eraseButton.Name = "eraseButton";
            this.eraseButton.Size = new Size(39, 23);
            this.eraseButton.TabIndex = 21;
            this.eraseButton.Text = "<-";
            this.eraseButton.UseVisualStyleBackColor = true;
            this.eraseButton.Click += this.EraseButton_Click;

            // startOverButton
            this.startOverButton.Location = new Point(273, 11);
            this.startOverButton.Name = "startOverButton";
            this.startOverButton.Size = new Size(39, 23);
            this.startOverButton.TabIndex = 22;
            this.startOverButton.Text = "esc";
            this.startOverButton.UseVisualStyleBackColor = true;
            this.startOverButton.Click += this.StartOverButton_Click;

            // fractionButton
            this.fractionButton.Location = new Point(297, 161);
            this.fractionButton.Name = "fractionButton";
            this.fractionButton.Size = new Size(59, 26);
            this.fractionButton.TabIndex = 23;
            this.fractionButton.Text = ",";
            this.fractionButton.UseVisualStyleBackColor = true;
            this.fractionButton.Click += this.FractionButton_Click;

            // equalsButton
            this.equalsButton.Location = new Point(297, 189);
            this.equalsButton.Name = "equalsButton";
            this.equalsButton.Size = new Size(59, 26);
            this.equalsButton.TabIndex = 24;
            this.equalsButton.Text = "=";
            this.equalsButton.UseVisualStyleBackColor = true;
            this.equalsButton.Click += this.EqualsButton_Click;

            // Calculator
            this.ClientSize = new Size(362, 228);
            this.Controls.Add(this.equalsButton);
            this.Controls.Add(this.fractionButton);
            this.Controls.Add(this.startOverButton);
            this.Controls.Add(this.eraseButton);
            this.Controls.Add(this.changeSignButton);
            this.Controls.Add(this.numberZeroButton);
            this.Controls.Add(this.displayTextBox);
            this.Controls.Add(this.operatorMultiplicationButton);
            this.Controls.Add(this.operatorDivisionButton);
            this.Controls.Add(this.operatorSubstractionButton);
            this.Controls.Add(this.operatorAdditionButton);
            this.Controls.Add(this.numberNineButton);
            this.Controls.Add(this.numberEightButton);
            this.Controls.Add(this.numberSevenButton);
            this.Controls.Add(this.numberSixButton);
            this.Controls.Add(this.numberFiveButton);
            this.Controls.Add(this.numberFourButton);
            this.Controls.Add(this.numberThreeButton);
            this.Controls.Add(this.numberTwoButton);
            this.Controls.Add(this.numberOneButton);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Name = "Calculator";
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void Print(Button operatorOrOperand)
        {
            bool buttonIsNumber = float.TryParse(operatorOrOperand.Text, out float buttonNumber) || int.TryParse(operatorOrOperand.Text, out int buttonInteger);
            bool isNumber = float.TryParse(this.displayTextBox.Text, out float number) || int.TryParse(this.displayTextBox.Text, out int integer);
            if (isNumber)
            {
                if (Evaluate.IsOperator(operatorOrOperand.Text[0]) && this.displayTextBox.Text[^1] != ',')
                {
                    if (!this.wasTheOperandPressed)
                    {
                        this.wasTheOperandPressed = true;
                        this.evaluateExpression = $"{number}" + operatorOrOperand.Text;
                        this.displayTextBox.Text = operatorOrOperand.Text;
                    }
                    else
                    {
                        this.evaluateExpression += $"{number}";
                        if (!Evaluate.CheckInput(this.evaluateExpression))
                        {
                            this.displayTextBox.Text = "Делить на ноль нельзя";
                            this.wasTheOperandPressed = false;
                        }
                        else
                        {
                            float resultOfCalculation = Evaluate.EvaluateString(this.evaluateExpression);
                            this.evaluateExpression = $"{resultOfCalculation}" + operatorOrOperand.Text;
                            this.displayTextBox.Text = $"{resultOfCalculation}" + " " + operatorOrOperand.Text;
                            this.startNewOperand = true;
                        }
                    }
                }
                else if (buttonIsNumber)
                {
                    if (this.startNewOperand)
                    {
                        this.displayTextBox.Text = operatorOrOperand.Text;
                        this.startNewOperand = false;
                    }
                    else
                    {
                        if (number != 0)
                        {
                            this.displayTextBox.Text += operatorOrOperand.Text;
                        }
                    }
                }
            }
            else
            {
                if (buttonIsNumber)
                {
                    this.displayTextBox.Text = operatorOrOperand.Text;
                    this.startNewOperand = false;
                }
            }
        }

        private void OperandOrOperatorButton_Click(object? sender, EventArgs e)
        {
            Button button = (Button)sender!;
            this.Print(button);
        }

        private void ChangeSignButton_Click(object? sender, EventArgs e)
        {
            if (float.TryParse(this.displayTextBox.Text, out float number))
            {
                this.displayTextBox.Text = $"{-number}";
            }
        }

        private void EraseButton_Click(object? sender, EventArgs e)
        {
            bool isNumber = (float.TryParse(this.displayTextBox.Text, out float number) || int.TryParse(this.displayTextBox.Text, out int integer)) && this.displayTextBox.Text[^1] != ',';
            if (isNumber)
            {
                if (this.displayTextBox.Text.Remove(this.displayTextBox.Text.Length - 1) == "-")
                {
                    this.displayTextBox.Text = string.Empty;
                }
                else if (this.displayTextBox.Text.Length > 0)
                {
                    this.displayTextBox.Text = this.displayTextBox.Text.Remove(this.displayTextBox.Text.Length - 1);
                }
            }
        }

        private void StartOverButton_Click(object? sender, EventArgs e)
        {
            this.displayTextBox.Text = string.Empty;
            this.wasTheOperandPressed = false;
            this.startNewOperand = false;
        }

        private void FractionButton_Click(object? sender, EventArgs e)
        {
            bool isNumber = (float.TryParse(this.displayTextBox.Text, out float number) || int.TryParse(this.displayTextBox.Text, out int integer)) && this.displayTextBox.Text[^1] != ',';
            if (isNumber && !this.displayTextBox.Text.Contains(','))
            {
                this.displayTextBox.Text += ",";
            }
        }

        private void EqualsButton_Click(object? sender, EventArgs e)
        {
            bool isNumber = (float.TryParse(this.displayTextBox.Text, out float number) || int.TryParse(this.displayTextBox.Text, out int integer)) && this.displayTextBox.Text[^1] != ',';
            if (isNumber && this.wasTheOperandPressed)
            {
                this.evaluateExpression += $"{number}";
                if (!Evaluate.CheckInput(this.evaluateExpression))
                {
                    this.displayTextBox.Text = "Делить на ноль нельзя";
                    this.wasTheOperandPressed = false;
                    return;
                }

                float resultOfCalculation = Evaluate.EvaluateString(this.evaluateExpression);
                this.displayTextBox.Text = $"{resultOfCalculation}";
                this.wasTheOperandPressed = false;
            }
        }
    }
}
