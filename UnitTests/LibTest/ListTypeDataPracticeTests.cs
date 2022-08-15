using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

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
        public void ListOrderByTest()
        {
            //arrange
            List<string> input1 = new List<string> { "1", "A", "B", "11", "10", "2", "03", "1" };
            List<string> expected1 = new List<string> { "1", "1", "2", "03", "10", "11", "A", "B", };

            //act
            var output = service.SemiNumericListOrderBy(input1);

            //assert
            CollectionAssert.AreEqual(expected1, output);
        }
    }
}