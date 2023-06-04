using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace MyData
{
    public class MyData
    {
        public static void info()
        {
            Console.WriteLine("Aleksandra Wolska, 251810");
            Console.WriteLine("Szymon Łopuszyński, 260454");
            DateTime date = DateTime.Now;
            Console.WriteLine(date.ToString("M") + ", " + date.ToString("T"));
            Console.WriteLine(Environment.Version);
            Console.WriteLine(Environment.UserName);
            Console.WriteLine(Environment.OSVersion.ToString());
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    if (ni.Name == "Wi-Fi")
                    {
                        foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                Console.WriteLine(ip.Address.ToString());
                            }
                        }
                    }
                }
            }
        }

    }
}

