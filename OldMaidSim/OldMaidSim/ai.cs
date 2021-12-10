using System.Collections.Generic;

namespace OldMaidSim {
    class ai : player {

        public ai(List<Card> dealtCards) : base(dealtCards) {

            bool[] delFlg = new bool[dealtCards.Count];  // 捨てるカードフラグ

            for (int i = 0; i < dealtCards.Count; i++) {
                for (int j = i + 1; j < dealtCards.Count; j++) {
                    if ((dealtCards[i].number == dealtCards[i].number) && (delFlg[j] == false)) {
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
        }


        // 隣からカードを1枚引く



        // そろっているカードを捨てる


    }
}
