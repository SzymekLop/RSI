using System.Net.Security;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WcfServiceMathLibrary
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę interfejsu „IService1” w kodzie i pliku konfiguracji.

    [ServiceContract(ProtectionLevel = ProtectionLevel.None)]
    public interface ICalculator
    {
        [OperationContract]
        int iAdd(int n1, int n2);

        [OperationContract]
        int iSub(int n1, int n2);

        [OperationContract]
        int iMul(int n1, int n2);

        [OperationContract]
        int iDiv(int n1, int n2);

        [OperationContract]
        int iMod(int n1, int n2);
        [OperationContract]
        Task<int> HMul(int n1, int n2);

        [OperationContract]
        Task<(int, int)> CountAndMaxPrimesInRangeAsync(int n1, int n2);
    }


    // Użyj kontraktu danych, jak pokazano w poniższym przykładzie, aby dodać typy złożone do operacji usługi.
    // Możesz dodać pliki XSD do projektu. Po skompilowaniu projektu możesz bezpośrednio użyć zdefiniowanych w nim typów danych w przestrzeni nazw „WcfServiceMathLibrary.ContractType”.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
