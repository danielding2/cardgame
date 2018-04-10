using System;
using System.Collections.Generic;

public class CardGame
{

    public static void Main(string[] args)
    {


        ConsoleKeyInfo key1;
        do
        {
            Console.WriteLine("Press Enter to Start the Game or Press Q to Quit ");
            key1 = Console.ReadKey();
        } while (!(key1.Key.Equals(ConsoleKey.Q) || key1.Key.Equals(ConsoleKey.Enter)));


        if (key1.Key == ConsoleKey.Enter)
        {
            Console.Clear();

            int numOfPlayers = 2;
            Hand[] player;
            Deck deck = new Deck();
            bool gameOver = false;

            Console.WriteLine("\n WELCOME TO BLACKJACK! {0} Players Created!", numOfPlayers);

            while (!gameOver)
            {
                player = new Hand[numOfPlayers];
                for (int i = 0; i < player.Length; i++)
                {
                    player[i] = new Hand();
                }

                Console.WriteLine("\n");
                for (int i = 0; i < player.Length; i++)
                {
                    player[i].DealCard(deck);
                    player[i].DealCard(deck);
                }

                for (int i = 0; i < player.Length; i++)
                {
                    Console.WriteLine("Player " + (i + 1) + " " + player[i].ShowCardsInHand() + "  Total: " + player[i].CardValueSum);
                }
            }
            Console.ReadLine();
        }
    }
}

