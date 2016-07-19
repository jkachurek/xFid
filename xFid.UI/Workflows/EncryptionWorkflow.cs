using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xFid.BLL;
using xFid.Models;

namespace xFid.UI.Workflows
{
    public class EncryptionWorkflow : IWorkflow
    {
        public void Execute()
        {
            var ops = new CipherOperations();
            var output = Encrypt(ops);
            ConsoleIO.Print("Your encrypted message is:");
            ConsoleIO.TextPrompt(output.EncryptedMessage);
        }

        private string GetMessage()
        {
            return ConsoleIO.InputPrompt("Please enter your message to be encrypted.");
        }

        private Cipher GetCipher(CipherOperations ops)
        {
            string name = ConsoleIO.InputPrompt("Please enter the name of the cipher you wish to use.");
            while (ops.GetCipher(name).Success == false)
                name = ConsoleIO.InputPrompt("Couldn't find that cipher.  Make sure you entered its name correctly.");
            return ops.GetCipher(name).Cipher;
        }

        private int GetIterations()
        {
            string input = ConsoleIO.InputPrompt("How many times would you like to run your message through the cipher?");
            int i;
            while (!int.TryParse(input, out i))
                input = ConsoleIO.InputPrompt("Please enter a valid number.");
            int iterations = int.Parse(input);
            return iterations;
        }

        private Message Encrypt(CipherOperations ops)
        {
            var encrypt = new Encryption();
            var input = GetMessage();
            var msg = new Message
            {
                OriginalMessage = input,
                EncryptedMessage = input,
                CipherUsed = GetCipher(ops),
                Iterations = GetIterations()
            };
            //TODO: The application is removing lowercase 'a' in here for some reason

            for (int i = 0; i < msg.Iterations; i++)
                msg.EncryptedMessage = encrypt.Encrypt(msg.EncryptedMessage, msg.CipherUsed);
            ops.NewMessage(msg);
            return msg;
        }
    }
}
