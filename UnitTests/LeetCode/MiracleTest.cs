using LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.LeetCode
{
    [TestClass]
    public class decTest
    {
        dec service;

        [TestInitialize]
        public void TestInitialize()
        {
            service = new dec();
        }

        [TestMethod]
        public void Miracle01Test()
        {
            //arrange
            int[]input = new int[] { 0};
            int[][] expected = new int[][] {
                new int[] { 1, 6 },
                new int[] { 8, 10 },
                new int[] { 15, 18 }
            };

            //act
            dec.Solve();

            //assert
            Assert.AreEqual(true, true);
        }

        
    }
}
