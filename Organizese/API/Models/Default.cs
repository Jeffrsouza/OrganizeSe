using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Organizese.API.Models
{
    public class Default
    {
        public class Posts
        {
            public int id { get; set; }
            public string texto { get; set; }
            public string titulo { get; set; }
            public string data { get; set; }
            public string categoria { get; set; }
            public string nome { get; set; }
            public string arquivo { get; set; }
        }

        public class Msg
        {
            public int idProtocol { get; set; }
            public int rem { get; set; } //A=Admin || U=User
            public int dest { get; set; } //A=Admin || U=User
            public string texto { get; set; }
            public DateTime data { get; set; }
        }
    }
}