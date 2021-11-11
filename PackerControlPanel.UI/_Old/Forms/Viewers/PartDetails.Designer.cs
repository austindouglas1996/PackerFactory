namespace PackerControlPanel.UI.Forms
{
    partial class PartDetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
        public void InitializeComponent()
        {
            this.FTitle = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PartNameTxt = new System.Windows.Forms.TextBox();
            this.DescriptionTxt = new System.Windows.Forms.TextBox();
            this.BoxCountTxt = new System.Windows.Forms.TextBox();
            this.PackInstructionsTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BoxTypeCb = new System.Windows.Forms.ComboBox();
            this.AcceptBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SearchTxt = new System.Windows.Forms.TextBox();
            this.ChildrenRemoveAllBtn = new System.Windows.Forms.Button();
            this.ChildrenRemoveSelectedBtn = new System.Windows.Forms.Button();
            this.ChildrenAddBtn = new System.Windows.Forms.Button();
            this.ChildrenView = new System.Windows.Forms.ListView();
            this.IDTab = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameTab = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DescriptionTab = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RelationshipTab = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ParentClearBtn = new System.Windows.Forms.Button();
            this.ParentSetBtn = new System.Windows.Forms.Button();
            this.ParentDescriptionTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ParentNameTxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DescriptionSetBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.PartIDTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // FTitle
            // 
            this.FTitle.AutoSize = true;
            this.FTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FTitle.Location = new System.Drawing.Point(17, 25);
            this.FTitle.Name = "FTitle";
            this.FTitle.Size = new System.Drawing.Size(123, 20);
            this.FTitle.TabIndex = 0;
            this.FTitle.Text = "Part Information";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Part Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Description:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Default Box Count:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Default Box Type:";
            // 
            // PartNameTxt
            // 
            this.PartNameTxt.Location = new System.Drawing.Point(121, 99);
            this.PartNameTxt.Name = "PartNameTxt";
            this.PartNameTxt.Size = new System.Drawing.Size(151, 20);
            this.PartNameTxt.TabIndex = 6;
            // 
            // DescriptionTxt
            // 
            this.DescriptionTxt.Location = new System.Drawing.Point(121, 124);
            this.DescriptionTxt.Name = "DescriptionTxt";
            this.DescriptionTxt.ReadOnly = true;
            this.DescriptionTxt.Size = new System.Drawing.Size(151, 20);
            this.DescriptionTxt.TabIndex = 7;
            // 
            // BoxCountTxt
            // 
            this.BoxCountTxt.Location = new System.Drawing.Point(122, 153);
            this.BoxCountTxt.Name = "BoxCountTxt";
            this.BoxCountTxt.Size = new System.Drawing.Size(151, 20);
            this.BoxCountTxt.TabIndex = 8;
            // 
            // PackInstructionsTxt
            // 
            this.PackInstructionsTxt.Location = new System.Drawing.Point(21, 225);
            this.PackInstructionsTxt.Multiline = true;
            this.PackInstructionsTxt.Name = "PackInstructionsTxt";
            this.PackInstructionsTxt.Size = new System.Drawing.Size(251, 66);
            this.PackInstructionsTxt.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Packaging Instructions:";
            // 
            // BoxTypeCb
            // 
            this.BoxTypeCb.FormattingEnabled = true;
            this.BoxTypeCb.Location = new System.Drawing.Point(122, 181);
            this.BoxTypeCb.Name = "BoxTypeCb";
            this.BoxTypeCb.Size = new System.Drawing.Size(151, 21);
            this.BoxTypeCb.TabIndex = 12;
            // 
            // AcceptBtn
            // 
            this.AcceptBtn.Location = new System.Drawing.Point(658, 430);
            this.AcceptBtn.Name = "AcceptBtn";
            this.AcceptBtn.Size = new System.Drawing.Size(75, 23);
            this.AcceptBtn.TabIndex = 13;
            this.AcceptBtn.Text = "Accept";
            this.AcceptBtn.UseVisualStyleBackColor = true;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(739, 430);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 14;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.SearchTxt);
            this.groupBox1.Controls.Add(this.ChildrenRemoveAllBtn);
            this.groupBox1.Controls.Add(this.ChildrenRemoveSelectedBtn);
            this.groupBox1.Controls.Add(this.ChildrenAddBtn);
            this.groupBox1.Controls.Add(this.ChildrenView);
            this.groupBox1.Location = new System.Drawing.Point(334, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 332);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Children Info";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "List Of Children:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(253, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Search";
            // 
            // SearchTxt
            // 
            this.SearchTxt.Location = new System.Drawing.Point(319, 58);
            this.SearchTxt.Name = "SearchTxt";
            this.SearchTxt.Size = new System.Drawing.Size(151, 20);
            this.SearchTxt.TabIndex = 24;
            // 
            // ChildrenRemoveAllBtn
            // 
            this.ChildrenRemoveAllBtn.Location = new System.Drawing.Point(127, 290);
            this.ChildrenRemoveAllBtn.Name = "ChildrenRemoveAllBtn";
            this.ChildrenRemoveAllBtn.Size = new System.Drawing.Size(107, 26);
            this.ChildrenRemoveAllBtn.TabIndex = 22;
            this.ChildrenRemoveAllBtn.Text = "Remove All";
            this.ChildrenRemoveAllBtn.UseVisualStyleBackColor = true;
            // 
            // ChildrenRemoveSelectedBtn
            // 
            this.ChildrenRemoveSelectedBtn.Location = new System.Drawing.Point(14, 290);
            this.ChildrenRemoveSelectedBtn.Name = "ChildrenRemoveSelectedBtn";
            this.ChildrenRemoveSelectedBtn.Size = new System.Drawing.Size(107, 26);
            this.ChildrenRemoveSelectedBtn.TabIndex = 16;
            this.ChildrenRemoveSelectedBtn.Text = "Remove Selected";
            this.ChildrenRemoveSelectedBtn.UseVisualStyleBackColor = true;
            // 
            // ChildrenAddBtn
            // 
            this.ChildrenAddBtn.Location = new System.Drawing.Point(14, 25);
            this.ChildrenAddBtn.Name = "ChildrenAddBtn";
            this.ChildrenAddBtn.Size = new System.Drawing.Size(75, 23);
            this.ChildrenAddBtn.TabIndex = 16;
            this.ChildrenAddBtn.Text = "Add Child";
            this.ChildrenAddBtn.UseVisualStyleBackColor = true;
            // 
            // ChildrenView
            // 
            this.ChildrenView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IDTab,
            this.NameTab,
            this.DescriptionTab,
            this.RelationshipTab});
            this.ChildrenView.FullRowSelect = true;
            this.ChildrenView.GridLines = true;
            this.ChildrenView.HideSelection = false;
            this.ChildrenView.Location = new System.Drawing.Point(14, 91);
            this.ChildrenView.Name = "ChildrenView";
            this.ChildrenView.Size = new System.Drawing.Size(456, 193);
            this.ChildrenView.TabIndex = 21;
            this.ChildrenView.UseCompatibleStateImageBehavior = false;
            this.ChildrenView.View = System.Windows.Forms.View.Details;
            // 
            // NameTab
            // 
            this.NameTab.Text = "Name";
            // 
            // DescriptionTab
            // 
            this.DescriptionTab.Text = "Description";
            // 
            // RelationshipTab
            // 
            this.RelationshipTab.Text = "Relationship Type";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ParentClearBtn);
            this.groupBox2.Controls.Add(this.ParentSetBtn);
            this.groupBox2.Controls.Add(this.ParentDescriptionTxt);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.ParentNameTxt);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(21, 297);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parent Info";
            // 
            // ParentClearBtn
            // 
            this.ParentClearBtn.Location = new System.Drawing.Point(184, 15);
            this.ParentClearBtn.Name = "ParentClearBtn";
            this.ParentClearBtn.Size = new System.Drawing.Size(75, 23);
            this.ParentClearBtn.TabIndex = 17;
            this.ParentClearBtn.Text = "Clear Parent";
            this.ParentClearBtn.UseVisualStyleBackColor = true;
            // 
            // ParentSetBtn
            // 
            this.ParentSetBtn.Location = new System.Drawing.Point(98, 15);
            this.ParentSetBtn.Name = "ParentSetBtn";
            this.ParentSetBtn.Size = new System.Drawing.Size(75, 23);
            this.ParentSetBtn.TabIndex = 16;
            this.ParentSetBtn.Text = "Set Parent";
            this.ParentSetBtn.UseVisualStyleBackColor = true;
            // 
            // ParentDescriptionTxt
            // 
            this.ParentDescriptionTxt.Location = new System.Drawing.Point(108, 69);
            this.ParentDescriptionTxt.Name = "ParentDescriptionTxt";
            this.ParentDescriptionTxt.ReadOnly = true;
            this.ParentDescriptionTxt.Size = new System.Drawing.Size(151, 20);
            this.ParentDescriptionTxt.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Part Name:";
            // 
            // ParentNameTxt
            // 
            this.ParentNameTxt.Location = new System.Drawing.Point(108, 44);
            this.ParentNameTxt.Name = "ParentNameTxt";
            this.ParentNameTxt.ReadOnly = true;
            this.ParentNameTxt.Size = new System.Drawing.Size(151, 20);
            this.ParentNameTxt.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Description:";
            // 
            // DescriptionSetBtn
            // 
            this.DescriptionSetBtn.Location = new System.Drawing.Point(278, 122);
            this.DescriptionSetBtn.Name = "DescriptionSetBtn";
            this.DescriptionSetBtn.Size = new System.Drawing.Size(39, 23);
            this.DescriptionSetBtn.TabIndex = 20;
            this.DescriptionSetBtn.Text = "Set";
            this.DescriptionSetBtn.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(187, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Jobs";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(283, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Receivers";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(380, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = "Notes";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Red;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(221, 403);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 25;
            this.button5.Text = "Delete";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // PartIDTxt
            // 
            this.PartIDTxt.Location = new System.Drawing.Point(122, 73);
            this.PartIDTxt.Name = "PartIDTxt";
            this.PartIDTxt.ReadOnly = true;
            this.PartIDTxt.Size = new System.Drawing.Size(151, 20);
            this.PartIDTxt.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "ID:";
            // 
            // PartDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 476);
            this.Controls.Add(this.PartIDTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DescriptionSetBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.AcceptBtn);
            this.Controls.Add(this.BoxTypeCb);
            this.Controls.Add(this.PackInstructionsTxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BoxCountTxt);
            this.Controls.Add(this.DescriptionTxt);
            this.Controls.Add(this.PartNameTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FTitle);
            this.Name = "PartDetailsForm";
            this.Text = "NewPartForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label FTitle;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox PartNameTxt;
        public System.Windows.Forms.TextBox DescriptionTxt;
        public System.Windows.Forms.TextBox BoxCountTxt;
        public System.Windows.Forms.TextBox PackInstructionsTxt;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox BoxTypeCb;
        public System.Windows.Forms.Button AcceptBtn;
        public System.Windows.Forms.Button CancelBtn;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button ParentClearBtn;
        public System.Windows.Forms.Button ParentSetBtn;
        public System.Windows.Forms.TextBox ParentDescriptionTxt;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox ParentNameTxt;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Button ChildrenAddBtn;
        public System.Windows.Forms.Button ChildrenRemoveSelectedBtn;
        public System.Windows.Forms.ListView ChildrenView;
        public System.Windows.Forms.Button ChildrenRemoveAllBtn;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox SearchTxt;
        public System.Windows.Forms.Button DescriptionSetBtn;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.ColumnHeader IDTab;
        public System.Windows.Forms.ColumnHeader NameTab;
        public System.Windows.Forms.ColumnHeader DescriptionTab;
        public System.Windows.Forms.ColumnHeader RelationshipTab;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        public System.Windows.Forms.TextBox PartIDTxt;
        public System.Windows.Forms.Label label1;
    }
}