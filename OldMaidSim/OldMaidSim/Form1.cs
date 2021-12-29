using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace OldMaidSim {
    public partial class Form1 : Form {

        List<ListBox> lBox = new List<ListBox>();

        //Form1オブジェクトを保持するためのフィールド
        private static Form1 _form1Instance;

        //Form1オブジェクトを取得、設定するためのプロパティ
        public static Form1 Form1Instance {
            get {
                return _form1Instance;
            }
            set {
                _form1Instance = value;
            }
        }

        public Form1() {
            InitializeComponent();
            lBox.Add(listBox1);
            lBox.Add(listBox2);
            lBox.Add(listBox3);
            lBox.Add(listBox4);
            lBox.Add(listBox5);
            lBox.Add(listBox6);
            lBox.Add(listBox7);
            lBox.Add(listBox8);
            lBox.Add(listBox9);
            lBox.Add(listBox10);
            lBox.Add(listBox11);
            lBox.Add(listBox12);
        }

        delegate void delegate1(List<Card> cardList, int num);
        public void dispCard(List<Card> cardList, int num) {
            Invoke(new delegate1(FormAddMsg), cardList, num);
        }

        public void FormAddMsg(List<Card> cardList, int num) {
            lBox[num].Items.Clear();
            foreach (Card c in cardList) {
                lBox[num].Items.Add(c.suit + "/" + c.number);
                Debug.WriteLine(c.suit + "/" + c.number);
            }
        }

    }
}
