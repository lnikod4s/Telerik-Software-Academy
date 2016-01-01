using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.Card.ToString.PokerDemo;

namespace TDD.Card.ToString
{
    [TestClass]
    public class CardToStringTests
    {
        [TestMethod]
        public void TestCardToStringWithValidData()
        {
            var cardFace = new List<CardFace>
            {
                CardFace.Two,
                CardFace.Three,
                CardFace.Four,
                CardFace.Five,
                CardFace.Six,
                CardFace.Seven,
                CardFace.Eight,
                CardFace.Nine,
                CardFace.Ten,
                CardFace.Jack,
                CardFace.Queen,
                CardFace.King,
                CardFace.Ace
            };

            var cardSuit = new List<CardSuit>
            {
                CardSuit.Clubs,
                CardSuit.Diamonds,
                CardSuit.Hearts,
                CardSuit.Spades
            };

            foreach (var face in cardFace)
            {
                foreach (var suit in cardSuit)
                {
                    var card = new PokerDemo.Card(face, suit);
                    Assert.AreEqual(string.Format("{0}{1}", face, suit), card.ToString());
                }
            }
        }

        [TestMethod]
        public void TestCardToStringWithInvalidData1()
        {
            const CardFace face = CardFace.Ace;
            const CardSuit suit = CardSuit.Diamonds;
            var card = new PokerDemo.Card(face, suit);
            Assert.AreNotEqual(string.Empty, card.ToString());
        }

        [TestMethod]
        public void TestCardToStringWithInvalidData2()
        {
            const CardFace face = CardFace.Ace;
            const CardSuit suit = CardSuit.Diamonds;
            var card = new PokerDemo.Card(face, suit);
            Assert.AreNotEqual(string.Format("{0} {1}", face, suit), card.ToString());
        }

        [TestMethod]
        public void TestCardToStringWithInvalidData3()
        {
            const CardFace face = CardFace.Ace;
            const CardSuit suit = CardSuit.Diamonds;
            var card = new PokerDemo.Card(face, suit);
            Assert.AreNotEqual(string.Format(" {0} {1}", face, suit), card.ToString());
        }

        [TestMethod]
        public void TestCardToStringWithInvalidData4()
        {
            const CardFace face = CardFace.Ace;
            const CardSuit suit = CardSuit.Diamonds;
            var card = new PokerDemo.Card(face, suit);
            Assert.AreNotEqual(string.Format("{0} {1} ", face, suit), card.ToString());
        }

        [TestMethod]
        public void TestCardToStringWithInvalidData5()
        {
            const CardFace face = CardFace.Ace;
            const CardSuit suit = CardSuit.Diamonds;
            var card = new PokerDemo.Card(face, suit);
            Assert.AreNotEqual(string.Format("{0},{1}", face, suit), card.ToString());
        }
    }
}