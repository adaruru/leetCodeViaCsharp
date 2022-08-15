using Lib.Reflect;
using BatchApp = Lib.Reflect.BatchAppEnumGeneric;
namespace LibApp.ReflectTest
{
    public class ViaGeneric
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

            foreach (var p in BatchApp.GetInfos(true))
            {
                Console.WriteLine($"{p.Key}.{p.Value}");
            }

            foreach (var p in BatchApp.GetValues())
            {
                Console.WriteLine($"list value: {p}");
            }

            foreach (var p in BatchApp.GetValues(true))
            {
                Console.WriteLine($"list value: {p}");
            }

            // SystemEnum.LaunchProgram.GetEnumName();
            //var name = BatchApp.GetName<BatchApp>(batchAppEnum);
            var name = BatchApp.GetName(batchAppEnum);
            Console.WriteLine(name);

            //var des = BatchApp.GetDescription<BatchApp>(batchAppEnum);
            var des = BatchApp.GetDescription(batchAppEnum);
            Console.WriteLine(des);


            Console.WriteLine("請輸入要執行的程式：");
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
                k = BatchApp.GetName(strProgram);
                Console.WriteLine(k);
                k = BatchApp.IsValueExist(strProgram).ToString();
                Console.WriteLine(k);

                var strProgram2 = Console.ReadLine();
                k = BatchApp.GetDescription(strProgram2);
                Console.WriteLine(k);
                k = BatchApp.GetName(strProgram2);
                Console.WriteLine(k);
                k = BatchApp.IsValueExist(strProgram2).ToString();
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
