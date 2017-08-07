namespace PokerLibrary
{
    public class Card
    {
        public CardSuitEnum Suit { get; private set; }
        public CardRankEnum Rank { get; private set; }

        public Card(string input) { 
            Suit = InitSuit(input[input.Length - 1]);
            Rank = InitRank(input.Remove(input.Length - 1));
        }

        /// <summary>
        /// Initialize Suit
        /// </summary>
        /// <param name="suit">Card Suit in char format</param>
        /// <returns>Emnum representation of Suit</returns>
        private CardSuitEnum InitSuit(char suit)
        {
            switch (suit)
            {
                case 'H':
                    return CardSuitEnum.H;
                case 'C':
                    return CardSuitEnum.C;
                case 'S':
                    return CardSuitEnum.S;
                default:
                    return CardSuitEnum.D;
            }
        }

        /// <summary>
        /// Initialize Rank 
        /// </summary>
        /// <param name="rank">Card Rank in string format</param>
        /// <returns></returns>
        private CardRankEnum InitRank(string rank)
        {
            switch (rank)
            {
                case "J":
                    return CardRankEnum.J;
                case "Q":
                    return CardRankEnum.Q;
                case "K":
                    return CardRankEnum.K;
                case "A":
                    return CardRankEnum.A;
                default:
                    return (CardRankEnum)(int.Parse(rank));
            }
        }
        
    }
}
