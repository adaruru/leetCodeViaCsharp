// See https://aka.ms/new-console-template for more information
using LibApp;
using LibApp.ReflectTest;

Console.WriteLine("LibTest Run");

//CoreLib.Run();
//ReflectTest.Run();

String a = "4";
String b = String.Intern(a);
b = "223";
a = "4";
Console.WriteLine(b);
PlayGround.Run(ref b);