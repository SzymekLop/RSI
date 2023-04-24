using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfClient.ServiceReference1;

namespace WcfClient
{
    public class MyCalculatorClient
    {
        private readonly CalculatorClient client;

        public MyCalculatorClient(string binding = "WSHttpBinding_ICalculator") {
            client = new CalculatorClient(binding);
        }

        public void CloseConnection()
        {
            client.Close();
        }

        public void Addition()
        {
            int n1 = ReadNumber("Pierwsza liczba: ");
            int n2 = ReadNumber("Druga liczba: ");

            try
            {
                int result = client.iAdd(n1, n2);
                Console.WriteLine($"{n1} + {n2} = {result}");
            }
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Subtraction()
        {
            int n1 = ReadNumber("Pierwsza liczba: ");
            int n2 = ReadNumber("Druga Liczba: ");

            try
            {
                int result = client.iSub(n1, n2);
                Console.WriteLine($"{n1} - {n2} = {result}");
            }
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Multiplication()
        {
            int n1 = ReadNumber("Pierwsza liczba: ");
            int n2 = ReadNumber("Druga Liczba: ");

            try
            {
                int result = client.iMul(n1, n2);
                Console.WriteLine($"{n1} * {n2} = {result}");
            }
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Division()
        {
            int n1 = ReadNumber("Pierwsza liczba: ");
            int n2 = ReadNumber("Druga Liczba: ");

            try
            {
                int result = client.iDiv(n1, n2);
                Console.WriteLine($"{n1} / {n2} = {result}");
            }
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Modulo()
        {
            int n1 = ReadNumber("Pierwsza liczba: ");
            int n2 = ReadNumber("Druga Liczba: ");

            try
            {
                int result = client.iMod(n1, n2);
                Console.WriteLine($"{n1} % {n2} = {result}");
            }
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void HMultiply()
        {
            int n1 = ReadNumber("Pierwsza liczba: ");
            int n2 = ReadNumber("Druga Liczba: ");

            try
            {
                Console.WriteLine($"HMultiply asyncronous start");
                var result = await client.HMulAsync(n1, n2);
                Console.WriteLine($"HMultiply asyncronous: {n1} * {n2} = {result}");
            }
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void CountAndMaxPrimesInRangeAsync()
        {
            int l1 = ReadNumber("Pierwsza liczba: ");
            int l2 = ReadNumber("Druga Liczba: ");

            try
            {
                var result = await client.CountAndMaxPrimesInRangeAsync(l1, l2);
                Console.WriteLine($"Znaleziono liczb pierwszych: {result.Item1}");
                Console.WriteLine($"Majwiększa liczba pierwsza z przedziału: {result.Item2}");
            }
            catch (FaultException<ArgumentException> ex)
            {
                Console.WriteLine(ex.Detail.Message);
            }
        }

        private int ReadNumber(string Message)
        {
            Console.Write(Message);
            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine("Prosze podać liczbę");
                return ReadNumber(Message);
            }
            return number;
        }

    }
}
