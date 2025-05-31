namespace TrieTests;
using Trie;

/// <summary>
/// Tests to check the functions of the trie class.
/// </summary>
public class TrieTests
{
    private Trie trie;

    /// <summary>
    /// Method which is called before each test is run.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        this.trie = new Trie();
        this.trie.Add("Sobaka");
        this.trie.Add("Koshka");
        this.trie.Add("Sobranie");
        this.trie.Add("Sobak");
    }

    /// <summary>
    /// Check if contains returns true when the word is actually contained in the trie.
    /// </summary>
    [Test]
    public void CheckIfContainsReturnsTrue()
    {
        Assert.That(this.trie.Contains("Sobaka"));
    }

    /// <summary>
    /// Check if contains returns false when the word is not in the trie.
    /// </summary>
    [Test]
    public void CheckIfContainsReturnsFalse()
    {
        Assert.That(!this.trie.Contains("Medved"));
    }

    /// <summary>
    /// Check if HowManyStartsWithPrefix returns the correct number of words beginning with the given prefix.
    /// </summary>
    [Test]
    public void CheckIfHowManyStartsWithPrefixReturnsRightAmount()
    {
        Assert.Multiple(() =>
        {
            Assert.That(this.trie.HowManyStartWithPrefix("Sob"), Is.EqualTo(3));
            Assert.That(this.trie.HowManyStartWithPrefix("Med"), Is.EqualTo(0));
            Assert.That(this.trie.HowManyStartWithPrefix("Sobak"), Is.EqualTo(2));
        });
    }

    /// <summary>
    /// Check if Remove returns false when the word was not in the trie.
    /// </summary>
    [Test]
    public void CheckIfRemoveReturnsFalse()
    {
        Assert.Multiple(() =>
        {
            Assert.That(this.trie.Remove("🐟"), Is.EqualTo(false));
            Assert.That(this.trie.Remove("Sobaka🐟"), Is.EqualTo(false));
        });
    }

    /// <summary>
    /// Check if Remove removes a word from the trie.
    /// </summary>
    [Test]
    public void CheckIfRemoveRemovesString()
    {
        Assert.Multiple(() =>
        {
            Assert.That(this.trie.Remove("Sobaka"), Is.EqualTo(true));
            Assert.That(this.trie.Contains("Sobaka"), Is.EqualTo(false));
        });
    }

    /// <summary>
    /// Check if removing prefix leaves words containing prefix.
    /// </summary>
    [Test]
    public void CheckIfRemoveRemovesPrefix()
    {
        this.trie.Remove("Sobak");
        Assert.That(this.trie.Contains("Sobaka"), Is.EqualTo(true));
    }

    /// <summary>
    /// Check if removing word containing prefix leaves prefix.
    /// </summary>
    [Test]
    public void CheckIfRemovesWordWithContainingPrefixes()
    {
        this.trie.Remove("Sobaka");
        Assert.That(this.trie.Contains("Sobak"), Is.EqualTo(true));
    }

    /// <summary>
    /// Check if Add adds a word to trie.
    /// </summary>
    [Test]
    public void CheckIfAddAddsString()
    {
        Assert.That(this.trie.Add("Medved"), Is.EqualTo(true));
        Assert.That(this.trie.Contains("Medved"), Is.EqualTo(true));
    }

    /// <summary>
    /// Check if Add returns false when the word was already in the trie.
    /// </summary>
    [Test]
    public void CheckIfAddReturnsFalse()
    {
        Assert.That(this.trie.Add("Sobaka"), Is.EqualTo(false));
    }
}