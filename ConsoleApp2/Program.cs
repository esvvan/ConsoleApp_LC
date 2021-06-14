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
            int[] nums = { 2, 7, 11, 15 };
            int[] twoSum = LT1.TwoSumII(9, nums);
            foreach (var item in twoSum) Console.WriteLine(item);
        }

    }
}
