namespace FunctionBuilder.Console
{
    using System;
    using System.Linq;
    using System.IO;
    using FunctionBuilder.Logic;

    class Program
    {
        static void Main(string[] args)
        {
            var str = File.ReadAllText(@"..\..\..\opz.txt");
            double start = -5;
            double end = 5;
            double delta = 1;
            Function function = new Function(str, start, end, delta);
            var resultOnOpz = function.GetRpn();
            Console.WriteLine(str);
            File.AppendAllText(@"..\..\..\opzResult.txt", resultOnOpz + "\n");
            var result = function.CalculateFunctionValues();
            for (var x = 0; x < result.Count; x++)
            {
                Console.WriteLine(result[x].ToString());
            }

        }

    }
}
