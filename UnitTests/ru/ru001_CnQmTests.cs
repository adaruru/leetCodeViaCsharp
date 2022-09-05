using LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTests.ru
{
    [TestClass()]
    public class ru001_CnQmTests
    {
        ru001_CnQm service;

        [TestInitialize]
        public void TestInitialize()
        {
            service = new ru001_CnQm();
        }
        [TestMethod()]
        public void DictionaryCmQnTest()
        {
            //arrange
            Dictionary<string, decimal> txns = new Dictionary<string, decimal>
            {
                ["a"] = 1,
                ["b"] = 2,
                ["c"] = 3
            };
            var expect = new List<Dictionary<string, decimal>>() {
                new Dictionary<string, decimal>{["a"] = 1},
                new Dictionary<string, decimal>{["b"] = 2},
                new Dictionary<string, decimal>{["a"] = 1,
                                                ["b"] = 2},
                new Dictionary<string, decimal>{["c"] = 3},
                new Dictionary<string, decimal>{["a"] = 1,
                                                ["c"] = 3},
                new Dictionary<string, decimal>{["b"] = 2,
                                                ["c"] = 3}};
            //act
            var act = service.DictionaryCmQn(txns);
            //assert
            for (int i = 0; i < act.Count; i++)
            {
                CollectionAssert.AreEqual(expect[i], act[i]);
            }

        }
        [TestMethod()]
        public void StringCmQnTest()
        {
            //arrange
            string[] values = { "a", "b", "c" };
            var expect = new List<List<string>>()
            {
                new List<string>{"a"},
                new List<string>{"b"},
                new List<string>{"a","b"},
                new List<string>{"c"},
                new List<string>{"a","c"},
                new List<string>{"b","c"},
            };
            //act
            var act = service.StringCmQn(values);
            //assert
            for (int i = 0; i < act.Count; i++)
            {
                CollectionAssert.AreEqual(expect[i], act[i]);
            }
        }
    }
}