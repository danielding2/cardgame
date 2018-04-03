using System.Collections.Generic;

internal class Hand
{
	private List<Card> cardsInHand;
	private int sumOfCardValues;
    private int winCount = 0;
    private bool winnerForTheRound = false;

	internal Hand()
	{
		cardsInHand = new List<Card>(3); 

	}

	public virtual void dealCard(Deck deck)
	{
		cardsInHand.Add(deck.drawFromDeck());
	}

	
	// public virtual string showCardsInHand()
	// {
		// return cardsInHand.ToString();
	// }

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

    public void addWinCount()
    {
        this.winCount++;
    }

    public int getWinCount()
    {
        return winCount;
    }

    public void setWinnerForTheRound(bool winnerForTheRound)
    {
        this.winnerForTheRound = winnerForTheRound;
    }

    public bool getWinnerForTheRound()
    {
        return winnerForTheRound;
    }

}
