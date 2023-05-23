using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MyWebService
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę interfejsu „IService1” w kodzie i pliku konfiguracji.
    [ServiceContract]
    public interface IRestService
    {

        [OperationContract]
        [WebGet(UriTemplate = "/people")]
        List<Person> getAllXml();

        [OperationContract]
        [WebGet(UriTemplate = "/people/{id}", ResponseFormat = WebMessageFormat.Xml)]
        Person getByIdXml(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/people", Method = "POST", RequestFormat = WebMessageFormat.Xml)]
        string addXml(Person item);

        [OperationContract]
        [WebInvoke(UriTemplate = "/people/{id}", Method = "DELETE")]
        string deleteXml(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/people/{id}", Method = "PUT", RequestFormat = WebMessageFormat.Xml)]
        string updateXml(string Id, Person person);

        [OperationContract]
        [WebGet(UriTemplate = "/people/count")]
        int getAllCountXml();

        [OperationContract]
        [WebGet(UriTemplate = "/people/age/{age}", ResponseFormat = WebMessageFormat.Xml)]
        List<Person> getFilteredByAgeXml(string Age);

        [OperationContract]
        [WebGet(UriTemplate = "/people/insurance/{isInsured}", ResponseFormat = WebMessageFormat.Xml)]
        List<Person> getFilteredByInsurenceXml(string IsInsured);

        [OperationContract]
        [WebGet(UriTemplate = "/people/insuranceClass/{insuranceClass}", ResponseFormat = WebMessageFormat.Xml)]
        List<Person> getFilteredByInsurenceClassXml(string InsuranceClass);

        [OperationContract]
        [WebGet(UriTemplate = "/json/people", ResponseFormat = WebMessageFormat.Json)]
        List<Person> getAllJson();

        [OperationContract]
        [WebGet(UriTemplate = "/json/people/{id}", ResponseFormat = WebMessageFormat.Json)]
        Person getByIdJson(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/people", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string addJson(Person item);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/people/{id}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
        string deleteJson(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/people/{id}", Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string updateJson(string Id, Person person);

        [OperationContract]
        [WebGet(UriTemplate = "/json/people/count")]
        int getAllCountJson();

        [OperationContract]
        [WebGet(UriTemplate = "/json/people/age/{age}", ResponseFormat = WebMessageFormat.Json)]
        List<Person> getFilteredByAgeJson(string Age);

        [OperationContract]
        [WebGet(UriTemplate = "/json/people/insurance/{isInsured}", ResponseFormat = WebMessageFormat.Json)]
        List<Person> getFilteredByInsurenceJson(string IsInsured);

        [OperationContract]
        [WebGet(UriTemplate = "/json/people/insuranceClass/{insuranceClass}", ResponseFormat = WebMessageFormat.Json)]
        List<Person> getFilteredByInsuranceClassJson(string InsuranceClass);

        [OperationContract]
        [WebGet(UriTemplate = "/people/authors", ResponseFormat = WebMessageFormat.Xml)]
        String getAuthorsXml();

        [OperationContract]
        [WebGet(UriTemplate = "/json/people/authors", ResponseFormat = WebMessageFormat.Json)]
        String getAuthorsJson();
    }

    [DataContract]
    public class Person
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public string Name { get; set; }

        [DataMember(Order = 3)]
        public int Age { get; set; }

        [DataMember(Order = 4)]
        public string Email { get; set; }

        [DataMember(Order = 5)]
        public bool IsInsured { get; set; }

        [DataMember(Order = 6)]
        public char IncuranceClass { get; set; }

    }
}
