using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WcfService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
    ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class DatabaseService : IDatabaseService
    {
        private ArrayList _users = new ArrayList();

        private bool contains(User user)
        {
            foreach (User u in _users)
            {
                if (u.Id == user.Id)
                {
                    return true;
                }
            }
            return false;
        }
        public User addUser(User user)
        {

            Console.Write("Add user ");
            Console.WriteLine($"Id: {user.Id} {user.Name}, age: {user.Age}");
            if (contains(user))
            {
                throw new FaultException<ArgumentException>(new ArgumentException(), "User already exists in the database");
            }
            _users.Add(user);
            return user;
        }

        public User deleteUser(int id)
        {
            Console.Write("Remove user ");
            foreach (User user in _users)
            {
                if(user.Id == id)
                {

                    Console.WriteLine($"Id: {user.Id} {user.Name}, age: {user.Age}");
                    _users.Remove(user);
                    return user;
                }
            }
            Console.WriteLine();
            throw new FaultException<ArgumentException>(new ArgumentException(), "User does not exist in the database");
        }

        public ArrayList getAllUsers()
        {
            Console.WriteLine("All users");
            return _users;
            
        }

        public async Task<ArrayList> getAllUsersSleep()
        {
            Console.Write("All user async start");
            await Task.Delay(3000);
            Console.Write("All user async end");
            return _users;
        }

        public int getUserDatabaseSize()
        {
            Console.Write("All user count");
            return _users.Count;
        }

        public User updateUser(User user)
        {
            Console.Write("Update user ");
            Console.WriteLine($"Id: {user.Id} {user.Name}, age: {user.Age}");
            if (!contains(user))
            {
                throw new FaultException<ArgumentException>(new ArgumentException(), "User does not exist in the database");
            }
            for(int i = 0; i < _users.Count; i++)
            {
                if (((User)_users[i]).Id == user.Id)
                {
                    _users[i] = user;
                    return user;
                }
            }
            return null;
        }
    }
}

