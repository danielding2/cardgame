using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cardGame
{
    class Blackjack
    {
        private Hand player = new Hand();
        private Hand dealer = new Hand();
        public Deck deck = new Deck();
        private bool gameOver;
        private int numOfRounds;
        

        public Blackjack() 
        {
            player = new Hand();
            dealer = new Hand();
            numOfRounds = 0;
            gameOver = false;
            MainGame(player, dealer, deck);            
        }
      
        public void MainGame(Hand player, Hand dealer, Deck deck)
        {
            //debug 
            //deck.PrintDeck();
            Console.WriteLine("WELCOME TO BLACKJACK CONSOLE VERSION!\n");

            NewRoundOrQuit();

            while (!gameOver)
            {
                player.bustedOrNot = false;
                dealer.bustedOrNot = false;
                Console.WriteLine("Blackjack Console version, YOU VS DEALER! \nRound: " + numOfRounds);
                DealFirst2Cards(player, dealer);
                Console.WriteLine(deck.Count() + " cards left!" + "\n"); 
                PrintTotalPointsHidden(player,dealer);

                GameLogic(player, dealer);
            }
            Console.ReadLine();
        }

        public void Restart()
        {
            Console.Clear();
            Console.WriteLine("Game restarted!");
            player = new Hand();
            dealer = new Hand();
            deck = new Deck();

            MainGame(player, dealer, deck);
        }

        public void DealFirst2Cards(Hand player, Hand dealer)
        {
            player.DealCard(deck);
            player.DealCard(deck);
            dealer.DealCard(deck);
            dealer.DealCard(deck);
        }

        // Dealer 2nd card shown
        public void PrintTotalPointsShow(Hand player, Hand dealer) 
        {
            Console.WriteLine("Player's Hand: " + player.ShowCardsInHand() + "  Total: " + player.CardValueSum + " " + BustedPrintPlayer());
            Console.WriteLine("Dealer's Hand: " + dealer.ShowCardsInHand() + "  Total: " + dealer.CardValueSum + " " + BustedPrintDealer());
        }

        // Dealer 2nd card hidden - showCardsInHand lazy way to overload
        public void PrintTotalPointsHidden(Hand player, Hand dealer)
        {
            Console.WriteLine("Player's Hand: " + player.ShowCardsInHand() + "  Total: " + player.CardValueSum + " " + BustedPrintPlayer());
            Console.WriteLine("Dealer's Hand: " + dealer.ShowCardsInHand(true) + "  Total: " + dealer.DealerCardValue + " " + BustedPrintDealer());
        }

        public void GameLogic(Hand player, Hand dealer)
        {
            ConsoleKeyInfo key;

            HitChoice:
            do
            {
                Console.WriteLine("Press n to Start a new game, Press h to Hit, Press s to Stand, Press q to Quit");
                key = Console.ReadKey();
            } while (!(key.Key.Equals(ConsoleKey.N) || key.Key.Equals(ConsoleKey.H) || key.Key.Equals(ConsoleKey.S) || key.Key.Equals(ConsoleKey.Q)));

            // if player chooses to restart the game 
            if (key.Key == ConsoleKey.N)
            {
                Restart();
            }

            // if player chooses to Hit (ask for another card)
            if (key.Key == ConsoleKey.H)
            {
                if (deck.Count() != 0)
                    player.DealCard(deck);
                else
                    Console.WriteLine("No cards left to hit");

                Console.WriteLine("\n\nYou hit");
                PrintTotalPointsHidden(player, dealer);

                if (player.CardValueSum == -1)
                {
                    Console.WriteLine("\nDealer wins!");
                    NewRoundOrQuit();
                }
                else    
                    goto HitChoice;
            }

            // if player chooses to Stand (not ask for another card)
            if (key.Key == ConsoleKey.S)
            {
                //dealer deals until points > 16
                while(dealer.CardValueSum <= 16)
                {
                    if (!dealer.bustedOrNot && deck.Count() != 0)
                        dealer.DealCard(deck);
                    else
                        break;
                }

                Console.WriteLine("\n\nYou stand");
                PrintTotalPointsShow(player, dealer);

                if (player.CardValueSum > dealer.CardValueSum)
                    Console.WriteLine("\nYou win!");
                else if (player.CardValueSum == dealer.CardValueSum)
                    Console.WriteLine("\nDraw");
                else
                    Console.WriteLine("\nDealer wins!");
                Console.WriteLine(deck.Count());
                NewRoundOrQuit();
            }

            // if player chooses to quit the game
            if (key.Key == ConsoleKey.Q)
            {
                Console.WriteLine("\n\nTHANKS FOR PLAYING BLACKJACK!");
                gameOver = true;
            }

            //check if enough cards for next round
            if (deck.Count() < 5)
            {
                Console.WriteLine("\nNo more cards left in the deck for another round!");
                NewRoundOrQuit();
                if (key.Key == ConsoleKey.Enter)
                {
                    Restart();
                }
            }                
        }

        public void NewRoundOrQuit()
        {
            player.ClearHand();
            dealer.ClearHand();
            numOfRounds++;

            ConsoleKeyInfo key;
            do
            {
                Console.WriteLine("\nPress Enter play Blackjack or Press Q to Quit");
                key = Console.ReadKey();
            } while (!(key.Key.Equals(ConsoleKey.Q) || key.Key.Equals(ConsoleKey.Enter)));

            if (key.Key == ConsoleKey.Enter)
                Console.Clear();
            else
                gameOver = true;

        }

        public string BustedPrintPlayer()
        {
            //if busted
            string bustedPrint;
            if (player.bustedOrNot)
                bustedPrint = "Busted!";
            else
                bustedPrint = "";
            return bustedPrint;
        }

        public string BustedPrintDealer()
        {
            //if busted
            string bustedPrint;
            if (dealer.bustedOrNot)
                bustedPrint = "Busted!";
            else
                bustedPrint = "";
            return bustedPrint;
        }
    }
}
