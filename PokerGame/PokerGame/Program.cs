using PokerLibrary;
using System;
using System.Collections.Generic;

namespace PokerGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Poker Stars");

            var input1 = "Joe, 3H, 4D, 5H, 6H, 8H";
            var input2 = "Bob, JC, AD, 5S, 8C, 10D";
            var input3 = "Sally, AC, 10C, 5C, 8S, 2C";
            var inputCollection = new List<string>();
            inputCollection.Add(input1);
            inputCollection.Add(input2);
            inputCollection.Add(input3);

            var pokerGame = new Poker();
            pokerGame.Init(inputCollection);
            
            var result = pokerGame.DefineWinner();

            if (result.Count > 0 ) {
                foreach (var item in result)
                {
                    Console.WriteLine(item.ToString());
                }
            } else {
                Console.WriteLine("Sorry, but we have no winning combination. Please enter correct input data.");
            }
 
            Console.ReadLine();
        }
    }
}
