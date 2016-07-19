using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xFid.Models
{
    public class Response
    {
        public string[] Prompt { get; set; }
        public Cipher Cipher { get; set; }
        public Message Message { get; set; }
        public bool Success { get; set; }
    }
}
