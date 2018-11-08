using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midterm_POS_App;

namespace POS_Unit_Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreditCardFormatting_Equals()
        {

            string inputstring = "1234567890123456";
            double inputdouble = Convert.ToDouble(inputstring);

            Assert.AreEqual(Validation.CreditCardVal(inputstring),inputdouble);

        }

    }
}
