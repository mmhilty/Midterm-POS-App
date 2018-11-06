using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Midterm_POS_App
{
    class Validation
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

        public static double CreditCardVal(string numberString)
        {

            while (true)
            {
                double NumberDbl;
                if (double.TryParse(numberString, out NumberDbl) && numberString.Count() == 16)
                {
                    if (Convert.ToInt32(NumberDbl.ToString()[0]) == 3 || 
                        Convert.ToInt32(NumberDbl.ToString()[0]) == 4 || 
                        Convert.ToInt32(NumberDbl.ToString()[0]) == 5 || 
                        Convert.ToInt32(NumberDbl.ToString()[0]) == 6)
                    {
                        return NumberDbl;
                    }
                }

                else
                {
                    Console.WriteLine("Invalid input. Please recheck your card number.\n");
                }

                numberString = Console.ReadLine();

            }
        }

        public static int SecurityCodeVal(string numberString, int maxNum)
        {
            string NumberString = numberString;
            NumberString.Replace(".", "");
            NumberString.Replace("", "");
            NumberString.Replace("/", "");

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

        public static string DateVal(string dateString)
        {
            while (true)
            {
                string DateString = dateString;
                DateTime date;
                if (DateTime.TryParse(dateString, out date))
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
