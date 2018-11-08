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
            Console.SetWindowSize(150, 50);
            Dictionary<string, FoodItem> foodDictionary = ManipFoodData.ReadData();

            //Art.IntroArt();
            MenusClass.MainMenu(foodDictionary);



        }
    }
}
