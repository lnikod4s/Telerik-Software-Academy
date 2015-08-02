namespace TDD.Card.ToString.PokerDemo
{
    public class Card : ICard
    {
        public Card(CardFace face, CardSuit suit)
        {
            Face = face;
            Suit = suit;
        }

        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public override string ToString()
        {
            var cardToString = string.Format("{0}{1}", Face, Suit);
            return cardToString;
        }
    }
}