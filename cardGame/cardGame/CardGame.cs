using System;
using System.Collections.Generic;

public class CardGame
{
	public static void Main(string[] args)
	{

		Hand[] player;
		bool gameOver = false;
		int numOfPlayers = 2;
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
				if (roundNum != 0)
				{
					Console.WriteLine("Round: " + roundNum);
					dealPlayerCards(player, cardsPerPlayer, deck);

					playerScore = new List<int>();
					playerCardScore(player);
					playerCards(player);

				};
				
				Console.WriteLine("");
				Console.WriteLine("Available cards: " /* + missing function */);

				if (roundNum != numOfRounds)
				{
					ConsoleKeyInfo key;
					do
					{
						Console.WriteLine("Please press Enter to deal cards");
						key = Console.ReadKey();
					}while(!key.Key.Equals(ConsoleKey.Enter));
				}
				else if (roundNum == numOfRounds)
				{
					List<int> winnerList = new List<int>();
				}

				roundNum++;

			}while (roundNum <= numOfRounds);

			gameOver = true;
		}

	}
	


	internal static int roundsCheck(Deck deck, int numOfPlayers, int cardsPerPlayer)
	{
		int numOfRounds = deck.DeckSize / (numOfPlayers * cardsPerPlayer);
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
