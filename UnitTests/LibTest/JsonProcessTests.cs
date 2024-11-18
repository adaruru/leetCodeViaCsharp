using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib;
using System;
using Newtonsoft.Json.Linq;

namespace UnitTests.LibTest;

[TestClass()]
public class JsonProcessTests
{
    JsonProcess service;

    [TestInitialize]
    public void TestInitialize()
    {
        service = new JsonProcess();
    }

    [TestMethod()]
    public void TestJsonParse()
    {

        //arrange
        var arrange = "{\"redirectType\":\"1\",\"customParams\":\"1\"}";
        //act
        var act = service.ParseJson(arrange);
        //assert
        Assert.AreEqual("1", act.redirectType);
    }

    [TestMethod()]
    public void JObjectGetTest()
    {
        // Arrange
        var arrange1 = new JObject();
        arrange1["errorCode"] = "0";

        var arrange2 = new JObject();
        arrange2["errorCode"] = "1";

        var arrange3 = new JObject(); // Missing errorCode

        // Act
        var act1 = service.JObjectGet(arrange1);
        var act2 = service.JObjectGet(arrange2);
        var act3 = service.JObjectGet(arrange3);

        // Assert
        Assert.AreEqual(true, act1);
        Assert.AreEqual(false, act2);
        Assert.AreEqual(false, act3);
    }
}