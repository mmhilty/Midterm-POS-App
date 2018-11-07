using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Midterm_POS_App
{
    class OrderOptions
    {
        public const double taxPercentageDecimal = .06;

        public static void ListFoodMenu(Dictionary<string, FoodItem> foodDictionary)
        {
            Console.WriteLine("____________________________________________________________________________________________________________________________\n");
            Console.WriteLine("                                                            MENU                                                            ");
            Console.WriteLine("____________________________________________________________________________________________________________________________");
            Console.WriteLine($"   {"Name",-25}{"Category",-10}{"Description",-80}{"Price",-6}");
            Console.WriteLine("____________________________________________________________________________________________________________________________");

            int i = 1;
            foreach (KeyValuePair<string, FoodItem> pair in foodDictionary)
            {                
                    FoodItem food = pair.Value;
                    Console.WriteLine($"{i,-3}{food.Name , -25}{food.Category,-10}{food.Description, -80}{food.Price,-6}");
                    i++;
            }
            Console.WriteLine("____________________________________________________________________________________________________________________________\n");

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

                Console.WriteLine("\nYou can type in either the number or the full name of the item.\n" +
                    "You can also type \"cancel\" to go back to the main order menu or \"menu\" to view the menu again.\n");
                Console.Write("What would you like to add to your order:");
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
                if (Int32.TryParse(userChooseInput, out userNumberInput) && userNumberInput <= foodDictionary.Count())
                {
                        userChoice = chooseFromDict[userNumberInput - 1];                 
                }

                else if (Int32.TryParse(userChooseInput, out userNumberInput) && userNumberInput >= foodDictionary.Count())
                {
                    userChoice = "";
                }

                else
                {
                    userChoice = userChooseInput;
                }
                // have userChoice, which is a string that contains the name of the thing in theory

                foreach (KeyValuePair<string, FoodItem> pair in foodDictionary)
                {
                    FoodItem item = pair.Value;
                    if (item.Name.ToLower() == userChoice.ToLower())
                    {
                        Console.WriteLine($"How many {item.Name}s do you want to add?");
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

        public static void ListCurrentOrderDetails(List<FoodItem> order, string title)
        {

            Dictionary<FoodItem,int> receiptDictionary = new Dictionary<FoodItem,int>();
            receiptDictionary = order.GroupBy(FoodItem => FoodItem).ToDictionary(group => group.Key, group => group.Count());
            Console.WriteLine($"________________________________________________\n");
            Console.WriteLine($"                    {title}                   ");
            Console.WriteLine($"________________________________________________\n" +
                $" {"Item",-25}{"Price",-7}{"Amount", -7}{"Cost",-6} \n" +
                $"________________________________________________");
            foreach (KeyValuePair<FoodItem,int> pair in receiptDictionary)
            {

                FoodItem item = pair.Key;
                Console.WriteLine($"{item.Name,-25}{String.Format("{0:C}", item.Price),-7}{pair.Value,-7}{String.Format("{0:C}", (item.Price * pair.Value),-6)}");
            }
            Console.WriteLine("_______________________________________________");
            decimal subtotal = GetSubtotal(order);
            decimal tax = GetTaxAmount(order, taxPercentageDecimal);
            decimal total = GetTotalCost(order, taxPercentageDecimal);

            Console.WriteLine($"\n{"Subtotal:",39}{String.Format("{0:C}", subtotal),6}\n" +
                $"{"Tax:",39}{String.Format("{0:C}", tax),6}\n" +
                $"\n{"Total:",39}{String.Format("{0:C}", total),6}\n");
        }

       
        #region moneymoneymoney

        public static decimal GetTotalCost(List<FoodItem> order, double taxPercentageDecimal)
        {
            List<double> subtotalList = new List<double>();
            foreach (FoodItem item in order)
            {
                subtotalList.Add(item.Price);
            }
            double subtotal = subtotalList.Sum();
            double tax = subtotal * taxPercentageDecimal;
            double total = tax + subtotal;

            return Math.Round(Convert.ToDecimal(total), 2);
        }

        public static decimal GetTaxAmount(List<FoodItem> order, double taxPercentageDecimal)
        {
            List<double> subtotalList = new List<double>();
            foreach (FoodItem item in order)
            {
                subtotalList.Add(item.Price);
            }
            double subtotal = subtotalList.Sum();
            double tax = subtotal * taxPercentageDecimal;

            return Math.Round(Convert.ToDecimal(tax), 2);
        }

        public static decimal GetSubtotal(List<FoodItem> order)
        {
            List<double> subtotalList = new List<double>();
            foreach (FoodItem item in order)
            {
                subtotalList.Add(item.Price);
            }
            return Math.Round(Convert.ToDecimal(subtotalList.Sum()),2);
        }

        #endregion

        

    }
}
