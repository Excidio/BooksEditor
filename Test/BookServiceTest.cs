using BooksEditor.Repository.Interfaces;
using BooksEditor.Services.Implementation;
using BooksEditor.Services.Interfaces;
using Moq;
using NUnit.Framework;

namespace BooksEditor.Test
{
    public class BookServiceTest
    {
        private readonly IBookService _bookService;

        public BookServiceTest()
        {
            var bookRepositoryMock = new Mock<IBookRepository>();

            _bookService = new BookService(bookRepositoryMock.Object);
        }

        [TestCase("978-5-496-00433-6")]
        [TestCase("978-5-93286-045-8")]
        [TestCase("978-5-8459-1911-3")]
        [TestCase("978-5-8459-2008-9")]
        [TestCase("3-88053-002-5")]
        [TestCase("3-88053-016-5")]
        public void IsbnValidateTrueTest(string isbn)
        {
            Assert.IsTrue(_bookService.IsValidIsbn(isbn));
        }

        [TestCase("978-5-496-00433-0")]
        [TestCase("3-88053-002-0")]
        public void IsbnValidateFalseTest(string isbn)
        {
            Assert.IsFalse(_bookService.IsValidIsbn(isbn));
        }
    }
}
