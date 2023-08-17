using Microsoft.Extensions.Logging;

namespace StringManipulation.Tests;

public class StringOperationsTest
{
    [Fact(Skip = "Esta prueba no es valida en este momento, TICKET-001")]
    public void ConcatenateStrings()
    {
        // Arrange
        var strOperations = new StringOperations();
        
        // Act
        var result = strOperations.ConcatenateStrings("Hello", "World");
        
        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal("Hello World", result);
    }

    [Fact]
    public void IsPalindrome_True()
    {
        // Arrange
        var strOperations = new StringOperations();
        
        // Act
        var result = strOperations.IsPalindrome("ama");

        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void IsPalindrome_False()
    {
        // Arrange
        var strOperations = new StringOperations();
        
        // Act
        var result = strOperations.IsPalindrome("dama");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void RemoveWhitespace()
    {
        // Arrange
        var strOperations = new StringOperations();
        
        // Act
        var result = strOperations.RemoveWhitespace(" hello world ");
        
        // Assert
        Assert.Equal("helloworld", result);
    }

    [Fact]
    public void QuantityInWords()
    {
        // Arrange
        var strOperations = new StringOperations();
        
        // Act
        var result = strOperations.QuantityInWords("cat", 10);
        
        // Assert
        Assert.StartsWith("ten", result);
        Assert.Contains("cats", result);
    }
    
    [Fact]
    public void GetStringLength_Exception()
    {
        // Arrange
        var strOperations = new StringOperations();
        
        // Act and Assert
        Assert.ThrowsAny<ArgumentNullException>(() => strOperations.GetStringLength(null));
    }

    [Theory]
    [InlineData("V", 5)]
    [InlineData("III", 3)]
    public void FromRomanToNumber(string romanNumber, int expected)
    {
        var strOperations = new StringOperations();
        var result = strOperations.FromRomanToNumber(romanNumber);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CountOccurrences()
    {
        var mockLogger = new Mock<ILogger<StringOperations>>();
        var strOperations = new StringOperations(mockLogger.Object);
        var result = strOperations.CountOccurrences("Hello World", 'o');
        Assert.Equal(2, result);
    }

    [Fact]
    public void ReadFile()
    {
        var strOperations = new StringOperations();
        var mockFileReader = new Mock<IFileReaderConector>();
        mockFileReader.Setup(p => p.ReadString(It.IsAny<string>())).Returns("Reading File");
        var result = strOperations.ReadFile(mockFileReader.Object, "file.txt");
        Assert.Equal("Reading File", result);
    }
}