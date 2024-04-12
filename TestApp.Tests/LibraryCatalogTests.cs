using NUnit.Framework;
using System;
using TestApp.Library;

namespace TestApp.Tests;

[TestFixture]
public class LibraryCatalogTests
{
    private LibraryCatalog _catalog = null!;

    [SetUp]
    public void SetUp()
    {
        this._catalog = new();
    }

    [Test]
    public void Test_AddBook_BookAddedToCatalog()
    {
        // Arrange
        string isbn = "148410-0";
        string bookName = "Harry Potter";
        string author = "Rouling K";

        string isbn1 = "148410-1";
        string bookName1 = "Person named Ove";
        string author1 = "Bakman Fredrik";

        string expectedResult = $"Library Catalog:" +
            $"{Environment.NewLine}Harry Potter by Rouling K (ISBN: 148410-0)" +
            $"{Environment.NewLine}Person named Ove by Bakman Fredrik (ISBN: 148410-1)";


        // Act
        this._catalog.AddBook(isbn, bookName, author);
        this._catalog.AddBook(isbn1, bookName1, author1);
        string result = this._catalog.DisplayCatalog();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));

    }

    [Test]
    public void Test_GetBook_BookExists_ReturnsBook()
    {
        // Arrange
        string isbn = "148410-0";
        string bookName = "Harry Potter";
        string author = "Rouling K";

        string isbn1 = "148410-1";
        string bookName1 = "Person named Ove";
        string author1 = "Bakman Fredrik";


        // Act
        this._catalog.AddBook(isbn, bookName, author);
        this._catalog.AddBook(isbn1, bookName1, author1);
        Book searchedBook = this._catalog.GetBook(isbn);


        // Assert
        Assert.That(searchedBook.Isbn, Is.EqualTo(isbn));
        Assert.That(searchedBook.Title, Is.EqualTo(bookName));
        Assert.That(searchedBook.Author, Is.EqualTo(author));
    }

    [Test]
    public void Test_GetBook_BookDoesNotExist_ThrowsArgumentException()
    {
        // Arrange
        string isbn = "148410-0";
        string bookName = "Harry Potter";
        string author = "Rouling K";


        string getISBN = "149991-25";

        // Act & Assert
        this._catalog.AddBook(isbn , bookName, author);
        Assert.That(() => this._catalog.GetBook(getISBN), Throws.ArgumentException);
    }

    [Test]
    public void Test_DisplayCatalog_NoBooks_ReturnsEmptyString()
    {
        // Arrange
        string isbn = string.Empty;
        string bookName = string.Empty;
        string author = string.Empty;
        string expectedResult = string.Empty;

        // Act
        string result = this._catalog.DisplayCatalog();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_DisplayCatalog_WithBooks_ReturnsFormattedCatalog()
    {
        // Arrange
        string isbn = "148410-0";
        string bookName = "Harry Potter";
        string author = "Rouling K";

        string isbn1 = "148410-1";
        string bookName1 = "Person named Ove";
        string author1 = "Bakman Fredrik";

        string expectedResult = $"Library Catalog:" +
            $"{Environment.NewLine}Harry Potter by Rouling K (ISBN: 148410-0)" +
            $"{Environment.NewLine}Person named Ove by Bakman Fredrik (ISBN: 148410-1)";


        // Act
        this._catalog.AddBook(isbn, bookName, author);
        this._catalog.AddBook(isbn1, bookName1, author1);
        string result = this._catalog.DisplayCatalog();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}
