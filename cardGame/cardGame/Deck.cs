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
		//Firstly, duplicates the cards on Stack to array
		//Copy the array to a List<Card>
		//Shuffle and add to the new List<Card>
		//Move from new List<Card> to the deckList
		//Convert back to Stack and return it

		//Declare all variables required
		//copy elements of stack to deckArray
		var deckArray = myDeck.ToArray();
		List<Card> deckList = new List<Card>();
		List<Card> shuffledDeck = new List<Card>();
		Random r = new Random();
		int i = 0;
		int p = 0;

		//add every cards on deckArray to deckList
		for (i = 0; i < deckArray.Length; i++) 
		{
			deckList.Add(deckArray[i]);
		}

		/*for debugging 
		var j = 0;
		var a = 0;
		for (a = 0; a < deckArray.Length; a++)
		{
			Console.WriteLine(deckArray[a]);
		}


		Console.WriteLine("This is the list of cards:\n\n");

		for (j = 0; j < deckList.Count; j++)
		{
			Console.WriteLine(deckList[j]);
		}*/


		//Shuffle it and store in shuffledDeck
		while (deckList.Count > 0)
		{
			p = r.Next(0, deckList.Count);
			shuffledDeck.Add(deckList[p]);
			deckList.Remove(deckList[p]);
		}

		//copy the cards to deckList
		deckList = shuffledDeck;

		/*for debugging 
		Console.WriteLine("This is the list of cards have been shuffled:\n\n");
		var b = 0;
		for (b = 0; b < deckList.Count; b++)
		{
			Console.WriteLine(deckList[b]);
		}*/


		//convert back to array
		deckArray = deckList.ToArray();

		/*for debugging
		var c = 0;
		Console.WriteLine("This is the deckArray");
		for (c = 0; c < deckArray.Length; c++)
		{
			Console.Write(c.ToString());
			Console.WriteLine(deckArray[c]);
		}*/

		//problem when copy back to the stack
		//convert back to stack
		foreach (Card card in deckArray)
		{
			myDeck.Push(card);
		}

		/*for debugging
		Console.WriteLine("This is the stack:");
		foreach (Card card in myDeck)
		{
			Console.WriteLine(card);
		}*/

		//return it
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

    //Allows readonly access to Deck collection and with 
    //such implementation allows a for-each statement.
    public IEnumerator<Card> GetEnumerator()
    {
        return ((IEnumerable<Card>)deck).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<Card>)deck).GetEnumerator();
    }

    public virtual void printDeck()
    {
        foreach (Card c in deck)
        {
            Console.Write(c + " ");
        }
    }

}