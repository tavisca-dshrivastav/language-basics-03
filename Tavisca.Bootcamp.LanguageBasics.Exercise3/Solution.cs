using System;
using System.Collections.Generic;
namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Solution
    {
        public static int GetMinValue(int[] items, List<int> itemIndexes)
        {
            int min = int.MaxValue;
            foreach (var i in itemIndexes)
            {
                if (min > items[i])
                    min = items[i];
            }
            // Console.WriteLine($"print min {min}");
            return min;
        }
        //function to find max item from the items accordence to itemIndexes
        public static int GetMaxValue(int[] items, List<int> itemIndexes)
        {
            int max = int.MinValue;
            foreach (var i in itemIndexes)
            {
                if (max < items[i])
                    max = items[i];
            }
            // Console.WriteLine($"print max {max}");
            return max;
        }


        public static List<int> GetIndex(int[] items, List<int> itemIndexes, int element)
        {
            var temp = new List<int>();
            foreach (var i in itemIndexes)
            {
                if (items[i] == element)
                    temp.Add(i);
            }
            return temp;
            // foreach(var i in temp)
            //     Console.log($"print indexes {i}");
        }
    }
}