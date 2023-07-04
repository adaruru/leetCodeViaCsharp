using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib;
using System;

namespace UnitTests.LibTest
{
    [TestClass()]
    public class DateFormatTests
    {
        DateFormat service;

        [TestInitialize]
        public void TestInitialize()
        {
            service = new DateFormat();
        }

        [TestMethod()]
        public void ToTaiwanCalendarStringTest()
        {
            //arrange
            var arrange = DateTime.Now;
            //act
            var act1 = service.ToTaiwanCalendarString(arrange, "yyyyMMdd");
            //assert
            Assert.AreEqual("5", act1);
        }
    }
}