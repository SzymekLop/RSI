﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfClient.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.ICalculator")]
    public interface ICalculator {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/iAdd", ReplyAction="http://tempuri.org/ICalculator/iAddResponse")]
        int iAdd(int n1, int n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/iAdd", ReplyAction="http://tempuri.org/ICalculator/iAddResponse")]
        System.Threading.Tasks.Task<int> iAddAsync(int n1, int n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/iSub", ReplyAction="http://tempuri.org/ICalculator/iSubResponse")]
        int iSub(int n1, int n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/iSub", ReplyAction="http://tempuri.org/ICalculator/iSubResponse")]
        System.Threading.Tasks.Task<int> iSubAsync(int n1, int n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/iMul", ReplyAction="http://tempuri.org/ICalculator/iMulResponse")]
        int iMul(int n1, int n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/iMul", ReplyAction="http://tempuri.org/ICalculator/iMulResponse")]
        System.Threading.Tasks.Task<int> iMulAsync(int n1, int n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/iDiv", ReplyAction="http://tempuri.org/ICalculator/iDivResponse")]
        int iDiv(int n1, int n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/iDiv", ReplyAction="http://tempuri.org/ICalculator/iDivResponse")]
        System.Threading.Tasks.Task<int> iDivAsync(int n1, int n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/iMod", ReplyAction="http://tempuri.org/ICalculator/iModResponse")]
        int iMod(int n1, int n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/iMod", ReplyAction="http://tempuri.org/ICalculator/iModResponse")]
        System.Threading.Tasks.Task<int> iModAsync(int n1, int n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/HMul", ReplyAction="http://tempuri.org/ICalculator/HMulResponse")]
        int HMul(int n1, int n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/HMul", ReplyAction="http://tempuri.org/ICalculator/HMulResponse")]
        System.Threading.Tasks.Task<int> HMulAsync(int n1, int n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/CountAndMaxPrimesInRange", ReplyAction="http://tempuri.org/ICalculator/CountAndMaxPrimesInRangeResponse")]
        System.ValueTuple<int, int> CountAndMaxPrimesInRange(int n1, int n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/CountAndMaxPrimesInRange", ReplyAction="http://tempuri.org/ICalculator/CountAndMaxPrimesInRangeResponse")]
        System.Threading.Tasks.Task<System.ValueTuple<int, int>> CountAndMaxPrimesInRangeAsync(int n1, int n2);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICalculatorChannel : WcfClient.ServiceReference1.ICalculator, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CalculatorClient : System.ServiceModel.ClientBase<WcfClient.ServiceReference1.ICalculator>, WcfClient.ServiceReference1.ICalculator {
        
        public CalculatorClient() {
        }
        
        public CalculatorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CalculatorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int iAdd(int n1, int n2) {
            return base.Channel.iAdd(n1, n2);
        }
        
        public System.Threading.Tasks.Task<int> iAddAsync(int n1, int n2) {
            return base.Channel.iAddAsync(n1, n2);
        }
        
        public int iSub(int n1, int n2) {
            return base.Channel.iSub(n1, n2);
        }
        
        public System.Threading.Tasks.Task<int> iSubAsync(int n1, int n2) {
            return base.Channel.iSubAsync(n1, n2);
        }
        
        public int iMul(int n1, int n2) {
            return base.Channel.iMul(n1, n2);
        }
        
        public System.Threading.Tasks.Task<int> iMulAsync(int n1, int n2) {
            return base.Channel.iMulAsync(n1, n2);
        }
        
        public int iDiv(int n1, int n2) {
            return base.Channel.iDiv(n1, n2);
        }
        
        public System.Threading.Tasks.Task<int> iDivAsync(int n1, int n2) {
            return base.Channel.iDivAsync(n1, n2);
        }
        
        public int iMod(int n1, int n2) {
            return base.Channel.iMod(n1, n2);
        }
        
        public System.Threading.Tasks.Task<int> iModAsync(int n1, int n2) {
            return base.Channel.iModAsync(n1, n2);
        }
        
        public int HMul(int n1, int n2) {
            return base.Channel.HMul(n1, n2);
        }
        
        public System.Threading.Tasks.Task<int> HMulAsync(int n1, int n2) {
            return base.Channel.HMulAsync(n1, n2);
        }
        
        public System.ValueTuple<int, int> CountAndMaxPrimesInRange(int n1, int n2) {
            return base.Channel.CountAndMaxPrimesInRange(n1, n2);
        }
        
        public System.Threading.Tasks.Task<System.ValueTuple<int, int>> CountAndMaxPrimesInRangeAsync(int n1, int n2) {
            return base.Channel.CountAndMaxPrimesInRangeAsync(n1, n2);
        }
    }
}
