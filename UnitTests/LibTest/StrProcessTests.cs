using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Lib.Model;

namespace UnitTests.LibTest
{
    [TestClass()]
    public class StrProcessTests
    {
        StrProcess service;

        [TestInitialize]
        public void TestInitialize()
        {
            service = new StrProcess();
        }

        [TestMethod()]
        public void GetApplyCodeTest()
        {
            //arrange
            var VACCIDNO1 = "    1234567890123";
            var VACCIDNO2 = "    12345678901234";
            var VACCIDNO3 = "    12300678901234";
            var VACCIDNO4 = "   01234567890123456";
            var VACCIDNO5 = "00001234567890123456";

            //act
            var applyCode1 = service.GetApplyCode(VACCIDNO1);
            var applyCode2 = service.GetApplyCode(VACCIDNO2);
            var applyCode3 = service.GetApplyCode(VACCIDNO3);
            var applyCode4 = service.GetApplyCode(VACCIDNO4);
            var applyCode5 = service.GetApplyCode(VACCIDNO5);

            //assert
            Assert.AreEqual("123456", applyCode1);
            Assert.AreEqual("12345", applyCode2);
            Assert.AreEqual("123", applyCode3);
            Assert.AreEqual("1234", applyCode4);
            Assert.AreEqual("1234", applyCode5);
        }
    }
}