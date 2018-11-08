using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Midterm_POS_App
{
    public class Validation
    {

        public static double NumberVal(string numberString)
        {
            string NumberString = numberString;
            double NumberDouble;

            while (true)
            {
                if (double.TryParse(NumberString, out NumberDouble) && (0 <= NumberDouble))
                {
                    return NumberDouble;
                }

                else
                {
                    Console.WriteLine("Invalid input. Please make sure your input is a whole number.\n");
                }

                NumberString = Console.ReadLine();

            }
        }

        public static string CreditCardVal(string numberString)
        {
            string NumberString = numberString;

            while (true)
            {
                double NumberDbl;
                if (double.TryParse(NumberString, out NumberDbl) && NumberString.Count() == 16)
                {
                    if (NumberString[0] == '3' || NumberString[0] == '4' || NumberString[0] == '5' || NumberString[0] == '6')
                    {
                        return NumberString;
                    }

                    else {
                        Console.WriteLine("Invalid input. Please recheck your card number and re-enter:\n");
                        NumberString = Console.ReadLine();

                    }

                }

                else
                {
                    Console.WriteLine("Invalid input. Please recheck your card number and re-enter:\n");
                    NumberString = Console.ReadLine();

                }

            }
        }

        public static int SecurityCodeVal(string numberString, int maxNum)
        {
            string NumberString = numberString;
          
            int NumberInt;

            while (true)
            {
                if (Int32.TryParse(NumberString, out NumberInt) && NumberString.Count() == maxNum)
                {
                    return NumberInt;
                }

                else
                {
                    Console.WriteLine("Invalid input. Please recheck your security code.\n");
                }

                NumberString = Console.ReadLine();

            }
        }

        public static double CheckNumsVal(string numberString, int maxNum)
        {
            string NumberString = numberString;

            double NumberDbl;

            while (true)
            {
                if (Double.TryParse(NumberString, out NumberDbl) && NumberString.Count() <= maxNum)
                {
                    return NumberDbl;
                }

                else
                {
                    Console.WriteLine("Invalid input. Please recheck your number.\n");
                }

                NumberString = Console.ReadLine();

            }
        }

        public static string DateVal(string dateString)
        {
            string DateString = dateString;

            while (true)
            {
                DateTime date;
                if (DateTime.TryParse(DateString, out date))
                {
                    return dateString;
                }
                else
                {
                    Console.WriteLine("Not a valid date. Please try again.");
                }

                DateString = Console.ReadLine();
            }
        }
    }

    
}
