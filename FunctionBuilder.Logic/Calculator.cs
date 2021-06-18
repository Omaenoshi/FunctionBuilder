using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionBuilder.Logic
{
    public class Calculator
    {
        readonly char[] Operators = new char[] { '+', '-', '*', '/', '^', '(', ')' };

        public double Calculate(char[] str)
        {
            var stack = new Stack<double>();
            foreach (var sym in str)
            {
                if (!Operators.Contains(sym))
                    stack.Push(double.Parse(sym.ToString()));
                else
                {
                    stack.Push(CalculateInStack(sym, stack.Pop(), stack.Pop()));
                }
            }
            return stack.Pop();
        }

        double CalculateInStack(char op, double fNumber, double sNumber)
        {
            switch (op)
            {
                case '+':
                    return sNumber + fNumber;
                case '-':
                    return sNumber - fNumber;
                case '*':
                    return sNumber * fNumber;
                case '/':
                    return sNumber / fNumber;
                case '^':
                    return Math.Pow(sNumber, fNumber);
                default:
                    throw new Exception("Такого опреатор нет");
            }
        }
    }
}
