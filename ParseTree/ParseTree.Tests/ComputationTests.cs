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
        Assert.Multiple (() =>
        {
            Assert.That(ParseTree.EvaluateExpression(inputSubstract), Is.EqualTo((float)-1));
            Assert.That(ParseTree.EvaluateExpression(inputMiltiply), Is.EqualTo((float)2));
            Assert.That(ParseTree.EvaluateExpression(inputAdd), Is.EqualTo((float)3));
            Assert.That(ParseTree.EvaluateExpression(inputDivide), Is.EqualTo((float)1/ 2));
            Assert.That(ParseTree.EvaluateExpression(inputNegativeSubstract), Is.EqualTo((float)3));
            Assert.That(ParseTree.EvaluateExpression(inputNegativeMiltiply), Is.EqualTo((float)2));
            Assert.That(ParseTree.EvaluateExpression(inputNegativeAdd), Is.EqualTo((float)-1));
            Assert.That(ParseTree.EvaluateExpression(inputNegativeDivide), Is.EqualTo((float)-1/2));
        });
    }
    public void CheckIfTreeWithDepthOfThreeComputeIsCorrect()
    {
        string input = "(* (- 1 2) (/ (+ 3 4) 2))";
        string inputNegative = "(* (- -1 2) (/ (+ 3 -4) -2))";
        Assert.Multiple (() =>
        {
            Assert.That(ParseTree.EvaluateExpression(input), Is.EqualTo((float)-1 * (7/2)));
            Assert.That(ParseTree.EvaluateExpression(inputNegative), Is.EqualTo((float)-1 * (3/2)));
        });

    }
    public void CheckIfTreeWithDepthOfFiveComputeIsCorrect()
    {
        string input = "(* (- 1 2) (/ (+ (- 3 (+ 1 9)) 4) 2))";
        string inputNegative = "(* (- 1 -2) (/ (+ (- 3 (+ -1 9)) -4) -2))";
        Assert.Multiple (() =>
        {
            Assert.That(ParseTree.EvaluateExpression(input), Is.EqualTo((float)-1 * (11/2)));
            Assert.That(ParseTree.EvaluateExpression(inputNegative), Is.EqualTo((float)27/2));
        });
    }
    public void CheckIfThrowsExceptionWhenDivisorsIs0()
    {
        string longInput = "(* (- 1 2) (/ 2 (+ (- 3 (+ -3 2)) 4)))";
        string input = "(/ 1 0)";
        Assert.Multiple (() => 
        {
            Assert.Throws<DivideByZeroException>(() => ParseTree.EvaluateExpression(input));
            Assert.Throws<DivideByZeroException>(() => ParseTree.EvaluateExpression(longInput));
        });
    }
}
