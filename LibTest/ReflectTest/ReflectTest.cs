namespace LibTest.ReflectTest;

public static class ReflectTest
{
    public static void Run()
    {
        Console.WriteLine("Hello, World!");

        var app = new ViaGeneric();
        try
        {
            app.GetLaunchProgram();
        }
        catch (Exception ex)
        {
            var a = ex;
            throw;
        }

    }
}
