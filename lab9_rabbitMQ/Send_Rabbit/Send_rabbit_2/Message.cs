﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Send_Rabbit_2
{
    public class Message
    {
        public DateTime Time {  get; set; }
        public string Body { get; set; }
        public int Value { get; set; }

        public Message(DateTime time, string body, int value) 
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
