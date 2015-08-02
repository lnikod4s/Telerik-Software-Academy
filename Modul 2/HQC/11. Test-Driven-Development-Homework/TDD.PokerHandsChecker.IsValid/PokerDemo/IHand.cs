using System.Collections.Generic;

namespace TDD.PokerHandsChecker.IsValid.PokerDemo
{
    public interface IHand
    {
        IList<ICard> Cards { get; }
        string ToString();
    }
}