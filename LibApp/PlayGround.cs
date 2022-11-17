using LeetCode;

namespace LibApp;

public static class PlayGround
{
    public static void Run(ref string a)
    {
        string c = "Test";
        string d = c;
        d = "2233";
        Console.WriteLine(c); // output: "Best"
        Console.WriteLine(d); // output: "Best"
    }
}
