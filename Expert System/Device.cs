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
    public partial class Device : Form
    {
        public List<Rule> Ruless;
        public Device(List<Rule> Ruless)
        {
            this.Ruless = Ruless;
            int i = 0;
            int size = Ruless.Select(r => r.device).Distinct().Count();
            InitializeComponent();
            RadioButton[] devices = new RadioButton[size];
            if(size > 3)
            {
                groupBox1.Size = new Size(150,20 + 30 * size);
                this.Size = new Size(166,100 + 30 *size);
            }
            foreach (string device in Ruless.Select(r => r.device).Distinct().ToList())
            {
                devices[i] = new RadioButton();
                devices[i].AutoSize = true;
                devices[i].Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                devices[i].Location = new System.Drawing.Point(6, 20 + 30 * i);
                devices[i].Name = "device" + i;
                devices[i].Text = device;
                devices[i].CheckedChanged += new EventHandler(this.devices_CheckedChanged);
                groupBox1.Controls.Add(devices[i]);
                i++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RadioButton checkedButton = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            Questions Questions = new Questions(Ruless, checkedButton.Text);
            Hide();
            Questions.ShowDialog();
            Close();
        }

        private void devices_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
    }
}
