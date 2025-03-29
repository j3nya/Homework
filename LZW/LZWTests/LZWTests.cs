using System.Reflection.Metadata;

namespace LZWTests;
public class Tests
{
    string TextFilePath;
    string ExeFilePath;
    string HTMLFilePath;
    [SetUp]
    public void Setup()
    {
        string baseDirectory = AppContext.BaseDirectory;

        string TextFileRelativePath = "./FilesForTests/TextFile.txt";
        string ExeFileRelativePath = "./FilesForTests/ExecutableFile.exe";
        string HTMLFileRelativePath = "./FilesForTests/HTMLFile.html";

        string TextFilePath = Path.GetFullPath(TextFileRelativePath, baseDirectory);
        string ExeFilePath = Path.GetFullPath(ExeFileRelativePath, baseDirectory);
        string HTMLFilePath = Path.GetFullPath(HTMLFileRelativePath, baseDirectory);
    }

    [Test]
    public void CheckIfCompressionAlgorithmsPreservesOriginalInformationTextFiles()
    {
    }
    [Test]

    public void CheckIfCompressionAlgorithmsPreservesOriginalInformationExeFiles()
    {

    }
    [Test]

    public void CheckForInvalidInput()
    {

    }
    [Test]
    public void CheckForInvalidKey()
    {

    }
    [Test]
    public void CheckForEmptyFileConentsCase()
    {

    }
}
