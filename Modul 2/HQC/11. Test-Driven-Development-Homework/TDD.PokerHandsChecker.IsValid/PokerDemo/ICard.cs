namespace TDD.PokerHandsChecker.IsValid.PokerDemo
{
    public interface ICard
    {
        CardFace Face { get; }
        CardSuit Suit { get; }
        string ToString();
    }
}