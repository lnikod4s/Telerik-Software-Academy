using System.Collections.Generic;

namespace TDD.Hand.ToString.PokerDemo
{
    public interface IHand
    {
        IList<ICard> Cards { get; }
        string ToString();
    }
}