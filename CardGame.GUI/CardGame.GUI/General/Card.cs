

namespace CardGame.GUI.General
{
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

        public virtual Ranks Rank
        {
            get
            {
                return rank;
            }
        }

        public virtual Suits Suit
        {
            get
            {
                return suit;
            }
        } 

        public Ranks GetCardValue
        {
            get
            {
                return this.rank;
            }
        }
    }

}
