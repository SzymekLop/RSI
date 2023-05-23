using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.UI;

namespace MyWebService
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie, usłudze i pliku konfiguracji.
    // UWAGA: aby uruchomić klienta testowego WCF w celu przetestowania tej usługi, wybierz plik Service1.svc lub Service1.svc.cs w eksploratorze rozwiązań i rozpocznij debugowanie.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class RestService : IRestService
    {
        private static int _id = 3;
        private static List<Person> _people = new List<Person>()
        {
            new Person() { Id = 0, Name = "Aleksandra Wolska", Age = 23, Email = "wschodzaca@gmail.com", IsInsured = true, IncuranceClass = '1'},
            new Person() { Id = 1, Name = "szymon Łopuszyński", Age = 22, Email = "szym3k@op.pl", IsInsured = false, IncuranceClass = '2'},
            new Person() { Id = 2, Name = "Jan Kowalski", Age = 13, Email = "kowal@wp.pl", IsInsured = true, IncuranceClass = '1'}
        };
        public List<Person> getAllXml()
        {
            return _people;
        }

        public List<Person> getAllJson()
        {
            return _people;
        }

        public Person getByIdXml(string Id)
        {
            int id = int.Parse(Id);
            int index = _people.FindIndex(p => p.Id == id);
            if (index == -1)
            {
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);
            }
            return _people.ElementAt(index);
        }

        public Person getByIdJson(string Id)
        {
            int id = int.Parse(Id);
            int index = _people.FindIndex(p => p.Id == id);
            if (index == -1)
            {
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);
            }
            return _people.ElementAt(index);
        }

        public string addXml(Person person)
        {

            if (person == null)
            {
                throw new WebFaultException<string>("400: BadRequest", HttpStatusCode.BadRequest);
            }
            foreach (Person p in _people)
            {
                if (p.Email.Equals(person.Email))
                {
                    throw new WebFaultException<string>("Email already used", HttpStatusCode.Conflict);
                }
            }
            person.Id = _id++;
            _people.Add(person);
            return "Added new person: " + person.Id + " " + person.Name + " age: " + person.Age + " " + person.Email;
        }

        public string addJson(Person person)
        {
            if (person == null)
            {
                throw new WebFaultException<string>("400: BadRequest", HttpStatusCode.BadRequest);
            }
            foreach(Person p in _people){
                if (p.Email.Equals(person.Email))
                {
                    throw new WebFaultException<string>("Email already used", HttpStatusCode.Conflict);
                }
            }
            person.Id = _id++;
            _people.Add(person);
            return "Added new person: " + person.Id + " " + person.Name + " age: " + person.Age + " " + person.Email;
        }

        public string deleteXml(string Id)
        {
            int id = int.Parse(Id);
            int index = _people.FindIndex(p => p.Id == id);
            if (index == -1)
            {
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);
            }
            Person person = _people.ElementAt(index);
            _people.RemoveAt(index);
            return "Removed person: " + person.Id + " " + person.Name + " age: " + person.Age + " " + person.Email;
        }

        public string deleteJson(string Id)
        {
            int id = int.Parse(Id);
            int index = _people.FindIndex(p => p.Id == id);
            if (index == -1)
            {
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);
            }
            Person person = _people.ElementAt(index);
            _people.RemoveAt(index);
            return "Removed person: " + person.Id + " " + person.Name;
        }

        public string updateXml(string Id, Person person)
        {
            int id = int.Parse(Id);
            int index = _people.FindIndex(p => p.Id == id);
            if (index == -1)
            {
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);
            }
            foreach (Person p in _people)
            {
                if (p.Email.Equals(person.Email))
                {
                    throw new WebFaultException<string>("Email already used", HttpStatusCode.Conflict);
                }
            }
            Person personToEdit = _people.ElementAt(index);
            personToEdit.Name = person.Name;
            personToEdit.Age = person.Age;
            personToEdit.Email = person.Email;

            return "Edited person: " + person.Id + " " + person.Name + " age: " + person.Age + " " + person.Email;
        }

        public string updateJson(string Id, Person person)
        {
            int id = int.Parse(Id);
            int index = _people.FindIndex(p => p.Id == id);
            if (index == -1)
            {
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);
            }
            foreach (Person p in _people)
            {
                if (p.Email.Equals(person.Email))
                {
                    throw new WebFaultException<string>("Email already used", HttpStatusCode.Conflict);
                }
            }
            Person personToEdit = _people.ElementAt(index);
            personToEdit.Name = person.Name;
            personToEdit.Age = person.Age;
            personToEdit.Email = person.Email;

            return "Edited person: " + person.Id + " " + person.Name + " age: " + person.Age + " " + person.Email;
        }

        public int getAllCountXml()
        {
            return _people.Count;
        }

        public int getAllCountJson()
        {
            return _people.Count;
        }

        public List<Person> getFilteredByAgeXml(string Age)
        {
            try
            {
                return _people.FindAll(person => person.Age == int.Parse(Age));
            }
            catch(FormatException ex)
            {
                throw new WebFaultException<string>("400: Bad request\nPath variable must be a number!", HttpStatusCode.BadRequest);
            }
        }

        public List<Person> getFilteredByInsurenceXml(string IsInsured)
        {
            try
            {
                return _people.FindAll(person => person.IsInsured == bool.Parse(IsInsured));
            }
            catch (FormatException ex)
            {
                throw new WebFaultException<string>("400: Bad request\nPath variable must be a logical value \"true\"/\"false\"!", HttpStatusCode.BadRequest);
            }
        }

        public List<Person> getFilteredByInsurenceClassXml(string InsurenceClass)
        {
             return _people.FindAll(person => person.IncuranceClass == InsurenceClass.ElementAt(0));
        }

        public List<Person> getFilteredByAgeJson(string Age)
        {
            try
            {
                return _people.FindAll(person => person.Age == int.Parse(Age));
            }
            catch (FormatException ex)
            {
                throw new WebFaultException<string>("400: Bad request\nPath variable must be a number!", HttpStatusCode.BadRequest);
            }
        }

        public List<Person> getFilteredByInsurenceJson(string IsInsured)
        {
            try
            {
                return _people.FindAll(person => person.IsInsured == bool.Parse(IsInsured));
            }
            catch (FormatException ex)
            {
                throw new WebFaultException<string>("400: Bad request\nPath variable must be a logical value \"true\"/\"false\"!", HttpStatusCode.BadRequest);
            }
        }

        public List<Person> getFilteredByInsuranceClassJson(string InsurenceClass)
        {
            return _people.FindAll(person => person.IncuranceClass == InsurenceClass.ElementAt(0));
        }

        public string getAuthorsXml()
        {
            return "Aleksandra Wolska 251810, Szymon Łopuszyński 260454";
        }
        public string getAuthorsJson()
        {
            return "Aleksandra Wolska 251810, Szymon Łopuszyński 260454";
        }
    }
}
