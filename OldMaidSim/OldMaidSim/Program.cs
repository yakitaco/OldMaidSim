using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            Form1 form1 = new Form1();
            Form1.Form1Instance = form1; //Form1Instanceに代入
            Task.Run(() => {
                Application.Run(form1);
            });
            Thread.Sleep(1000);

            Card.deal();

            for (int i = 0; i < 5; i++) {
                dealCard[i] = new List<Card>();
            }

            int cnt = 0;
            Debug.WriteLine("Deck:" + Card.deckNum());
            while (Card.deckNum() > 0) {
                dealCard[cnt].Add(Card.drawFromDeck());
                cnt++;
                if (cnt == 5) cnt = 0;
            }

            Debug.WriteLine(dealCard[0].Count);
            for (int i = 0; i < 5; i++) {
                pList.Add(new ai(dealCard[i]));
                Form1.Form1Instance.dispCard(dealCard[i], i);
                Debug.WriteLine(dealCard[i].Count);
            }

            // メインループ
            cnt = 0;
            while (pList.Count > 1) {
                int ncnt = cnt + 1;
                if (ncnt == pList.Count) ncnt = 0;

                pList[cnt].pullCard(dealCard[ncnt]);
                Debug.WriteLine("Next:");
                Form1.Form1Instance.dispCard(dealCard[cnt], cnt);
                Form1.Form1Instance.dispCard(dealCard[ncnt], ncnt);

                

                Thread.Sleep(1000);

                cnt++;
                if (cnt == pList.Count) cnt = 0;

            }


        }
    }
}
