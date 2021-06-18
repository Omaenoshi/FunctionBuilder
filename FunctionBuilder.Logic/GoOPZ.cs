using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FunctionBuilder.Logic
{
    public class GoOPZ
    {
        readonly char[] Operators = new char[] { '+', '-', '*', '/', '^', '(', ')' };

        Queue<char> GetOpz(char[] str)
        {
            var stack = new Stack<char>();
            var queue = new Queue<char>();
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

        int GetPriority(char sym)
        {
            if (sym == '^')
                return 4;
            if (sym == '*' || sym == '/')
                return 3;
            if (sym == '+' || sym == '-')
                return 2;
            return 1;
        }

        public string GetResult(char[] str)
        {
            var res = GetOpz(str);
            var sb = new StringBuilder();
            foreach (var item in res)
            {
                sb.Append(item + " ");
            }
            return sb.ToString();
        }
    }
}
