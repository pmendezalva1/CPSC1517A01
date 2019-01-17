using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Turn
    {
        //Turns
        public int Player1 { get; set; }
        public int Player2 { get; set; }
        //The object/class stands by itself! It'll hang onto the data value of 2 dice.

        public Turn()
        {

        }
        public Turn(int player1, int player2)
        {
            Player1 = player1;
            Player2 = player2;
        }
        //Don't put static unless you intend to share this info.
    }
}
