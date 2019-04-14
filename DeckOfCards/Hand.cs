using System;
using System.Collections;
using System.Collections.Generic;

namespace DeckOfCards {
    public class Hand<T> where T : Card {
        protected List<T> cards = new List<T>();

        public int Score() {
            int score = 0;
            foreach (T card in cards) {
                score += card.Value();
            }

            return score;
        }

        public void AddCard(T card) {
            cards.Add(card);
        }


        public void Print() {
            foreach (Card card in cards) {
                card.Print();
            }
        }
    }
}