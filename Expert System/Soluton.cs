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
    public partial class Soluton : Form
    {
        Rule Rule;
        int cf;
        public Soluton(Rule Rule , int cf)
        {
            this.Rule = Rule;
            this.cf = cf;
            InitializeComponent();
            SolutiontextBox.Text = Rule.solution;
            ProblemtextBox.Text = Rule.problem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Because " + Rule.question +" in " + Rule.device + " With CF = " + cf, "How ?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
