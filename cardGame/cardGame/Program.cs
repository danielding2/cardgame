
using System;
using System.Collections.Generic;

public class CardGame
{

    public static void Main(string[] args)
    {
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		ConsoleKeyInfo key1;


		do
		{
			Console.WriteLine("**Welcome to BlackJack!**\nIn this game, you play against an AI dealer. Good luck!**");
			Console.WriteLine("\nPress ENTER to Start the Game or Press [Q] to Quit.");

			key1 = Console.ReadKey();

		}while(!(key1.Key.Equals(ConsoleKey.Q) || key1.Key.Equals(ConsoleKey.Enter)));

		ConsoleKeyInfo newRound;
		string testCard = "\u2660";

		do
		{
			int numOfPlayer;
			Console.Clear();
			Console.WriteLine("How many players are playing?");
			numOfPlayer = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Press ENTER To start the game");
			Console.ReadLine();

			//**deal cards to players**
			for (int x = 1; x < numOfPlayer + 1; x++)
			{
				for (int y = 0; y < 2; y++)
				{
					//deal cards facing up to player's hand

				}	
			}

			//display players' cards
			for (int x = 1; x < numOfPlayer + 1; x++)
			{
				Console.WriteLine("Player {0}'s cards:", x);
				Console.WriteLine("A" + testCard);
				Console.WriteLine("A" + testCard + "\n");
			}

			//**deal 2 cards to dealer**
			//deal 1 card face up
			//deal 1 card face down

			ConsoleKeyInfo playerAction;


			for (int x = 1; x < numOfPlayer + 1; x++)
			{
				do
				{
					Console.WriteLine("**Player {0}'s turn**\n", x);
					//display player's cards:
					/*
					 * 
					 */

					Console.WriteLine("\n[D] - Draw a card");
					Console.WriteLine("[S] - Stand");
					playerAction = Console.ReadKey();


					Console.Clear();

				} while (!(playerAction.Key.Equals(ConsoleKey.S)));

				Console.Clear();
				Console.WriteLine("**Player {0}'s cards:**", x);
				//display player's cards:
				/*
				 * 
				 */

				Console.WriteLine("Press ENTER to end turn");
				Console.ReadLine();
			}

			//****AI dealer's actions****
			Console.WriteLine("**Dealer's turn**");
			//display dealer's cards:
			/*
			 * 
			 * 
			 */

			//display dealer's actions:
			/*
			 * 
			 */

			//display winners
			/*
			 * 
			 */

			Console.WriteLine("Do you want to play a new round?");
			Console.WriteLine("[Y] - Yes");
			Console.WriteLine("[N] - No");
			newRound = Console.ReadKey();

		} while (!(newRound.Key.Equals(ConsoleKey.N)));

/*** OLD CODE ***
			Hand[] player;
			bool gameOver = false;
			//int cardsPerPlayer = 1;
			//List<int> playerScore;

			while (!gameOver)
			{
				//int roundNum = 0;

				player = new Hand[1];
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
						Console.WriteLine("\nPlayer" + RoundWinner + " won Round " + roundNum);
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
						getWinnerScore(player, winnerList);
						Console.WriteLine("\nPress any key to Continue");
						Console.ReadLine();
					}

					roundNum++;
			

				} while (numOfRounds != 0);

				//Quan: FROM LINE 85, couldnt work there
				List<int> winnerList = new List<int>();
				getWinnerScore(player, winnerList);
				//end 

				gameOver = true;
			}*/

		
	
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
            Console.WriteLine("The overall winner is P" + winnerList[0] + ". Congratz!!");
        }
        else
        {
            Console.WriteLine("The overall winners are ");
            for (int i = 0; i < winnerList.Count; ++i)
                Console.WriteLine("P" + winnerList[i] + " ");
            Console.WriteLine("");
        };

    }

}

