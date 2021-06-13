using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    //155 Min stack
    class MinStack
    {
        int[] mArray;
        public MinStack()
        {
            mArray = new int[0];
        }

        public void Push(int val)
        {
            Console.WriteLine("valores del primer array");
            foreach (var item in mArray) Console.WriteLine(item + ", ");

            int[] auxArr = new int[mArray.Length + 1];
            mArray.CopyTo(auxArr, 0);
            auxArr[auxArr.Length - 1] = val;

            mArray = new int[auxArr.Length];
            auxArr.CopyTo(mArray, 0);

            Console.WriteLine("valores del segundo array");
            foreach (var item in mArray) Console.WriteLine(item + ", ");
        }

        public void Pop()
        {
            if (mArray.Length > 0)
            {
                int[] auxArr = new int[mArray.Length - 1];
                for (int i = 0; i < auxArr.Length; i++)
                {
                    auxArr[i] = mArray[i];
                }

                mArray = new int[auxArr.Length];
                auxArr.CopyTo(mArray, 0);
            }
            Console.WriteLine("Resultado del Pop");
            foreach (var item in mArray) Console.WriteLine(item + ",");
        }

        public int Top()
        {
            Console.WriteLine("TOP: " + mArray[mArray.Length - 1]);
            return mArray[mArray.Length - 1];
        }

        public int GetMin()
        {
            int min = mArray[0];
            foreach (var item in mArray) if (item < min) min = item;
            Console.WriteLine("Resultado del getmin: " + min);
            return min;
        }
    }
}
