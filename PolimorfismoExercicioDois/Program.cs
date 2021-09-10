using System;
using PolimorfismoExercicioDois.Entities;
using System.Collections.Generic;
using System.Globalization;

namespace PolimorfismoExercicioDois
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Product> products = new List<Product>();
            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Common, used or imported (c/u/i)? ");
                char commonUsedImported = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (commonUsedImported == 'c')
                {
                    products.Add(new Product(name, price));
                } 
                else if(commonUsedImported == 'u')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime manuFactureDate = DateTime.Parse(Console.ReadLine());
                    products.Add(new UsedProduct(name, price, manuFactureDate));
                }
                else if(commonUsedImported == 'i')
                {
                    Console.Write("Custom fee: ");
                    double customFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    products.Add(new ImportedProduct(name, price, customFee));
                }
                else
                {
                    Console.WriteLine("Error to read c/u/i (common, used or imported)");
                }
            }
            Console.WriteLine();
            foreach(Product p in products)
            {
                Console.WriteLine(p.PriceTag());
            }

        }
    }
}
