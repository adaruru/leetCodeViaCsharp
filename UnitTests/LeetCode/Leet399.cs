using LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTests.LeetCode
{
    [TestClass]
    public class Leet399
    {
        [TestMethod]
        public void Leet399Case1()
        {
            //arrange
            IList<IList<string>> Input1 = new List<IList<string>> { new List<string> { "a", "b" }, new List<string> { "b", "c" } };
            double[] values1 = { 2.0, 3.0 };
            IList<IList<string>> queries1 = new List<IList<string>> {
                new List<string> {"a", "c"},
                new List<string> {"b", "a"},
                new List<string> {"a", "e"},
                new List<string> {"a", "a"},
                new List<string> {"x", "x"}};

            IList<IList<string>> Input2 = new List<IList<string>> {
                new List<string> { "a", "b" },
                new List<string> { "b", "c" },
                new List<string> { "e", "f" }};
            double[] values2 = { 1.5, 2.5, 5 };
            IList<IList<string>> queries2 = new List<IList<string>> {
                new List<string> {"a", "c"},
                new List<string> {"c", "b"},
                new List<string> {"e", "f"},
                new List<string> {"f", "e"}};

            double[] Expected1 = new double[] { 6, 0.5, -1, 1, -1 };
            double[] Expected2 = new double[] { 3.75, 0.4, 5, 0.2 };

            //act
            var act1 = Leet399_EvaluateDivision.CalcEquation(Input1, values1, queries1);
            var act2 = Leet399_EvaluateDivision.CalcEquation(Input2, values2, queries2);

            //assert
            CollectionAssert.AreEqual(Expected1, act1);
            CollectionAssert.AreEqual(Expected2, act2);
        }
    }
}