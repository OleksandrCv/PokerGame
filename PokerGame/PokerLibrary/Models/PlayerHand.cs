using System.Collections.Generic;

namespace PokerLibrary
{
    public class Player
    {
        private List<Card> cards;

        public string Name { get; set; }
        public List<Card> Cards
        { 
            get { 
                if (cards != null) return cards;
                else return new List<Card>();
            } 
            set {
                cards = value;
            }
        }

        public Player(string name, List<Card> cards)
        {
            Name = name;
            Cards = cards;
        }
    }
}
