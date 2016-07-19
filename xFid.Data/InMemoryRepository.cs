using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xFid.Models;

namespace xFid.Data
{
    public class InMemoryRepository : Repository
    {
        //static char[,,] DefaultCipher = new char[5,5,5];

        public InMemoryRepository()
        {
            char[,,] defaultGrid = new char[5,5,5];

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
        }
    }
}
