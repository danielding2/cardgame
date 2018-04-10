using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Deck : IEnumerable<Card>
{

    private Stack<Card> deck;

    internal Deck()
    {
        deck = new Stack<Card>();
        NewDeck();
        Console.WriteLine("Deck created");
        deck = ShuffleDeck(deck);
        Console.WriteLine("Deck shuffled");
    }

    public void NewDeck()
    {
        deck.Clear();
        foreach (Suits s in Enum.GetValues(typeof(Suits)))
        {
            foreach (Ranks r in Enum.GetValues(typeof(Ranks)))
            {
                Card c = new Card(s, r);
                deck.Push(c);
            };
        };
    }

    public static Stack<Card> ShuffleDeck(Stack<Card> myDeck)
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
        foreach (Card card in deckArray.OrderBy(x => r.Next()))
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

    public virtual Card DrawFromDeck()
    {
        Card poppedCards = deck.Pop();
        return poppedCards;
    }

    public virtual void PrintDeck()
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