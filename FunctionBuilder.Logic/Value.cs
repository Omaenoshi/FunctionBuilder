using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionBuilder.Logic
{
    public class Value
    {
        public double X { get; set; }

        public double Y { get; set; }

        public override string ToString()
        {
            return $"X = {X}" + "\t" + $"Y = {Y}";
        }
    }
}
