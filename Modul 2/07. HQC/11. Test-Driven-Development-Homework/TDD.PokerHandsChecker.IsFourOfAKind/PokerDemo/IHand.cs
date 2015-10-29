using System.Collections.Generic;

namespace TDD.PokerHandsChecker.IsFourOfAKind.PokerDemo
{
    public interface IHand
    {
        IList<ICard> Cards { get; }
        string ToString();
    }
}