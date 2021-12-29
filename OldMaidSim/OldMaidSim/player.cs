using System.Collections.Generic;

namespace OldMaidSim {
    class player {
        List<Card> myCard;

        public player(List<Card> dealtCards) {
            myCard = dealtCards;
        }

        public virtual void pullCard(List<Card> beseCard) {
        }

    }
}
