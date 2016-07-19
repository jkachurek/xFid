using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xFid.UI
{
    public static class ConsoleIO
    {
        public static void Print(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Overload: Prints a string array line by line
        /// </summary>
        /// <param name="messageBlock">String array to be printed</param>
        public static void Print(string[] messageBlock)
        {
            foreach (var line in messageBlock)
                Print(line);
        }

        public static void TextPrompt(string message)
        {
            Print(message);
            Console.ReadLine();
        }

        public static void TextPrompt(string[] message)
        {
            Print(message);
            Console.ReadLine();
        }

        public static string InputPrompt(string message)
        {
            Print(message);
            return InputPrompt();
        }
        public static string InputPrompt(string[] message)
        {
            Print(message);
            return InputPrompt();
        }
        public static string InputPrompt()
        {
            string input = Console.ReadLine();
            while (input == null)
            {
                Print("Please enter a response.");
                input = Console.ReadLine();
            }
            return input;
        }

        public static void EnterAndClear()
        {
            Print("Press enter to continue.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
