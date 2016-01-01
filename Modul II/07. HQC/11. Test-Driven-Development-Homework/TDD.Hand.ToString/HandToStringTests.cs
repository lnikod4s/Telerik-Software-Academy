using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.Hand.ToString.PokerDemo;

namespace TDD.Hand.ToString
{
    [TestClass]
    public class HandToStringTests
    {
        private readonly List<CardFace> _cardFaces = new List<CardFace>
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

        private readonly List<CardSuit> _cardSuits = new List<CardSuit>
        {
            CardSuit.Clubs,
            CardSuit.Diamonds,
            CardSuit.Hearts,
            CardSuit.Spades
        };

        [TestMethod]
        public void TestHandToStringWithEmptyCardsSet()
        {
            var cards = new List<ICard>();
            var hand = new PokerDemo.Hand(cards);
            Assert.AreEqual("[]", hand.ToString());
        }

        [TestMethod]
        public void TestHandToStringWithOneCardSet()
        {
            var face = CardFace.Eight;
            var suit = CardSuit.Diamonds;
            var card = new Card(face, suit);
            var cards = new List<ICard> {card};
            var hand = new PokerDemo.Hand(cards);
            Assert.AreEqual(string.Format("[{0}]", card), hand.ToString());
        }

        [TestMethod]
        public void TestHandToStringWithValidDeck()
        {
            var cards =
                (from face in _cardFaces from suit in _cardSuits select new Card(face, suit)).Cast<ICard>().ToList();
            var hand = new PokerDemo.Hand(cards);
            Assert.AreEqual(string.Format("[{0}]", string.Join(", ", cards)), hand.ToString());
        }

        [TestMethod]
        public void TestHandToStringWithValidDeckButWrongFormatting1()
        {
            var cards =
                (from face in _cardFaces from suit in _cardSuits select new Card(face, suit)).Cast<ICard>().ToList();
            var hand = new PokerDemo.Hand(cards);
            Assert.AreNotEqual(string.Format("[{0}]", string.Join(",", cards)), hand.ToString());
        }

        [TestMethod]
        public void TestHandToStringWithValidDeckButWrongFormatting2()
        {
            var cards =
                (from face in _cardFaces from suit in _cardSuits select new Card(face, suit)).Cast<ICard>().ToList();
            var hand = new PokerDemo.Hand(cards);
            Assert.AreNotEqual(string.Format("[{0}]", string.Join(" ,", cards)), hand.ToString());
        }

        [TestMethod]
        public void TestHandToStringWithValidDeckButWrongFormatting3()
        {
            var cards =
                (from face in _cardFaces from suit in _cardSuits select new Card(face, suit)).Cast<ICard>().ToList();
            var hand = new PokerDemo.Hand(cards);
            Assert.AreNotEqual(string.Format("[{0}]", string.Join(" , ", cards)), hand.ToString());
        }
    }
}