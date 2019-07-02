using System;
using System.Collections.Generic;
namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class RestaurantMeal
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
        public static int GetMaxValue(int[] items, List<int> itemIndexes)
        {
            int max = int.MinValue;
            foreach (var i in itemIndexes)
            {
                if (max < items[i])
                    max = items[i];
            }
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
       
        }
        public int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            int n = protein.Length;
            int[] calories = new int[n];
            for (int i = 0; i < n; i++)
                calories[i] = fat[i] * 9 + (protein[i] + carbs[i]) * 5;
            int len = dietPlans.Length;

            int[] selectedItemIndexes = new int[dietPlans.Length];

            for (int i = 0; i < len; i++)
            {
                string diet = dietPlans[i];
                var itemIndexes = new List<int>();

                int dietLength = diet.Length;
                if (dietLength == 0)
                {
                    selectedItemIndexes[i] = 0;
                    continue;
                }
                for (int j = 0; j < n; j++)
                    itemIndexes.Add(j);

                foreach (var d in diet)
                {
                    int min, max;
                    switch (d)
                    {
                        case 'p':
                            min = GetMinValue(protein, itemIndexes);
                            itemIndexes = GetIndex(protein, itemIndexes, min);
                            break;
                        case 'P':
                            max = GetMaxValue(protein, itemIndexes);
                            itemIndexes = GetIndex(protein, itemIndexes, max);
                            break;
                        case 'c':
                            min = GetMinValue(carbs, itemIndexes);
                            itemIndexes = GetIndex(carbs, itemIndexes, min);
                            break;
                        case 'C':
                            max = GetMaxValue(carbs, itemIndexes);
                            itemIndexes = GetIndex(carbs, itemIndexes, max);
                            break;
                        case 'f':
                            min = GetMinValue(fat, itemIndexes);
                            itemIndexes = GetIndex(fat, itemIndexes, min);
                            break;
                        case 'F':
                            max = GetMaxValue(fat, itemIndexes);
                            itemIndexes = GetIndex(fat, itemIndexes, max);
                            break;
                        case 't':
                            min = GetMinValue(calories, itemIndexes);
                            itemIndexes = GetIndex(calories, itemIndexes, min);
                            break;
                        case 'T':
                            min = GetMaxValue(calories, itemIndexes);
                            itemIndexes = GetIndex(calories, itemIndexes, min);
                            break;
                        default:
                            continue;
                    }
                }
                selectedItemIndexes[i] = itemIndexes[0];
            }
            return selectedItemIndexes;
        }
    }
}