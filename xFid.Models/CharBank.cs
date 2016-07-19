using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xFid.Models
{
    /* DEFAULT CIPHER LAYOUT
     *  
     *    LAYER 1        LAYER 2        LAYER 3        LAYER 4        LAYER 5
     *   1 2 3 4 5      1 2 3 4 5      1 2 3 4 5      1 2 3 4 5      1 2 3 4 5
     * 1  |!|"|#|$    1 9|:|;|<|=    1 R|S|T|U|V    1 k|l|m|n|o    1 Å|Æ|Ç|È|É 
     * 2 %|&|'|(|)    2 >|?|@|A|B    2 W|X|Y|Z|[    2 p|q|r|s|t    2 Ê|Ë|Ì|Í|Î 
     * 3 *|+|,|-|.    3 C|D|E|F|G    3 \|]|^|_|`    3 u|v|w|x|y    3 Ï|Ð|Ñ|Ò|Ó 
     * 4 /|0|1|2|3    4 H|I|J|K|L    4 a|b|c|d|e    4 z|{|||}|~    4 Ô|Õ|Ö|×|Ø 
     * 5 4|5|6|7|8    5 M|N|O|P|Q    5 f|g|h|i|j    5 À|Á|Â|Ã|Ä    5 Ù|Ú|Û|Ü|Ý 
     * 
     * SO: Hello
     *     23444
     *     15225
     *     44111
     *  J   n   Ë   ×     
     * 234 441 522 544 111
     */

    public class CharBank
    {
        public List<char> CharList { get; set; }

        // 32  -> 126 = 94 total items
        // 192 -> 223 = 31 total items
        // 125 total items 

        public CharBank()
        {
            CharList = new List<char>(125);
            for (int i = 32; i <= 126; i++)
                CharList.Add((char)i);
            for (int i = 192; i <= 223; i++)
                CharList.Add((char)i);
        }
    }
}
