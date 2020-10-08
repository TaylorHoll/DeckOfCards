
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DeckOfCardsTest
{
	class Card
	{
		private string Face { get; } //Card's face ("Ace", "Deuce"
		private string Suit { get; }

		public Card(string face, string suit)
		{
			Face = face;
			Suit = suit;
		}

		public override string ToString() => $"{Face} of {Suit}";
	}

}