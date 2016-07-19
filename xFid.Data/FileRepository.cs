using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xFid.Models;


namespace xFid.Data
{
    public class FileRepository : Repository
    {
        private string _cipherPath = @".\Ciphers\";
        private string _msgPath = @".\Messages\";
        private string _filext = ".txt";


        public FileRepository()
        {
            if (!Directory.Exists(_cipherPath))
                Directory.CreateDirectory(_cipherPath);

            if (!File.Exists($"{_cipherPath}default.txt"))
                CreateDefaultCipher();

            var cipherFiles = Directory.EnumerateFiles(_cipherPath);

            foreach (var file in cipherFiles)
            {
                LoadCipher(file);
            }

            if (!Directory.Exists(_msgPath))
                Directory.CreateDirectory(_msgPath);

            var msgFiles = Directory.EnumerateFiles(_msgPath);
            foreach (var file in msgFiles)
            {
                LoadMessage(file);
            }

        }

        private void CreateDefaultCipher()
        {
            char[,,] defaultGrid = new char[5, 5, 5];

            var defaultBank = new CharBank();
            int c = 0;

            for (int z = 0; z < 5; z++)
            {
                for (int y = 0; y < 5; y++)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        defaultGrid[x, y, z] = defaultBank.CharList[c];
                        c++;
                    }
                }
            }


            var defaultCipher = new Cipher("default", defaultGrid);
            CipherDb.Add(defaultCipher);
            WriteCipher(defaultCipher);
        }

        private void LoadCipher(string file)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                string name = sr.ReadLine();
                
                // Prevents app from reloading a cipher
                if (CipherDb.Any(x => x.Name == name)) return;

                {
                    string[] chars = sr.ReadLine()?.Split((char) 167);
                    string[] coords = sr.ReadLine()?.Split((char) 167);
                    char[,,] grid = new char[5, 5, 5];

                    for (int i = 0; i < 125; i++)
                    {
                        int z = Convert.ToInt32(coords[i].Substring(0, 1));
                        int x = Convert.ToInt32(coords[i].Substring(1, 1));
                        int y = Convert.ToInt32(coords[i].Substring(2, 1));
                        grid[x, y, z] = Convert.ToChar(chars[i]);
                    }

                    Cipher loaded = new Cipher(name, grid);
                    CipherDb.Add(loaded);
                }
            }
        }

        public override void NewCipher(Cipher cipher)
        {
            base.NewCipher(cipher);
            WriteCipher(cipher);
        }

        private void WriteCipher(Cipher cipher)
        {
            string filename = RemoveInvalidChars(cipher.Name);
            using (StreamWriter sw = new StreamWriter(_cipherPath + filename + _filext, false))
            {
                sw.WriteLine(cipher.Name);
                foreach (var x in cipher.Dict1.Keys)
                    sw.Write($"{x}\u00A7");
                sw.WriteLine();
                foreach (var x in cipher.Dict1.Values)
                    sw.Write($"{x}\u00A7");
            }
        }

        public override void NewMessage(Message message)
        {
            base.NewMessage(message);
            WriteMessage(message);
        }

        private void WriteMessage(Message message)
        {
            string filename = message.MessageTime.ToShortDateString() + message.MessageTime.ToFileTime();
            //filename = filename.Remove(filename.Length - 3, 3);
            filename = RemoveInvalidChars(filename);

            using (StreamWriter sw = new StreamWriter(_msgPath + filename + _filext, false))
            {
                sw.WriteLine(message.MessageNum);
                sw.WriteLine(message.MessageTime);
                sw.WriteLine(message.EncryptedMessage);
                sw.WriteLine(message.CipherUsed.Name);
                sw.WriteLine(message.Iterations);
            }
        }

        private void LoadMessage(string file)
        {
            using (StreamReader sr = new StreamReader(file))
            {

                Message loaded = new Message
                {
                    //MessageNum = GetNextMsgNum(),
                    MessageNum = int.Parse(sr.ReadLine()),
                    MessageTime = DateTime.Parse(sr.ReadLine()),
                    EncryptedMessage = sr.ReadLine(),
                    OriginalMessage = "Message not yet decrypted",
                    CipherUsed = GetCipher(sr.ReadLine()),
                    Iterations = int.Parse(sr.ReadLine())
                };
                // Prevents app from reloading a cipher
                if (MsgDb.Any(x => x.EncryptedMessage == loaded.EncryptedMessage)) return;
                MsgDb.Add(loaded);
            }
        }

        private static string RemoveInvalidChars(string input)
        {
            string output = input.Replace("/", "");
            // Backslash
            output = output.Replace(((char) 92).ToString(), "");
            output = output.Replace("?", "");
            output = output.Replace("%", "");
            output = output.Replace("*", "");
            output = output.Replace(":", "");
            output = output.Replace("|", "");
            output = output.Replace("\"", "");
            output = output.Replace("<", "");
            output = output.Replace(">", "");
            output = output.Replace(".", "");
            output = output.Replace(" ", "_");
            return output;
        }
    }
}
