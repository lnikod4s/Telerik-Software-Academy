using System.Collections.Generic;

namespace TDD.PokerHandsChecker.IsFlush.PokerDemo
{
    public interface IHand
    {
        IList<ICard> Cards { get; }
        string ToString();
    }
}