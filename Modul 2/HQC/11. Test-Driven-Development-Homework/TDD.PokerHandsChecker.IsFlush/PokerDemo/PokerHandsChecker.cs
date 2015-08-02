using System;

namespace TDD.PokerHandsChecker.IsFlush.PokerDemo
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
            throw new NotImplementedException();
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
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
                var fifthCard = handCards[i + 4];
                if (firstCard.Suit == secondCard.Suit &&
                    secondCard.Suit == thirdCard.Suit &&
                    thirdCard.Suit == fourthCard.Suit &&
                    fourthCard.Suit == fifthCard.Suit &&
                    secondCard.Face == firstCard.Face + 1 &&
                    thirdCard.Face == secondCard.Face + 1 &&
                    fourthCard.Face == thirdCard.Face + 1 &&
                    fifthCard.Face == fourthCard.Face + 1)
                {
                    return true;
                }
            }

            return false;
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