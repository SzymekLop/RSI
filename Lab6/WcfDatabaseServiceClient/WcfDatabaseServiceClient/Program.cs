using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfDatabaseServiceClient
{
    public class Program
    {
        static void Main(string[] args)
        {

            MyData.MyData.info();
            DatabaseClient client = new DatabaseClient();
            int choice = 0;

            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Pokaż wyszyskich użytkowników");
                Console.WriteLine("2. Wybierz użytkownika");
                Console.WriteLine("3. Dodaj użytkownika");
                Console.WriteLine("4. Edytuj użytkownika");
                Console.WriteLine("5. Usuń użytkownika");
                Console.WriteLine("6. Pokaż wszystkich uzytkowników async");
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
                        client.GetUsers();
                        break;
                    case 2:
                        client.GetUser();
                        break;
                    case 3:
                        client.AddUser();
                        break;
                    case 4:
                        client.UpdateUser();
                        break;
                    case 5:
                        client.RemoveUser();
                        break;
                    case 6:
                        client.GetUsersAsync();
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór.");
                        break;
                }
            }
            while (choice != 0);
        }
    }
}
