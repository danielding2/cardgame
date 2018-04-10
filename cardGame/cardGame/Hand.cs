using System;
using System.Collections.Generic;

public class Hand
{
    private List<Card> cardsInHand;
    private int sumOfCardValues;
    private string AllCardsInHand;
    private string TempAllCardsInHand;

    public Hand()
    {
        cardsInHand = new List<Card>();

    }

    public void DealCard(Deck deck)
    {
        cardsInHand.Add(deck.DrawFromDeck());
    }


    public string ShowCardsInHand()
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

    public int CardValueSum
    {
        get
        {
            sumOfCardValues = 0;
            for (int i = 0; i < cardsInHand.Count; ++i)
            {
                sumOfCardValues += cardsInHand[i].CardValue;
            }
            return sumOfCardValues;
        }
    }

    public void DealNewSetOfCards()
    {
        cardsInHand.Clear();
        cardsInHand = new List<Card>(3);
    }

}
