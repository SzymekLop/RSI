using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string xmlType = "text/xml";
            string jsonType = "application/json";
            string get = "GET";
            string post = "POST";
            string put = "PUT";
            string delete = "DELETE";

            MyRestClient client = new MyRestClient();

            int choice = 0;

            do
            {
                Console.WriteLine("Wybierz operacje:");
                Console.WriteLine("XML");
                Console.WriteLine("    1. Wszyscy ludzie");
                Console.WriteLine("    2. Jedna osoba");
                Console.WriteLine("    3. Nowa osoba");
                Console.WriteLine("    4. Usuń osobę");
                Console.WriteLine("    5. Edytuj osobę");
                Console.WriteLine("    6. Liczba ludzi");
                Console.WriteLine("JSON");
                Console.WriteLine("    7. Wszyscy ludzie");
                Console.WriteLine("    8. Jedna osoba");
                Console.WriteLine("    9. Nowa osoba");
                Console.WriteLine("    10. Usuń osobę");
                Console.WriteLine("    11. Edytuj osobę");
                Console.WriteLine("    12. Liczba ludzi");
                Console.WriteLine("0. Exit");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Niepoprawny wybór!");
                    continue;
                }

                string endpoint = "";
                string method = "";
                string type = "";

                switch (choice)
                {
                    case 0:
                        break;
                    case 1:
                        endpoint = "people";
                        method = get;
                        type = xmlType;
                        break;
                    case 2:
                        Console.Write("Podaj indeks osoby: ");
                        int getId = int.Parse(Console.ReadLine()); 
                        endpoint = $"people/{getId}";
                        method = get;
                        type = xmlType;
                        break;
                    case 3:
                        endpoint = "people";
                        method = post;
                        type = xmlType;
                        break;
                    case 4:
                        Console.Write("Podaj indeks osoby: ");
                        int delId = int.Parse(Console.ReadLine());
                        endpoint = $"people{delId}";
                        method = delete;
                        type = xmlType;
                        break;
                    case 5:
                        Console.Write("Podaj indeks osoby: ");
                        int editId = int.Parse(Console.ReadLine());
                        endpoint = $"people{editId}";
                        method = put;
                        type = xmlType;
                        break;
                    case 6:
                        endpoint = "people/count";
                        method = get;
                        type = xmlType;
                        break;
                    case 7:
                        endpoint = "json/people";
                        method = get;
                        type = jsonType;
                        break;
                    case 8:
                        Console.Write("Podaj indeks osoby: ");
                        int getIdJson = int.Parse(Console.ReadLine());
                        endpoint = $"json/people/{getIdJson}";
                        method = get;
                        type = jsonType;
                        break;
                    case 9:
                        endpoint = "json/people";
                        method = post;
                        type = jsonType;
                        break;
                    case 10:
                        Console.Write("Podaj indeks osoby: ");
                        int delIdJson = int.Parse(Console.ReadLine());
                        endpoint = $"json/people{delIdJson}";
                        method = delete;
                        type = jsonType;
                        break;
                    case 11:
                        Console.Write("Podaj indeks osoby: ");
                        int editIdJson = int.Parse(Console.ReadLine());
                        endpoint = $"json/people{editIdJson}";
                        method = put;
                        type = jsonType;
                        break;
                    case 12:
                        endpoint = "json/people/count";
                        method = get;
                        type = jsonType;
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór!");
                        break;
                }

                client.processRequest(endpoint, method, type);
            }
            while (choice != 0);

        }
    }
}
