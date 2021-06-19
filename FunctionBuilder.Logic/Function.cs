using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FunctionBuilder.Logic
{
    public class Function
    {
        private Rpn rpn = new Rpn();
        readonly char[] Operators = new char[] { '+', '-', '*', '/', '^', '(', ')' };
        private double start, end, delta;
        private char[] reversPolishNotation;

        public Function(string expression, double rangeStart = double.NaN, double rangeEnd = double.NaN, double delta = double.NaN)
        {
            this.start = rangeStart;
            this.end = rangeEnd;
            this.delta = delta;

            reversPolishNotation = rpn.ToRpn(expression);
        }

        public List<Value> CalculateFunctionValues()
        {
            var result = new List<Value>();

            double argument = start;
            do
            {
                result.Add(new Value { X = argument, Y = Calculate(argument) });
                argument += delta;
            }
            while (argument <= end);

            return result;
        }

        public double Calculate(double argument = double.NaN) // принимает строку в опз
        {
            var stack = new Stack<double>();
            foreach (var sym in reversPolishNotation)
            {
                if (!Operators.Contains(sym))
                {
                    if (sym == 'x')
                        stack.Push(argument);
                    else
                        stack.Push(double.Parse(sym.ToString()));
                }
                else
                    stack.Push(CalculateInStack(sym, stack.Pop(), stack.Pop()));
            }
            return stack.Pop();
        }

        private double CalculateInStack(char op, double firstNumber, double secondNumber)
        {
            switch (op)
            {
                case '+':
                    return secondNumber + firstNumber;
                case '-':
                    return secondNumber - firstNumber;
                case '*':
                    return secondNumber * firstNumber;
                case '/':
                    return secondNumber / firstNumber;
                case '^':
                    return Math.Pow(secondNumber, firstNumber);
                default:
                    throw new Exception("Такого оператора нет.");
            }
        }

        public string GetRpn()
        {
            return rpn.ToString();
        }
    }
}
