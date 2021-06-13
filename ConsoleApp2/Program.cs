using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {

        static void Main(string[] args)
        {
            MinStack minStack = new MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            minStack.GetMin(); // return -3
            minStack.Pop();
            minStack.Top();    // return 0
            minStack.GetMin(); // return -2
        }

    }
}
