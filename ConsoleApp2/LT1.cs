using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    class LT1
    {
        //prs1
        public static int CShift()
        {
            int wk = 30;
            int[] periods = { 3, 2, 1 };
            int[] arrWk = new int[wk];

            int j = 0;
            for (int i = 0; i < arrWk.Length; i++)
            {
                if (j >= periods.Length) j = 0;
                arrWk[i] = periods[j];
                j++;
            }
            return arrWk[wk - 1];
        }
        //1 Two Sum
        public static int[] TwoSum(int target, int[] nums)
        {
            Hashtable hashtable = new Hashtable();
            int[] result = new int[2];

            for (int i = 0; i < nums.Length; i++)
            {
                hashtable.Add(nums[i], i);
                int complement = target - nums[i];
                if (hashtable.ContainsKey(complement))
                {
                    result[0] = (int)hashtable[complement];
                    result[1] = (int)hashtable[target - complement];
                }
            }
            return result;
        }
        //9 Palindrome Number.
        public static bool IsPalindromeNumber(int x)
        {
            int revertedNumber = 0;
            if (x < 0) return false;

            while (revertedNumber < x)
            {
                revertedNumber = (revertedNumber * 10) + (x % 10);
                x /= 10;
            }
            return (revertedNumber == x || revertedNumber / 10 == x);
        }
        //13 Roman to Integer
        public static int RomanToInt(string s)
        {
            int value = 0;
            int counter = 0;
            Hashtable hashtable = new Hashtable();
            hashtable.Add('I', 1);
            hashtable.Add('V', 5);
            hashtable.Add('X', 10);
            hashtable.Add('L', 50);
            hashtable.Add('C', 100);
            hashtable.Add('D', 500);
            hashtable.Add('M', 1000);

            for (int i = 0; i < s.Length; i++)
            {
                if (i > 0)
                {
                    if (s[i].Equals(s[i - 1])) counter++;

                    if (s[i].Equals('V') || s[i].Equals('X'))
                    {
                        if (s[i - 1].Equals('I')) value -= 2;
                    }

                    if (s[i].Equals('L') || s[i].Equals('C'))
                    {
                        if (s[i - 1].Equals('X')) value -= 20;
                    }

                    if (s[i].Equals('D') || s[i].Equals('M'))
                    {
                        if (s[i - 1].Equals('C')) value -= 200;
                    }
                }

                //mas de 1 V, L, D
                if ((counter == 1) && (s[i].Equals('V') || s[i].Equals('L') || s[i].Equals('D'))) return 0;

                if (counter == 3) return 0;

                value += (int)hashtable[s[i]];
            }
            return value;
        }
        public static int RomanToInt_LC(string s)
        {
            int value = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                //Console.Write("Letter: [" + s[i] + "], ");
                switch (s[i])
                {
                    case 'I':   //IV or IX
                        value += (value >= 5 ? -1 : 1);
                        break;
                    case 'V':
                        value += 5;
                        break;
                    case 'X':   //XL or XC
                        value += 10 * (value >= 50 ? -1 : 1);
                        break;
                    case 'L':
                        value += 50;
                        break;
                    case 'C':   //CD or CM
                        value += 100 * (value >= 500 ? -1 : 1);
                        break;
                    case 'D':
                        value += 500;
                        break;
                    case 'M':
                        value += 1000;
                        break;
                    default:
                        break;
                }
            }
            return value;
        }
        //14 Longest Common Prefix
        public static string LongestPrefix(string[] words)
        {
            string prefix = "";
            char letter = ' ';
            if (words.Length == 0) return prefix;
            for (int i = 0; i < words[0].Length; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    letter = words[0][i];
                    if (!letter.Equals(words[j][i])) return prefix;
                }
                prefix += letter;
            }
            return prefix;
        }
        //20 Valid Parenthesis
        public static bool ValidParenthesis(string strInput)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add('{', '}');
            hashtable.Add('(', ')');
            hashtable.Add('[', ']');

            Stack stack = new Stack();
            foreach (char item in strInput)
            {
                if (hashtable.ContainsKey(item))
                {
                    stack.Push(item);
                }
                else
                {
                    char stackLastElement = (stack.Count == 0) ? '#' : (char)stack.Pop();
                    if (!hashtable[stackLastElement].Equals(item))
                    {
                        return false;
                    }
                }
            }
            return (stack.Count == 0);
        }
        //21 Merge Two SortedLists
        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode dummy = new ListNode(-1);
            ListNode head = dummy;

            while (list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    dummy.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    dummy.next = list2;
                    list2 = list2.next;
                }
                dummy = dummy.next;
            }

            if (list1 != null)
            {
                dummy.next = list1;
            }
            else
            {
                dummy.next = list2;
            }
            return head.next;
        }
        //26 Remove Duplicates from sorted array
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            //i pointer
            int i = 0;
            for (int k = 0; k < nums.Length; k++)
            {
                if (nums[k] != nums[i])
                {
                    Console.Write(nums[i] + ", ");
                    i++;
                    nums[i] = nums[k];
                }
            }
            Console.Write(nums[i]);
            Console.WriteLine();
            return i + 1;
        }
        //27 Remove Element
        public static int RemoveElement(int[] nums, int val)
        {
            if (val >= nums.Length) return 0;
            int aux;
            aux = nums[val];

            for (int i = val; i < nums.Length - 1; i++)
            {
                nums[i] = nums[i + 1];
            }
            nums[nums.Length - 1] = aux;
            int len = nums.Length - 1;
            return len;
        }
        public static int RemoveElement_LC(int[] nums, int val)
        {
            int index = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val) nums[index++] = nums[i];
            }
            return index;
        }
        //28 Implement strStr()
        public static int StrStr(string haystack, string needle)
        {
            if (haystack.Length == 0 || needle.Length == 0) return 0;

            for (int i = 0; i < (haystack.Length - needle.Length) + 1; i++)
            {
                int j;
                for (j = 0; j < needle.Length; j++)
                {
                    if (haystack[i + j] != needle[j])
                    {
                        break;
                    }
                }
                if (j == needle.Length)
                {
                    return i;
                }
            }
            return -1;
        }
        //35 Search Insert Position.
        public static int SearchInsert(int[] nums, int target)
        {
            int aux = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target) //checked
                {
                    return i;
                }

                if (nums[i] < target)
                {
                    aux++;
                }
            }

            if (target > nums[nums.Length - 1])
            {
                return nums.Length;
            }

            if (target < nums[0])
            {
                return 0;
            }
            return aux;
        }
        //53 Maximum SubArray
        public static int MaximumSubArray(int[] nums)
        {
            int maxSubArray = int.MinValue;
            int j = 0;

            while (j < nums.Length)
            {
                int summary = 0;
                for (int i = j; i < nums.Length; i++)
                {
                    summary = summary + nums[i];
                    if (maxSubArray < summary) maxSubArray = summary;
                }
                j++;
            }

            return maxSubArray;
        }
        //58 Length of last word.
        public static int LastWordLength(string text)
        {
            int cont = 0;
            for (int i = text.Length - 1; i > 0; i--)
            {
                if (text[i].Equals(' ')) break;
                cont++;
            }
            if (cont < 1) return 0;
            return cont;
        }
        //66 Plus One.
        public static int[] PlusOne(int[] nums)
        {
            nums[nums.Length - 1] = nums[nums.Length - 1] + 1;
            return nums;
        }
        //83 Remove duplicates from SortedList.
        public static LinkedList<int> RemoveDuplicatesLinkedList(LinkedList<int> linkedList)
        {
            int index = 0, val = 0;
            while (val != linkedList.Last.Value)
            {
                if (linkedList.ElementAt(index) == val) linkedList.Remove(val);
                else
                {
                    val = linkedList.ElementAt(index);
                    index++;
                }
            }
            return linkedList;
        }
        //88 MergeSortedArray.
        public static int[] MergeSortedArray_ESV(int[] arr, int[] arr2)
        {
            int j = 0, k;
            int i = 0;
            while (j < arr2.Length)
            {
                if (arr[i] > arr2[j]) // si es menor que i que recorra y agregar en el hueco
                {
                    k = arr.Length - 2;
                    while (k >= i)
                    {
                        arr[k + 1] = arr[k];
                        k--;
                    }
                    arr[i] = arr2[j];
                    i++;
                    j++;
                }
                else if (arr[i] == arr2[j])
                {
                    k = arr.Length - 2;
                    while (k > i)
                    {
                        arr[k + 1] = arr[k];
                        k--;
                    }
                    arr[i + 1] = arr2[j];
                    i++;
                    j++;
                }
                else if (arr[i] < arr2[j])
                {
                    //abrir un espacio e insertar
                    for (int z = i; z < arr.Length - 1; z++)
                    {
                        if (arr2[j] < arr[z])
                        {
                            k = arr.Length - 2;
                            while (k >= z)
                            {
                                arr[k + 1] = arr[k];
                                k--;
                            }
                            arr[z] = arr2[j];
                            i++;
                            j++;
                        }

                        if (arr2[j] > arr[z] && arr[z] == 0)
                        {
                            arr[z] = arr2[j];
                            i++;
                            j++;
                        }
                    }
                    if (arr2[j] > arr[arr.Length - 1])
                    {
                        arr[arr.Length - 1] = arr2[j];
                        j++;
                    }
                }
            }
            return arr;
        }
        //118 pascal triangle May12th
        public static List<List<int>> PascalTriangle(int numRows)
        {
            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i < numRows; i++)
            {
                List<int> list = new List<int>();
                for (int j = 0; j <= i; j++)
                {
                    int x = (j == 0 || j == i) ? 1 : result[i - 1][j - 1] + result[i - 1][j];
                    list.Add(x);
                }
                result.Add(list);
            }
            return result;
        }
        //119 pascal triangle2 May22th, 2021
        public static List<int> PascalTriangle2(int numRows)
        {
            List<int> prevTest = new List<int> { 1 };

            for (int i = 1; i <= numRows; i++)
            {
                List<int> list = new List<int>();
                for (int j = 1; j <= i; j++)
                {
                    int x = (j == 1 || j == i) ? 1 : prevTest[j - 2] + prevTest[j - 1];
                    list.Add(x);
                }
                prevTest = list;
            }
            return prevTest;
        }
        //121 Best time to buy and sell stock
        public static int MaxProfit(int[] prices)
        {
            int myIndex = 0;
            int lowerPrice = 1, higherPrice = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] <= lowerPrice) myIndex = i;
            }
            for (int j = myIndex; j < prices.Length; j++)
            {
                if (prices[j] > higherPrice) higherPrice = prices[j];
            }
            return higherPrice - lowerPrice;
        }
        //122 part2
        public static int MaxProfit2(int[] prices)
        {
            int i = 0;
            int lowerPrice;
            int higherPrice = 0;
            int result = 0;

            for (int j = 0; j < prices.Length; j++)
            {
                if (prices[j] <= 1) i = j;
            }
            lowerPrice = prices[i];
            while (i < prices.Length)
            {
                if (prices[i] == prices[prices.Length - 1] ||
                    (prices[i] > higherPrice && prices[i] < prices[i + 1]))
                {
                    higherPrice = prices[i];
                }
                result += higherPrice - lowerPrice;
                i++;
            }
            return result;
        }
        //125 Valid Palindrome
        public static bool IsPalindromeString(string s)
        {
            int i = 0, j = s.Length - 1;
            while (i < j && j > i)
            {
                if (s[i] == s[j])
                {
                    i++;
                    j--;
                }
                else return false;
            }
            return true;
        }
    }
}
