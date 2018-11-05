using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
