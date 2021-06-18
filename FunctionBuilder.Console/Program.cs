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
            var str = GetChars(File.ReadAllText(@"..\..\..\opz.txt"));
            var opz = new GoOPZ();
            var resultOnOpz = opz.GetResult(str);
            Console.WriteLine(resultOnOpz);
            File.AppendAllText(@"..\..\..\opzResult.txt", resultOnOpz + "\n");

            var calc = new Calculator();

            var result = calc.Calculate(GetChars(resultOnOpz));
            Console.WriteLine(result);
            File.AppendAllText(@"..\..\..\opzResult.txt", result.ToString() + "\n");
        }

        public static char[] GetChars(string str)
        {
            return str.ToCharArray()
            .Where(x => x != ' ')
            .ToArray();
        }
    }
}
