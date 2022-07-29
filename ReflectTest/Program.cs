using ReflectTest;

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

