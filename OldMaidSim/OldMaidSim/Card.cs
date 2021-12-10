using System;
using System.Collections.Generic;
using System.Linq;

namespace OldMaidSim {

    public enum SUIT : int {
        None = 0,
        SPADE = 1,
        HEART = 2,
        DIAMOND = 3,
        CLUB = 4,
    }
    // トランプのカード
    class Card {

        static List<Card> deck = new List<Card>();
        public int number; // 数 (1-13 Jokerは0)
        public SUIT suit; // マーク(1-4 Jokerは0)

        // トランプの初期化
        static Card() {
            for (int tmpSuit = 0; tmpSuit < 5; tmpSuit++) {
                for (int tmpNum = 0; tmpNum < 14; tmpNum++) {
                    new Card(tmpNum, (SUIT)tmpSuit);
                }
            }
            new Card(0, (SUIT)0); // ジョーカー(1枚)

            deal();
        }

        Card(int _number, SUIT _suit) {
            number = _number;
            suit = _suit;
            deck.Add(this);
        }

        // 山から一枚引く
        public static Card drawFromDeck() {
            Card ret = null;
            if (deck.Count > 0) {
                ret = deck[0];
                deck.RemoveAt(0);
            }
            return ret;
        }

        // カードを捨てる
        public void getRid() {

        }

        // カードをシャッフル
        public static void deal() {
            deck = deck.OrderBy(i => Guid.NewGuid()).ToList();
        }

        public static int deckNum() {
            return deck.Count;
        }

    }



}
