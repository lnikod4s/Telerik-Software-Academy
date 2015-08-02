namespace TDD.PokerHandsChecker.IsFlush.PokerDemo
{
    public interface ICard
    {
        CardFace Face { get; }
        CardSuit Suit { get; }
        string ToString();
    }
}