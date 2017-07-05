namespace Expert_System
{
    partial class Rules
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this._Device = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Question = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Problem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Solution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Cf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._Device,
            this._Question,
            this._Problem,
            this._Solution,
            this._Cf});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(784, 561);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            // 
            // _Device
            // 
            this._Device.HeaderText = "Device";
            this._Device.Name = "_Device";
            // 
            // _Question
            // 
            this._Question.HeaderText = "Question";
            this._Question.Name = "_Question";
            this._Question.Width = 200;
            // 
            // _Problem
            // 
            this._Problem.HeaderText = "Problem";
            this._Problem.Name = "_Problem";
            this._Problem.Width = 200;
            // 
            // _Solution
            // 
            this._Solution.HeaderText = "Solution";
            this._Solution.Name = "_Solution";
            this._Solution.Width = 200;
            // 
            // _Cf
            // 
            this._Cf.HeaderText = "CF";
            this._Cf.Name = "_Cf";
            this._Cf.Width = 50;
            // 
            // Rules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Rules";
            this.Text = "Rules";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Rules_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Device;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Question;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Problem;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Solution;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Cf;
    }
}