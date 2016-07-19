using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xFid.Models;

namespace xFid.BLL
{
    public class Encryption
    {
        public string Encrypt(string message, Cipher cipher)
        {
            string sequence1 = "";
            string sequence2 = "";
            string sequence3 = "";

            foreach (char c in message)
            {
                if (cipher.Dict1.ContainsKey(c))
                {
                    sequence1 += cipher.Dict1[c].Substring(0, 1);
                    sequence2 += cipher.Dict1[c].Substring(1, 1);
                    sequence3 += cipher.Dict1[c].Substring(2, 1);
                }
            }
            string digitSequence = sequence1 + sequence2 + sequence3;
            string output = "";
            //TODO: The application is removing lowercase 'a' in here for some reason
            for (int i = 0; i < digitSequence.Length; i += 3)
            {
                output += cipher.Dict2[digitSequence.Substring(i, 3)];
            }
            return output;
        }

        public string Decrypt(string message, Cipher cipher)
        {
            string numSequence = "";

            foreach (char c in message)
            {
                if (cipher.Dict1.ContainsKey(c))
                    numSequence += cipher.Dict1[c];
            }

            string sequence1 = numSequence.Substring(0, message.Length);
            string sequence2 = numSequence.Substring((message.Length), message.Length);
            string sequence3 = numSequence.Substring((message.Length * 2), message.Length);

            string output = "";

            for (int i = 0; i < message.Length; i++)
                output += cipher.Dict2[$"{sequence1[i]}{sequence2[i]}{sequence3[i]}"];

            return output;
        }

        //public string Encrypt(string message, Cipher cipher)
        //{
        //    string sequence1 = "";
        //    string sequence2 = "";
        //    string sequence3 = "";

        //    foreach (char c in message)
        //    {
        //        //var cipherChar = cipher.CharList.FirstOrDefault(x => x.Char == Convert.ToChar(c));
        //        //sequence1 += cipherChar?.ZCoord;
        //        //sequence2 += cipherChar?.XCoord;
        //        //sequence3 += cipherChar?.YCoord;

        //        sequence1 += cipher.Dict1[c].Substring(0, 1);
        //        sequence2 += cipher.Dict1[c].Substring(1, 1);
        //        sequence3 += cipher.Dict1[c].Substring(2, 1);
        //    }

        //    string digitSequence = sequence1 + sequence2 + sequence3;
        //    string output = "";
        //    for (int i = 0; i < digitSequence.Length; i += 3)
        //    {
        //        //var newCoords = digitSequence.Substring(i, 3);
        //        //var newChar = cipher.CharList
        //        //    .Where(z => z.ZCoord == newCoords[0])
        //        //    .Where(x => x.XCoord == newCoords[1])
        //        //    .FirstOrDefault(y => y.YCoord == newCoords[2])?.Char;
        //        //output += newChar;

        //        output += cipher.Dict2[digitSequence.Substring(i, 3)];
        //    }
        //    return output;
        //}

        //public string Decrypt(string message, Cipher cipher)
        //{
        //    string numSequence = "";

        //    foreach (char c in message)
        //    {
        //        var coord = cipher.CharList.FirstOrDefault(x => x.Char == c);
        //        numSequence += coord?.ZCoord + coord?.XCoord + coord?.YCoord;
        //    }

        //    string sequence1 = numSequence.Substring(0, message.Length);
        //    string sequence2 = numSequence.Substring((message.Length), message.Length);
        //    string sequence3 = numSequence.Substring((message.Length * 2), message.Length);

        //    string output = "";

        //    for (int i = 0; i < message.Length; i++)
        //        output += cipher.CharList
        //            .Where(z => z.ZCoord == sequence1[i])
        //            .Where(x => x.XCoord == sequence2[i])
        //            .FirstOrDefault(y => y.YCoord == sequence3[i]);

        //    return output;
        //}
    }
}
