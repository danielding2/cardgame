
using System;
using System.Collections.Generic;

public class CardGame
{

    public static void Main(string[] args)
    {
        //Determine number of players
        bool playersCreated = false;
        int numOfPlayers;


		ConsoleKeyInfo key1;

		do
		{
			Console.WriteLine("Press Enter to Start the Game or Press Q to Quit ");

			key1 = Console.ReadKey();

		}while(!(key1.Key.Equals(ConsoleKey.Q) || key1.Key.Equals(ConsoleKey.Enter)));


		if (key1.Key == ConsoleKey.Enter)
		{


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
						deck.printDeck();
						Console.WriteLine("");
						Console.WriteLine("Round: " + roundNum);
						Console.WriteLine("Rounds remaining: " + numOfRounds);
						dealPlayerCards(player, cardsPerPlayer, deck);

						playerScore = new List<int>();
						//Shows winner of the round
						int RoundWinner = playerCardScore(player);
						playerCards(player);
						Console.WriteLine("\nPlayer" + RoundWinner + " Won");
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
						/*List<int> winnerList = new List<int>();
						getWinnerScore(player, winnerList);
						Console.WriteLine("\nPress any key to Continue");
						Console.ReadLine();*/
					}

					roundNum++;

				} while (numOfRounds != 0);

				//Quan: FROM LINE 85, couldnt work there
				List<int> winnerList = new List<int>();
				getWinnerScore(player, winnerList);
				//end 

				gameOver = true;
			}

		}
	
		Console.WriteLine("\n\nThanks for playing the game\n");

		Console.WriteLine("Press Enter to Continue");
		Console.ReadLine();   
	

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

    internal static int playerCardScore(Hand[] player)
    {
        int highestScore = player[0].CardValueSum;
        for (int i = 1; i < player.Length; i++)
        {
            if (highestScore <= player[i].CardValueSum)
            {
                highestScore = player[i].CardValueSum;
            }
        }

        for (int i = 0; i < player.Length; i++)
        {
            if (highestScore == player[i].CardValueSum)
            {
                player[i].addWinCount();
                player[i].setWinnerForTheRound(true);
                int CurrentPlayer = i + 1;
                return CurrentPlayer;
            }
        }
        return 0;
    }

    static void getWinnerScore(Hand[] player, List<int> winnerList)
    {
        int highestWinCount = player[0].getWinCount();
        for (int i = 1; i < player.Length; i++)
        {
            if (highestWinCount <= player[i].getWinCount())
                highestWinCount = player[i].getWinCount();
        };

        for (int i = 1; i < player.Length + 1; i++)
        {
            if (highestWinCount == player[i - 1].getWinCount())
                winnerList.Add(i);
        };
        if (winnerList.Count == 1)
        {
            Console.WriteLine("The Winner is P" + winnerList[0] + ". Congratz!!");
        }
        else
        {
            Console.WriteLine("The Winners are ");
            for (int i = 0; i < winnerList.Count; ++i)
                Console.WriteLine("P" + winnerList[i] + " ");
            Console.WriteLine("");
        };

    }

}

