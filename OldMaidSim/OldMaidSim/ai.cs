using System;
using System.Collections.Generic;

namespace OldMaidSim {
    class ai : player {
        List<Card> myCard;
        Random rnd = new System.Random();

        public ai(List<Card> dealtCards) : base(dealtCards) {

            bool[] delFlg = new bool[dealtCards.Count];  // 捨てるカードフラグ

            for (int i = 0; i < dealtCards.Count; i++) {
                for (int j = i + 1; j < dealtCards.Count; j++) {
                    if ((dealtCards[i].number == dealtCards[j].number) && (delFlg[j] == false)) {
                        delFlg[i] = true;
                        delFlg[j] = true;
                        break;
                    }
                }
            }

            // 後ろから削除
            for (int i = dealtCards.Count - 1; i >= 0; i--) {
                if (delFlg[i] == true) dealtCards.RemoveAt(i);
            }
            myCard = dealtCards;
        }


        // 隣からカードを1枚引く
        public override void pullCard(List<Card> beseCard){
            int read = rnd.Next(0, beseCard.Count);
            myCard.Add(beseCard[read]);
            beseCard.RemoveAt(read);
        }


        // そろっているカードを捨てる


    }
}
