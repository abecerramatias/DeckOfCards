namespace DeckOfCards {
    public class BlackJackCard : Card {
        public BlackJackCard(int c, Suit s) : base(c, s) {
        }

        public override int Value() {
            if (IsAce()) { // Ace
                return 1;
            }
            else if (FaceValue >= 11 && FaceValue <= 13) { // Face card
                return 10;
            }
            else { // Number card
                return FaceValue;
            }
        }

        public int MinValue() {
            if (IsAce()) { // Ace
                return 1;
            }
            else {
                return Value();
            }
        }

        public int MaxValue() {
            if (IsAce()) { // Ace
                return 11;
            }
            else {
                return Value();
            }
        }

        public bool IsAce() {
            return FaceValue == 1;
        }

        public bool IsFaceCard() {
            return FaceValue >= 11 && FaceValue <= 13;
        }
    }
}