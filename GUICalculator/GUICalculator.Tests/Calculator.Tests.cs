namespace GUICalculator
{
    public class CalculatorTests
    {
        [Test]
        public void CheckIfCheckInputReturnsCorrectValue()
        {
            Assert.Multiple(() =>
            {
                Assert.That(Evaluate.CheckInput("3+2"));
                Assert.That(!Evaluate.CheckInput("3/0"));
            });
        }

        [Test]

        public void CheckIfCalculateWorks()
        {
            Assert.Multiple(() =>
            {
                Assert.That(Evaluate.EvaluateString("3+2"), Is.EqualTo(3F + 2));
                Assert.That(Evaluate.EvaluateString("3-2"), Is.EqualTo(3F - 2));
                Assert.That(Evaluate.EvaluateString("3/2"), Is.EqualTo(3F / 2));
                Assert.That(Evaluate.EvaluateString("3*2"), Is.EqualTo(3F * 2));
                Assert.Throws<DivideByZeroException>(() => Evaluate.EvaluateString("3/0"));
            });
        }
    }
}
