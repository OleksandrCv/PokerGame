using System.Collections.Generic;
using System.Linq;

namespace PokerLibrary
{
    public static class Converter
    {
        /// <summary>
        /// Convertion of player data
        /// </summary>
        /// <param name="pokerCollection">List of strings with players data.(Sally, AC, 10C, 5C, 8S, 2C)</param>
        /// <returns>List of Player objects</returns>
        public static List<Player> ConvertToEntities(List<string> pokerCollection) 
        {
            var playerCollection = new List<Player>();

            foreach (var pokerHand in pokerCollection)
            {
                var playCardCollection = new List<Card>();
                var formattedPlayerData = pokerHand.Replace(" ", string.Empty);
                var playerName = formattedPlayerData.Split(',')[0].Trim();
                var playerCards = formattedPlayerData.Substring(playerName.Length + 1).Trim();
                var playerCardsCollection = playerCards.Split(',').Select(p => p.Trim()).ToList();

                foreach (var card in playerCardsCollection)
                {
                    var playerCardtest = new Card(card);
                    playCardCollection.Add(playerCardtest);
                }

                var player = new Player(playerName, playCardCollection);
                playerCollection.Add(player);
            }
            return playerCollection;
        }
    }
}
