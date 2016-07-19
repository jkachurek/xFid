using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xFid.Models
{
    public class Cipher
    {
        public string Name { get; set; }
        private char[,,] Grid = new char[5, 5, 5];
        //public List<Coordinate> CharList = new List<Coordinate>();

        public Dictionary<char, string> Dict1 = new Dictionary<char, string>();
        public Dictionary<string, char> Dict2 = new Dictionary<string, char>();

        public Cipher(string name, char[,,] grid)
        {
            Name = name;
            Grid = grid;

            for (int z = 0; z < 5; z++)
            {
                for (int y = 0; y < 5; y++)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        char newChar = Grid[x, y, z];
                        Dict1.Add(newChar, $"{z}{x}{y}");
                        Dict2.Add($"{z}{x}{y}", newChar);
                    }
                }
            }
        }




        //public Cipher(string name, char[,,] grid)
        //{
        //    Name = name;
        //    Grid = grid;

        //    for (int z = 0; z < 5; z++)
        //    {
        //        for (int y = 0; y < 5; y++)
        //        {
        //            for (int x = 0; x < 5; x++)
        //            {
        //                char newChar = Grid[x, y, z];

        //                //CharList.Add(new Coordinate
        //                //{
        //                //    Char = newChar,
        //                //    XCoord = x,
        //                //    YCoord = y,
        //                //    ZCoord = z
        //                //});
        //                Dict1.Add(newChar, $"{z}{x}{y}");
        //                Dict2.Add($"{z}{x}{y}", newChar);
        //            }
        //        }
        //    }
        //}
    }
}
