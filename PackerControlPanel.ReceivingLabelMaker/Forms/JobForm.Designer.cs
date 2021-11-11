namespace PackerControlPanel.RPCP.Forms
{
    partial class JobForm
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
            this.components = new System.ComponentModel.Container();
            this.IDTxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PartIDTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GlobalCb = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PartNameTxt = new System.Windows.Forms.TextBox();
            this.ModifiedTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CreationTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TotalReceivedTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CompletionTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.StateCb = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.EntriesView = new PackerControlPanel.RPCP.Controls.ListWithSearch();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.notesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // IDTxt
            // 
            this.IDTxt.Location = new System.Drawing.Point(129, 65);
            this.IDTxt.Name = "IDTxt";
            this.IDTxt.ReadOnly = true;
            this.IDTxt.Size = new System.Drawing.Size(150, 20);
            this.IDTxt.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "ID:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "Job";
            // 
            // NameTxt
            // 
            this.NameTxt.Location = new System.Drawing.Point(129, 91);
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.ReadOnly = true;
            this.NameTxt.Size = new System.Drawing.Size(150, 20);
            this.NameTxt.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PartIDTxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.GlobalCb);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.PartNameTxt);
            this.groupBox1.Location = new System.Drawing.Point(30, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 105);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Part Information";
            // 
            // PartIDTxt
            // 
            this.PartIDTxt.Location = new System.Drawing.Point(71, 29);
            this.PartIDTxt.Name = "PartIDTxt";
            this.PartIDTxt.ReadOnly = true;
            this.PartIDTxt.Size = new System.Drawing.Size(150, 20);
            this.PartIDTxt.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "ID:";
            // 
            // GlobalCb
            // 
            this.GlobalCb.AutoSize = true;
            this.GlobalCb.Location = new System.Drawing.Point(145, 81);
            this.GlobalCb.Name = "GlobalCb";
            this.GlobalCb.Size = new System.Drawing.Size(76, 17);
            this.GlobalCb.TabIndex = 35;
            this.GlobalCb.Text = "Global Job";
            this.GlobalCb.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Name:";
            // 
            // PartNameTxt
            // 
            this.PartNameTxt.Location = new System.Drawing.Point(71, 55);
            this.PartNameTxt.Name = "PartNameTxt";
            this.PartNameTxt.ReadOnly = true;
            this.PartNameTxt.Size = new System.Drawing.Size(150, 20);
            this.PartNameTxt.TabIndex = 26;
            // 
            // ModifiedTxt
            // 
            this.ModifiedTxt.Location = new System.Drawing.Point(129, 367);
            this.ModifiedTxt.Name = "ModifiedTxt";
            this.ModifiedTxt.ReadOnly = true;
            this.ModifiedTxt.Size = new System.Drawing.Size(150, 20);
            this.ModifiedTxt.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 370);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Modified Time:";
            // 
            // CreationTxt
            // 
            this.CreationTxt.Location = new System.Drawing.Point(129, 322);
            this.CreationTxt.Name = "CreationTxt";
            this.CreationTxt.ReadOnly = true;
            this.CreationTxt.Size = new System.Drawing.Size(150, 20);
            this.CreationTxt.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 325);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Creation Time:";
            // 
            // TotalReceivedTxt
            // 
            this.TotalReceivedTxt.Location = new System.Drawing.Point(129, 253);
            this.TotalReceivedTxt.Name = "TotalReceivedTxt";
            this.TotalReceivedTxt.ReadOnly = true;
            this.TotalReceivedTxt.Size = new System.Drawing.Size(150, 20);
            this.TotalReceivedTxt.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Total Received";
            // 
            // CompletionTxt
            // 
            this.CompletionTxt.Location = new System.Drawing.Point(129, 393);
            this.CompletionTxt.Name = "CompletionTxt";
            this.CompletionTxt.ReadOnly = true;
            this.CompletionTxt.Size = new System.Drawing.Size(150, 20);
            this.CompletionTxt.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 396);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Completion Time:";
            // 
            // StateCb
            // 
            this.StateCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StateCb.FormattingEnabled = true;
            this.StateCb.Location = new System.Drawing.Point(129, 295);
            this.StateCb.Name = "StateCb";
            this.StateCb.Size = new System.Drawing.Size(150, 21);
            this.StateCb.TabIndex = 33;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 298);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "State";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DodgerBlue;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button4.Location = new System.Drawing.Point(204, 428);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 36;
            this.button4.Text = "Update";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.UpdateJob_Click);
            // 
            // EntriesView
            // 
            this.EntriesView.BackColor = System.Drawing.Color.Transparent;
            this.EntriesView.Location = new System.Drawing.Point(301, 12);
            this.EntriesView.Name = "EntriesView";
            this.EntriesView.Size = new System.Drawing.Size(724, 542);
            this.EntriesView.TabIndex = 37;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(311, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 20);
            this.label11.TabIndex = 38;
            this.label11.Text = "Entries:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 428);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 39;
            this.button1.Text = "Extract";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(106, 26);
            // 
            // notesToolStripMenuItem
            // 
            this.notesToolStripMenuItem.Name = "notesToolStripMenuItem";
            this.notesToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.notesToolStripMenuItem.Text = "Notes";
            this.notesToolStripMenuItem.Click += new System.EventHandler(this.Notes_Click);
            // 
            // JobForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 566);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.EntriesView);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.StateCb);
            this.Controls.Add(this.CompletionTxt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TotalReceivedTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ModifiedTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CreationTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.IDTxt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.NameTxt);
            this.Controls.Add(this.label1);
            this.Name = "JobForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "JobForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IDTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox NameTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox PartIDTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PartNameTxt;
        private System.Windows.Forms.TextBox ModifiedTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CreationTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TotalReceivedTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox CompletionTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox StateCb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox GlobalCb;
        private System.Windows.Forms.Button button4;
        private RPCP.Controls.ListWithSearch EntriesView;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem notesToolStripMenuItem;
    }
}