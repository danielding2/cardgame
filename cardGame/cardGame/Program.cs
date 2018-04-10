using System;
using System.Collections.Generic;

public class CardGame
{

	public static void Main(string[] args)
	{


		ConsoleKeyInfo key1, key2;
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
		Start:
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
			HitChoice:
				do
				{
					Console.WriteLine("Press n to Start a new game, Press h to Hit, Press s to Stand, Press q to Quit");
					key2 = Console.ReadKey();
				} while (!(key2.Key.Equals(ConsoleKey.N) || key2.Key.Equals(ConsoleKey.H) || key2.Key.Equals(ConsoleKey.S) || key2.Key.Equals(ConsoleKey.Q)));

				if (key2.Key == ConsoleKey.N)
				{
					for (int i = 0; i < player.Length; i++)
					{
						player[i].DealNewSetOfCards();
					}
					goto Start;
				}

				if (key2.Key == ConsoleKey.H)
				{
					player[0].DealCard(deck);
					for (int i = 0; i < player.Length; i++)
					{
						Console.WriteLine("Player " + (i + 1) + " " + player[i].ShowCardsInHand() + "  Total: " + player[i].CardValueSum);
					}
					goto HitChoice;
				}

				if (key2.Key == ConsoleKey.S)
				{
					if (player[0].CardValueSum > player[1].CardValueSum)
						Console.WriteLine("You win!");
					else
						Console.WriteLine("Dealer wins!");
				}

				if (key2.Key == ConsoleKey.Q)
				{
					Console.WriteLine("\n\nTHANKS FOR PLAYING BLACKJACK!");
					gameOver = true;
				}
			}
			Console.ReadLine();
		}
	}
}

