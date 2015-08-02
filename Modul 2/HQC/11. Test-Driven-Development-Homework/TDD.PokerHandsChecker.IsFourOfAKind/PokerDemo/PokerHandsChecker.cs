using System;

namespace TDD.PokerHandsChecker.IsFourOfAKind.PokerDemo
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            var handCards = hand.Cards;
            if (handCards.Count != 5)
            {
                return false;
            }
            for (var i = 0; i < handCards.Count; i += 5)
            {
                var firstCard = handCards[i];
                var secondCard = handCards[i + 1];
                var thirdCard = handCards[i + 2];
                var fourthCard = handCards[i + 3];
                if (firstCard.Suit != secondCard.Suit &&
                    secondCard.Suit != thirdCard.Suit &&
                    thirdCard.Suit != fourthCard.Suit &&
                    secondCard.Face == firstCard.Face &&
                    thirdCard.Face == secondCard.Face &&
                    fourthCard.Face == thirdCard.Face)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}