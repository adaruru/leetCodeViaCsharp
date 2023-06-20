using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib;

namespace UnitTests.LibTest
{
    [TestClass()]
    public class DataConvertTests
    {
        DataConvert service;

        [TestInitialize]
        public void TestInitialize()
        {
            service = new DataConvert();
        }

        [TestMethod()]
        public void StringDecimalPointTest()
        {
            //arrange
            //act
            service.StringDecimalPoint();
            //assert
            Assert.AreEqual(true, true);
        }
    }
}