namespace ParseTree;

public class CheckInputTests
{
    [Test]
    public void CheckIfCorrectInputReturnsTrue()
    {
        Assert.Multiple (() =>
        {
            Assert.That(InputHandler.CheckInput("(* 3 1)"));
            Assert.That(InputHandler.CheckInput("(* (- 1 -2) (/ (+ (- 3 (+ -1 9)) -4) -2))"));
            Assert.That(InputHandler.CheckInput("(9)"));
        });
    }

    [Test]
    public void CheckIfIncorrectInputReturnsFalse()
    {
        Assert.Multiple (() =>
        {
            Assert.That(!InputHandler.CheckInput(""));
            Assert.That(!InputHandler.CheckInput("()"));
            Assert.That(!InputHandler.CheckInput("9"));
            Assert.That(!InputHandler.CheckInput("(* ( 1 -2) (/ (+ (- 3 + -1 9)) -4) -2)"));
        });
    }
    [Test]
    public void CheckIfIncorrectInputExceptionThrows()
    {
        Assert.Throws<IncorrectInputException>(() => ParseTree.EvaluateExpression(""));
    }
    [Test]
    public void CheckIfToNodesWorksCorrectly()
    {
        string longInput = "(* (- 1 -2) (/ (+ (- 3 (+ -1 9)) -4) -2))";
        string input = "(* 3 1)";
        Assert.Multiple (() =>
        {
            Assert.That(InputHandler.ToNodes(longInput)[0], Is.EqualTo("*"));
            Assert.That(InputHandler.ToNodes(longInput)[1], Is.EqualTo("(- 1 -2)"));
            Assert.That(InputHandler.ToNodes(longInput)[2], Is.EqualTo("(/ (+ (- 3 (+ -1 9)) -4) -2)"));
            Assert.That(InputHandler.ToNodes(input)[0], Is.EqualTo("*"));
            Assert.That(InputHandler.ToNodes(input)[1], Is.EqualTo("3"));
            Assert.That(InputHandler.ToNodes(input)[2], Is.EqualTo("1"));
        });
    }
}