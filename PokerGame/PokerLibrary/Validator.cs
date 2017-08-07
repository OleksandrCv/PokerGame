using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PokerLibrary
{
    public static class Validator
    {
        /// <summary>
        /// Validate the format of input for one player data
        /// </summary>
        /// <param name="playerHand"></param>
        /// <returns>bool for valid or not</returns>
        public static bool ValidateFormat(string playerHand) 
        {
            const int numberOfGroups = 11;
            var isValid = false;
            var formattedPlayerHand = playerHand.Replace(" ",string.Empty ).ToUpperInvariant();
            var expression = @"\w+,([2-9]|10|[|J|Q|K|A])([H|C|S|D]),([2-9]|10|[|J|Q|K|A])([H|C|S|D]),([2-9]|10|[|J|Q|K|A])([H|C|S|D]),([2-9]|10|[|J|Q|K|A])([H|C|S|D]),([2-9]|10|[|J|Q|K|A])([H|C|S|D])";

            Regex regex = new Regex(expression);

            MatchCollection matches = regex.Matches(formattedPlayerHand);
            if (matches.Count > 0) {
                foreach (Match match in matches) {
                    if (match.Groups.Count == numberOfGroups)
                        isValid = true;
                }
            }

            return isValid;
        }

        /// <summary>
        /// Check provided cards for meeting the criteria of the game
        /// </summary>
        /// <param name="players">List of PlayerHand objects with players data</param>
        /// <returns>bool for valid or not</returns>
        public static bool IsValidGameRules(List<Player> players)
        {
            var isDuplicatedCards = players
                .SelectMany(x => x.Cards)
                .GroupBy(x => new { x.Rank, x.Suit })
                .Any(x => x.Count() > 1);

            if (isDuplicatedCards)
            {
                Console.WriteLine("Duplicate cards are not acceptable");
            }

            return !isDuplicatedCards;
        }

        /// <summary>
        /// Check validation of format for the collection of player data
        /// </summary>
        /// <param name="players">List of string with players data</param>
        /// <returns>bool for valid or not</returns>
        public static bool CheckInputFormat(List<string> players)
        {
            //Check validation format rules
            var isValid = true;
            foreach (var playerCombination in players)
            {
                var isValidFormat = Validator.ValidateFormat(playerCombination);

                if (!isValidFormat)
                {
                    Console.WriteLine("Validation failed for {0}. Please provide correct format.", playerCombination);
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }
    }
}
