namespace TDD.PokerHandsChecker.IsFourOfAKind.PokerDemo
{
    public interface ICard
    {
        CardFace Face { get; }
        CardSuit Suit { get; }
        string ToString();
    }
}