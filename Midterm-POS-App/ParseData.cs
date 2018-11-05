using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;

namespace Midterm_POS_App
{
    class ParseData
    {
        public static FoodItem CreateFoodItem(string input)
        {
            List<string> stringList = new List<string>();
            string[] items = Regex.Split(input, "/");
            foreach (string item in items)
            {
                stringList.Add(item);
            }
            FoodItem fooditeminstance = new FoodItem(stringList[0],stringList[1], stringList[2], Convert.ToDouble(stringList[3]));

            return fooditeminstance;
        }

        public static string CreateKeyNoSpaces(string input)
        {
            string[] inputList = Regex.Split(input, " ");
            return inputList.ToString();
        }

    }
}
