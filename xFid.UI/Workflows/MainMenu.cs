using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xFid.Models;

namespace xFid.UI.Workflows
{
    public class MainMenu
    {
        private static readonly string[] MenuOptions =
        {
            "",
            " xFID CIPHER MAIN MENU",
            " 1.) Create Cipher",
            " 2.) View Cipher List",
            " 3.) Delete Cipher",
            " 4.) Encrypt Message",
            " 5.) Decrypt Message",
            " 6.) View Messages",
            " 7.) Quit"
        };

        public void DisplayMenu()
        {
            Menu(ConsoleIO.InputPrompt("Welcome to the xFid Encryption Application.\n" +
                                       "Press enter to see the main menu."));
        }

        private void Menu(string input)
        {


            while (input?.ToUpper() != "Q" && input != "7")
            {
                IWorkflow workflow = null;
                Console.Clear();
                ConsoleIO.Print(MenuOptions);
                input = ConsoleIO.InputPrompt("\n\t  Please enter the number of the\n" +
                                              "\toperation you would like to perform\n");
                switch (input)
                {
                    case "1": //Create
                        workflow = new NewCipherWorkflow();
                        goto default;
                    case "2": //Cipher List
                        workflow = new ViewCiphersWorkflow();
                        goto default;
                    case "3": //Delete
                        workflow = new DeleteWorkflow();
                        goto default;
                    case "4": //Encrypt
                        workflow = new EncryptionWorkflow();
                        goto default;
                    case "5": //Decrypt
                        workflow = new DecryptionWorkflow();
                        goto default;
                    case "6": //Message List
                        workflow = new MessagesWorkflow();
                        goto default;
                    default:
                        Console.Clear();
                        workflow?.Execute();
                        break;
                }
            }
        }
    }
}
