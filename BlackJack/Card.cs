using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Card
    {
        public string suit { set; get; }
        public int value { set; get; }
        public int card_number { set; get; }

        public Card()
        {
            value = -1;
            suit = "";
            card_number = -1;
        }
    } //END Card class
}
