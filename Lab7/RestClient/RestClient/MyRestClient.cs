using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RestClient
{
    public class MyRestClient
    {
        private static readonly string ADDRESS = "http://192.168.43.18:10000/Service1.svc/";

        public void processRequest(string endpoint, string method, string type)
        {
            try
            {
                HttpWebRequest req = WebRequest.Create(ADDRESS + endpoint) as HttpWebRequest;
                req.KeepAlive = false;
                req.Method = method;
                req.ContentType = type;
                
                string payload = "";
                if(method == "POST" || method == "PUT") {
                    if (type == "application/json")
                    {
                        payload = getJsonPerson();
                    }
                    else
                    {
                        payload = getXmlPerson();
                    }
                }

                switch(method)
                {

                    case "GET":
                        break;
                    case "POST":
                        byte[] buforPost = Encoding.UTF8.GetBytes(payload);
                        req.ContentLength = buforPost.Length;
                        Stream postData = req.GetRequestStream();
                        postData.Write(buforPost, 0, buforPost.Length);
                        postData.Close();
                        break;
                    case "PUT":
                        byte[] buforPut = Encoding.UTF8.GetBytes(payload);
                        req.ContentLength = buforPut.Length;
                        Stream putData = req.GetRequestStream();
                        putData.Write(buforPut, 0, buforPut.Length);
                        putData.Close();
                        break;
                    case "DELETE":
                        break;
                }

                HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
                Encoding enc = Encoding.GetEncoding(1252);
                StreamReader responseStream = new StreamReader(resp.GetResponseStream(), enc);
                string responseString = responseStream.ReadToEnd();
                responseStream.Close();
                resp.Close();
                Console.WriteLine(responseString);
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public static String getXmlPerson()
        {
            StringBuilder sb = new StringBuilder("<Person xmlns=\"http://schemas.datacontract.org/2004/07/MyWebService\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\">");
            sb.Append("<Id>");
            sb.Append(0);
            sb.Append("</Id>");
            sb.Append("<Name>");
            Console.Write("Podaj imie i nazwisko osoby: ");
            sb.Append(Console.ReadLine());
            sb.Append("</Name>");
            sb.Append("<Age>");
            Console.Write("Podaj wiek osoby: ");
            sb.Append(int.Parse(Console.ReadLine()));
            sb.Append("</Age>");
            sb.Append("<Email>");
            Console.Write("Podaj email: ");
            sb.Append(Console.ReadLine());
            sb.Append("</Email>");
            sb.Append("</Person>");

            Console.WriteLine(sb.ToString());

            return sb.ToString();
        }

        public static String getJsonPerson()
        {
            StringBuilder sb = new StringBuilder("{");
            sb.Append("\"Id\":");
            sb.Append(0);
            sb.Append(",");
            sb.Append("\"Name\":\"");
            Console.Write("Podaj imie i nazwisko osoby: ");
            sb.Append(Console.ReadLine());
            sb.Append("\",\"Age\":");
            Console.Write("Podaj wiek osoby: ");
            sb.Append(int.Parse(Console.ReadLine()));
            sb.Append(",\"Email\":\"");
            Console.Write("Podaj email: ");
            sb.Append(Console.ReadLine());
            sb.Append("\"}");

            Console.WriteLine(sb.ToString());

            return sb.ToString();
        }

    }
}
