using LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.LeetCode
{
    [TestClass]
    public class Leet056_MergeIntervalsTest
    {
        Leet056_MergeIntervals service;

        [TestInitialize]
        public void TestInitialize()
        {
            service = new Leet056_MergeIntervals();
        }

        [TestMethod]
        public void Leet056Case1()
        {
            //arrange
            int[][] input = new int[][] {
                new int[] { 1, 3 },
                new int[] { 2, 6 },
                new int[] { 8, 10 },
                new int[] { 15, 18 }
            };
            int[][] expected = new int[][] {
                new int[] { 1, 6 },
                new int[] { 8, 10 },
                new int[] { 15, 18 }
            };

            //act
            var actual = service.Merge(input);

            //assert
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void Leet056Case2()
        {
            //arrange
            int[][] input = new int[][] {
                new int[] { 1, 4 },
                new int[] { 4, 5 }
            };
            int[][] expected = new int[][] {
                new int[] { 1, 5 }
            };

            //act
            var actual = service.Merge(input);

            //assert
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void Leet056Case3_Unsorted()
        {
            //arrange
            int[][] input = new int[][] {
                new int[] { 5, 6 },
                new int[] { 1, 3 },
                new int[] { 2, 4 }
            };
            int[][] expected = new int[][] {
                new int[] { 1, 4 },
                new int[] { 5, 6 }
            };

            //act
            var actual = service.Merge(input);

            //assert
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
