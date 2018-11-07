using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;

namespace Midterm_POS_App
{
    class Checkout
    {

        public static void Cash(List<FoodItem> order)
        {
            //List Receipt

            decimal orderTotal = OrderOptions.GetTotalCost(order, OrderOptions.taxPercentageDecimal);
            decimal moneyTendered = 0;
            while (moneyTendered < orderTotal)
            {
                Console.WriteLine("\nHow much cash are you paying?");

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

                if (moneyTendered >= orderTotal)
                {
                    OrderOptions.ListCurrentOrderDetails(order, " Receipt  ");
                    Console.WriteLine($"\n{"Money Tendered:",39}{String.Format("{0:C}", moneyTendered),6}\n");
                    Console.WriteLine($"{"Change:",39}{String.Format("{0:C}", moneyTendered - orderTotal),6}\n");
                }
            }


        }

        public static void CreditCard(List<FoodItem> order)
        {
            decimal orderTotal = OrderOptions.GetTotalCost(order, OrderOptions.taxPercentageDecimal);
            
            Console.WriteLine($"You are paying {String.Format("{0:C}", orderTotal)} by credit card. Please enter your credit card number:");
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
            Console.WriteLine("Thank you!");
            OrderOptions.ListCurrentOrderDetails(order, " Receipt  ");

            Console.WriteLine($"{String.Format("{0:C}", orderTotal)} has been paid via your credit card: \n");
            Console.WriteLine($"{"Card Number:",20}{ccNum.ToString("D"),25}");
            Console.WriteLine($"{"Security Code:",20}{secCode,25}");
            Console.WriteLine($"{"Expiration Date:",20}{ccExp,25}\n");
            Console.WriteLine("Have a great day!\n");
        }

        public static void Check(List<FoodItem> order)
        {
            decimal orderTotal = OrderOptions.GetTotalCost(order, OrderOptions.taxPercentageDecimal);

            Console.WriteLine($"You are paying {String.Format("{0:C}", orderTotal)} by check. Please enter your 9 digit bank routing number:");
            double routingNum = Validation.CheckNumsVal(Console.ReadLine(), 12);
            Console.WriteLine("\nPlease enter your bank account number:");
            double acctNum = Validation.CheckNumsVal(Console.ReadLine(), 12);
            Console.WriteLine("\nPlease enter the check number:");
            double checkNum = Validation.CheckNumsVal(Console.ReadLine(), 20);

            OrderOptions.ListCurrentOrderDetails(order, " Receipt  ");

            Console.WriteLine($"{String.Format("{0:C}", orderTotal)} has been paid via check: \n");
            Console.WriteLine($"{"Check Details:",14}{$" {routingNum} {acctNum} {checkNum}",31}");
            Console.WriteLine("\nHave a great day!\n");
        }



    }
}
