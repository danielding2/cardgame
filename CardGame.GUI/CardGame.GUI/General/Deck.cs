using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame.GUI.General
{
    public class Deck
    {
        private Stack<Card> deck = new Stack<Card>();

        Random GetRandom = new Random();

        //Shuffles a new deck
        public void Shuffle()
        {
            var deckArray = deck.ToArray();
            foreach (Card card in deckArray.OrderBy(x => GetRandom.Next()))
            {
                deck.Push(card);
            }

        }

        public virtual int DeckSize
        {
            get
            {
                return deck.Count;
            }
        }

        internal Card DrawCard()
        { 
            return deck.Pop();
        }

        //For Debugging
        /*public virtual void printDeck()
        {
            foreach (Card c in deck)
            {
                Console.Write(c + " ");
            }
        }*/

    }

}