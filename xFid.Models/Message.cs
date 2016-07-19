using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xFid.Models
{
    public class Message
    {

        public string OriginalMessage { get; set; }
        public string EncryptedMessage { get; set; }
        public int MessageNum { get; set; }
        public Cipher CipherUsed { get; set; }
        public int Iterations { get; set; }
        public DateTime MessageTime { get; set; }


        public Message()
        {
            MessageTime = DateTime.Now;
        }
    }
}
