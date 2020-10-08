using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DeckOfCardsTest
{

	// Define class.

	class DeckOfCardsTest
	{
		// Execution of app starts from here.
		public static void Main()

		{

			// Declare a variable.
			int a;

			// Create object of class DeckOfCards.
			var myDeckOfCards = new DeckOfCardsTest();

			// Set the card in random order.
			myDeckOfCards.Shuffle();

			Card[] hand1 = new Card[5];

			do
			{
				Console.WriteLine("Cards on " + "Hand........");
				for (var i = 0; i < 5; ++i)
				{
					hand1[i] = myDeckOfCards.DealCard();
					Console.WriteLine($"{hand1[i]}");
				}

				//check if hand get four of a kind
				if (myDeckOfCards.fourOfAKindCheck(hand1))

					//Display the string to user. 

					Console.WriteLine("It's Four " + "Of a Kind!");

				//Check if hand get the full house
				else if (myDeckOfCards.fullHouseCheck(hand1))
					Console.WriteLine("It's a Fullhouse");

				//Check if hand get the flush
				else if (myDeckOfCards.flushCheck(hand1))
					Console.WriteLine("Its a Flush");

				//check if hand get the straight
				else if (myDeckOfCards.straightCheck(hand1))
					Console.WriteLine("It's a Straight");

				//Check if hand get the three of a kind
				else if (myDeckOfCardsOfCards.threeOfAKindCheck(hand1))
					Console.WriteLine("It's a Three" + " Of a kind!");

				//Check if hand get the Two Pair 
				else if (myDeckOfCards.twoPairCheck(hand1))
					Console.WriteLine("It's a Two Pair");

				//Check if hand gets a pair
				else if (myDeckOfCards.aPairCheck(hand1))
					Console.WriteLine("It" + "s a Pairs!");

				else
					Console.WriteLine("Oh!" + "Youe have a No Pair!");

				//Call shuffle method to set the card in random order.

				myDeckOfCards.Shuffle();

				//Display the string to user. 
				Console.WriteLine("Enter 0 to" + " continue, -1 to exit: ");
				a = int.Parse(Console.ReadLine());
			}
			while (a != -1);


			Console.ReadLine();
		}
	}
}

