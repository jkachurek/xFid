using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using xFid.BLL;
using xFid.Models;

namespace xFid.UI.Workflows
{
    public class MessagesWorkflow : IWorkflow
    {
        public void Execute()
        {
            var ops = new CipherOperations();
            if (ViewMessages(ops))
                ConsoleIO.TextPrompt("\nPress enter to continue.");
        }

        public bool ViewMessages(CipherOperations ops)
        {
            var msgList = ops.ViewMessages();

            if (msgList.Count == 0)
            {
                ConsoleIO.TextPrompt(new[]
                {
                    "There are currently no saved messages.",
                    "Press enter to return to the main menu."
                });
                return false;
            }

            ConsoleIO.Print(new [] {"Here are the encrypted messages in the database:"});
            foreach (var msg in msgList)
            {
                string[] msgPrint = 
                {
                    $"#{msg.MessageNum} | {msg.MessageTime.ToShortDateString()} | {msg.MessageTime.ToShortTimeString()}",
                    "\tEncrypted Message:",
                    $"\t{msg.EncryptedMessage}"
                };
                ConsoleIO.Print(msgPrint);
            }
            return true;
        }
    }
}
