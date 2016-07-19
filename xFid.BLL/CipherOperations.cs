using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using xFid.Data;
using xFid.Models;

namespace xFid.BLL
{
    public class CipherOperations
    {
        private Random _rng = new Random();
        private StandardKernel kernel = new StandardKernel();
        public Repository Repo;

        public CipherOperations()
        {
            kernel.Load(Assembly.GetExecutingAssembly());
            Repo = kernel.Get<Repository>();
        }

        public Cipher NewCipher(string name)
        {
            //var repo = RepositoryFactory.CreateAccountRepository();
            char[,,] grid = new char[5, 5, 5];
            CharBank charBank = new CharBank();

            for (int z = 0; z < 5; z++)
            {
                for (int y = 0; y < 5; y++)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        int c = _rng.Next(0, charBank.CharList.Count);
                        grid[x, y, z] = charBank.CharList[c];
                        charBank.CharList.RemoveAt(c);
                    }
                }
            }
            var cipher = new Cipher(name, grid);
            Repo.NewCipher(cipher);
            return cipher;
        }

        public Response GetCipher(string name)
        {
            var response = new Response {Cipher = Repo.GetCipher(name)};
            response.Success = response.Cipher != null;
            response.Prompt = response.Success
                ? new[] {"Cipher successfully retrieved."}
                : new[] {"Couldn't find that cipher. Please try again."};
            
            return response;
        }

        public void DeleteCipher(Cipher cipher)
        {
            Repo.DeleteCipher(cipher);
        }

        public List<Cipher> ViewCiphers()
        {
            return Repo.GetAllCiphers();
        }

        public List<Message> ViewMessages()
        {
            return Repo.GetAllMessages();
        }

        public Response GetMessage(string numS)
        {
            int num;
            if (!int.TryParse(numS, out num))
                return new Response {Prompt = new []{"Please enter a valid number."}, Success = false};
            num = int.Parse(numS);
            var response = new Response {Message = Repo.GetMessage(num)};
            response.Success = response.Message != null;
            response.Prompt = response.Success
                ? new[] {"Message retrieved!"}
                : new[] {"Couldn't find a message with that number."};
            return response;
        }

        public void NewMessage(Message msg)
        {
            msg.MessageNum = Repo.GetNextMsgNum();
            Repo.NewMessage(msg);
        }
    }
}
