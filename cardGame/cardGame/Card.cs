public class Card
{

    private Ranks rank;
    private Suits suit;

    internal Card(Suits suit, Ranks rank)
    {
        this.rank = rank;
        this.suit = suit;
    }

    public override string ToString()
    {
        return suit + "" + rank;
    }

    public Ranks Rank
    {
        get
        {
            return rank;
        }
    }

    public Suits Suit
    {
        get
        {
            return suit;
        }
    }

    public virtual int CardValue
    {
        get
        {
            if ((int)rank < 9)
            {
                return ((int)rank + 1);
            }
            else
            {
                return 10;
            }
        }
    }

}