using System.Collections.Generic;

namespace TDD.Card.ToString.PokerDemo
{
    public interface IHand
    {
        IList<ICard> Cards { get; }
        string ToString();
    }
}