using Blackjack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class cardForm : Form
    {
        public Deck currentdeck { get; set; }
        public Hand playerhand { get; set; }
        public Hand playerhand2 { get; set; }
        public Hand dealer_hand { get; set; }
        public int numcards { get; set; }
        public int playerScore = 0;
        public int dealerScore = 0;
        public int minBet = 50;
        public int Bet = 50;
        public int Money = 2500;
        public bool isSplit = false;
        public bool winner = false;


        // System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        public cardForm()
        {
           
            InitializeComponent();
            // player.SoundLocation = "Terra-incognita-instrumental-background-music.wav";
            // player.PlayLooping();
            MainTextBox.Text = "Welcome to the best Blackjack game" + Environment.NewLine;
            MainTextBox.Text += "Press Deal to begin or change your bet" + Environment.NewLine;
            richTextBox2.Visible = false;
            richTextBox3.Visible = false;
            richTextBox5.Visible = true;
            dealButton.Visible = true; // deal button is visible
            stayButton.Visible = false; // stick button hidden
            pictureBox1.Visible = false; //showing spot for first card
            pictureBox2.Visible = false; //showing second card
            pictureBox3.Visible = false; //hiding the rest
            pictureBox4.Visible = false; //hiding the rest
            pictureBox5.Visible = false; //hiding the rest
            pictureBox6.Visible = false; //hiding the rest
            pictureBox7.Visible = false; //hiding the rest
            pictureBox8.Visible = false; //hiding the rest
            pictureBox9.Visible = false; //hiding the rest
            pictureBox10.Visible = false; //hiding the rest
            pictureBox11.Visible = false; //hiding the rest
            pictureBox12.Visible = false; //hiding the rest
            pictureBox13.Visible = false; //hiding the rest
            pictureBox14.Visible = false; //hiding the rest
            pictureBox15.Visible = false; //hiding the rest
            pictureBox16.Visible = false; //hiding the rest
            pictureBox18.Visible = false;

            splitButton.Visible = false;
            textBox6.Visible = false;
            textBox3.Text = "Type your bet below before dealing the cards. The minimum bet is:  " + minBet + "  dollars";
            textBox4.Text = "Current Money: " + Money + Environment.NewLine;
            textBox4.Text += "Current Bet: " + Bet;
            richTextBox4.Text = playerScore.ToString();
            richTextBox5.Text = dealerScore.ToString();
        }

        private void cardForm_Load(object sender, EventArgs e)
        {
            this.SetStyle(System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = System.Drawing.Color.Transparent;

        }
        private void end_game(Hand player_hand, Hand dealer_hand)
        {
            player_hand.isDone = true;
            dealer_hand.evaluate_hand();
            while (dealer_hand.score < 15) //dealer sticks on 15 or higher
            {
                dealer_hand.add_card(currentdeck, 1);
                dealer_hand.evaluate_hand();
            }
            MainTextBox.Text += "Dealer has " + dealer_hand.score + Environment.NewLine;
            if (player_hand.score > 21)
            {
                MainTextBox.Text = "You bust better luck next time." + Environment.NewLine;
                dealerScore += 1;
                Money = Money - Bet;
            }
            else if ((player_hand.score == dealer_hand.score) && (player_hand.score <= 21))
            {
                MainTextBox.Text = "Dealer has " + dealer_hand.score + ", Tie so that's a push no one loses." + Environment.NewLine;

            }
            else if (dealer_hand.score == 21)
            {
                MainTextBox.Text = "Dealer has " + dealer_hand.score + ", you have " + player_hand.score+" Dealer wins." + Environment.NewLine;
                dealerScore += 1;
                Money = Money - Bet;
            }
            else if (dealer_hand.score > 21)
            {
                MainTextBox.Text = "Dealer Busts " + ", congratulations you win ." + Environment.NewLine;
                playerScore += 1;
                Money = Money + Bet;
                winner = true;
              
            }
            else
            {
                if (player_hand.score > 21)
                {
                    MainTextBox.Text = "You bust better luck next time." + Environment.NewLine;
                    dealerScore += 1;
                    Money = Money - Bet;
                }
                else if ((player_hand.score == 21) && (player_hand.size == 2))
                {
                    MainTextBox.Text = "Congratulations BLACKJACK, you win ." + Environment.NewLine;
                    playerScore += 1;
                    Money = Money + Bet;
                    winner = true;

                }
                else if ((player_hand.score > dealer_hand.score) && (player_hand.score <= 21))
                {
                    MainTextBox.Text = "Dealer has " + dealer_hand.score + ", you have "+ player_hand.score+" congratulations you win ." + Environment.NewLine;
                    playerScore += 1;
                    Money = Money + Bet;
                    winner = true;

                }
                else if ((player_hand.score == dealer_hand.score) && (player_hand.score <= 21))
                {
                    MainTextBox.Text = "Dealer has " + dealer_hand.score + ", Tie so that's a push no one loses." + Environment.NewLine;
                    
                }
                else if (dealer_hand.score > 21)
                {
                    MainTextBox.Text = "Dealer busts, you win ." + Environment.NewLine;
                    playerScore += 1;
                    Money = Money + Bet;
                    winner = true;

                }
               
                else if ((dealer_hand.score <= 21) && (player_hand.score < dealer_hand.score))
                {
                    MainTextBox.Text = "Dealer has " + dealer_hand.score + ", better luck next time." + Environment.NewLine;
                    dealerScore += 1;
                    Money = Money - Bet;
                }
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
                Bet = Int32.Parse(textBox5.Text);
            if (Bet <= Money && Bet >= 50)
            {
                // player.SoundLocation = "shuffling-cards-1.wav";
                //player.PlaySync();
                isSplit = false;
                numcards = 2; //deal 2  initially
                currentdeck = new Deck(); //create new deck of cards
                playerhand = new Hand(numcards); //create hand for player
                dealer_hand = new Hand(numcards); // create hand for dealer

                stayButton.Visible = false; // stick button hidden
                pictureBox1.Visible = false; //showing spot for first card
                pictureBox2.Visible = false; //showing second card
                pictureBox3.Visible = false; //hiding the rest
                pictureBox4.Visible = false; //hiding the rest
                pictureBox5.Visible = false; //hiding the rest
                pictureBox6.Visible = false; //hiding the rest
                pictureBox7.Visible = false; //hiding the rest
                pictureBox8.Visible = false; //hiding the rest
                pictureBox9.Visible = false; //hiding the rest
                pictureBox10.Visible = false; //hiding the rest
                pictureBox11.Visible = false; //hiding the rest
                pictureBox12.Visible = false; //hiding the rest
                pictureBox13.Visible = false; //hiding the rest
                pictureBox14.Visible = false; //hiding the rest
                pictureBox15.Visible = false; //hiding the rest
                pictureBox16.Visible = false; //hiding the rest
                pictureBox18.Visible = false;
                pictureBox18b.Visible = false;
                pictureBox19.Visible = false;
                pictureBox20.Visible = false;
                pictureBox17b.Visible = false;
               
                splitButton.Visible = false;
                textBox6.Visible = false;

                playerhand.deal_cards(currentdeck, numcards);
                dealer_hand.deal_cards(currentdeck, numcards); //deal cards to dealer
                display_playerhand(playerhand);
                display_dealercards(dealer_hand);
                playerhand.evaluate_hand();
                var splittable = playerhand.splittable();
                //var splittable = true;

                Console.WriteLine(splittable);

                MainTextBox.Text = playerhand.result + Environment.NewLine;
                MainTextBox.Text += "Would you like to hit or stay?" + Environment.NewLine;
                richTextBox2.Visible = true;
                richTextBox3.Visible = true;
                richTextBox4.Visible = true;
                richTextBox5.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = false;
                textBox4.Text = "Current Money: " + Money + Environment.NewLine;
                textBox4.Text += "Current Bet: " + Bet;


                dealButton.Visible = false;
                pictureBox18.Visible = true;
                stayButton.Visible = true;
                if (splittable == true)
                    splitButton.Visible = true;
               // player.SoundLocation = "Terra-incognita-instrumental-background-music.wav";
                //player.PlayLooping();
            }
            else
            {
                MainTextBox.Text = "That is an invalid bet, correct it and try again" + Environment.NewLine;
                MainTextBox.Text += "Would you like to hit or stay?";
            }
           

        }

        private void display_playerhand(Hand playerhand)
        {
            int count = 0;
            string currentcard_picture = "";
            DateTime t = DateTime.Now;

            if (playerhand.cards != null && playerhand != null)
                foreach (Card currentcard in playerhand.cards)
                {
                    if (currentcard != null && currentcard.suit != "")
                    {
                        if (currentcard.value < 10)
                            currentcard_picture = "_"+currentcard.value.ToString() + "_of_" + currentcard.suit;
                        if (currentcard.value == 10)
                            currentcard_picture = "_" + currentcard.value.ToString() + "_of_" + currentcard.suit;
                        if (currentcard.value == 11)
                            currentcard_picture = "jack" + "_of_" + currentcard.suit;
                        if (currentcard.value == 12)
                            currentcard_picture = "queen" + "_of_" + currentcard.suit;
                        if (currentcard.value >= 13)
                            currentcard_picture = "king" + "_of_" + currentcard.suit;
                    }
                    else
                        currentcard_picture = "space";

                    if (count == 0)
                    {

                        pictureBox1.Visible = true; //showing first card
                        pictureBox1.BringToFront();
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox1.Image = myImage;
                        pictureBox1.BringToFront();
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 1)
                    {
                        pictureBox2.Visible = true; //showing second card
                        pictureBox2.BringToFront();
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox2.Image = myImage;
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 2)
                    {
                        pictureBox3.Visible = true;
                        pictureBox3.BringToFront();
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox3.BringToFront();
                        pictureBox3.Image = myImage;
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 3)
                    {
                        pictureBox4.Visible = true;
                        pictureBox4.BringToFront();
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox4.BringToFront();
                        pictureBox4.Image = myImage;
                        pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 4)
                    {
                        pictureBox5.Visible = true;
                        pictureBox5.BringToFront();
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        pictureBox3.BringToFront();
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox5.BringToFront();
                        pictureBox5.Image = myImage;
                        pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 5)
                    {
                        pictureBox6.Visible = true;
                        pictureBox6.BringToFront();
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox6.BringToFront();
                        pictureBox6.Image = myImage;
                        pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 6)
                    {
                        pictureBox7.Visible = true;
                        pictureBox7.BringToFront();
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox7.BringToFront();
                        pictureBox7.Image = myImage;
                        pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 7)
                    {
                        pictureBox8.Visible = true;
                        pictureBox8.BringToFront();
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox8.BringToFront();
                        pictureBox8.Image = myImage;
                        pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 8)
                    {
                        pictureBox9.Visible = true;
                        pictureBox9.BringToFront();
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox9.BringToFront();
                        pictureBox9.Image = myImage;
                        pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 9)
                    {
                        pictureBox10.Visible = true;
                        pictureBox10.BringToFront();
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox10.BringToFront();
                        pictureBox10.Image = myImage;
                        pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 10)
                    {
                        pictureBox11.Visible = true;
                        pictureBox11.BringToFront();
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox11.BringToFront();
                        pictureBox11.Image = myImage;
                        pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 11)
                    {
                        pictureBox12.Visible = true;
                        pictureBox12.BringToFront();
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox12.BringToFront();
                        pictureBox12.Image = myImage;
                        pictureBox12.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    count++;
                }

        }
        public void display_dealercards(Hand dealerhand)
        {
            string currentcard_picture = "";
            if (dealerhand.cards != null && dealerhand != null)
                foreach (Card currentcard in dealerhand.cards)
                {
                    if (currentcard != null && currentcard.suit != "")
                    {
                        if (currentcard.value < 10)
                            currentcard_picture = "_" + currentcard.value.ToString() + "_of_" + currentcard.suit;
                        if (currentcard.value == 10)
                            currentcard_picture = "_" + currentcard.value.ToString() + "_of_" + currentcard.suit;
                        if (currentcard.value == 11)
                            currentcard_picture = "jack" + "_of_" + currentcard.suit;
                        if (currentcard.value == 12)
                            currentcard_picture = "queen" + "_of_" + currentcard.suit;
                        if (currentcard.value >= 13)
                            currentcard_picture = "king" + "_of_" + currentcard.suit;
                    }
                    else
                        currentcard_picture = "space";
                }
            pictureBox13.Visible = true;
            System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
            Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
            pictureBox13.BringToFront();
            pictureBox13.Image = myImage;
            pictureBox13.SizeMode = PictureBoxSizeMode.StretchImage;

            string currentcard_picture2 = "";
            currentcard_picture2 = "back_image";
            pictureBox14.Visible = true;
            Bitmap myImage2 = (Bitmap)rm.GetObject(currentcard_picture2);
            pictureBox14.BringToFront();
            pictureBox14.Image = myImage2;
            pictureBox14.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void display_dealerhand(Hand playerhand)
        {
            int count = 0;
            string currentcard_picture = "";
            DateTime t = DateTime.Now;

            if (playerhand.cards != null && playerhand != null)
                foreach (Card currentcard in playerhand.cards)
                {
                    if (currentcard != null && currentcard.suit != "")
                    {
                        if (currentcard.value < 10)
                            currentcard_picture = "_" + currentcard.value.ToString() + "_of_" + currentcard.suit;
                        if (currentcard.value == 10)
                            currentcard_picture = "_" + currentcard.value.ToString() + "_of_" + currentcard.suit;
                        if (currentcard.value == 11)
                            currentcard_picture = "jack" + "_of_" + currentcard.suit;
                        if (currentcard.value == 12)
                            currentcard_picture = "queen" + "_of_" + currentcard.suit;
                        if (currentcard.value >= 13)
                            currentcard_picture = "king" + "_of_" + currentcard.suit;
                    }
                    else
                        currentcard_picture = "space";

                    if (count == 0)
                    {

                        pictureBox13.Visible = true; //showing first card
                        pictureBox13.BringToFront();
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox13.Image = myImage;
                        pictureBox13.BringToFront();
                        pictureBox13.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 1)
                    {
                        pictureBox14.Visible = true; //showing second card
                        pictureBox14.BringToFront();
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox14.Image = myImage;
                        pictureBox14.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 2)
                    {
                        pictureBox15.Visible = true;
                        pictureBox15.BringToFront();
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox15.BringToFront();
                        pictureBox15.Image = myImage;
                        pictureBox15.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 3)
                    {
                        pictureBox16.Visible = true;
                        pictureBox16.BringToFront();
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox16.BringToFront();
                        pictureBox16.Image = myImage;
                        pictureBox16.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    count++;
                }

        }



        private void pictureBox18_Click(object sender, EventArgs e)
        {

            if (isSplit == false)
            {

                playerhand.add_card(currentdeck, 1);
                display_playerhand(playerhand);
                playerhand.evaluate_hand();
                if (playerhand.size >= 3)
                {
                    splitButton.Visible = false;
                }
                MainTextBox.Text = playerhand.result + Environment.NewLine;
                MainTextBox.Text += "Would you like to hit or stay?";

                dealButton.Visible = false;
                pictureBox18.Visible = true;
                stayButton.Visible = true;
                textBox4.Text = "Current Money: " + Money + Environment.NewLine;
                textBox4.Text += "Current Bet: " + Bet;
                if (playerhand.score >= 21)
                {
                    end_game(playerhand, dealer_hand);
                    textBox4.Text = "Current Money: " + Money + Environment.NewLine;
                    textBox4.Text += "Current Bet: " + Bet;
                    MainTextBox.Text += "Press deal cards to play again.";
                    display_dealerhand(dealer_hand);
                    richTextBox4.Text = playerScore.ToString();
                    richTextBox5.Text = dealerScore.ToString();
                    dealButton.Visible = true; // deal button is visible
                    pictureBox18.Visible = false; // hit button hidden
                    stayButton.Visible = false; // stick button hidden
                    textBox5.Visible = true;
                   

                }
            }
            else if (isSplit == true && playerhand.isDone == false)
            {
                playerhand.add_card(currentdeck, 1);
                display_playerhand(playerhand);
                playerhand.evaluate_hand();

                MainTextBox.Text = playerhand.result + Environment.NewLine;
                MainTextBox.Text += "Would you like to hit or stay?";

                dealButton.Visible = false;
                pictureBox18.Visible = true;
                stayButton.Visible = true;
                textBox4.Text = "Current Money: " + Money + Environment.NewLine;
                textBox4.Text += "Current Bet: " + Bet;
                if (playerhand.score >= 21)
                {
                    playerhand.isDone = true;
                    textBox4.Text = "Current Money: " + Money + Environment.NewLine;
                    textBox4.Text += "Current Bet: " + Bet;
                    MainTextBox.Text += "You busted, What would you like to do for hand 2";
                    
                    richTextBox4.Text = playerScore.ToString();
                    richTextBox5.Text = dealerScore.ToString();
                }
                
            }
            else if (isSplit == true && playerhand.isDone == true)
            {
                playerhand2.add_card(currentdeck, 1);
                display_playerhand_number2(playerhand2);
                playerhand2.evaluate_hand();

                MainTextBox.Text = playerhand2.result + Environment.NewLine;
                MainTextBox.Text += "Would you like to hit or stay?";

                dealButton.Visible = false;
                pictureBox18.Visible = true;
                stayButton.Visible = true;
                textBox4.Text = "Current Money: " + Money + Environment.NewLine;
                textBox4.Text += "Current Bet: " + Bet;
                if (playerhand2.score >= 21)
                {
                    end_game(playerhand, dealer_hand);
                    MainTextBox.Text = "";
                    end_game(playerhand2, dealer_hand);
                    display_dealerhand(dealer_hand);
                    textBox4.Text = "Current Money: " + Money + Environment.NewLine;
                    textBox4.Text += "Current Bet: " + Bet;
                    MainTextBox.Text += "Press deal cards to play again.";
                    display_dealerhand(dealer_hand);
                    richTextBox4.Text = playerScore.ToString();
                    richTextBox5.Text = dealerScore.ToString();
                    dealButton.Visible = true; // deal button is visible
                    pictureBox18.Visible = false; // hit button hidden
                    stayButton.Visible = false; // stick button hidden
                    textBox5.Visible = true;
                    
                }
              
            }
           // if (winner)
           // {
           //     pictureBox21.Visible = true;
            //    dealButton.BringToFront();
            //    MainTextBox.Text = "You won. Press deal cards to play again.";
           // }

        }
        

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            if (isSplit == false)
            {
                splitButton.Visible = false;
                end_game(playerhand, dealer_hand);
                textBox4.Text = "Current Money: " + Money + Environment.NewLine;
                textBox4.Text += "Current Bet: " + Bet;
                MainTextBox.Text += "Press deal cards to play again.";
                display_dealerhand(dealer_hand);
                richTextBox4.Text = playerScore.ToString();
                richTextBox5.Text = dealerScore.ToString();
                dealButton.Visible = true; // deal button is visible
                pictureBox18.Visible = false; // hit button hidden
                stayButton.Visible = false; // stick button hidden
                textBox5.Visible = true;

            }
            else if (isSplit == true && playerhand.isDone == false)
            {
                playerhand.isDone = true;
                textBox4.Text = "Current Money: " + Money + Environment.NewLine;
                textBox4.Text += "Current Bet: " + Bet;
                MainTextBox.Text = "What would you like to do for hand 2";
                splitButton.Visible = false;
                richTextBox4.Text = playerScore.ToString();
                richTextBox5.Text = dealerScore.ToString();

            }
            else if (isSplit == true && playerhand.isDone == true)
            {
                end_game(playerhand, dealer_hand);
                MainTextBox.Text = "";
                end_game(playerhand2, dealer_hand);
                textBox4.Text = "Current Money: " + Money + Environment.NewLine;
                textBox4.Text += "Current Bet: " + Bet;
                MainTextBox.Text += "Press deal cards to play again.";
                display_dealerhand(dealer_hand);
                richTextBox4.Text = playerScore.ToString();
                richTextBox5.Text = dealerScore.ToString();
                display_dealerhand(dealer_hand);
                dealButton.Visible = true; // deal button is visible
                pictureBox18.Visible = false; // hit button hidden
                stayButton.Visible = false; // stick button hidden
                textBox5.Visible = true;

            }

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            isSplit = true;
            splitButton.Visible = false;
            textBox6.Visible = true;
            textBox6.Text = "Player Hand 2";
            richTextBox2.Text = "Player Hand 1";
            playerhand2 = new Hand(numcards);
            playerhand2.startSplit(playerhand);
            playerhand.cards.RemoveAt(1);
            playerhand.add_card(currentdeck, 1);
            playerhand2.add_card(currentdeck, 1);
            display_playerhand(playerhand);
            display_playerhand_number2(playerhand2);
            playerhand.evaluate_hand();
            playerhand2.evaluate_hand();
            MainTextBox.Text = "You have " + playerhand.score + " in your first hand. And " + playerhand2.score + " in the second. Would you like to hit or stay for hand 1?";

        }
        private void display_playerhand_number2(Hand playerhand)
        {
            int count = 0;
            string currentcard_picture = "";
            DateTime t = DateTime.Now;

            if (playerhand.cards != null && playerhand != null)
                foreach (Card currentcard in playerhand.cards)
                {
                    if (currentcard != null && currentcard.suit != "")
                    {
                        if (currentcard.value < 10)
                            currentcard_picture = "_" + currentcard.value.ToString() + "_of_" + currentcard.suit;
                        if (currentcard.value == 10)
                            currentcard_picture = "_" + currentcard.value.ToString() + "_of_" + currentcard.suit;
                        if (currentcard.value == 11)
                            currentcard_picture = "jack" + "_of_" + currentcard.suit;
                        if (currentcard.value == 12)
                            currentcard_picture = "queen" + "_of_" + currentcard.suit;
                        if (currentcard.value >= 13)
                            currentcard_picture = "king" + "_of_" + currentcard.suit;
                    }
                    else
                        currentcard_picture = "space";

                    if (count == 0)
                    {

                        pictureBox18b.Visible = true; //showing first card
                        pictureBox18b.BringToFront();
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox18b.Image = myImage;
                        pictureBox18b.BringToFront();
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 1)
                    {
                        pictureBox19.Visible = true; //showing second card
                        pictureBox19.BringToFront();
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox19.Image = myImage;
                        pictureBox19.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 2)
                    {
                        pictureBox20.Visible = true;
                        pictureBox20.BringToFront();
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox20.BringToFront();
                        pictureBox20.Image = myImage;
                        pictureBox20.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 3)
                    {
                        pictureBox17b.Visible = true;
                        pictureBox17b.BringToFront();
                        System.Resources.ResourceManager rm = BlackJack.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox17b.BringToFront();
                        pictureBox17b.Image = myImage;
                        pictureBox17b.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    
                    count++;
                }

        }
    }
}
