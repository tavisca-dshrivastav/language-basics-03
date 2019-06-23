using System;
using System.Linq;
using System.Collections.Generic;
namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            int n  = protein.Length;
            int[] calories = new int[n];

            //calculate calories 
            for(int i=0; i<n; i++)
                calories[i] = fat[i]*9 + (protein[i] + carbs[i])*5;
            int len = dietPlans.Length;

            //Stores selected index for the dietPlans
            int[] selectedItemIndexes = new int[dietPlans.Length];

            for(int i=0; i<len; i++){
                string diet = dietPlans[i];
                var itemIndexes = new List<int>();
                
                int dietLength = diet.Length;
                //if diet has empty string than it will select first index i.e., 0
                if(dietLength==0){
                    selectedItemIndexes[i]=0;
                    continue;
                }
                //adding indexes to itemIdexes for further calculations 
                //upto the length of array of protien, carb or fat
                for(int j=0; j<n; j++)
                    itemIndexes.Add(j);
                
                //iterate each character of each diet inthe dietplans 
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
                //adding first item from itemIndexes to selectedItemIndexes
                selectedItemIndexes[i] = itemIndexes[0];
            }
            // foreach(var i in selectedItemIndexes)
            //     Console.WriteLine($"debug {i}");
            return selectedItemIndexes;
            throw new NotImplementedException();
        }
        
        //function to find min item from the items accordence to itemIndexes
        public static int GetMinValue(int[] items, List<int> itemIndexes){
            int min = int.MaxValue;
            foreach(var i in itemIndexes){
                if(min>items[i])
                    min = items[i];
            }
            // Console.WriteLine($"print min {min}");
            return min;
        }
        //function to find max item from the items accordence to itemIndexes
        public static int GetMaxValue(int[] items, List<int> itemIndexes){
            int max = int.MinValue;
            foreach(var i in itemIndexes){
                if(max<items[i])
                    max = items[i];
            }
            // Console.WriteLine($"print max {max}");
            return max;
        }
    
    
        public static List<int> GetIndex(int[] items, List<int> itemIndexes, int element){
            var temp = new List<int>();
            foreach(var i in itemIndexes){
                if(items[i]==element)
                    temp.Add(i);
            }
            return temp;
            // foreach(var i in temp)
            //     Console.log($"print indexes {i}");
        }
    }
}
