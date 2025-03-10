using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib;
using DataProcessCheck;
using System.IO;
using System.Text;
using System;

namespace UnitTests.LibTest
{
    [TestClass()]
    public class FortifyFixHelperTests
    {

        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestMethod()]
        public void CustomReadToEndTest()
        {
            // Arrange
            string input = @" [TestMethod()]
        public void CustomReadToEndTest()
        {
            // Arrange
            string input = ""H"";
            using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(input));
            using var reader = new StreamReader(memoryStream);

            // Arrange2
            byte[] buffer = new byte[31457280];
            // (可選) 填入任意內容
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte)(i % 256);
            }
            using var memoryStream2 = new MemoryStream(buffer);
            using var reader2 = new StreamReader(memoryStream2);

            // Act
            string result = reader.CustomReadToEnd();
            string result2 = reader2.CustomReadToEnd();

            // Assert
            Assert.AreEqual(input, result);
            Assert.AreEqual(31457280, Encoding.UTF8.GetByteCount(result2));

        }";
            using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(input));
            using var reader = new StreamReader(memoryStream);

            // Arrange2
            byte[] buffer = new byte[31457280];
            // (可選) 填入任意內容
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte)(i % 256);
            }
            using var memoryStream2 = new MemoryStream(buffer);
            using var reader2 = new StreamReader(memoryStream2);

            // Arrange3
            byte[] buffer3 = new byte[31457281];
            // (可選) 填入任意內容
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte)(i % 256);
            }
            using var memoryStream3 = new MemoryStream(buffer3);
            using var reader3 = new StreamReader(memoryStream3);

            // Act 1 2
            string result = reader.CustomReadToEnd();
            string result2 = reader2.CustomReadToEnd();

            // Assert 1 2
            Assert.AreEqual(input, result);
            Assert.AreEqual(31457280, result2.Length);

            // Act 3 Assert 3
            var ex = Assert.ThrowsException<Exception>(() => reader3.CustomReadToEnd());
            Assert.AreEqual("CustomReadToEnd Response 讀取異常，內容超過 30MB 限制", ex.Message);

        }
        [TestMethod()]
        public void CustomReadLine()
        {
            // Arrange 測試讀取一行
            string input = @" [TestMethod()]
        public void CustomReadToEndTest()
        {
            // Arrange
            string input = ""H"";
            using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(input));
            using var reader = new StreamReader(memoryStream);

            // Arrange2
            byte[] buffer = new byte[31457280];
            // (可選) 填入任意內容
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte)(i % 256);
            }
            using var memoryStream2 = new MemoryStream(buffer);
            using var reader2 = new StreamReader(memoryStream2);

            // Act
            string result = reader.CustomReadToEnd();
            string result2 = reader2.CustomReadToEnd();

            // Assert
            Assert.AreEqual(input, result);
            Assert.AreEqual(31457280, Encoding.UTF8.GetByteCount(result2));

        }";
            using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(input));
            using var reader = new StreamReader(memoryStream);

            // Arrange2 測試第一行是空的
            string input2 = @"
[TestMethod()]
        }";
            using var memoryStream2 = new MemoryStream(Encoding.UTF8.GetBytes(input2));
            using var reader2 = new StreamReader(memoryStream2);

            // Act 1 2
            string result = reader.CustomReadLine();
            string result2 = reader2.CustomReadLine();

            // Assert 1 2
            Assert.AreEqual(" [TestMethod()]", result);
            Assert.AreEqual(string.Empty, result2);
        }
    }
}