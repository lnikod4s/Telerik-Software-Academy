using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.PokerHandsChecker.IsValid.PokerDemo;

namespace TDD.PokerHandsChecker.IsValid
{
    [TestClass]
    public class PokerHandsCheckerIsValidTests
    {
        private readonly IPokerHandsChecker _pokerHandsChecker = new PokerDemo.PokerHandsChecker();

        [TestMethod]
        public void TestOnHandWithNoCards()
        {
            var handWithNoCards = new Hand(new List<ICard>());
            var expected = false;
            var actual = _pokerHandsChecker.IsValidHand(handWithNoCards);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithFiveDifferentCards()
        {
            var handWithFiveDifferentCards = new Hand(new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            });

            var expected = true;
            var actual = _pokerHandsChecker.IsValidHand(handWithFiveDifferentCards);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithSixDifferentCards()
        {
            var handWithSixDifferentCards = new Hand(new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Spades)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsValidHand(handWithSixDifferentCards);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithTwoEqualCards()
        {
            var handWithTwoEqualCards = new Hand(new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsValidHand(handWithTwoEqualCards);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithFiveEqualCards()
        {
            var handWithFiveEqualCards = new Hand(new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsValidHand(handWithFiveEqualCards);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithTwoEqualPairOfCards()
        {
            var handWithTwoEqualPairOfCards = new Hand(new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsValidHand(handWithTwoEqualPairOfCards);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithTwoEqualOfFourCards()
        {
            var handWithTwoEqualOfFourCards = new Hand(new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsValidHand(handWithTwoEqualOfFourCards);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithTwoEqualOfSixCards()
        {
            var handWithTwoEqualOfSixCards = new Hand(new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsValidHand(handWithTwoEqualOfSixCards);
            Assert.AreEqual(expected, actual);
        }
    }
}