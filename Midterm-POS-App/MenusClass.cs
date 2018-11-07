using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
                Console.WriteLine(@"
....................................................................
|                                                         MAIN MENU |
|...................................................................|
| : : : :::#:#:#:#:##:##:######:#####:#############|________|_______|
| : : : :::#:#:#:#:##:##:######:#####:#############|        |       |
| : : : : : ::#:#:#:#:#:##:###:###:#####:##########|        |       |
| : : :  (-) :::#:#:#:#:#:#:##:####:###:###:####:##|        |       |
|______.-'-'-.___________________________:####::###|________|_______|
|      |-...-|             .--''''''--.  \:###:#####:###############|
|      |;:.._|            |'''''/      |  \:#:#:##:##:###:#####:####|
|      `-...-'            '''''/_...--'|   \#:#:#:##:##:###:###:####|
|                          /\  |__...--'    \ :::#::#:#:#:#:#####:##|
|_________________________/  \_______________\                      |
|                                      | |      1. Order food       |
|  Welcome to the The Chat-E Cheese!   | |      2. Buy some potions |
|  What are you aiming to do?          | |      3. Skedaddle        |
|......................................|.|..........................|
");
                Console.Write("Type a number to make a selection: ");
               string userMainMenuInput = Console.ReadLine();
            
               switch (userMainMenuInput)
                {
                    case "1":
                        OrderMenu(foodDictionary);
                        break;
                    case "2":
                        Console.WriteLine(@"
....................................................................
|                                                        NO POTIONS |
|...................................................................|
| : : : :::#:#:#:#_[_]_#:######:#####:#############|________|_______|
| : : : :::#:#:#:/_   _\:######:#####:#############|        |       |
| : : : : : ::#:#)_``'_(##:###:###:#####:##########|        |       |
| : : :  (-) :::#|;:   |#:#:##:####:###:###:####:##|        |       |
|______.-'-'-.___|;:.._|_________________:####::###|_____/\_|_______|
|      |-...-|   `-...-'   .--''''''--.  \:###:#####:## [_ ] #######|
|      |;:.._|            |'''''/      |  \:#:#:##:##  -'. '-. :####|
|      `-...-'            '''''/_...--'|   \#:#:#:## /:;/ _.-'\  ###|
|                          /\  |__...--'    \ :::#:  |:.TOO .-|  :##|
|_________________________/  \_______________\       | STRONG |     |
|                                      | |           |:.FOR   |     |
|  My potions are too strong for you,  | |           |:.YOU~  |     |
|  traveler!                           | |           |:._     |     |
|......................................|.|...........|........|.....|
");
                        Thread.Sleep(1500);
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
            List<FoodItem> userOrder = new List<FoodItem>();

            bool killswitch = true;
            while (killswitch)
            {
                //Console.WriteLine("\nWhat would you like to do?\n" +
                //    "1. Add an item to your order\n" +
                //    "2. View Your Order\n" +
                //    "3. View the Menu\n" +
                //    "4. Check Out\n" +
                //    "5. Cancel order and go back to main menu.\n");

                Console.WriteLine(@"
....................................................................
|                                                        ORDER UP   |
|...................................................................|
| : : : :::#:#:#:#:##:##:######:#####:#############|________|_______|
| : : : :::#:#:#:#:##:##:######:#####:#############|        |       |
| : : : : : ::#:#:#:#:#:##:###:###:#####:##########|        |       |
| : : :  (-) :::#:#:#:#:#:#:##:####:###:###:####:##|        |       |
|______.-'-'-.___________________________:####::###|________|_______|
|      |-...-|   _______   .--''''''--.  \:###:#####:###############|
|      |;:.._|  / MENU /  |'''''/      |  \:#                     ##|
|      `-...-' / ==== /   '''''/_...--'|   \#   1. Add food       ##|
|             /______/     /\  |__...--'    \   2. View order     ##|
|_________________________/  \_______________\  3. Look at menu     |
|                                      | |      4. Check out        |
|  So you want to order some food, eh? | |      5. Never mind. Go   |
|  Hit me.                             | |         back.            |
|......................................|.|..........................|
");
                Console.Write("Type a number to make a selection: ");

                string userOrderMenuInput = Console.ReadLine();
                switch (userOrderMenuInput)
                {
                    case "1":
                        OrderOptions.ListFoodMenu(foodDictionary);
                        userOrder = OrderOptions.AddFoodItem(userOrder, foodDictionary);
                        break;
                    case "2":
                        OrderOptions.ListCurrentOrderDetails(userOrder,"Your Order");
                        break;
                    case "3":
                        OrderOptions.ListFoodMenu(foodDictionary);
                        break;
                    case "4":
                        killswitch = MenusClass.CheckoutMenu(userOrder);                        
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

        }

        public static bool CheckoutMenu(List<FoodItem> order)
        {

            while (true)
            {
                //Console.WriteLine($"Now checking you out. Your total is {String.Format("{0:C}", OrderOptions.GetTotalCost(order, OrderOptions.taxPercentageDecimal))}\n" +
                //    "Type in a number from the list to:\n" +
                //    "1. Pay by Cash\n" +
                //    "2. Pay by Credit Card\n" +
                //    "3. Pay by Check\n" +
                //    "4. Cancel and go back to your order\n");
                OrderOptions.ListCurrentOrderDetails(order, "Your Order");
                Console.WriteLine(@"
....................................................................
|                                                        CHECK OUT  |
|...................................................................|
| : : : :::#:#:#:#:##:##:######:#####:#############|________|_______|
| : : : :::#:#:#:#:##:##:######:#####:#############|        |       |
| : : : : : ::#:#:#:#:#:##:###:###:#####:##########|        |       |
| : : :  (-) :::#:#:#:#:#:#:##:####:###:###:####:##|        |       |
|______.-'-'-.___________________________:####::###|________|_______|
|      |-...-|    _____    .--''''''--.  \:###:#####:###############|
|      |;:.._| O/ BILL /  |'''''/      |  \:#                     ##|
|      `-...-' /oO  o /   '''''/_...--'|   \#   1. Pay with Cash  ##|
|            o/O____O/     /\  |__...--'    \   2. Pay with Check ##|
|_________________________/  \_______________\  3. Pay with Credit  |
|                                      | |         card.            |");
                Console.WriteLine($"| Your total is { $"{String.Format("{0:C}", OrderOptions.GetTotalCost(order, OrderOptions.taxPercentageDecimal))}",-10}             | |      4. Never mind. Go   | ");
Console.WriteLine("| How are you paying?                  | |         back.            |\n"+
"|......................................|.|..........................| \n");

                Console.Write("Type a number to make a selection: ");

                int checkoutUserInput = Convert.ToInt32(Validation.NumberVal(Console.ReadLine()));
                switch (checkoutUserInput)
                {
                    case 1:
                        Checkout.Cash(order);
                        Thread.Sleep(250);
                        return false;                        
                    case 2:
                        Checkout.Check(order);
                        Thread.Sleep(250);
                        return false;
                    case 3:
                        Checkout.CreditCard(order);
                        Thread.Sleep(250);
                        return false;
                    case 4:
                        return true;
                    default:
                        Console.WriteLine("Not an option. Please try again..");
                        break;
                }

            }
        }
    }
}
