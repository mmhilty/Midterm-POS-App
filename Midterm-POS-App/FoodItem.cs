using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Midterm_POS_App
{
    class FoodItem
    {
         
        private string _name;
        private string _category;
        private string _description;
        private double _price;
        #region constructor
        public FoodItem(string Name, string Category, string Description, double Price)
        {
            _name = Name;
            _category = Category;
            _description = Description;
            _price = Price;

        }
        #endregion

        #region properties
        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string Category
        {
            get
            {
                return _category;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
        }

        public double Price
        {
            get
            {
                return _price;
            }
        }
        #endregion



    }

}
