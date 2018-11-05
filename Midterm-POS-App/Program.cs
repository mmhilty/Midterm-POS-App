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
            MenusClass.MainMenu(foodDictionary);

            //dictionaries are unsorted and only findable by key


        }
    }
}
