using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Hand
    {
        public List<Card> cards { set; get; }
        public int number_of_cards { set; get; }
        public int score { set; get; }
        public string result { set; get; }
        public int size { set; get; }
        public bool isDone = false;

        // ******************************************************
        public Hand(int numcards) //constructor creates list and places empty cards in it
        {
            number_of_cards = numcards; //number of cards in a hand
            size = 0;

            cards = new List<Card>();     // list to hold cards
            Card emptycard = new Card(); // blank card 

            for (int i = 0; i < numcards; i++)
            {
                cards.Add(emptycard);       // adding blank cards to list
            }

        }
        // *******************************************************************************************
        public void add_card(Deck currentdeck, int number_cards_in_a_hand) // picks random card from deck and puts it in one of the blank card spots created 
        {
            bool added = false;
            int pickedcard = 0;

            if (currentdeck.cards.Count <= 2)
            {
                currentdeck.loaddeck();
                //clear_hand();
            }
            pickedcard = RandomNumber.NumberBetween(2, currentdeck.cards.Count - 1);
            Card currentcard = currentdeck.cards.ElementAt(pickedcard);
            Card tobereplaced = new Card();

            while (!added)
            {
                foreach (Card temp in cards)
                {
                    if (temp.suit == "") //place to put new card in
                        tobereplaced = temp;
                }
                if (tobereplaced != null)
                {
                    cards.Remove(tobereplaced);
                    cards.Add(currentcard);
                    size += 1;
                    added = true;
                    currentdeck.cards.Remove(currentcard);
                }

            }


        }
        // ***********************************************************************************************

        public void deal_cards(Deck currentdeck, int numcards)
        {
            numcards = cards.Count;
            for (int i = 0; i < numcards; i++)
            {
                add_card(currentdeck, numcards);
            }
        }

        // ***********************************************************************************************
        public void evaluate_hand()
        {
            score = 0;

            foreach (Card temp in cards)
            {
                if (temp.value < 10)
                    score = score + temp.value;
                else
                    score = score + 10; // assigning face cards a value of 10
            }

            // adjust for aces
            foreach (Card temp in cards)
            {
                if (temp.value == 1 && score + 10 <= 21)
                    score = score + 10; // We haven't gone bust yet so Ace is scored at 11
            }
            if (score > 21)
            {
                result = "Sorry you bust";
            }
            else
            {
                result = "You have " + score;
            }
        }
        public bool splittable()
        {
            int firstVal = 0;
            int secondVal = 0;

            firstVal = cards.ElementAt(0).value;
            secondVal = cards.ElementAt(1).value;
            Console.WriteLine(firstVal);
            Console.WriteLine(secondVal);
            if (firstVal == secondVal)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public void startSplit(Hand playerhand)
        {
            Card card = playerhand.cards.ElementAt(1);
            cards.Add(card);
        }


    } //End hand
}