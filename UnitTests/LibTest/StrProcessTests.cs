using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Lib.Model;
using static Lib.StrProcess;
using System.IO;
using System.Security;

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
        public enum TestEnum
        {
            DefaultTest = 0,
            FirstTest = 1,
            SecondTest = 2,
        }


        [TestMethod()]
        public void SecureStringToStringTest()
        {
            //arrange
            var input = "ASSDFSDF3444";

            //加密
            SecureString arrange = new SecureString();
            foreach (char c in input)
            {
                arrange.AppendChar(c);
            }

            //act 解密
            var act1 = service.SecureStringToString1(arrange);
            var act2 = service.SecureStringToString2(arrange);

            //assert
            Assert.AreEqual(act1, act1);
        }

        [TestMethod()]
        public void ContainTest()
        {
            //arrange
            var arrange = "TDRr";
           
            //act null 不能執行contain
            var act1 = arrange.Contains("R");
            var act2 = arrange.Contains("r");

            //assert
            Assert.AreEqual(true, act1);
            Assert.AreEqual(false, act2);
        }

        [TestMethod()]
        public void GetCheckCodeTest()
        {
            //arrange
            var arrange = "008100";
            //act
            var act1 = service.GetCheckCode(arrange);
            //assert
            Assert.AreEqual("5", act1);
        }

        [TestMethod()]
        public void SplitTest()
        {
            //arrange
            var arrange = "sadfaaa_aaa_sdf_sdf_sdfsdf";
            var arrange2 = "Test_TestImport_temp_20230419094657.json";

            //act
            var act1 = arrange.Split('_')[0];

            var act2 = arrange2.Substring(0, arrange2.LastIndexOf('_'));
            var act3 = act2.Substring(0, act2.LastIndexOf('_'));
            var act4 = act2.Substring(act2.LastIndexOf('_') + 1);
            //assert
            Assert.AreEqual("sadfaaa", act1);
            Assert.AreEqual("Test_TestImport_temp", act2);
            Assert.AreEqual("Test_TestImport", act3);
            Assert.AreEqual("temp", act4);
        }

        [TestMethod()]
        public void EnumStringTest()
        {
            //arrange
            TestEnum? arrange = TestEnum.FirstTest;
            //act
            var key = (int)arrange;
            var value = arrange.ToString();

            arrange = null;
            //var nullkey = (int)arrange; runtime error
            var nullValue = arrange.ToString();

            //assert
            Assert.AreEqual(1, key);
            Assert.AreEqual("FirstTest", value);
            Assert.AreEqual("", nullValue);
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

        [TestMethod()]
        public void StrSubAllTest()
        {
            service.StrSubAll();
            //assert
            Assert.AreEqual(1, 1);
        }
    }
}