using System;
using System.Collections.Generic;

internal class Deck
{

	private Stack<Card> deck;

	internal Deck()
	{
		deck = new Stack<Card>();
		newDeck();
		Console.WriteLine("Deck created");
	}

	public virtual void newDeck()
	{
		deck.Clear();
		foreach (Suits s in Enum.GetValues(typeof(Suits)))
		{
			foreach (Ranks r in Enum.GetValues(typeof(Ranks)))
			{
				Card c = new Card(s,r);
				deck.Push(c);
			};
		};
	}

	public virtual int DeckSize
	{
		get
		{
			return deck.Count;
		}
	}

	public virtual Card drawFromDeck()
	{
		Card poppedCards = deck.Pop();
		return poppedCards;
	}
	
	// public virtual string printDeck()
	// {
		// return deck.ToString;
	// }

}