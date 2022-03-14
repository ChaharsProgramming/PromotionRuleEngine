using System;
using System.Text;

namespace RuleEngine
{
    //*TODO: UI interaction is pending with console
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder stringBuilder;
            Console.WriteLine("Rule Engine Running.....");
            do
            {
                Console.WriteLine("Press 1 to check Promotions.....");
                Console.WriteLine("Press 2 to check SKU ids from Cart.....");
                Console.WriteLine("Press 3 to check Inventory Item.....");

                var userChoice = int.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        stringBuilder = new StringBuilder(Console.ReadLine());
                        Console.WriteLine("Promotions.....");
                        //promotion 
                        break;
                    case 2:
                        stringBuilder = new StringBuilder(Console.ReadLine());
                        Console.WriteLine("SKUIds Item.....");
                        //SKU Ids
                        break;
                    case 3:
                        stringBuilder = new StringBuilder(Console.ReadLine());
                        Console.WriteLine("Inventory.....");
                        // Invetory Items
                        break;
                    default:
                        Console.WriteLine("not valid option");
                        break;

                }
                Console.WriteLine("Do you want to continue to check another string (Y/N)?");
            } while (Console.ReadLine().ToUpper() == "Y");

        }

    }
}

