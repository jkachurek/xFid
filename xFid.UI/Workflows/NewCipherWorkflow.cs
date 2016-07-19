using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xFid.BLL;
using xFid.Models;

namespace xFid.UI.Workflows
{
    public class NewCipherWorkflow : IWorkflow
    {
        public void Execute()
        {
            NewCipher();
        }

        public void NewCipher()
        {
            var ops = new CipherOperations();
            string name = ConsoleIO.InputPrompt("Please enter a name for your new cipher.");
            ops.NewCipher(name);
            ConsoleIO.TextPrompt("Cipher created!");
        }
    }
}
