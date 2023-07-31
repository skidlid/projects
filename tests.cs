using System.IO;
using NUnit.Framework;

[TestFixture]
public class FileIOExampleTests
{
    private const string TestFilePath = "test_input.txt";
    private const string TestOutputFilePath = "test_output.txt";

    [SetUp]
    public void SetUp()
    {
        // Create a test input file with some test data
        File.WriteAllText(TestFilePath, "Test data line 1\nTest data line 2");
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up the test input and output files after each test
        if (File.Exists(TestFilePath))
            File.Delete(TestFilePath);

        if (File.Exists(TestOutputFilePath))
            File.Delete(TestOutputFilePath);
    }

    [Test]
    public void TestFileInput()
    {
        // Arrange
        using (var writer = new StreamWriter(TestOutputFilePath))
        {
            // Act
            FileIOExample.ReadFileContent(TestFilePath, writer);

            // Assert
            Assert.That(File.ReadAllText(TestOutputFilePath), Is.EqualTo("Test data line 1\nTest data line 2"));
        }
    }

    [Test]
    public void TestFileOutput()
    {
        // Arrange
        const string dataToWrite = "Hello, this is a test!";
        File.WriteAllText(TestFilePath, dataToWrite);

        // Act
        FileIOExample.WriteDataToFile(TestFilePath, TestOutputFilePath);

        // Assert
        Assert.That(File.ReadAllText(TestOutputFilePath), Is.EqualTo(dataToWrite));
    }
}
