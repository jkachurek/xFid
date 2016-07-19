using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xFid.Models;

namespace xFid.Data
{
    public abstract class Repository
    {
        protected static List<Cipher> CipherDb { get; }
        protected static List<Message> MsgDb { get; }

        /// <summary>
        /// Instantiates new repository
        /// </summary>
        static Repository()
        {
            CipherDb = new List<Cipher>();
            MsgDb = new List<Message>();
        }

        /// <summary>
        /// Adds new cipher to cipher database
        /// </summary>
        /// <param name="cipher"></param>
        public virtual void NewCipher(Cipher cipher)
        {
            CipherDb.Add(cipher);
        }

        /// <summary>
        /// Retrieves cipher from cipher database
        /// </summary>
        /// <param name="cipher">Cipher to be retrieved</param>
        /// <returns>Cipher to be retrieved, null if not found</returns>
        public Cipher GetCipher(string name)
        {
            return CipherDb.FirstOrDefault(x => x.Name == name);
        }

        /// <summary>
        /// Retrieves list of all ciphers
        /// </summary>
        /// <returns></returns>
        public List<Cipher> GetAllCiphers()
        {
            return CipherDb;
        }

        /// <summary>
        /// Deletes cipher from database
        /// </summary>
        /// <param name="cipher">Cipher to be deleted</param>
        public virtual void DeleteCipher(Cipher cipher)
        {
            CipherDb.Remove(cipher);
        }

        public virtual void NewMessage(Message message)
        {
            MsgDb.Add(message);
        }

        public int GetNextMsgNum()
        {
            if (MsgDb.Count == 0)
                return 1;
            return MsgDb.Max(x => x.MessageNum) + 1;
        }

        public List<Message> GetAllMessages()
        {
            return MsgDb;
        }

        public Message GetMessage(int num)
        {
            return MsgDb.FirstOrDefault(x => x.MessageNum == num);
        }
    }
}
