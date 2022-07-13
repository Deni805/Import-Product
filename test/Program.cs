using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using test.Entities;

namespace test
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Product> list = new List<Product>();


            Console.WriteLine("Quantidade de produtos: ");
            Console.Write("R: ");
            int qp = int.Parse(Console.ReadLine());

            for (int i = 0; i < qp; i++)
            {
                Console.WriteLine("\n\nO seu produto é COMUM, IMPORTADOR ou USADO (c/i/u)?");
                Console.Write("R: ");
                string type = Console.ReadLine();

                Console.Write("Nome: ");
                String name = Console.ReadLine();
                Console.Write("\nPreço: ");
                double price = double.Parse(Console.ReadLine());

                if (type == "c")
                {
                    list.Add(new Product(name, price));
                }
                else if (type == "u")
                {
                    Console.Write("\nData de fabricação (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    list.Add(new UsedProduct(name, price, date));
                }
                else
                {
                    Console.Write("\nCusto de taxação: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new ImportedProduct(name, price, customsFee));
                }
            }

            Console.WriteLine("****** ETIQUETAS ******");
            foreach (Product prod in list)
            {
                Console.WriteLine(prod.PriceTag());
            }
        }
    }
}
