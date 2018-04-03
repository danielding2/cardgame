using System;
using System.Collections;
using System.Collections.Generic;

internal class Deck : IEnumerable<Card>
{

	private Stack<Card> deck;

	internal Deck()
	{
		deck = new Stack<Card>();
		newDeck();
		Console.WriteLine("Deck created");
		deck = shuffleDeck(deck);
		Console.WriteLine("Deck shuffled");
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

	public static Stack<Card> shuffleDeck(Stack<Card> myDeck)
	{
		//Declare all variables required
		//copy elements of stack to deckArray
		var deckArray = myDeck.ToArray();
		Random r = new Random();

        //Clear the stack to avoid doubling the cards
        myDeck.Clear();

        //for debugging
		/*var a = 0;
		for (a = 0; a < deckArray.Length; a++)
		{
			Console.WriteLine(deckArray[a]);
		}*/

        //shuffle the cards and add to stack
        foreach (Card card in deckArray)
		{
			myDeck.Push(card);
		}

        //for debugging to check if the stack is shuffled
        /*Console.WriteLine("This is the stack:");
		foreach (Card card in myDeck)
		{
			Console.WriteLine(card);
		}*/

		//return the stack
		return myDeck;
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

    public virtual void printDeck()
    {
        foreach (Card c in deck)
        {
            Console.Write(c + " ");
        }
    }

    //allows readonly access to deck collection and with 
    //such implementation allows a for-each statement.
    public IEnumerator<Card> GetEnumerator()
    {
        return ((IEnumerable<Card>)deck).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<Card>)deck).GetEnumerator();
    }
}