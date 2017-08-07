using PokerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibraryTests
{
    public static class TestHelper
    {
        public static List<Player> CreateData(bool validData) 
        {
            List<Player> players = new List<Player>();

            var card1 = validData ? new Card("9H") : new Card("8D");
            var card2 = new Card("8D");
            var card3 = new Card("AH");
            var card4 = new Card("JC");
            var card5 = new Card("KH");
            var cardList1 = new List<Card>();
            cardList1.Add(card1);
            cardList1.Add(card2);
            cardList1.Add(card3);
            cardList1.Add(card4);
            cardList1.Add(card5);
            var player1 = new Player("Joe", cardList1);

            var card6 = new Card("2C");
            var card7 = new Card("3C");
            var card8 = new Card("5C");
            var card9 = new Card("7S");
            var card10 = new Card("10C");
            var cardList2 = new List<Card>();
            cardList2.Add(card6);
            cardList2.Add(card7);
            cardList2.Add(card8);
            cardList2.Add(card9);
            cardList2.Add(card10);
            var player2 = new Player("Bob", cardList2);
            players.Add(player1);
            players.Add(player2);

            return players;
        
        }
    }
}
