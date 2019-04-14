using System;
using System.Runtime.ConstrainedExecution;

namespace DeckOfCards {
    public abstract class Card {
        private bool _available = true;

        /* number or face that's on card - a number 2 through 10, 
         * or 11 for Jack, 12 for Queen, 13 for King, or 1 for Ace 
         */
        protected int FaceValue;
        protected Suit suit;

        public Card(int c, Suit s) {
            FaceValue = c;
            suit = s;
        }

        public abstract int Value();
        public Suit Suit { get; }

        /* returns whether or not the card is available to be given out to someone */
        public bool IsAvailable() {
            return _available;
        }

        public void MarkUnavailable() {
            _available = false;
        }

        public void MarkAvailable() {
            _available = true;
        }

        public void Print() {
            String[] faceValues = {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
            Console.WriteLine(faceValues[FaceValue - 1]);
            switch (suit) {
                case Suit.Club:
                    Console.WriteLine("c");
                    break;
                case Suit.Heart:
                    Console.WriteLine("h");
                    break;
                case Suit.Diamond:
                    Console.WriteLine("d");
                    break;
                case Suit.Spade:
                    Console.WriteLine("s");
                    break;
            }

            Console.WriteLine(" ");
        }
    }
}