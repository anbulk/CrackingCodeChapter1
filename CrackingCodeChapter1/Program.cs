using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;

namespace CrackingCodeChapter1
{
    class Program
    {

        //known problemss - set row and column of matrix to zero if element is 0
        //see if s2 is a roitation of s1 => if s2 is substring of s1s1

        public static void RotateCQMatric(ref int[,] a)
        {
            for(var i = 0; i < a.GetLength(0) / 2; i++)
            {
                var first = i;
                var last = a.GetLength(0) - 1 - i;

                for(var j=first;j<last;j++)
                {
                    var offset = j - first;
                    var top = a[first, j];

                    a[first, j] = a[last - offset, first];

                    a[last - offset, first] = a[last, last-offset];

                    a[last, last - offset] = a[j, last];

                    a[j, last] = top;
                }

            }


        }


        public static void RotateACWMatrix(ref int[,] a)
        {
            for(var i=0;i<a.GetLength(0)/2;i++)
            {
                int first =i, last= a.GetLength(0)- 1  - i;

                for(var j= first;j<last;j++)
                {
                    //save top to temp
                    var offset = j - first;

                    var top = a[first, j];

                    //move right to top

                    a[first, j] = a[ j, last];

                    //bottom to the right
                    a[j, last ] = a[last,last - offset];

                    //left to the bottom 
                    a[last, last - offset] = a[last - offset, first];

                    //temp to the left

                    a[last - offset, first] = top;

                }

            }




        }

        public static int[,] RotateCWMatrix_MN(int[,] a)
        {
            var m = a.GetLength(0);
            var n = a.GetLength(1);

            var b = new int[n, m];

            for(var i=0;i<m;i++)
            {

                for(var j=0;j<n;j++)
                {
                    b[j, m -1 - i] = a[i, j];

                }
            }
            return b;
        }


        public static void RotateCWMatrix(ref int[,] a)
        {
            for(var i=0;i<a.GetLength(0);i++)
            {
                var first = i;
                var last = a.GetLength(1) - 1 - first;

                for(var j=first;i<last;j++)
                {
                    var top = a[first, j];

                    var offset = j - first;

                    a[first, j] = a[last - offset, first];

                    a[last - offset, first] = a[last, last - offset];

                    a[last, last - offset] = a[i, last];

                    a[i, last] = top;

                }

            }




        }

        public static bool IsPermutation(string a, string b)
        {
            if (a.Length != b.Length)
                return false;

            var arr = a.ToCharArray();
            var charArr = new int[256];
            foreach (var c in arr)
            {
                charArr[c]++;
            }

            foreach (var c in b.ToCharArray())
            {
                if (--charArr[c] < 0)
                    return false;
            }
            return true;

        }

        public static string CompressedString(string input)
        {
            StringBuilder result = new StringBuilder();

            var count = 0;
            var c = input[0];
            var compressed = false;
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == c)
                    count++;
                else
                {
                    if (count > 1)
                    {
                        compressed = true;
                    }
                    result.Append(c);
                    result.Append(count.ToString());
                    c = input[i];
                    count = 1;
                }

            }

            result.Append(c);
            result.Append(count.ToString());
            if (count > 1)
            {
                compressed = true;
            }

            if (compressed)
                return result.ToString();
            else
                return input;
        }

        public static string ReplaceSpace(string input, int length)
        {
            var arr = input.ToCharArray();
            var spaceCount = 0;
            for (var i = 0; i < length; i++)
            {
                if (input[i] == ' ')
                    spaceCount++;
            }
            var newLen = length + (spaceCount * 2);
            for (var i = length - 1; i >= 0; i--)
            {
                if (arr[i] == ' ')
                {
                    arr[newLen - 1] = '0';
                    arr[newLen - 2] = '2';
                    arr[newLen - 3] = '%';

                    newLen -= 3;

                }
                else
                {
                    arr[newLen - 1] = arr[i];
                    newLen--;
                }


            }
            return String.Join("", arr);

        }

        public static void PrintMatrix(int[,] a)
        {
            for (var i = 0; i < a.GetLength(0); i++)
            {
                for (var j = 0; j < a.GetLength(1); j++)
                    Console.Write("|"+ a[i, j] + "|");
                Console.WriteLine();
            }
        }

        public static bool IsUnique(string input)
        {
            if (input.Length > 256)
                return false;
            if (input.Length == 1)
                return true;

            var arr = input.ToCharArray();
            Array.Sort(arr);
            input = String.Join("", arr);
            for (var i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])

                    return false;

            }
            return true;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Is String Unique");

            //Console.WriteLine(IsUnique("aby3456") ? "Yes" : "No");

            //Console.WriteLine(IsPermutation(" dog", "g od") ? "Yes" : "No");


            //Console.WriteLine(ReplaceSpace("lubna karody  ", 12));

            Console.WriteLine(CompressedString("aabcccccaaa"));

            int[,] a = new int[4, 3]
            {
                { 1,2,3},
                 { 4,5,6},
                  { 7,8,9},
                   { 10,11,12},
            };

            //PrintMatrix(a);

            //var b = RotateCWMatrix_MN(a);

            // PrintMatrix(b);


            int[,] b= new int[3, 3]
            {
                { 1,2,3},
                 { 4,5,6},
                  { 7,8,9}
            };


            PrintMatrix(b);

            RotateCQMatric(ref b);
            Console.WriteLine("----90degree AntiClockwise Rotation----");
            PrintMatrix(b);

        }
    }
}
