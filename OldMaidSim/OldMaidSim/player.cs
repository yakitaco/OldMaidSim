using System.Collections.Generic;

namespace OldMaidSim {
    class player {
        public List<Card> myCard;

        public player(List<Card> dealtCards) {
            myCard = dealtCards;
        }

        public virtual void pullCard(List<Card> beseCard) {
        }

        public virtual void removeCard() {
        }

    }
}
