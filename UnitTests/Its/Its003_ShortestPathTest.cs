using LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTests.Its;

[TestClass]
public class Its003_ShortestPathTest
{
    Its003_ShortestPath service;

    [TestInitialize]
    public void TestInitialize()
    {
        service = new Its003_ShortestPath();
    }

    [TestMethod]
    public void BestSumUnderMax()
    {
        //arrange
        List<string> routes = new List<string>{
            "桃園-新竹",
            "新竹-台中",
            "花蓮-屏東",
            "宜蘭-基隆",
            "基隆-台北",
            "台北-新竹",
            "台中-高雄",
            "高雄-屏東",
            "新竹-苗栗",
            "苗栗-台中",
            "台中-彰化",
            "彰化-南投",
            "南投-台南",
            "台南-高雄",
            "新竹-台北",
            "台中-宜蘭",
            "宜蘭-桃園",
        };

        string start = "桃園";
        string target = "南投";


        //act
        var shortestPath = service.ShortestPath(start, target, routes);

        if (shortestPath != null)
        {
            Console.WriteLine($"最短路徑: {string.Join(" -> ", shortestPath)}");
        }
        else
        {
            Console.WriteLine("找不到路徑");
        }
        //assert
        Assert.AreEqual(5, shortestPath.Count);
    }
}