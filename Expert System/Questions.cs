using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expert_System
{
    public partial class Questions : Form
    {
        List<Rule> ques;
        ComboBox[] comboBox;
        TextBox[] textBox;
        int SIZE;
        public Questions(List<Rule> Ruless, string device)
        {
            ques = Ruless.Where(r => r.device == device).ToList();
            SIZE = ques.Count();
            InitializeComponent();
            Label[] label = new Label[SIZE];
            comboBox = new ComboBox[SIZE];
            textBox = new TextBox[SIZE];
            Button[] button = new Button[SIZE];
            int i = 0;
            this.Size = new Size(600, 70 + 30 * SIZE);
            foreach (Rule Rule in ques.ToList())
            {
                label[i] = new Label();
                label[i].AutoSize = true;
                label[i].Location = new Point(10, 10 + 30 * i);
                label[i].Name = "label" + i;
                label[i].Size = new Size(400, 20);
                label[i].Text = Rule.question + " ?";
                Controls.Add(label[i]);

                comboBox[i] = new ComboBox();
                comboBox[i].FormattingEnabled = true;
                comboBox[i].DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox[i].Items.AddRange(new object[] { "Yes", "No" });
                comboBox[i].Location = new Point(410, 10 + 30 * i);
                comboBox[i].Name = "comboBox" + i;
                comboBox[i].Size = new Size(50, 20);
                Controls.Add(comboBox[i]);

                textBox[i] = new TextBox();
                textBox[i].Location = new Point(470, 10 + 30 * i);
                textBox[i].Name = "textBox" + i;
                textBox[i].Size = new Size(40, 20);
                Controls.Add(textBox[i]);

                button[i] = new Button();
                button[i].Location = new Point(520, 10 + 30 * i);
                button[i].Name = "button" + i;
                button[i].Text = "Why ?";
                button[i].Size = new Size(50, 20);
                button[i].Click += new EventHandler(this.why_Click);
                Controls.Add(button[i]);
                i++;
            }
        }

        private void why_Click(object sender, EventArgs e)
        {
            Button But = (Button)sender;
            string name = But.Name.Substring(6);
            int index = int.Parse(name);
            Rule rul = ques[index];
            MessageBox.Show("Because IF " + rul.question + " THEN problem is " + rul.problem + " CF = " + rul.cf.ToString(), "Why?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, List<int>> DIC = new Dictionary<string, List<int>>();
            List<string> ss = ques.Select(r => r.problem).Distinct().ToList();
            foreach (string s in ss)
            {
                List<Rule> lst = ques.FindAll(a => a.problem == s);
                List<int> ind = new List<int>();
                foreach (Rule r in lst)
                {
                    ind.Add(ques.FindIndex(q => q.question == r.question));
                }
                DIC.Add(s, ind);
            }
            int[] CF = new int[DIC.Count];
            int j = 0;
            foreach (string key in DIC.Keys)
            {
                int[] _cf = new int[DIC[key].Count];
                for (int i = 0; i < DIC[key].Count; i++)
                {
                    if (comboBox[DIC[key][i]].Text.ToString() == "Yes")
                    {
                        _cf[i] = int.Parse(textBox[DIC[key][i]].Text) * ques[DIC[key][i]].cf / 100;
                    }
                }
                CF[j] = 0;
                for (int i = 0; i < _cf.Length; i++)
                {
                    CF[j] += _cf[i] * (100 - CF[j]) / 100;
                }
                j++;
            }
            int Index = Array.FindIndex(CF, w => w == CF.Max());
            Soluton Soluton = new Soluton(ques[Index], CF[Index]);
            Hide();
            Soluton.ShowDialog();
            Close();
        }
    }
}
