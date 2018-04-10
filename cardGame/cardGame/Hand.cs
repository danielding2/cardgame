using System;
using System.Collections.Generic;

internal class Hand
{
	private List<Card> cardsInHand;
	private int sumOfCardValues;
	private string AllCardsInHand;
	private string TempAllCardsInHand;

	internal Hand()
	{
		cardsInHand = new List<Card>(3); 

	}

	public virtual void dealCard(Deck deck)
	{
		cardsInHand.Add(deck.drawFromDeck());
	}

	public virtual string showCardsInHand()
	{
		TempAllCardsInHand = "";
		foreach (Card c in cardsInHand)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			string a = c.Suit.ToString();
			string SuitUnicode = "";

			if (a == "SPADES")
				SuitUnicode = "\u2660";
			else if (a == "HEARTS")
				SuitUnicode = "\u2665";
			else if (a == "DIAMONDS")
				SuitUnicode = "\u2666";
			else if (a == "CLUBS")
				SuitUnicode = "\u2663";
			TempAllCardsInHand = TempAllCardsInHand + c.Rank + SuitUnicode + " ";
		}
		AllCardsInHand = TempAllCardsInHand;
		return AllCardsInHand;
	}

	public virtual int CardValueSum
	{
		get
		{
			sumOfCardValues = 0;
			for (int i = 0; i < cardsInHand.Count; ++i)
			{
				sumOfCardValues += cardsInHand[i].CardValue;
			}
			sumOfCardValues = (sumOfCardValues % 10);
			return sumOfCardValues;
		}
	}

	public virtual void dealNewSetOfCards()
	{
		cardsInHand.Clear();
		cardsInHand = new List<Card>(3);
	}

}
