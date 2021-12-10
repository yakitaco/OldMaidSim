using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OldMaidSim {
    static class Program {

        static List<player> pList = new List<player>();

        static List<Card>[] dealCard = new List<Card>[5];

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Task.Run(() => {
                Application.Run(new Form1());
            });
            Thread.Sleep(1000);

            Card.deal();

            for (int i = 0; i < 5 ; i++) {
                dealCard[i] = new List<Card>();
            }

            for (int i = 0; i < 5 && Card.deckNum() > 0; i++) {
                dealCard[i].Add(Card.drawFromDeck());
            }

            for (int i = 0; i < 5; i++) {
                ai tmpAi = new ai(dealCard[i]);
                pList[i] = tmpAi;
            }

            // メインループ
            for (int i = 0; i < 5; i++) {
                // 



            }


            }
    }
}
