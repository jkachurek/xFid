using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xFid.BLL;
using xFid.Models;

namespace xFid.UI.Workflows
{
    public class DecryptionWorkflow : IWorkflow
    {
        public void Execute()
        {
            var ops = new CipherOperations();
            //var output = Decrypt(ops);
            var output = DecryptMenu(ops);
            if (output == null) return;
            ConsoleIO.Print("Your decrypted message is:");
            ConsoleIO.TextPrompt(output.OriginalMessage);
        }

        private string GetMessage()
        {
            return ConsoleIO.InputPrompt("Please enter your message to be decrypted.");
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

        private string[] _choicePrompt =
        {
            "Would you like to decrypt an existing message or a new message?",
            "",
            "Press enter to go to the message selection menu.",
            "Enter 'N' to enter the details of a new message."
        };

        private string[] _msgNumPrompt =
            {
                "",
                "Please enter the number of the message",
                "you would like to decrypt.",
                "Or press C to cancel and return to the main menu."
            };

        private Message DecryptMenu(CipherOperations ops)
        {
            string input = ConsoleIO.InputPrompt(_choicePrompt);
            if (input.ToUpper() == "N")
                return Decrypt(ops);

            var view = new MessagesWorkflow();
            var response = new Response {Success = false};
            
            while (!response.Success && input.ToUpper() != "C")
            {
                Console.Clear();
                view.ViewMessages(ops);
                input = ConsoleIO.InputPrompt(_msgNumPrompt);
                response = ops.GetMessage(input);
                if (!response.Success) ConsoleIO.TextPrompt("Message not found. Press enter to try again.");
            }
            if (input.ToUpper() == "C") return null;
            return Decrypt(ops.GetMessage(input).Message);
        }

        /// <summary>
        /// Decrypts a new message that is not in the database.
        /// </summary>
        /// <param name="ops">Current instance of CipherOperations</param>
        /// <returns>Decrypted message</returns>
        private Message Decrypt(CipherOperations ops)
        {
            var input = GetMessage();
            var msg = new Message
            {
                EncryptedMessage = input,
                OriginalMessage = input,
                CipherUsed = GetCipher(ops),
                Iterations = GetIterations()
            };
            return Decrypt(msg);
        }

        /// <summary>
        /// Overload: Decrypts an existing message
        /// </summary>
        /// <param name="msg">Existing message to decrypt</param>
        /// <returns>Decrypted message</returns>
        private Message Decrypt(Message msg)
        {
            var decrypt = new Encryption();
            msg.OriginalMessage = msg.EncryptedMessage;
            for (int i = 0; i < msg.Iterations; i++)
                msg.OriginalMessage = decrypt.Decrypt(msg.OriginalMessage, msg.CipherUsed);
            return msg;
        }
    }
}
