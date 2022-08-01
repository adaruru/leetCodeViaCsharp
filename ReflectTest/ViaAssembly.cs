using Lib.Reflect;
using BatchApp = Lib.Reflect.BatchAppEnumAssembly;
namespace ReflectTest
{
    public class ViaAssembly
    {
        public void GetLaunchProgram()
        {
            var batchAppEnum = BatchApp.UserDataImport;
            var arg = "901";


            Console.WriteLine("請輸入要執行的程式：");

            foreach (var p in BatchApp.GetInfos())
            {
                Console.WriteLine($"{p.Key}.{p.Value}");
            }

            foreach (var p in BatchApp.GetValues())
            {
                Console.WriteLine($"list value: {p}");
            }

            // SystemEnum.LaunchProgram.GetEnumName();
            //var name = BatchApp.GetName<BatchApp>(batchAppEnum);
            var name = BatchApp.GetName(batchAppEnum);
            System.Console.WriteLine(name);

            //var des = BatchApp.GetDescription<BatchApp>(batchAppEnum);
            var des = BatchApp.GetDescription(batchAppEnum);
            System.Console.WriteLine(des);


            System.Console.WriteLine("請輸入要執行的程式：");
            //foreach (var p in BatchAppEnum.GetValues())
            //{
            //    Enum.TryParse(p.ToString(), true, out SystemEnum.LaunchProgram program);
            //    System.Console.WriteLine($"{(int)program}.{program.GetEnumClassName()}");
            //}
            try
            {
                var strProgram = Console.ReadLine();
                // var k = BatchApp.GetDescription<BatchApp>(strProgram);
                var k = BatchApp.GetDescription(strProgram);

                Console.WriteLine(k);
            }
            catch (Exception ex)
            {
                var ha = ex;
                throw;
            }

        }
    }
}
