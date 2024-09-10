using LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTests.Its;

[TestClass]
public class Its002_ParkingLotTest
{
    Its002_ParkingLot service;
    public TestContext TestContext { get; set; }


    [TestInitialize]
    public void TestInitialize()
    {
        service = new Its002_ParkingLot();
    }

    [TestMethod]
    public void ParkingLot()
    {
        var parkingLotCapacity = 5;
        var addCarLicence = "000";
        var parkingCarLicences = new Dictionary<string, int> {
            { "333" ,3}
        };
        var shift = 3;

        service.ParkingLot(
            parkingCarLicences,
            parkingLotCapacity,
            addCarLicence,
            shift);

        Assert.AreEqual(true, true);

        //index: 0,LicenseNumber: 000
        //index: 3,LicenseNumber: 333

        //index: 1,LicenseNumber: 333
        //index: 3,LicenseNumber: 000
    }
}
