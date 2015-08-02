namespace TDD.Hand.ToString.PokerDemo
{
    public interface ICard
    {
        CardFace Face { get; }
        CardSuit Suit { get; }
        string ToString();
    }
}