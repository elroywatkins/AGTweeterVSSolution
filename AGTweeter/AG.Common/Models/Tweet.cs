using System;
using System.Collections.Generic;
using System.Text;

namespace AG.Common
{
    
        public class Tweet : IMessage, IMessageOrder
        {
            //public string UserName; // this property is used to map to text file string first
            public User Tweeter { get; set; }
            public string Message { get; set; }
            public int MessageOrder { get; set; }
        }
   
}
