using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.PokerHandsChecker.IsFlush.PokerDemo;

namespace TDD.PokerHandsChecker.IsFlush
{
    [TestClass]
    public class PokerHandsCheckerIsFlushTests
    {
        private readonly IPokerHandsChecker _pokerHandsChecker = new PokerDemo.PokerHandsChecker();

        [TestMethod]
        public void TestOnHandWithNoCards()
        {
            var handWithNoCards = new Hand(new List<ICard>());
            var expected = false;
            var actual = _pokerHandsChecker.IsFlush(handWithNoCards);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithFourDifferentCardsOnEqualSuit()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsFlush(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithThreeEqualOnSuitOfFiveCards()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>
            {
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsFlush(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithValidFullHouse()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>
            {
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsFlush(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithInvalidFullHouse()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>
            {
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsFlush(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithOnePair()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsFlush(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithTwoPair()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsFlush(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithTwoEqualOnSuitOfFiveCards()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsFlush(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithThreeOfAKind()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>
            {
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsFlush(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithFourOfAKind()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>
            {
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsFlush(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithFiveDifferentCardsOnEqualSuit()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>
            {
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds)
            });

            var expected = true;
            var actual = _pokerHandsChecker.IsFlush(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithTwoEqualOfFiveCardsOnEqualSuit()
        {
            var handWithTwoEqualOfFiveCardsOnEqualSuit = new Hand(new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsFlush(handWithTwoEqualOfFiveCardsOnEqualSuit);
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
            var actual = _pokerHandsChecker.IsFlush(handWithSixDifferentCards);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithTwoEqualCards()
        {
            var handWithTwoEqualCard = new Hand(new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsFlush(handWithTwoEqualCard);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithTwoEqualOnSuitCards()
        {
            var handWithTwoEqualCard = new Hand(new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsFlush(handWithTwoEqualCard);
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
            var actual = _pokerHandsChecker.IsFlush(handWithFiveEqualCards);
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
            var actual = _pokerHandsChecker.IsFlush(handWithTwoEqualPairOfCards);
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
            var actual = _pokerHandsChecker.IsFlush(handWithTwoEqualOfFourCards);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithTwoEqualOfSixCardsWithDifferentFaces()
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
            var actual = _pokerHandsChecker.IsFlush(handWithTwoEqualOfSixCards);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithTwoEqualOfSixCardsOnFiveWithEqualFaces()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsFlush(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithTwoEqualOfSixCardsOnEqualSuit()
        {
            var handWithTwoEqualOfSixCardsOnEqualSuit = new Hand(new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsFlush(handWithTwoEqualOfSixCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithValidStraight_1()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Clubs)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsFlush(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithValidStraight_2()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsFlush(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithValidStraight_3()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsFlush(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithHighCard_1()
        {
            var handWithTwoEqualOfSixCardsOnEqualSuit = new Hand(new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsFlush(handWithTwoEqualOfSixCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithHighCard_2()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsFlush(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithHighCard_3()
        {
            var handWithTwoEqualOfSixCardsOnEqualSuit = new Hand(new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsFlush(handWithTwoEqualOfSixCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithValidStraightFlush_1()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs)
            });

            var expected = true;
            var actual = _pokerHandsChecker.IsFlush(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithValidStraightFlush_2()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs)
            });

            var expected = false;
            var actual = _pokerHandsChecker.IsFlush(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOnHandWithValidStraightFlush_3()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs)
            });

            var expected = true;
            var actual = _pokerHandsChecker.IsFlush(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }
    }
}