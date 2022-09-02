using LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTests.Its;

[TestClass]
public class Its001_BestSumTest
{
    Its001_BestSum service;

    [TestInitialize]
    public void TestInitialize()
    {
        service = new Its001_BestSum();
    }

    [TestMethod]
    public void BestSumUnderMax()
    {
        //arrange
        Dictionary<string, decimal> txn = new Dictionary<string, decimal>
        {
            ["a"] = 1,
            ["b"] = 2,
            ["c"] = 3,
            ["d"] = 4,
            ["e"] = 5,
        };
        decimal deposits = 11;
        Dictionary<string, decimal> exDebit = new Dictionary<string, decimal>
        {
            ["b"] = 2,
            ["d"] = 4,
            ["e"] = 5,
        };
        Dictionary<string, decimal> extInsufficient = new Dictionary<string, decimal>
        {
            ["b"] = 2,
            ["d"] = 4,
            ["e"] = 5,
        };

        //act
        (var actDebit, var actInsufficient) = service.BestSumUnderMax(txn, deposits);

        //assert
        CollectionAssert.AreEqual(exDebit, actDebit);
        CollectionAssert.AreEqual(extInsufficient, actInsufficient);
    }

    [TestMethod]
    public void BestSumUnderCount()
    {
        //arrange
        Dictionary<string, decimal> txn = new Dictionary<string, decimal>
        {
            ["水費"] = 500,
            ["電費"] = 2000,
            ["瓦斯費"] = 1500,
        };
        int count = 2;
        Dictionary<string, decimal> exDebit = new Dictionary<string, decimal>
        {
            ["電費"] = 2000,
        };
        Dictionary<string, decimal> extInsufficient = new Dictionary<string, decimal>
        {
            ["水費"] = 500,
            ["瓦斯費"] = 1500,
        };

        //act
        (var actDebit, var actInsufficient) = service.BestSumUnderCount(txn, count);

        //assert
        CollectionAssert.AreEqual(exDebit, actDebit);
        CollectionAssert.AreEqual(extInsufficient, actInsufficient);
    }
}