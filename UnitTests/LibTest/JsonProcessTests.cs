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
    public void ModelParseTest()
    {

        //arrange
        var arrange = "{\"redirectType\":\"1\",\"customParams\":\"1\"}";
        //act
        var act = service.ModelParse(arrange);
        //assert
        Assert.AreEqual("1", act.redirectType);
    }

    [TestMethod()]
    public void JObjectParseTest()
    {

        //arrange
        var arrange = "{\"errorCode\":0,\"errorMessage\":\"Account: BNS login Success!\",\"data\":{\"accessToken\":\"eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJKV1RUb2tlbiIsInVzZXJfaWQiOjQ0MCwiVGhyZWFkSWQiOjY1MDYsImlzcyI6IlNTNiIsImZvciI6MiwidHlwZSI6MSwiZXhwIjoxNzQwNTY3NjM4LCJjcmVhdGVBdCI6MTc0MDU2NzMzODAxN30.THnF7J2cP9tDrmALyoi4D2-AdjYAAa6j7NKylhvYgXs\",\"refreshToken\":\"eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJKV1RUb2tlbiIsInVzZXJfaWQiOjQ0MCwiVGhyZWFkSWQiOjY1MDYsImlzcyI6IlNTNiIsImZvciI6MiwidHlwZSI6MiwiZXhwIjoxNzQwNTY3OTM4LCJjcmVhdGVBdCI6MTc0MDU2NzMzODAxN30.-2s97LxRO_JltkjYm43-7iIp486TvsBhJoERvgOHX0c\",\"expiresIn\":5,\"tokenType\":\"Bearer\"}}";
        //act
        var act = service.JObjectParse(arrange);
        //assert
        Assert.AreEqual("0", act);
    }


    [TestMethod()]
    public void JObjectDynamicParseTest()
    {

        //arrange
        var plain = "plain";
        var arrange = "{\"errorCode\":0,\"errorMessage\":\"Account: BNS login Success!\",\"data\":{\"accessToken\":\"eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJKV1RUb2tlbiIsInVzZXJfaWQiOjQ0MCwiVGhyZWFkSWQiOjY1MDYsImlzcyI6IlNTNiIsImZvciI6MiwidHlwZSI6MSwiZXhwIjoxNzQwNTY3NjM4LCJjcmVhdGVBdCI6MTc0MDU2NzMzODAxN30.THnF7J2cP9tDrmALyoi4D2-AdjYAAa6j7NKylhvYgXs\",\"refreshToken\":\"eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJKV1RUb2tlbiIsInVzZXJfaWQiOjQ0MCwiVGhyZWFkSWQiOjY1MDYsImlzcyI6IlNTNiIsImZvciI6MiwidHlwZSI6MiwiZXhwIjoxNzQwNTY3OTM4LCJjcmVhdGVBdCI6MTc0MDU2NzMzODAxN30.-2s97LxRO_JltkjYm43-7iIp486TvsBhJoERvgOHX0c\",\"expiresIn\":5,\"tokenType\":\"Bearer\",\"plain\":\"" + plain + "\"}}";
        var arrange2 = "{\"errorCode\":0,\"errorMessage\":\"Account: BNS login Success!\",\"data\":{\"accessToken\":\"eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJKV1RUb2tlbiIsInVzZXJfaWQiOjQ0MCwiVGhyZWFkSWQiOjY1MDYsImlzcyI6IlNTNiIsImZvciI6MiwidHlwZSI6MSwiZXhwIjoxNzQwNTY3NjM4LCJjcmVhdGVBdCI6MTc0MDU2NzMzODAxN30.THnF7J2cP9tDrmALyoi4D2-AdjYAAa6j7NKylhvYgXs\",\"refreshToken\":\"eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJKV1RUb2tlbiIsInVzZXJfaWQiOjQ0MCwiVGhyZWFkSWQiOjY1MDYsImlzcyI6IlNTNiIsImZvciI6MiwidHlwZSI6MiwiZXhwIjoxNzQwNTY3OTM4LCJjcmVhdGVBdCI6MTc0MDU2NzMzODAxN30.-2s97LxRO_JltkjYm43-7iIp486TvsBhJoERvgOHX0c\",\"expiresIn\":5,\"tokenType\":\"Bearer\"}}";

        //act
        var act = service.JObjectDynamicParse(arrange);
        var act2 = service.JObjectDynamicParse(arrange2);
        //assert
        Assert.AreEqual(plain, act);
        Assert.AreEqual(string.Empty, act2);
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