using System.Linq;

namespace PokerLibrary
{
    public static class Helper
    {
        /// <summary>
        /// Define Flush combination - five cards of the same Suit
        /// </summary>
        /// <param name="player">Player object</param>
        /// <returns></returns>
        public static bool IsFlush(Player player) 
        {
            var playerCardCollection = player.Cards;
            var isFlush = playerCardCollection.GroupBy(pc => pc.Suit).Count() == 1;
            
            return isFlush ? true : false;
        }

        /// <summary>
        /// Define combination with tree or two identical Ranks
        /// </summary>
        /// <param name="player">Player object</param>
        /// <param name="repetetiveRank">number of Ranks to match</param>
        /// <returns></returns>
        public static bool isCardsOfAKind(Player player, int repetetiveRank)
        {
            var groupedCollection = player.Cards.GroupBy(pc => pc.Rank).Select(obj => new { Rank = obj.Key, Count = obj.Count() });
            return groupedCollection.Where(el => el.Count == repetetiveRank).Count() > 0 ? true : false;
        }

        /// <summary>
        /// Get the highest card for one player
        /// </summary>
        /// <param name="player">Player object</param>
        /// <returns>Number of Highest card</returns>
        public static int GetHighestRank(Player player) {
            var cardCollectiom = player.Cards;
            var rank = (int)cardCollectiom.OrderByDescending(pc => pc.Rank).FirstOrDefault().Rank;
            return rank;
        }

        /// <summary>
        /// Create the chain of objects with successors
        /// </summary>
        /// <returns>First Handler</returns>
        public static WinHandler HandlerCreator()
        {
            WinHandler flushCombo = new FlushHandler();
            WinHandler threeOfAKindCombo = new ThreeOfAKindHandler();
            WinHandler onePairCombo = new OnePairHandler();
            WinHandler highCardCombo = new HighCardHandler();

            flushCombo.SetSuccessor(threeOfAKindCombo);
            threeOfAKindCombo.SetSuccessor(onePairCombo);
            onePairCombo.SetSuccessor(highCardCombo);
            return flushCombo;
        }

    }
}
