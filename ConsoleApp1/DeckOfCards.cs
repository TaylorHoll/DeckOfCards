using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DeckOfCardsTest
{

	class DeckOfCards
	{

		private static Random randomNumbers = new Random();

		private const int NumberOfCards = 52;
		private Card[] deck = new Card[NumberOfCards];
		private int currentCard = 0;


		public DeckOfCards()
		{
			string[] faces = {"Ace", "Deuce", "Three", "Four", "Five", "Six",
				"Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
			string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

			for (var count = 0; count < deck.Length; ++count)
			{
				deck[count] = new Card(faces[count % 13], suits[count / 13]);
			}
		}

		public void Shuffle()
		{
			currentCard = 0;

			for (var first = 0; first < deck.Length; ++first)
			{

				var second = randomNumbers.Next(NumberOfCards);

				Card temp = deck[first];
				deck[first] = deck[second];
				deck[second] = temp;
			}
		}

		public Card DealCard()
		{
			if (currentCard < deck.Length)
			{
				return deck[currentCard++];
			}
			else
			{
				return null;
			}
		}

		private bool cardContains(Card[] hand, string value)
		{
			bool isPresent = false;

			for (int i = 0; i < hand.Length; i++)
			{

				Card icurrent = hand[i];

				string[] cardinf = icurrent.ToString().Split();

				if (cardinf[0] == value)
				{

					isPresent = true;
					break;
				}
			}


			return isPresent;
		}

		public bool aPairCheck(Card[] hand)
		{

			int counter = 1;


			for (int i = 0; i < hand.Length; i++)
			{
				counter = 1;
				Card icurrent = hand[i];
				string[] cardinf = icurrent.ToString().Split();

				for (int j = 0; j < hand.Length; j++)
				{
					if (i == j)
						continue;

					Card jCurrent = hand[j];
					string[] cardjnf = jCurrent.ToString().Split();

					if (cardinf[0] == cardjnf[0])
						counter++;
				}

				if (counter >= 2)
					return true;
			}
			return false;
		}

		public bool fourOfAKindCheck(Card[] hand)
		{
			int counter = 1;

			for (int i = 0; i < hand.Length; i++)
			{
				counter = 1;

				Card icurrent = hand[i];

				string[] cardinf = icurrent.ToString().Split();

				for (int j = 0; j < hand.Length; j++)
				{

					if (i == j)
						continue;
					Card jCurrent = hand[j];

					string[] cardjnf = jCurrent.ToString().Split();

					if (cardinf[0] == cardjnf[0])
						counter++;
				}

				if (counter >= 4)
					return true;
			}
			return false;
		}

		public bool fullHouseCheck(Card[] hand)
		{

			int counter = 1;
			Card first = null;

			for (int i = 0; i < hand.Length; i++)
			{
				counter = 1;
				Card icurrent = hand[i];

				string[] cardinf = icurrent.ToString().Split();

				for (int j = 0; j < hand.Length; j++)
				{

					if (i == j)
						continue;
					Card jCurrent = hand[j];

					string[] cardjnf = jCurrent.ToString().Split();

					if (cardinf[0] == cardjnf[0])
						counter++;
				}

				if (counter >= 3)
					first = hand[i];
			}

			if (first == null)
				return false;
			string[] firstinf = first.ToString().Split();

			for (int i = 0; i < hand.Length; i++)
			{
				counter = 1;

				Card icurrent = hand[i];

				string[] cardinf = icurrent.ToString().Split();

				for (int j = 0; j < hand.Length; j++)
				{
					if (i == j)
						continue;
					Card jCurrent = hand[j];

					string[] cardjnf = jCurrent.ToString().Split();

					if (cardinf[0] == cardjnf[0] && cardinf[0] != firstinf[0])
						counter++;
				}

				if (counter >= 2)
					return true;
			}
			return false;
		}

		public bool flushCheck(Card[] hand)
		{
			Card card = hand[0];
			string[] inf = card.ToString().Split();
			string suit = inf[2];

			for (int i = 0; i < hand.Length; i++)
			{
				Card icurrent = hand[i];

				string[] cardinf = icurrent.ToString().Split();

				if (cardinf[2] != suit)
					return false;
			}
			return true;
		}

		public bool straightCheck(Card[] hand)
		{

			if (cardContains(hand, "A"))
			{
				if (cardContains(hand, "2") && cardContains(hand, "3") && cardContains(hand, "4") && cardContains(hand, "5"))
					return true;
				else if (cardContains(hand, "10") && cardContains(hand, "J") && cardContains(hand, "Q") && cardContains(hand, "K"))
					return true;
			}
			else if (cardContains(hand, "2"))
			{
				if (cardContains(hand, "6")
					&& cardContains(hand, "3")
					&& cardContains(hand, "4")
					&& cardContains(hand, "5"))
					return true;
			}
			else if (cardContains(hand, "3"))
			{
				if (cardContains(hand, "6")
					&& cardContains(hand, "7")
					&& cardContains(hand, "4")
					&& cardContains(hand, "5"))
					return true;
			}
			else if (cardContains(hand, "4"))
			{
				if (cardContains(hand, "6")
					&& cardContains(hand, "7")
					&& cardContains(hand, "8")
					&& cardContains(hand, "5"))
					return true;
			}
			else if (cardContains(hand, "5"))
			{
				if (cardContains(hand, "6")
					&& cardContains(hand, "7")
					&& cardContains(hand, "8")
					&& cardContains(hand, "9"))
					return true;
			}
			else if (cardContains(hand, "6"))
			{
				if (cardContains(hand, "10")
					&& cardContains(hand, "7")
					&& cardContains(hand, "8")
					&& cardContains(hand, "9"))
					return true;
			}
			else if (cardContains(hand, "7"))
			{
				if (cardContains(hand, "10")
					&& cardContains(hand, "J")
					&& cardContains(hand, "8")
					&& cardContains(hand, "9"))
					return true;
			}
			else if (cardContains(hand, "8"))
			{
				if (cardContains(hand, "10")
					&& cardContains(hand, "J")
					&& cardContains(hand, "Q")
					&& cardContains(hand, "9"))
					return true;
			}
			else if (cardContains(hand, "9"))
			{
				if (cardContains(hand, "10")
					&& cardContains(hand, "J")
					&& cardContains(hand, "Q")
					&& cardContains(hand, "K"))
					return true;
			}
			return false;
		}

		public bool threeOfAKindCheck(Card[] hand)
		{
			int counter = 1;

			for (int i = 0; i < hand.Length; i++)
			{
				counter = 1;
				Card icurrent = hand[i];

				string[] cardinf = icurrent.ToString().Split();

				for (int j = 0; j < hand.Length; j++)
				{
					if (i == j)
						continue;

					Card jCurrent = hand[j];
					string[] cardjnf = jCurrent.ToString().Split();

					if (cardinf[0] == cardjnf[0])
						counter++;
				}

				if (counter >= 3)
					return true;
			}
			return false;
		}

		public bool twoPairCheck(Card[] hand)
		{
			int counter = 1;
			Card first = null;

			for (int i = 0; i < hand.Length; i++)
			{
				counter = 1;
				Card icurrent = hand[i];
				string[] cardinf = icurrent.ToString().Split();

				for (int j = 0; j < hand.Length; j++)
				{
					if (i == j)
						continue;
					Card jCurrent = hand[i];

					string[] cardjnf = jCurrent.ToString().Split();

					if (cardinf[0] == cardjnf[0])
						counter++;
				}
				if (counter >= 2)
					first = hand[i];
			}

			if (first == null)
				return false;
			string[] firstinf = first.ToString().Split();

			for (int i = 0; i < hand.Length; i++)
			{
				counter = 1;

				Card iCurrent = hand[i];

				string[] cardinf = iCurrent.ToString().Split();

				for (int j = 0; j < hand.Length; j++)
				{
					if (i == j)
						continue;
					Card jCurrent = hand[i];
					string[] cardjnf = jCurrent.ToString().Split();

					if (cardinf[0] == cardjnf[0] && cardinf[0] != firstinf[0])
						counter++;
				}

				if (counter >= 2)
					return true;
			}
			return false;
		}
	}
}
		