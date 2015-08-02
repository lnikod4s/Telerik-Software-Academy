using NUnit.Framework;
using Santase.Logic.Cards;

namespace SantaseGameEngine.Deck.NUnitTests
{
    [TestFixture]
    public class DeckNUnitTests
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(16)]
        [TestCase(17)]
        [TestCase(18)]
        [TestCase(19)]
        [TestCase(20)]
        [TestCase(21)]
        [TestCase(22)]
        [TestCase(23)]
        [TestCase(24)]
        public void TestDeckCtorWithInvalidCardsCount(int cardsCount)
        {
            var deck = new Santase.Logic.Cards.Deck();

            if (cardsCount == 24)
            {
                Assert.AreEqual(cardsCount, deck.CardsLeft);
            }
            else
            {
                Assert.AreNotEqual(cardsCount, deck.CardsLeft);
            }

        }

        [Test]
        public void TestDeckChangeTrumpCard()
        {
            var card = new Card(CardSuit.Club, CardType.Jack);
            var deck = new Santase.Logic.Cards.Deck();
            deck.ChangeTrumpCard(card);
            Assert.AreEqual(card, deck.GetTrumpCard);
        }

        [Test]
        public void TestDeckGetNextCard()
        {
            var deck = new Santase.Logic.Cards.Deck();
            var card = deck.GetNextCard();
            Assert.AreEqual(23, deck.CardsLeft);
        }

        [TestCase(25)]
        [ExpectedException]
        public void TestDeckGetNextCardWhenDeckIsEmpty(int count)
        {
            var deck = new Santase.Logic.Cards.Deck();
            for (int i = 0; i < count; i++)
            {
                var card = deck.GetNextCard();
            }
        }
    }
}
