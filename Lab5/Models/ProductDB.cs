using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    class ProductDB : ObservableObject
    {
        /// <summary>
        /// The list of members to be saved.
        /// </summary>
        private ObservableCollection<Product> products;
        /// <summary>
        /// Where the database is stored.
        /// </summary>
        private const string filepath = "../products.txt";
        /// <summary>
        /// Creates a new member database.
        /// </summary>
        /// <param name="m">The list to saved from or written to.</param>
        public ProductDB(ObservableCollection<Product> m)
        {
            products = m;
        }
        /// <summary>
        /// Reads the saved text file database into the program's list of members.
        /// </summary>
        /// <returns>The list containing the text file data read in.</returns>
        public ObservableCollection<Product> GetProducts()
        {
            try
            {
                StreamReader input = new StreamReader(new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Read));
                input.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }
            catch (FormatException)
            {

                Console.WriteLine("Invalid quantity address format.");
            }
            return products;
        }
        /// <summary>
        /// Saves the program's list of members into the text file database.
        /// </summary>
        public void SaveProducts()
        {
            StreamWriter output = new StreamWriter(new FileStream(filepath, FileMode.Create, FileAccess.Write));

            output.Close();
        }
    }
}
