using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FunctionBuilder.Logic
{
    public class Rpn
    {
        readonly char[] Operators = new char[] { '+', '-', '*', '/', '^', '(', ')' };

        private char[] rpn;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var e in rpn)
            {
                sb.Append(e + " ");
            }

            return sb.ToString();
        }

        private Queue<char> ConvertToRnp(char[] str)
        {
            Stack<char> stack = new Stack<char>();
            Queue<char> queue = new Queue<char>();

            foreach (var sym in str)
            {
                if (!Operators.Contains(sym))
                {
                    queue.Enqueue(sym);
                }
                else if (stack.Count == 0 || sym == '(' || GetPriority(sym) > GetPriority(stack.Peek()))
                {
                    stack.Push(sym);
                }
                else if (GetPriority(stack.Peek()) >= GetPriority(sym) && sym != ')')
                {
                    while (stack.Count != 0 && GetPriority(stack.Peek()) >= GetPriority(sym))
                    {
                        queue.Enqueue(stack.Pop());
                    }
                    stack.Push(sym);
                }
                else if (sym == ')')
                {
                    while (stack.Peek() != '(')
                    {
                        queue.Enqueue(stack.Pop());
                    }
                    stack.Pop();
                }
            }
            while (stack.Count != 0)
            {
                queue.Enqueue(stack.Pop());
            }
            return queue;
        }

        private int GetPriority(char sym)
        {
            if (sym == '^')
                return 4;
            if (sym == '*' || sym == '/')
                return 3;
            if (sym == '+' || sym == '-')
                return 2;
            return 1;
        }

        public char[] ToRpn(string expression)
        {
            char[] parsedStr = ParseString(expression);
            Queue<char> result = ConvertToRnp(parsedStr);
            rpn = result.ToArray();

            return result.ToArray();
        }

        private char[] ParseString(string str)
        {
            return str.ToCharArray().Where(x => x != ' ').ToArray();
        }

        
    }
}
