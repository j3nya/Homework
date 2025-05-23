namespace CountZeroElementsTests;

using System.Security.Principal;
using CountZeroElements;

public class CountZeroElementsTests
{
    private MyList<int> myList = new MyList<int>();

    [SetUp]
    public void Setup()
    {
        myList.AddElement(3);
        myList.AddElement(0);
        myList.AddElement(6);
        myList.AddElement(0);
    }

    [Test]
    public void CheckIfReturnRightAmountOfZeros()
    {
        Assert.That(ZerosCounter.CountZeros(myList, x => x == 0), Is.EqualTo(2));
    }

    [Test]

    public void CheckIfAddAndCountWorks()
    {
        myList.AddElement(7);
        Assert.Multiple(() =>
        {
            Assert.That(myList[myList.Count - 1] == 7);
            Assert.That(myList.Count == 5);
        });
    }
}
