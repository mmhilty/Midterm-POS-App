using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Midterm_POS_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, FoodItem> foodDictionary = ManipFoodData.ReadData();
            foreach (KeyValuePair<string, FoodItem> pair in foodDictionary)
            {
                FoodItem food = pair.Value;
                Console.WriteLine($"Name: {food.Name}\n" +
                    $"Category: {food.Category}\n" +
                    $"Description: {food.Description} \n" +
                    $"Price: ${food.Price, 2}");
                
            }
        }
    }
}
