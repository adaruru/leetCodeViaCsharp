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
    public class ListTypeDataPracticeTests
    {
        ListTypeDataPractice service;

        [TestInitialize]
        public void TestInitialize()
        {
            service = new ListTypeDataPractice();
        }

        [TestMethod()]
        public void ListUpdateTest()
        {
            //arrange
            //act
            service.ListUpdate();
            //assert
            Assert.AreEqual("123", "123");
        }

        [TestMethod()]
        public void ListValidateTest2()
        {
            //arrange
            List<ObjectWithDefaultValue> list = new List<ObjectWithDefaultValue>() {
                new ObjectWithDefaultValue {
                    ValuelikeString ="123",
                    ValueIsString ="123",
                    numberInt=123},
                new ObjectWithDefaultValue {
                    ValuelikeString ="1233",
                    ValueIsString ="1233",
                    numberInt=1233},
                new ObjectWithDefaultValue {
                    ValuelikeString ="123123",
                    ValueIsString ="123123",
                    numberInt=123123},
            };
            //act
            var output1 = service.ListValidate2(list);
            //assert
            Assert.AreEqual("123", output1);
        }

        [TestMethod()]
        public void ListValidateTest()
        {
            //arrange
            List<ObjectWithDefaultValue> list = new List<ObjectWithDefaultValue>() {
                new ObjectWithDefaultValue {
                    ValuelikeString ="123",
                    ValueIsString ="123",
                    numberInt=123},
                new ObjectWithDefaultValue {
                    ValuelikeString ="1233",
                    ValueIsString ="1233",
                    numberInt=1233},
                new ObjectWithDefaultValue {
                    ValuelikeString ="123123",
                    ValueIsString ="123123",
                    numberInt=123123},
            };
            //act
            var output1 = service.ListValidate(list);
            //assert
            Assert.AreEqual(true, output1);
        }


        [TestMethod()]
        public void ChuckdObjectTest()
        {
            //arrange
            var temp = new List<ObjectWithDefaultValue>();
            var packedNumber1 = 3;//每兩筆一包
            List<string> input1 = new List<string> {
                "1", "2", "3",
                "4", "5", "6",
                "7", "8", "9",
                "10", "11" };
            List<string[]> expected1 = new List<string[]> {
                new string[]{"1","2","3" },
                new string[]{"4","5","6" },
                new string[]{"7","8","9" },
                new string[]{"10", "11" },
            };
            //act
            var output1 = service.ChuckdObject(packedNumber1, input1);

            //assert
            for (int i = 0; i < expected1.Count(); i++)
            {
                CollectionAssert.AreEqual(expected1[i], output1[i]);
            }
        }

        [TestMethod()]
        public void ChuckdObjectByLoopTest()
        {
            //arrange
            var temp = new List<ObjectWithDefaultValue>();
            var packedNumber1 = 3;//每兩筆一包
            List<string> input1 = new List<string> {
                "1", "2", "3",
                "4", "5", "6",
                "7", "8", "9",
                "10", "11" };
            List<List<string>> expected1 = new List<List<string>> {
                new List<string> {"1","2","3" },
                new List<string> {"4","5","6" },
                new List<string> {"7","8","9" },
                new List<string> {"10", "11" },
            };
            //act
            var output1 = service.ChuckdObjectByLoop(packedNumber1, input1);

            //assert
            for (int i = 0; i < expected1.Count(); i++)
            {
                CollectionAssert.AreEqual(expected1[i], output1[i]);
            }
        }

        [TestMethod()]
        public void SemiNumericListOrderByTest()
        {
            //arrange
            List<string> input1 = new List<string> { "3", "2", "6", "02", "01", "1", "001" };
            List<string> expected1 = new List<string> { "01", "1", "001", "2", "02", "3", "6" };

            List<string> input2 = new List<string> { "1", "A", "B", "11", "10", "2", "03", "1" };
            List<string> expected2 = new List<string> { "1", "1", "2", "03", "10", "11", "A", "B", };

            //act
            var output1 = service.SemiNumericListOrderBy(input1);
            var output2 = service.SemiNumericListOrderBy(input2);

            //assert
            CollectionAssert.AreEqual(expected1, output1);
            CollectionAssert.AreEqual(expected2, output2);
        }
    }
}