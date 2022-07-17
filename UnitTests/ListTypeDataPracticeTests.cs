using Microsoft.VisualStudio.TestTools.UnitTesting;
using dataProcessCheck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace dataProcessCheckTests
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
            List<string> input = new List<string> { "1", "A", "B", "11", "10", "2", "03", "1" };
            List<string> expected = new List<string> { "1", "A", "B", "11", "10", "2", "03", "1" };

            //act
            var output = service.ListOrderBy(input);

            //assert
            // Assert.AreEqual(expected, output);
            CollectionAssert.AreEqual(expected, output, StructuralComparisons.StructuralComparer);
        }
    }
}