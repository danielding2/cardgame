using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame.GUI.Players;
using CardGame.GUI.General;

namespace CardGame.GUI.GameMaster
{
    public class Admin
    {
        private Deck playingDeck = new Deck();
        private List<Player> players = new List<Player>();
        private List<int> playerScores = new List<int>();
        private Player dealer = new Player();
        public bool PlayingDeck { get; set; }

        public Card DealerVisibleCard
        {
            get
            {
                return dealer.ShowHand()[0];
            }
        }

        public Card DealerLastCard
        {
            get
            {
                return dealer.ShowHand()[dealer.ShowHand().Count - 1];
            }
        }

        public List<Card> getDealerCards()
        {
            return dealer.ShowHand();
        }

        public Admin()
        {
            PlayingDeck = false;
        }

        public Admin(Player player1)
        {
            players.Add(player1);
        }

        public void AddPlayer(Player newPlayer)
        {
            players.Add(newPlayer);
        }

        public void DealFirstTwoCards()
        {
            playingDeck.Shuffle();

            dealer.GetCard(playingDeck);
            dealer.GetCard(playingDeck);

            for (int i = 0; i < players.Count; i++)
            {
                players[i].GetCard(playingDeck);
                players[i].GetCard(playingDeck);
            }
        }

        public Card DealCard()
        {
            return playingDeck.DrawCard();
        }

        public void StartNewDeal()
        {
            playingDeck = new Deck();
            for (int i = 0; i < players.Count; i++)
            {
                players[i].FoldCards();
                dealer.FoldCards();
            }
            DealFirstTwoCards();
        }

        private int GetHandScore(List<Card> cards)
        {
            int score = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                int cardValue = (int)cards[i].GetCardValue;
                if (cardValue > 10)
                {
                    cardValue = 10;
                }
                score += cardValue;
            }

            if (score > 21)
            {
                score = -1;
            }

            //Blackjack returns 0
            if (cards.Count == 2 && ((cards[0].GetCardValue == Ranks.ACE && (int)cards[1].GetCardValue >= 10) || (cards[1].GetCardValue == Ranks.ACE && (int)cards[0].GetCardValue >= 10)))
            {
                return 0;
            }

            return score;
        }

        public string DisplayScores()
        {
            StringBuilder showScores = new StringBuilder();
            for (int i = 0; i < players.Count; i++)
            {
                showScores.AppendLine(String.Format("Player {0} score: {1}", i, playerScores[i]));
            }
            return showScores.ToString();
        }

        public void GiveDealerACard()
        {
            dealer.GetCard(playingDeck);
        }

        public int GetDealerScore()
        {
            return dealer.GetHandValue();
        }


    }
}
