using System;
using System.Collections.Generic;

namespace DeckOfCards {
    public class Deck<T> where T : Card {
        private List<T> cards; //all cards, dealt or not (distribuited or not)
        private int dealtIndex = 0; // marks first undealt car

        public void SetDeckOfCards(List<T> deckOfCards) {
            cards = deckOfCards;
        }

        public void Shuffle() {
            Random rnd = new Random();
            for (int i = 0; i < cards.Count; i++) {
                int j = i < cards.Count - i - 1 ? rnd.Next(i, cards.Count - i - 1) : rnd.Next(cards.Count - i - 1, i);
                T card1 = cards[i];
                T card2 = cards[j];
                cards[j] = card1;
                cards[i] = card2;
            }
        }

        public int RemainingCards() {
            return cards.Count - dealtIndex;
        }

        public T[] DealHand(int number) {
            if (RemainingCards() < number) {
                return null;
            }

            T[] hand = (T[]) new Card[number];
            int count = 0;

            while (count < number) {
                T card = DealCard();
                if (card != null) {
                    hand[count] = card;
                    count++;
                }
            }

            return hand;
        }

        public T DealCard() {
            if (RemainingCards() == 0) {
                return null;
            }

            T card = cards[dealtIndex];
            card.MarkUnavailable();
            dealtIndex++;

            return card;
        }
    }
}