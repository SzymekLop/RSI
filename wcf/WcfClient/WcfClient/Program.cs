using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyCalculatorClient client = new MyCalculatorClient();
            int choice = 0;

            do
            {
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Modulo");
                Console.WriteLine("6. HMultiply");
                Console.WriteLine("7. Count and find max prime numbers in range");
                Console.WriteLine("0. Exit");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                switch (choice)
                {
                    case 0:
                        client.CloseConnection();
                        break;
                    case 1:
                        client.Addition();
                        break;
                    case 2:
                        client.Subtraction();
                        break;
                    case 3:
                        client.Multiplication();
                        break;
                    case 4:
                        client.Division();
                        break;
                    case 5:
                        client.Modulo();
                        break;
                    case 6:
                        client.HMultiply();
                        break;
                    case 7:
                        client.CountAndMaxPrimesInRangeAsync();
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            } 
            while (choice != 0);
        }
    }
}
