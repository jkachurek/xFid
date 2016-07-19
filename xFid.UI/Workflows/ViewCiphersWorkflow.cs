using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xFid.BLL;
using xFid.Models;

namespace xFid.UI.Workflows
{
    public class ViewCiphersWorkflow : IWorkflow
    {
        public void Execute()
        {
            var ops = new CipherOperations();
            ViewCiphers(ops);
        }

        public void ViewCiphers(CipherOperations ops)
        {
            var cipherList = ops.ViewCiphers();
            ConsoleIO.Print("The ciphers currently in the database are:");
            foreach (var cipher in cipherList)
            {
                ConsoleIO.Print($"=> {cipher.Name}");
            }
            ConsoleIO.TextPrompt("\nPress enter to return to the main menu.");
        }
    }
}
