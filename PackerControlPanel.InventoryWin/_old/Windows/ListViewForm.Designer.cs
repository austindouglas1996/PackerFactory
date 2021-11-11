namespace PackerControlPanel.InventoryWin.Windows
{
    partial class ListViewForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.AscendingRBTN = new System.Windows.Forms.RadioButton();
            this.DescendingRBTN = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(370, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Sort By:";
            // 
            // AscendingRBTN
            // 
            this.AscendingRBTN.AutoSize = true;
            this.AscendingRBTN.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.AscendingRBTN.Location = new System.Drawing.Point(374, 56);
            this.AscendingRBTN.Name = "AscendingRBTN";
            this.AscendingRBTN.Size = new System.Drawing.Size(83, 17);
            this.AscendingRBTN.TabIndex = 10;
            this.AscendingRBTN.TabStop = true;
            this.AscendingRBTN.Text = "Ascending";
            this.AscendingRBTN.UseVisualStyleBackColor = true;
            this.AscendingRBTN.CheckedChanged += new System.EventHandler(this.AscendingRBTN_CheckedChanged);
            // 
            // DescendingRBTN
            // 
            this.DescendingRBTN.AutoSize = true;
            this.DescendingRBTN.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.DescendingRBTN.Location = new System.Drawing.Point(487, 56);
            this.DescendingRBTN.Name = "DescendingRBTN";
            this.DescendingRBTN.Size = new System.Drawing.Size(91, 17);
            this.DescendingRBTN.TabIndex = 9;
            this.DescendingRBTN.TabStop = true;
            this.DescendingRBTN.Text = "Descending";
            this.DescendingRBTN.UseVisualStyleBackColor = true;
            this.DescendingRBTN.CheckedChanged += new System.EventHandler(this.DescendingRBTN_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(613, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Search:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(616, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(182, 26);
            this.textBox1.TabIndex = 7;
            // 
            // listView1
            // 
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 95);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(801, 566);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ListViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 673);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AscendingRBTN);
            this.Controls.Add(this.DescendingRBTN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listView1);
            this.Name = "ListViewForm";
            this.Text = "PartViewForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton AscendingRBTN;
        private System.Windows.Forms.RadioButton DescendingRBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView listView1;
    }
}