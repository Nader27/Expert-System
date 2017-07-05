using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Expert_System
{
    public partial class Rules : Form
    {
        private string device;
        private string problem;
        private string question;
        private string solution;
        private int cf;
        private Stream fileStream;
        private Start SF;
        public Rules(Start SF)
        {
            this.SF = SF;
            InitializeComponent();
            load();
        }

        public void load()
        {
            fileStream = new FileStream("Rules.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader SR = new StreamReader(fileStream);
            SF.Ruless = new List<Rule>();
            SF.Ruless.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            while (SR.Peek() >= 0)
            {
                device = SR.ReadLine();
                question = SR.ReadLine();
                problem = SR.ReadLine();
                solution = SR.ReadLine();
                cf = int.Parse(SR.ReadLine());
                dataGridView1.Rows.Add(device, question, problem, solution, cf.ToString());
                SF.Ruless.Add(new Rule(device, question, problem, solution, cf));
            }
            SR.Close();
            fileStream.Close();
        }

        private void save()
        {
            fileStream = new FileStream("Rules.txt", FileMode.Create, FileAccess.Write);
            StreamWriter SW = new StreamWriter(fileStream);
            SF.Ruless = new List<Rule>();
            SF.Ruless.Clear();
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                if (!Row.IsNewRow)
                {
                    device = Row.Cells["_Device"].Value.ToString();
                    question = Row.Cells["_Question"].Value.ToString();
                    problem = Row.Cells["_Problem"].Value.ToString();
                    solution = Row.Cells["_Solution"].Value.ToString();
                    cf = int.Parse(Row.Cells["_Cf"].Value.ToString());
                    SW.WriteLine(device);
                    SW.WriteLine(question);
                    SW.WriteLine(problem);
                    SW.WriteLine(solution);
                    SW.WriteLine(cf.ToString());
                    SF.Ruless.Add(new Rule(device, question , problem, solution, cf));
                }
            }
            SW.Flush();
            SW.Close();
            fileStream.Close();
        }

        private void Rules_FormClosing(object sender, FormClosingEventArgs e)
        {
            save();
        }

        private void dataGridView1_CellValidating(object sender,
        DataGridViewCellValidatingEventArgs e)
        {
            string headerText =
                dataGridView1.Columns[e.ColumnIndex].HeaderText;

            // Confirm that the cell is not empty.
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                dataGridView1.Rows[e.RowIndex].ErrorText =
                    headerText + " must not be empty";
                e.Cancel = true;
            }
        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            if (string.IsNullOrEmpty(row.Cells[dataGridView1.Columns[0].Index].Value.ToString()) ||
            string.IsNullOrEmpty(row.Cells[dataGridView1.Columns[1].Index].Value.ToString()) ||
            string.IsNullOrEmpty(row.Cells[dataGridView1.Columns[2].Index].Value.ToString()) ||
            string.IsNullOrEmpty(row.Cells[dataGridView1.Columns[3].Index].Value.ToString()) ||
            string.IsNullOrEmpty(row.Cells[dataGridView1.Columns[4].Index].Value.ToString()))
                e.Cancel = true;
        }

        void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.   
            dataGridView1.Rows[e.RowIndex].ErrorText = String.Empty;
        }
    }
}
