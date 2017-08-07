using PokerLibrary;
using System;
using System.Collections.Generic;

namespace PokerGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Poker Stars!");

            var players = new List<string>()
			{
				"Joe, 3H, 4H, 5S, 6C, 8H",
				"Bob, JC, 3D, 3S, 8C, 10D",
                "Sally, AC, 10C, 5C, 2S, 2C"
			};

            Console.WriteLine("Input:");
			foreach (var player in players)
			{
				Console.WriteLine(player);
			}

            var pokerGame = new Poker();
            pokerGame.Init(players);
            
            var result = pokerGame.DefineWinner();

            if (result.Count > 0) 
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item.ToString());
                }
            } else 
            {
                Console.WriteLine("Sorry, but we have no winning combination. Please enter correct input data.");
            }
 
            Console.ReadLine();
        }
    }
}
