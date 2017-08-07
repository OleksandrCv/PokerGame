using System.Collections.Generic;

namespace PokerLibrary
{
    public class Poker
    {
        private List<Player> pokerData {get; set;}
        private bool isValid { get; set; }

        /// <summary>
        /// Initialization  and conversion of players data
        /// </summary>
        /// <param name="players">List of string with player data</param>
        public void Init(List<string> players) 
        {
            isValid = false;
            pokerData = null;

            var isValidFormat = Validator.CheckInputFormat(players);
            if (!isValidFormat) {
                return;
            }
            var convertedPokerData = Converter.ConvertToEntities(players);

            var isValidGameRules = Validator.IsValidGameRules(convertedPokerData);
            if (!isValidGameRules) {
                return;
            }

            isValid = true;
            pokerData = convertedPokerData;
            
        }
        
        /// <summary>
        /// Get the winners for the PokerGame
        /// </summary>
        /// <returns>List of winner(s)</returns>
        public List<string> DefineWinner()
        {
            var result = new List<string>();

            if (isValid)
            {
                var winHadler = Helper.HandlerCreator();
                result = winHadler.HandleRequest(pokerData);
            }

            return result;
        }
    }
}
