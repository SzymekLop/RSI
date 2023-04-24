using System;
using System.ServiceModel.Description;
using System.ServiceModel;
using WcfService;
using System.ServiceModel.Channels;

namespace WcfServiceHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyData.MyData.info();
            //Uri baseAddress = new Uri("http://192.168.43.18:10000/DatabaseService");
            Uri baseAddress = new Uri("http://localhost:10000/DatabaseService");
            ServiceHost myHost = new ServiceHost(typeof(DatabaseService), baseAddress);

            BasicHttpBinding myBinding = new BasicHttpBinding();
            myBinding.OpenTimeout = new TimeSpan(0, 0, 30);
            myBinding.CloseTimeout = new TimeSpan(0, 0, 30);
            myBinding.SendTimeout = new TimeSpan(0, 0, 30);
            myBinding.ReceiveTimeout = new TimeSpan(0, 0, 30);
            Console.WriteLine(myBinding.ReceiveTimeout.ToString());
            ServiceEndpoint endpoint1 = myHost.AddServiceEndpoint(typeof(IDatabaseService), myBinding, "endpoint1");

            WSHttpBinding binding2 = new WSHttpBinding();
            binding2.OpenTimeout = new TimeSpan(0, 0, 30);
            binding2.CloseTimeout = new TimeSpan(0, 0, 30);
            binding2.SendTimeout = new TimeSpan(0, 0, 30);
            binding2.ReceiveTimeout = new TimeSpan(0, 0, 30);
            binding2.Security.Mode = SecurityMode.None;
            ServiceEndpoint endpoint2 = myHost.AddServiceEndpoint(typeof(IDatabaseService), binding2, "endpoint2");


            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            myHost.Description.Behaviors.Add(smb);

            try
            {
                Console.WriteLine("---> Endpointy:");
                Console.WriteLine("Service endpoint: {0}", endpoint1.Name);
                Console.WriteLine("Binding: {0}", endpoint1.Binding.ToString());
                Console.WriteLine("ListenUri: {0}", endpoint1.ListenUri.ToString());
                Console.WriteLine("Service endpoint: {0}", endpoint2.Name);
                Console.WriteLine("Binding: {0}", endpoint2.Binding.ToString());
                Console.WriteLine("ListenUri: {0}", endpoint2.ListenUri.ToString());

                myHost.Open();
                Console.WriteLine("Service is started and running.");
                Console.WriteLine("Press <ENTER> to STOP service...");
                Console.WriteLine();
                Console.ReadLine();
                myHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("Wystapil wyjatek: {0}", ce.Message);
                myHost.Abort();
            }
        }
    }
}
