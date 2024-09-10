using System.Text;

namespace LeetCode;

public class Its002_ParkingLot
{
    public void ParkingLot(
        Dictionary<string, int> parkingCarLicences,
        int parkingLotCapacity,
        string addCarLicence,
        int shift)
    {
        var myParkingLot = new ParkingLot(parkingLotCapacity);
        foreach (var item in parkingCarLicences)
        {
            myParkingLot[item.Value] = new Car(item.Key);
        }

        Car newCar = new Car(addCarLicence);
        myParkingLot = myParkingLot + newCar;

        Console.WriteLine(myParkingLot.PrintInfo());

        myParkingLot = myParkingLot >> shift;

        Console.WriteLine(myParkingLot.PrintInfo());
    }
}
public class ParkingLot
{
    public ParkingLot(int capicity)
    {
        Capicity = capicity;
        ParkingCars = new Car[capicity];

    }
    public int Capicity { get; set; }
    public Car[] ParkingCars { get; set; }
    public Car this[int index]
    {
        get
        {
            return ParkingCars[index];
        }
        set
        {
            ParkingCars[index] = value;
        }
    }

    /// <summary>
    /// 改寫 + 運算子，將車輛停入停車場第一個空位(遇占用就往後)
    /// </summary>
    /// <param name="parkingLot"></param>
    /// <param name="car"></param>
    /// <returns></returns>
    public static ParkingLot operator +(ParkingLot parkingLot, Car car)
    {
        for (int i = 0; i < parkingLot.ParkingCars.Length; i++)
        {
            if (parkingLot.ParkingCars[i] == null)
            {
                parkingLot.ParkingCars[i] = car;
                break;
            }
        }
        return parkingLot;
    }

    /// <summary>
    /// 改寫 >> 運算子，將停車場的車輛往後移動 shift 位
    /// 超過停車場長度的車輛會回到第一個位置
    /// </summary>
    /// <param name="parkingLot"></param>
    /// <param name="shift"></param>
    /// <returns></returns>
    public static ParkingLot operator >>(ParkingLot parkingLot, int shift)
    {
        var length = parkingLot.ParkingCars.Length;
        var newParkingLot = new ParkingLot(length);

        for (int i = 0; i < length; i++)
        {
            if (parkingLot.ParkingCars[i] != null)
            {
                if (i + shift >= 0 && i + shift < parkingLot.ParkingCars.Length)
                {
                    newParkingLot.ParkingCars[i + shift] = parkingLot.ParkingCars[i];
                }
                else if (length != 0)
                {
                    newParkingLot.ParkingCars[(i + shift) % length] = parkingLot.ParkingCars[i];
                }
            }
        }
        return newParkingLot;
    }

    public string PrintInfo()
    {
        var carList = new StringBuilder();

        for (int i = 0; i < ParkingCars.Length; i++)
        {
            if (ParkingCars[i] != null)
            {
                carList.AppendLine("index : " + i.ToString() + ParkingCars[i].ToString());
            }
        }
        return carList.ToString();
    }
}

public class Car
{
    public Car(string licenseNumber)
    {
        LicenseNumber = licenseNumber;
    }
    public string LicenseNumber { get; set; }
    public override string ToString() => $",LicenseNumber : {LicenseNumber}";
}
