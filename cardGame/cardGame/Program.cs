using System;
using System.Collections.Generic;

public class CardGame
{
	
	public static void Main(string[] args)
	{
		//Determine number of players
		bool playersCreated = false;
		int numOfPlayers;
		do
		{
			Console.WriteLine("Please enter number of players:");
			numOfPlayers = Convert.ToInt32(Console.ReadLine());

			if (numOfPlayers < 2)
			{
				Console.WriteLine("\nPlease enter at least 2 Players");
				Console.ReadLine();
				Console.Clear();
			}
			else if (numOfPlayers >= 2)
			{
				Console.WriteLine("\n{0} Players Created!", numOfPlayers);
				playersCreated = true;
			}
		} while (playersCreated == false);

		Console.WriteLine("\nPress any key to START");
		Console.ReadLine();
		Console.Clear();


		Hand[] player;
		bool gameOver = false;
		int cardsPerPlayer = 1;
		List<int> playerScore;

		while (!gameOver)
		{
			int roundNum = 0;

			player = new Hand[numOfPlayers];
			for (int i = 0; i < player.Length; ++i)
			{
				player[i] = new Hand();
			}

			Deck deck = new Deck();

			int numOfRounds = roundsCheck(deck, numOfPlayers, cardsPerPlayer);

			do
			{
				numOfRounds = roundsCheck(deck, numOfPlayers, cardsPerPlayer);
				if (roundNum != 0)
				{
					Console.WriteLine("Round: " + roundNum);
					Console.WriteLine("Rounds remaining: " + numOfRounds);
					dealPlayerCards(player, cardsPerPlayer, deck);

					playerScore = new List<int>();
					playerCardScore(player);
					playerCards(player);

				};



				Console.WriteLine("");
				Console.WriteLine("Available cards: {0}", deck.DeckSize);

				if (roundNum != numOfRounds)
				{
					ConsoleKeyInfo key;
					do
					{
						Console.WriteLine("Please press Enter to deal cards\n");
						key = Console.ReadKey();
					} while (!key.Key.Equals(ConsoleKey.Enter));
				}
				else if (roundNum == numOfRounds)
				{
					List<int> winnerList = new List<int>();
				}

				roundNum++;

			} while (numOfRounds != 0);

			gameOver = true;
		}

	}



	internal static int roundsCheck(Deck deck, int numOfPlayers, int cardsPerPlayer)
	{
		int numOfRounds = (deck.DeckSize / (numOfPlayers * cardsPerPlayer)) - 1;
		return numOfRounds;
	}

	internal static void dealPlayerCards(Hand[] player, int cardsPerPlayer, Deck deck)
	{
		for (int i = 0; i < cardsPerPlayer; ++i)
		{
			for (int j = 0; j < player.Length; ++j)
			{
				player[j].dealCard(deck);
			}
		}
	}


	internal static void playerCards(Hand[] player)
	{
		for (int i = 1; i < player.Length + 1; ++i)
		{
			Console.Write("P" + i + " cards: "/*  + missing function */ + " | Sum = " + player[i - 1].CardValueSum);
			Console.WriteLine("");
			player[i - 1].dealNewSetOfCards();
		}
	}

	internal static void playerCardScore(Hand[] player)
	{
		int highestScore = player[0].CardValueSum;
		for (int i = 1; i < player.Length; i++)
		{
			if (highestScore <= player[i].CardValueSum)
			{
				highestScore = player[i].CardValueSum;
			}
		}
	}

}
