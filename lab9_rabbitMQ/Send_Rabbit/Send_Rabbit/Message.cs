using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Send_Rabbit
{
    public class Message
    {
        public TimeSpan Time {  get; set; }
        public string Body { get; set; }
        public int Value { get; set; }

        public Message(TimeSpan time, string body, int value) 
        {
            Time = time;
            Body = body;
            Value = value;
        }

        override public string ToString()
        {
            return "At: " + Time + ", " + Body + ", " + Value;
        }
    }
}
