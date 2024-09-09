using LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace UnitTests.Its;

[TestClass]
public class Its004_SeatWithTest
{
    Its004_SeatWith service;
    public TestContext TestContext { get; set; }


    [TestInitialize]
    public void TestInitialize()
    {
        service = new Its004_SeatWith();
    }

    [TestMethod]
    public void SeatWith()
    {
        Its004_SeatWith.Main(new string[] { "" }); // 使用類型名稱
        TestContext.WriteLine("This is a test message.");
        Assert.AreEqual(true, true);
    }
}
