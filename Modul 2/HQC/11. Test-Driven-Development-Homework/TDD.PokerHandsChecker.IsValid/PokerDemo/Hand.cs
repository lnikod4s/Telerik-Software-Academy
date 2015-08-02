using System.Collections.Generic;
using System.Text;

namespace TDD.PokerHandsChecker.IsValid.PokerDemo
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
            var handToString = new StringBuilder();
            handToString.AppendFormat("[" + string.Join(", ", Cards) + "]");
            return handToString.ToString();
        }
    }
}