using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{

    public class Product : ObservableObject
    {

        private string productId;
        private string productName;
        private string quantity;
        private int TEXT_LIMIT = 50;

        public Product() { }

        public Product(string fName, string lName, string mail)
        {
            productId = fName;
            productName = lName;
            quantity = mail;
        }


        public string ProductName
        {
            get
            {
                return productName;
            }
            set
            {
                if (value.Length > TEXT_LIMIT)
                {
                    throw new ArgumentException("Too long");
                }
                if (value.Length == 0)
                {
                    throw new NullReferenceException();
                }
                productName = value;
            }
        }

        public string ProductId
        {
            get
            {
                return productId;
            }
            set
            {
                if (value.Length > TEXT_LIMIT)
                {
                    throw new ArgumentException("Too long");
                }
                if (value.Length == 0)
                {
                    throw new NullReferenceException();
                }
                productId = value;
            }
        }

        public string Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if (value.Length > TEXT_LIMIT)
                {
                    throw new ArgumentException("Too long");
                }
                if (value.Length == 0)
                {
                    throw new NullReferenceException();
                }
                if (value.IndexOf("@") == -1 || value.IndexOf(".") == -1)
                {
                    throw new FormatException();
                }
                quantity = value;
            }
        }


        /// <summary>
        /// Text to be displayed in the list box.
        /// </summary>
        /// <returns>A concatenation of the member's first name, last name, and email.</returns>
        public string display()
        {
            return productId + " " + productName + ", " + quantity;
        }

    }
}

