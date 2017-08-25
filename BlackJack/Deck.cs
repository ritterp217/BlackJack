using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Deck
    {
        public List<Card> cards { set; get; } //deck is list of cards

        // ******************************************************

        public Deck()   //create a deck
        {
            cards = new List<Card>();
            loaddeck();

        }
        // *******************************************************************
        public void loaddeck()
        {
            cards.Clear();
            int cardnum = 1;
            for (int i = 1; i < 5; i++) // 4 suits
            {
                for (int j = 1; j < 14; j++)  // 13 cards each (total 52 cards)
                {
                    Card currentcard = new Card(); //create a new card

                    //assign suit
                    currentcard.card_number = cardnum;
                    if (i == 1)
                        currentcard.suit = "spades";
                    if (i == 2)
                        currentcard.suit = "clubs";
                    if (i == 3)
                        currentcard.suit = "hearts";
                    if (i == 4)
                        currentcard.suit = "diamonds";
                    // assign value
                    currentcard.value = j;
                    // put in deck 
                    cards.Add(currentcard); // adding card to deck
                    //next card
                    cardnum++;
                }
            }
        }
        // ********************************************************************
        public Card FindCard(int cardnum)
        {
            foreach (Card a_card in cards)
            {
                if (a_card.card_number == cardnum)
                {
                    return a_card;
                }
            }
            return null;
        }
        // *************************************************************************

    } // end deck class
}
