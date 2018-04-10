using CardGame.GUI.General;
using System.Collections.Generic;

namespace CardGame.GUI.Players
{
    public class Hand
    {
        private List<Card> cardsInHand = new List<Card>();
        private int handValue;
        
        //Player's status, true if handValue > 21, false if handValue < 21
        private bool Kaboom { get; set; }

        public Hand()
        {
            Kaboom = false;
        }

        public void DealCard(Deck deck)
        {
            cardsInHand.Add(deck.DealCard());
        }

        public virtual string ShowCardsInHand()
        {
            return cardsInHand.ToString();
        }

        //Determines the hand's value
        public virtual int GetHandValue()
        {
            handValue = 0;
            //Grabs the value of the card, determined by the ranks of it
            for (int i = 0; i < cardsInHand.Count; i++)
            {
                if ((int)cardsInHand[i].GetCardValue < 10)
                {
                    handValue += (int)cardsInHand[i].GetCardValue;
                }
                else
                {
                    handValue += 10;
                }
            }

            //ACE is a wild card, can be either 1, 10 or 11
            if (cardsInHand.Count == 2 && ((cardsInHand[0].GetCardValue == Ranks.ACE && (int)cardsInHand[1].GetCardValue >= 10) || (cardsInHand[1].GetCardValue == Ranks.ACE && (int)cardsInHand[0].GetCardValue >= 10)))
            {
                return 21;
            }

            if (handValue > 21)
            {
                Kaboom = true;
            }

            return handValue;
        }

        //Folds the cards, equivalent to forfeiting the round
        public void FoldCards()
        {
            cardsInHand.Clear();
            Kaboom = false;
        }
    }
}

