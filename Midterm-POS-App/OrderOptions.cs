using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_POS_App
{
    class OrderOptions
    {
        public const double taxPercentageDecimal = .06;

        public static void ListFoodMenu(Dictionary<string, FoodItem> foodDictionary)
        { 
            Console.WriteLine($"   {"Name",-25}{"Category",-10}{"Description",-80}{"Price",-6}");
            int i = 1;
            foreach (KeyValuePair<string, FoodItem> pair in foodDictionary)
            {                
                    FoodItem food = pair.Value;
                    Console.WriteLine($"{i,-3}{food.Name , -25}{food.Category,-10}{food.Description, -80}{food.Price,-6}");
                    i++;
            }
        }
               
        public static List<FoodItem> AddFoodItem(List<FoodItem> order, Dictionary<string,FoodItem> foodDictionary)
        {
            while (true)
            {
                Dictionary<int, string> chooseFromDict = new Dictionary<int, string>();
                int i = 0;
                foreach (KeyValuePair<string, FoodItem> pair in foodDictionary)
                {
                    FoodItem item = pair.Value;
                    chooseFromDict.Add(i, item.Name);
                    i++;
                }

                Console.WriteLine("What would you like to add to your order?\n" +
                    "You can type in either the number or the full name of the item.\n" +
                    "You can also type \"cancel\" to go back to the main order menu or \"menu\" to view the menu again.\n");
                string userChooseInput = Console.ReadLine();
                if (userChooseInput.ToLower() == "menu")
                {
                    OrderOptions.ListFoodMenu(foodDictionary);
                    continue;
                }
                if (userChooseInput.ToLower() == "cancel")
                {
                    return order;
                }
                string userChoice;
                int userNumberInput;
                if (Int32.TryParse(userChooseInput, out userNumberInput))
                {
                    userChoice = chooseFromDict[userNumberInput-1];
                }
                else
                {
                    userChoice = userChooseInput;
                }
                // have userChoice, which is a string that contains the name of the thing in theory

                foreach (KeyValuePair<string, FoodItem> pair in foodDictionary)
                {
                    FoodItem item = pair.Value;
                    if (item.Name == userChoice)
                    {
                        Console.WriteLine("How many do you want to add?");
                        int numberOfItem = Convert.ToInt32(Validation.NumberVal(Console.ReadLine()));
                        if (numberOfItem == 0)
                        {
                            Console.WriteLine("Nothing was added.");
                            return order;
                        }
                        else
                        {
                            int integer = 0;
                            for (integer = 0; integer < numberOfItem; integer++)
                            {
                                order.Add(item);
                            }

                            if (integer == 1)
                            {
                                Console.WriteLine($"{integer} {item.Name} has been added to your order!");
                            }
                            else
                            {
                                Console.WriteLine($"{integer} {item.Name}s have been added to your order!");
                            }
                            return order;
                        }
                    }
                }

                Console.WriteLine("Sorry, couldn't find that item. Try again!");

            }
        }

        public static void ListCurrentOrderDetails(List<FoodItem> order)
        {
            Console.WriteLine($"{"Item",-25}{"Cost",-6}");
            foreach (FoodItem item in order)
            {
                Console.WriteLine($"{item.Name,-25}{item.Price,-6}");
            }

            List<double> subtotalList = new List<double>();
            foreach (FoodItem item in order)
            {
                subtotalList.Add(item.Price);
            }
            double subtotal = GetSubtotal(order);
            double tax = GetTaxAmount(order, taxPercentageDecimal);
            double total = GetTotalCost(order, taxPercentageDecimal);

            Console.WriteLine($"Subtotal:{subtotal}\n" +
                $"Tax:{tax}\n" +
                $"Total:{total}");

        }

        #region moneymoneymoney

        public static double GetTotalCost(List<FoodItem> order, double taxPercentageDecimal)
        {
            List<double> subtotalList = new List<double>();
            foreach (FoodItem item in order)
            {
                subtotalList.Add(item.Price);
            }
            double subtotal = subtotalList.Sum();
            double tax = subtotal * taxPercentageDecimal;
            double total = tax + subtotal;

            return total;
        }

        public static double GetTaxAmount(List<FoodItem> order, double taxPercentageDecimal)
        {
            List<double> subtotalList = new List<double>();
            foreach (FoodItem item in order)
            {
                subtotalList.Add(item.Price);
            }
            double subtotal = subtotalList.Sum();
            double tax = subtotal * taxPercentageDecimal;

            return tax;
        }

        public static double GetSubtotal(List<FoodItem> order)
        {
            List<double> subtotalList = new List<double>();
            foreach (FoodItem item in order)
            {
                subtotalList.Add(item.Price);
            }
            return subtotalList.Sum();
        }

        #endregion
    }
}
