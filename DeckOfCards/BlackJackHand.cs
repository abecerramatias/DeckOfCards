using System;
using System.Collections;
using System.Collections.Generic;

namespace DeckOfCards {
    public class BlackJackHand : Hand<BlackJackCard> {
        public new int Score() {
            List<int> scores = PossibleScores();
            int maxUnder = Int32.MinValue;
            int minOver = Int32.MaxValue;
            foreach (int score in scores) {
                if (score > 21 && score < minOver) {
                    minOver = score;
                }
                else if (score <= 21 && score > maxUnder) {
                    maxUnder = score;
                }
            }

            return maxUnder == Int32.MinValue ? minOver : maxUnder;
        }

        private List<int> PossibleScores() {
            List<int> scores = new List<int>();
            if (cards.Count == 0)
            {
                return scores;
            }

            foreach (var card in cards) {
                AddCardToScoreList(card, scores);
            }

            return scores;
        }

        private void AddCardToScoreList(BlackJackCard card, List<int> scores) {
            if (scores.Count == 0) {
                scores.Add(0);
            }

            int length = scores.Count;
            for (int i = 0; i < length; i++) {
                int score = scores[i];
                scores[i] = score + card.MinValue();
                if (card.MinValue() != card.MaxValue()) {
                    scores.Add(score + card.MaxValue());
                }
            }
        }

        public bool Busted() {
            return Score() > 21;
        }

        public bool Is21() {
            return Score() == 21;
        }

        public bool IsBlackJack() {
            if (cards.Count != 2) {
                return false;
            }

            BlackJackCard first = cards[0];
            BlackJackCard second = cards[1];
            return (first.IsAce() && second.IsFaceCard()) || (second.IsAce() && first.IsFaceCard());
        }
    }
}