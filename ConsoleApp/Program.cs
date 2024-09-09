// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Text.Json;

public class Its004_SeatWith
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Passenger[] passengers;
        Stopwatch stopwatch = new Stopwatch();

        string json = File.ReadAllText("File/Passengers1000000.json");
        List<Passenger>? people = JsonSerializer.Deserialize<List<Passenger>>(json);
        stopwatch.Restart();
        Solve(people);
        stopwatch.Stop();
        Console.WriteLine($"Solve in {stopwatch.ElapsedMilliseconds}milliSecond");
    }


    static void Solve(List<Passenger> passengers)
    {
        // 過濾掉 ComeWithID == null 的乘客
        passengers = passengers.Where(p => p.ComeWithID.HasValue).ToList();

        // 存儲乘客關聯的圖
        Dictionary<int, List<int>> seatGroup = new Dictionary<int, List<int>>();

        foreach (var passenger in passengers)
        {
            if (!seatGroup.ContainsKey(passenger.ID))
                seatGroup[passenger.ID] = new List<int>();

            if (passenger.ComeWithID.HasValue)
            {
                if (!seatGroup.ContainsKey(passenger.ComeWithID.Value))
                    seatGroup[passenger.ComeWithID.Value] = new List<int>();

                seatGroup[passenger.ID].Add(passenger.ComeWithID.Value);
                seatGroup[passenger.ComeWithID.Value].Add(passenger.ID);
            }
        }
        HashSet<int> visited = new HashSet<int>();
        List<List<int>> groups = new List<List<int>>();
        foreach (var passenger in passengers)
        {
            if (!visited.Contains(passenger.ID))
            {
                List<int> group = new List<int>();
                MapGroup(passenger.ID, seatGroup, visited, group);
                groups.Add(group);
            }
        }

        // 計算總群組數量和平均每個群組的人數
        int totalGroups = groups.Count;
        double averageGroupSize = groups.Count > 0 ? groups.Average(g => g.Count) : 0;

        Console.WriteLine($"Groups Number: {totalGroups}");
        Console.WriteLine($"average member: {averageGroupSize}");
    }

    static void MapGroup(int id, Dictionary<int, List<int>> seatGroup, HashSet<int> visited, List<int> group)
    {
        visited.Add(id);
        group.Add(id);

        if (seatGroup.ContainsKey(id))
        {
            foreach (int neighbor in seatGroup[id])
            {
                if (!visited.Contains(neighbor))
                {
                    MapGroup(neighbor, seatGroup, visited, group);
                }
            }
        }
    }

}

class Passenger
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Route { get; set; }
    public int? ComeWithID { get; set; }
    public override string ToString()
    {
        return $"ID:{ID}, With:{ComeWithID}, Route:{Route}";
    }
}