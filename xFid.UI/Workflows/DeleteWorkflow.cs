using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xFid.BLL;
using xFid.Models;

namespace xFid.UI.Workflows
{
    public class DeleteWorkflow : IWorkflow
    {
        public void Execute()
        {
            var ops = new CipherOperations();
            Delete(ops);
        }

        private Cipher GetCipher(CipherOperations ops)
        {
            
            string name = ConsoleIO.InputPrompt("Please enter the name of the cipher you wish to delete.");
            var response = ops.GetCipher(name);
            while (response.Success == false)
            {
                name = ConsoleIO.InputPrompt(response.Prompt);
                response = ops.GetCipher(name);
            }
            return response.Cipher;
        }

        private void Delete(CipherOperations ops)
        {
            var cipher = GetCipher(ops);
            ops.DeleteCipher(cipher);
        }
    }
}
