using ReflectTest;

Console.WriteLine("Hello, World!");

var app = new ViaMethodBase();
try
{
    app.GetLaunchProgram();
}
catch (Exception ex)
{
    var a = ex;
    throw;
}

