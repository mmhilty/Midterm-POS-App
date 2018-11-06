using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Midterm_POS_App
{
    class Checkout
    {

        public static void Cash(List<FoodItem> order)
        {
            //List Receipt
            OrderOptions.ListCurrentOrderDetails(order);

            decimal orderTotal = OrderOptions.GetTotalCost(order, OrderOptions.taxPercentageDecimal);
            decimal moneyTendered = 0;
            while (moneyTendered < orderTotal)
            {
                Console.WriteLine("\n How much cash are you paying?");

                moneyTendered = moneyTendered + (Convert.ToDecimal(Validation.NumberVal(Console.ReadLine())));

                if (moneyTendered > orderTotal)
                {
                    Console.WriteLine($"Thank you! You've paid {String.Format("{0:C}", moneyTendered)}.\n" +
                        $"Your change is {String.Format("{0:C}", moneyTendered - orderTotal)}\n" +
                        $"Have a great day!\n");
                }

                else if (moneyTendered == orderTotal)
                {
                    Console.WriteLine($"Thank you! You've paid {String.Format("{0:C}", moneyTendered)}.\n" +
                        $"Have a great day!\n");
                }

                else
                {
                    Console.WriteLine($"Thank you! You've paid {String.Format("{0:C}", moneyTendered)}.\n" +
                        $"You still have {String.Format("{0:C}", orderTotal - moneyTendered)} left on this order.");
                }
            }


        }

        public static void CreditCard(List<FoodItem> order)
        {
            OrderOptions.ListCurrentOrderDetails(order);
            decimal orderTotal = OrderOptions.GetTotalCost(order, OrderOptions.taxPercentageDecimal);
            
            Console.WriteLine("You are paying by credit card. Please enter your credit card number:");
            double ccNum = Validation.CreditCardVal(Console.ReadLine());

            int secCode;
            if (ccNum.ToString()[0] == 3)
            {
                Console.WriteLine("Please enter the 4 digit security code on the front of your card.");
                secCode = Validation.SecurityCodeVal(Console.ReadLine(), 4);
            }
            else 
            {
                Console.WriteLine("Please enter the 3 digit security code on the back of your card.");
                secCode = Validation.SecurityCodeVal(Console.ReadLine(), 3);
            }

            Console.WriteLine("Please enter the expiration date in format MM/YYYY:");
            string ccExp = Validation.DateVal(Console.ReadLine());

        }

        public static void Check(List<FoodItem> order)
        {

        }

       

    }
}
