namespace ParseTree;

public class ComputationTests
{
    [Test]
    public void CheckIfTreeWithDepthOfOneComputeIsCorrect()
    {
        string inputSubstract = "(- 1 2)";
        string inputMiltiply = "(* 1 2)";
        string inputAdd = "(+ 1 2)";
        string inputDivide = "(/ 1 2)";
        string inputNegativeSubstract = "(- 1 -2)";
        string inputNegativeMiltiply = "(* -1 -2)";
        string inputNegativeAdd = "(+ 1 -2)";
        string inputNegativeDivide = "(/ -1 2)";
        Assert.Multiple(() =>
        {
            Assert.That(ParseTree.EvaluateExpression(inputSubstract), Is.EqualTo(-1F));
            Assert.That(ParseTree.EvaluateExpression(inputMiltiply), Is.EqualTo(2F));
            Assert.That(ParseTree.EvaluateExpression(inputAdd), Is.EqualTo(3F));
            Assert.That(ParseTree.EvaluateExpression(inputDivide), Is.EqualTo(1F / 2));
            Assert.That(ParseTree.EvaluateExpression(inputNegativeSubstract), Is.EqualTo(3F));
            Assert.That(ParseTree.EvaluateExpression(inputNegativeMiltiply), Is.EqualTo(2F));
            Assert.That(ParseTree.EvaluateExpression(inputNegativeAdd), Is.EqualTo(-1F));
            Assert.That(ParseTree.EvaluateExpression(inputNegativeDivide), Is.EqualTo(-1F / 2));
        });
    }

    [Test]
    public void CheckIfTreeWithDepthOfThreeComputeIsCorrect()
    {
        string input = "(* (- 1 2) (/ (+ 3 4) 2))";
        string inputNegative = "(* (- -1 2) (/ (+ 3 -4) -2))";
        Assert.Multiple(() =>
        {
            Assert.That(ParseTree.EvaluateExpression(input), Is.EqualTo(-7F / 2));
            Assert.That(ParseTree.EvaluateExpression(inputNegative), Is.EqualTo(-3F / 2));
        });
    }

    [Test]
    public void CheckIfTreeWithDepthOfFiveComputeIsCorrect()
    {
        string input = "(* (- 1 2) (/ (+ (- 3 (+ 1 9)) 4) 2))";
        string inputNegative = "(* (- 1 -2) (/ (+ (- 3 (+ -1 9)) -4) -2))";
        Assert.Multiple(() =>
        {
            Assert.That(ParseTree.EvaluateExpression(input), Is.EqualTo(3F / 2));
            Assert.That(ParseTree.EvaluateExpression(inputNegative), Is.EqualTo(27F / 2));
        });
    }

    [Test]
    public void CheckIfThrowsWhenDivisorsEquals0()
    {
        string longInput = "(* (- 1 2) (/ (+ (- 3 (+ 1 9)) 4) (- 1 1)))";
        Assert.Throws<DivideByZeroException>(() => ParseTree.EvaluateExpression(longInput));
    }

    [Test]
    public void CheckIfOneNumberComputeIsCorrect()
    {
        string input = "(1)";
        Assert.That(ParseTree.EvaluateExpression(input), Is.EqualTo(1));
    }

    [Test]
    public void CheckIfIncorrectOperationCharThrows()
    {
        Assert.Throws<IncorrectOperationCharException>(() => Operator.GetOperator(")"));
    }

    [Test]
    public void CheckMeaninglessExpressionExceptionThrows()
    {
        Multiplication multiplication = new Multiplication();

        Assert.Throws<MeaninglessExpressionException>(() => multiplication.Evaluate());
    }
}
