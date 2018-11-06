using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Midterm_POS_App
{
    class MenusClass
    {
        public static void MainMenu(Dictionary<string,FoodItem> foodDictionary)
        {
            bool killswitch = true;
            while(killswitch)
            {
                List<FoodItem> order = new List<FoodItem>();
                Console.WriteLine("Welcome to the The Winking Skeever! What are you aiming to do?\n" +
                    "1. Order food\n" +
                    "2. Buy some potions\n" +
                    "3. Skedaddle\n");
               string userMainMenuInput = Console.ReadLine();
            
               switch (userMainMenuInput)
                {
                    case "1":
                        OrderMenu(foodDictionary);
                        break;
                    case "2":
                        Console.WriteLine("My potions are too strong for you, traveller!\n");
                        break;
                    case "3":
                        killswitch = false;
                        break;
                    default:
                        Console.WriteLine("I'm not sure what you mean, traveller.\n");                        
                        break;
                
                }
            }
        }

        public static void OrderMenu(Dictionary<string, FoodItem> foodDictionary)
        {
            // view menu
            List<FoodItem> userOrder = new List<FoodItem>();

            bool killswitch = true;
            while (killswitch)
            {
                Console.WriteLine("\nWhat would you like to do?\n" +
                    "1. Add an item to your order\n" +
                    "2. View Your Order\n" +
                    "3. View the Menu\n" +
                    "4. Check Out\n" +
                    "5. Cancel order and go back to main menu.\n");

                string userOrderMenuInput = Console.ReadLine();
                switch (userOrderMenuInput)
                {
                    case "1":
                        OrderOptions.ListFoodMenu(foodDictionary);
                        userOrder = OrderOptions.AddFoodItem(userOrder, foodDictionary);
                        break;
                    case "2":
                        OrderOptions.ListCurrentOrderDetails(userOrder);
                        break;
                    case "3":
                        OrderOptions.ListFoodMenu(foodDictionary);
                        break;
                    case "4":
                        MenusClass.CheckoutMenu(userOrder);
                        killswitch = false;
                        break;
                    case "5":
                        Console.WriteLine("Are you sure you want to cancel this transaction? Y/N");
                        string uSure = Console.ReadLine();
                        if (uSure.ToUpper() == "Y")
                        {
                            killswitch = false;
                        }
                        break;
                }

            }
            // add to order

            // checkout 
            

            // clear order 
            //// you sure?
        }

        public static void CheckoutMenu(List<FoodItem> order)
        {
            //// would you like to 1 pay by cash 2 pay by credit card 3 pay by check 4 go back

            bool killswitch = true;
            while (killswitch)
            {
                Console.WriteLine("Now checking you out. \n " +
                    $"Your total is {String.Format("{0:C}", OrderOptions.GetTotalCost(order, OrderOptions.taxPercentageDecimal))}\n" +
                    "Type in a number from the list to:\n" +
                    "1. Pay by Cash\n" +
                    "2. Pay by Credit Card\n" +
                    "3. Pay by Check\n" +
                    "4. Cancel and go back to your order\n");
                int checkoutUserInput = Convert.ToInt32(Validation.NumberVal(Console.ReadLine()));
                switch (checkoutUserInput)
                {
                    case 1:
                        Checkout.Cash(order);
                        killswitch = false;
                        break;
                    case 2:
                        Checkout.CreditCard(order);
                        killswitch = false;
                        break;
                    case 3:
                        Checkout.Check(order);
                        killswitch = false;
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Not an option. Please try again..");
                        break;
                }

            }
        }
    }
}
