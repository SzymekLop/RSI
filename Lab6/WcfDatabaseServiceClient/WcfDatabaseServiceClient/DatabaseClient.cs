using System;
using System.ServiceModel;
using WcfDatabaseServiceClient.ServiceReference1;

namespace WcfDatabaseServiceClient
{
    public class DatabaseClient
    {

        private readonly DatabaseServiceClient client;

        public DatabaseClient(string binding = "WSHttpBinding_IDatabaseService")
        {
            client = new DatabaseServiceClient(binding);
        }

        public void CloseConnection()
        {
            client.Close();
        }

        public void GetUsers()
        {
            try
            {
                Console.WriteLine();
                var list = client.getAllUsers();
                foreach (User user in list) 
                {
                    Console.WriteLine($"Id: {user.Id} {user.Name}, age: {user.Age}");
                }
            }
            catch (FaultException ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void GetUsersAsync()
        {
            try
            {
                Console.WriteLine();
                var list = await client.getAllUsersSleepAsync();
                foreach (User user in list)
                {
                    Console.WriteLine($"Id: {user.Id} {user.Name}, age: {user.Age}");
                }
            }
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(TimeoutException)
            {
                Console.WriteLine("Operacja zajela zbyt duzo czasu");
            }
        }

        public void GetUser()
        {
            try
            {
                Console.WriteLine("Podaj id użytkownika");
                int id = int.Parse(Console.ReadLine());
                var list = client.getAllUsers();
                foreach (User user in list)
                {
                    if (user.Id == id)
                    {
                        Console.WriteLine($"Id: {user.Id} {user.Name}, age: {user.Age}");
                        return;
                    }
                }
            }
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetDatabaseSize()
        {
            try
            {
               Console.WriteLine(client.getUserDatabaseSize());
            }
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddUser()
        {
            Console.WriteLine("Podaj id użytkownika: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj imie i nazwisko użytkownika: ");
            string name = Console.ReadLine();
            Console.Write("Podaj wiek użytkownika: ");
            int age = int.Parse(Console.ReadLine());

            User user = new User { Id = id, Name = name, Age = age };

            try
            {
                client.addUser(user);
            }
            catch(FaultException ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RemoveUser()
        {
            Console.WriteLine("Podaj id użytkownika: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                client.deleteUser(id);
            }
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateUser()
        {
            Console.WriteLine("Podaj id użytkownika: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj imie i nazwisko użytkownika: ");
            string name = Console.ReadLine();
            Console.Write("Podaj wiek użytkownika: ");
            int age = int.Parse(Console.ReadLine());

            User user = new User { Id = id, Name = name, Age = age };

            try
            {
                client.updateUser(user);
            }
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
