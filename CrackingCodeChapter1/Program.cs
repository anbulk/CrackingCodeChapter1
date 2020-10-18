using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text;

namespace CrackingCodeChapter1
{
    class Program
    {

        //known problemss - set row and column of matrix to zero if element is 0
        //see if s2 is a roitation of s1 => if s2 is substring of s1s1

        public static void RotateCQMatric(ref int[,] a)
        {
            for (var i = 0; i < a.GetLength(0) / 2; i++)
            {
                var first = i;
                var last = a.GetLength(0) - 1 - i;

                for (var j = first; j < last; j++)
                {
                    var offset = j - first;
                    var top = a[first, j];

                    a[first, j] = a[last - offset, first];

                    a[last - offset, first] = a[last, last - offset];

                    a[last, last - offset] = a[j, last];

                    a[j, last] = top;
                }

            }


        }


        public static void RotateACWMatrix(ref int[,] a)
        {
            for (var i = 0; i < a.GetLength(0) / 2; i++)
            {
                int first = i, last = a.GetLength(0) - 1 - i;

                for (var j = first; j < last; j++)
                {
                    //save top to temp
                    var offset = j - first;

                    var top = a[first, j];

                    //move right to top

                    a[first, j] = a[j, last];

                    //bottom to the right
                    a[j, last] = a[last, last - offset];

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

            for (var i = 0; i < m; i++)
            {

                for (var j = 0; j < n; j++)
                {
                    b[j, m - 1 - i] = a[i, j];

                }
            }
            return b;
        }


        public static void RotateCWMatrix(ref int[,] a)
        {
            for (var i = 0; i < a.GetLength(0); i++)
            {
                var first = i;
                var last = a.GetLength(1) - 1 - first;

                for (var j = first; i < last; j++)
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
                    Console.Write("|" + a[i, j] + "|");
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

        /* Sorting */

        public static void PrintArray(int[] arr)
        {
            Console.WriteLine("Array\n");
            for (var i = 0; i < arr.Length - 1; i++)
                Console.Write(arr[i] + ", ");
            Console.Write(arr[arr.Length - 1]);
        }

        public static void ReccursiveBubbleSort(int[] arr, int n)
        {
            if (n == 0)
                return;

            for (var j = 0; j < n - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    var a = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = a;
                }

            }

            ReccursiveBubbleSort(arr, n - 1);

        }

        public static void BubbleSort(int[] arr)
        {
            for (var i = 0; i < arr.Length - 1; i++)
            {
                int j = 0;
                for (; j < arr.Length - i; j++)
                {

                    if (j != arr.Length - 1 && arr[j] > arr[j + 1])
                    {

                        var a = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = a;
                    }

                }

                Console.Write(arr[j - 1] + ",");
            }

            Console.Write(arr[0]);

        }

        public static void RecurrsiveSelectionSort(int[] arr, int start)
        {

            if (start == arr.Length - 1)
                return;

            var mini = start;
            for (var j = start; j < arr.Length; j++)
            {
                if(arr[mini] > arr[j])
                {
                    mini = j;
                }

            }
            if(start != mini)
            {
                var a = arr[mini];
                arr[mini] = arr[start];
                arr[start] = a;

            }

            RecurrsiveSelectionSort(arr, start + 1);

        }

        public static void SelectionSort(int[] arr)
        {
            for (var i = 0; i < arr.Length - 1; i++)
            {
                var mini = i;
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[mini] > arr[j])
                        mini = j;
                }
                if (i != mini)
                {
                    var a = arr[mini];
                    arr[mini] = arr[i];
                    arr[i] = a;
                }

                Console.Write(arr[i] + ",");

            }

            Console.Write(arr[arr.Length - 1]);

        }

        public static void MinHeap(int[] arr)
        {



        }

        public static void MaxHeap(int[] arr)
        {



        }

        static int Partition(int[] arr, int low, int high)
        {
            int i = low - 1;
            int pivot = arr[high];

            for(var j=low; j<= high-1;j++)
            {
                if( pivot > arr[j])
                {
                    i++;
                    var t = arr[i];
                    arr[i] = arr[j];
                    arr[j] = t;

                }


            }

            var t1 = arr[i+1];
            arr[i+1] = arr[high];
            arr[high] = t1;

            return i+ 1;
        }

        public static void QuickSort(int[] arr,int low,int high)
        {

            if(low < high)
            {
                var pi = Partition(arr, low, high);

                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);

            }

        }

        public static void Merge(int[] arr,int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r- m;

            var larr = new int[n1];
            var rarr = new int[n2];

            int i = 0;

            for (i = 0; i < n1; i++)
                larr[i] = arr[l + i];


            for (i = 0; i < n2; i++)
                rarr[i] = arr[m + 1 + i];

            int j = 0;
            int k = l;
             i = 0;

            while (i <n1 && j <n2)
            {

                if (larr[i] <= rarr[j])
                    arr[k] = larr[i++];
                else
                    arr[k] = rarr[j++];

                k++;
            }

            while (i < n1){
                arr[k] = larr[i];
                k++;
                i++;
            }

            while (j < n2)
            {
                arr[k] = rarr[j];
                k++;
                j++;
            }
        }

        public static void MergeSort(int[] arr,int l,int r)
        {
            if (l < r)
            {
                int m = ( l+ r )/ 2;

                MergeSort(arr, l, m);
                MergeSort(arr, m + 1, r);


                //Merge the arrays
                Merge(arr, l, m, r);

            }


        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Is String Unique");

            //Console.WriteLine(IsUnique("aby3456") ? "Yes" : "No");

            //Console.WriteLine(IsPermutation(" dog", "g od") ? "Yes" : "No");


            //Console.WriteLine(ReplaceSpace("lubna karody  ", 12));

            //Console.WriteLine(CompressedString("aabcccccaaa"));

            //int[,] a = new int[4, 3]
            //{
            //    { 1,2,3},
            //     { 4,5,6},
            //      { 7,8,9},
            //       { 10,11,12},
            //};

            //PrintMatrix(a);

            //var b = RotateCWMatrix_MN(a);

            // PrintMatrix(b);


            //int[,] b= new int[3, 3]
            //{
            //    { 1,2,3},
            //     { 4,5,6},
            //      { 7,8,9}
            //};


            //PrintMatrix(b);

            //RotateCQMatric(ref b);
            //Console.WriteLine("----90degree AntiClockwise Rotation----");
            //PrintMatrix(b);

            // SelectionSort(new int[] { 64, 25, 12, 22, 11 });
            // BubbleSort(new int[] { 64, 25, 12, 22, 11 });
            // var arr = new int[] { 64, 25, 12, 22, 11 };

            //no of test case
            //var t = Convert.ToInt32(Console.ReadLine());

            //int[] k = new int[t];


            //for (var j = 0; j < t; j++)
            //{
            //    var n = Convert.ToInt32(Console.ReadLine());

            //    int[] arr = new int[n];
            //    var num = (Console.ReadLine());
            //    for (var i = 0; i < n; i++)
            //    {
            //        arr[i] = Convert.ToInt32(num.Split(" ")[i]);
            //    }
            //    k[j] = Convert.ToInt32(Console.ReadLine());
            //    MergeSort(arr, 0, arr.Length - 1);
            //    k[j] = arr[k[j] - 1];

            //}

            //for (var i=0;i<t;i++)
            //{
            //    Console.WriteLine(k[i]);
            //}

            //for (var i = 0; i < t; i++)
            //  {
            // Array.Sort(arr[i]);
            //MergeSort(arr[i], 0, arr[i].Length - 1);
            //    Console.WriteLine(arr[i][k[i]-1]);
            //   }

            //var k = Convert.ToInt32(Console.ReadLine());
            //var n = Convert.ToInt32(Console.ReadLine());


            //int[] arr = new int[n];

            //for (var i = 0; i < n; i++)
            //{
            //    arr[i] = Convert.ToInt32(Console.ReadLine());
            //}


            //MergeSort(arr, 0, arr.Length-1);
            //RecurrsiveSelectionSort(arr, 0);
            //PrintArray(arr);
            var arr = new int[] { 10, 80, 30, 90, 40, 50, 70 };
            QuickSort(arr,0,6);

            for (var i = 0; i < 7; i++)
            {
                Console.WriteLine(arr[i]);
            }

            Console.ReadLine();
        }
    }
}
