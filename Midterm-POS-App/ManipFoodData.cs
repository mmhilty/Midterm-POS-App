using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Midterm_POS_App
{
    class ManipFoodData
    {
        //stream to access textfile
        
        public static Dictionary<string,FoodItem> ReadData()
        {
            Dictionary<string, FoodItem> FoodDict = new Dictionary<string, FoodItem>();
            string filePath = Path.GetDirectoryName(Directory.GetParent(Directory.GetCurrentDirectory()).FullName);

            StreamReader reader = new StreamReader(filePath + "\\FoodDataText.txt");
            try
            {
                while (reader.EndOfStream == false)
                {
                    string lineData = reader.ReadLine();
                    FoodItem food = ParseData.CreateFoodItem(lineData);
                    FoodDict.Add(food.Name, food);

                }
            }
            catch
            {
                Console.WriteLine("file not found");
                Console.WriteLine(Directory.GetCurrentDirectory() );
                Console.WriteLine("press any key to continue");
                Console.ReadLine();

            }

            return FoodDict;

        }

        //public method to return list or dictionary of items

    }
}
