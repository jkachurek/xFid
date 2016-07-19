using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xFid.BLL;
using xFid.UI.Workflows;

namespace xFid.UI
{
    class Program
    {
        //private CipherOperations _ops = new CipherOperations();
        private static MainMenu menu = new MainMenu();
        static void Main(string[] args)
        {
            menu.DisplayMenu();
            
        }
    }
}
