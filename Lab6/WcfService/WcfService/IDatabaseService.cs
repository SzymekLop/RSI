using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WcfService
{
    [ServiceContract(ProtectionLevel = System.Net.Security.ProtectionLevel.None)]
    [ServiceKnownType(typeof(User))]
    public interface IDatabaseService
    {
        [OperationContract]
        ArrayList getAllUsers();

        [OperationContract] 
        Task<ArrayList> getAllUsersSleep();

        [OperationContract]
        int getUserDatabaseSize();

        [OperationContract]
        User addUser(User user);

        [OperationContract]
        User updateUser(User user);

        [OperationContract]
        User deleteUser(int id);

    }

    [DataContract]
    public class User
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }
    }
}
