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
            string CardSuit = c.Suit.ToString();
            TempAllCardsInHand = TempAllCardsInHand + c.Rank + StringSuitToUnicode(CardSuit) + " ";
        }
        AllCardsInHand = TempAllCardsInHand;

        return AllCardsInHand;
    }

    public string ShowCardsInHand(bool hidecard)
    {
        TempAllCardsInHand = "";
        for (int i=0; i< cardsInHand.Count; i++)
        {
            if(i==1)
            {
                TempAllCardsInHand = TempAllCardsInHand + "HiddenCard";
            }
            else
            {
                string CardSuit = cardsInHand[i].Suit.ToString();
                TempAllCardsInHand = TempAllCardsInHand + cardsInHand[i].Rank + StringSuitToUnicode(CardSuit) + " ";
            }
        }

        AllCardsInHand = TempAllCardsInHand;

        return AllCardsInHand;
    }

    public string StringSuitToUnicode(string CardSuit)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        if (CardSuit == "SPADES")
            return "\u2660";
        else if (CardSuit == "HEARTS")
            return "\u2665";
        else if (CardSuit == "DIAMONDS")
            return "\u2666";
        else //CLUBS
            return "\u2663";
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

            // easy lucky blackjack 
            if (cardsInHand.Count == 2 && ((cardsInHand[0].CardValue == (int)Ranks.Ace && (int)cardsInHand[1].CardValue >= 10) || (cardsInHand[1].CardValue == (int)Ranks.Ace && (int)cardsInHand[0].CardValue >= 10)))
            {
                return 21;
            }
            
            //If total card sum <=10 and has an ace card, ace will be counted as 11
            for (int i = 0; i < cardsInHand.Count; ++i)
            {
                if (sumOfCardValues <= 10)
                    if (cardsInHand[i].CardValue == (int)Ranks.Ace)
                        sumOfCardValues = sumOfCardValues + 10;
            }

            //busted 
            if (sumOfCardValues > 21)
            {
                sumOfCardValues = -1;
            }

            return sumOfCardValues;
        }
    }

    //Get 1st dealer's card value only
    public int DealerCardValue
    {
        get
        {
            return cardsInHand[0].CardValue;
        }       
    }

    public void ClearHand()
    {
        cardsInHand.Clear();
    }

    /* unused code
    public void DealNewSetOfCards()
    {
        cardsInHand.Clear();
        cardsInHand = new List<Card>();
    }*/



}
