using System;
using System.Collections.Generic;

namespace TDD.Card.ToString.PokerDemo
{
    public class Hand : IHand
    {
        public Hand(IList<ICard> cards)
        {
            Cards = cards;
        }

        public IList<ICard> Cards { get; private set; }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}