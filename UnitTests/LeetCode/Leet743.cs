using LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTests.LeetCode
{
    [TestClass]
    public class Leet743
    {
        Leet743_NetworkDelayTime service;

        [TestInitialize]
        public void TestInitialize()
        {
            service = new Leet743_NetworkDelayTime();
        }

        [TestMethod]
        public void Leet743Case1()
        {
            //arrange
            int[][] times1 = new int[][] { new int[] { 1, 2, 1 } };
            int n1 = 2;
            int k1 = 1;

            int Expected1 = 1;

            //act
            var act1 = service.NetworkDelayTime(times1, n1, k1);

            //assert
            Assert.AreEqual(Expected1, act1);
        }

        [TestMethod]
        public void Leet743Case2()
        {
            //arrange
            int[][] times1 = new int[][] { new int[] { 1, 2, 1 } };
            int n1 = 2;
            int k1 = 1;

            int Expected1 = 1;

            //act
            var act1 = service.NetworkDelayTime(times1, n1, k1);

            //assert
            Assert.AreEqual(Expected1, act1);
        }


    }
}