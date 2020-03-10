using System;
using System.Reflection;
using ClassLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookTest
{
    [TestClass]
    public class UnitTest1
    {
        private Book book1;
        [TestInitialize]
        public void Testinit()
        {
            book1 = new Book("title", "author", 130, "1234567891011");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAuthorOneChar()
        {
            book1.Author = "a";
        }

        [TestMethod]
        public void TestAuthorTwoChar()
        {
            book1.Author = "ab";

            Assert.AreEqual("ab",book1.Author);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void TestPagesTooLow()
        {
            book1.Pages = 3;

            Assert.AreEqual(2, book1.Pages);
        }

        [TestMethod]
        public void TestPagesLowerLimit()
        {
            book1.Pages = 4;

            Assert.AreEqual(4, book1.Pages);
        }

        [TestMethod]
        public void TestPagesUpperLimit()
        {
            book1.Pages = 1000;

            Assert.AreEqual(1000, book1.Pages);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void TestPagesTooHigh()
        {
            book1.Pages = 1001;
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void TestIsbnTooshort()
        {
            book1.Isbn13 = "123456789787";
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void TestIsbnToolong()
        {
            book1.Isbn13 = "12645789654655";
        }

        [TestMethod]
        public void TestIsbn13digits()
        {
            book1.Isbn13 = "1264578965465";
            Assert.AreEqual(13,book1.Isbn13.Length);
        }
    }
}
