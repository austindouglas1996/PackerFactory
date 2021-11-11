namespace PackerControlPanel.InventoryWin.Forms
{
    partial class PartViewer
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
            this.tab4 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.partBoxDirTB = new System.Windows.Forms.TextBox();
            this.partBoxTypeCB = new System.Windows.Forms.ComboBox();
            this.partFlagsStringTB = new System.Windows.Forms.TextBox();
            this.partBoxCountTB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.partParentIDTb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.partParentNameTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.partParentDescTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.partIDTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.partNameTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.partDescTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.JobList = new PackerControlPanel.InventoryWin.Controls.ListWithSearch();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.ChildrenList = new PackerControlPanel.InventoryWin.Controls.ListWithSearch();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.NotesRemoveAll = new System.Windows.Forms.Button();
            this.NotesRemove = new System.Windows.Forms.Button();
            this.NotesAdd = new System.Windows.Forms.Button();
            this.NotesList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tab4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab4
            // 
            this.tab4.Controls.Add(this.tabPage1);
            this.tab4.Controls.Add(this.tabPage2);
            this.tab4.Controls.Add(this.tabPage3);
            this.tab4.Controls.Add(this.tabPage5);
            this.tab4.Location = new System.Drawing.Point(2, 0);
            this.tab4.Name = "tab4";
            this.tab4.SelectedIndex = 0;
            this.tab4.Size = new System.Drawing.Size(520, 680);
            this.tab4.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.CloseBtn);
            this.tabPage1.Controls.Add(this.SaveBtn);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(512, 654);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(407, 622);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 20;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(320, 622);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 19;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.partBoxDirTB);
            this.groupBox3.Controls.Add(this.partBoxTypeCB);
            this.groupBox3.Controls.Add(this.partFlagsStringTB);
            this.groupBox3.Controls.Add(this.partBoxCountTB);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(17, 348);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(465, 257);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Boxing Info:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "Boxing Directions:";
            // 
            // partBoxDirTB
            // 
            this.partBoxDirTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partBoxDirTB.Location = new System.Drawing.Point(173, 134);
            this.partBoxDirTB.Multiline = true;
            this.partBoxDirTB.Name = "partBoxDirTB";
            this.partBoxDirTB.Size = new System.Drawing.Size(257, 112);
            this.partBoxDirTB.TabIndex = 7;
            // 
            // partBoxTypeCB
            // 
            this.partBoxTypeCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partBoxTypeCB.FormattingEnabled = true;
            this.partBoxTypeCB.Location = new System.Drawing.Point(173, 61);
            this.partBoxTypeCB.Name = "partBoxTypeCB";
            this.partBoxTypeCB.Size = new System.Drawing.Size(257, 24);
            this.partBoxTypeCB.TabIndex = 6;
            // 
            // partFlagsStringTB
            // 
            this.partFlagsStringTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partFlagsStringTB.Location = new System.Drawing.Point(173, 91);
            this.partFlagsStringTB.Name = "partFlagsStringTB";
            this.partFlagsStringTB.Size = new System.Drawing.Size(257, 22);
            this.partFlagsStringTB.TabIndex = 5;
            // 
            // partBoxCountTB
            // 
            this.partBoxCountTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partBoxCountTB.Location = new System.Drawing.Point(173, 27);
            this.partBoxCountTB.Name = "partBoxCountTB";
            this.partBoxCountTB.Size = new System.Drawing.Size(257, 22);
            this.partBoxCountTB.TabIndex = 3;
            this.partBoxCountTB.Text = "PART_BOXCOUNT";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "Box Count:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Box Type:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(15, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 16);
            this.label11.TabIndex = 1;
            this.label11.Text = "Flags:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.linkLabel1);
            this.groupBox2.Controls.Add(this.partParentIDTb);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.partParentNameTB);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.partParentDescTB);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(17, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 172);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parent Info";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(300, 144);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(80, 13);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Edit Parent Info";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // partParentIDTb
            // 
            this.partParentIDTb.BackColor = System.Drawing.SystemColors.Control;
            this.partParentIDTb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.partParentIDTb.Enabled = false;
            this.partParentIDTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partParentIDTb.Location = new System.Drawing.Point(123, 32);
            this.partParentIDTb.Name = "partParentIDTb";
            this.partParentIDTb.ReadOnly = true;
            this.partParentIDTb.Size = new System.Drawing.Size(209, 22);
            this.partParentIDTb.TabIndex = 5;
            this.partParentIDTb.Text = "PARENT_ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "ID:";
            // 
            // partParentNameTB
            // 
            this.partParentNameTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.partParentNameTB.Enabled = false;
            this.partParentNameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partParentNameTB.Location = new System.Drawing.Point(123, 66);
            this.partParentNameTB.Name = "partParentNameTB";
            this.partParentNameTB.Size = new System.Drawing.Size(209, 22);
            this.partParentNameTB.TabIndex = 12;
            this.partParentNameTB.Text = "PARENT_NAME";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Description:";
            // 
            // partParentDescTB
            // 
            this.partParentDescTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.partParentDescTB.Enabled = false;
            this.partParentDescTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partParentDescTB.Location = new System.Drawing.Point(123, 104);
            this.partParentDescTB.Name = "partParentDescTB";
            this.partParentDescTB.Size = new System.Drawing.Size(257, 22);
            this.partParentDescTB.TabIndex = 13;
            this.partParentDescTB.Text = "PART_DESCRIPTION";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Part Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.partIDTB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.partNameTB);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.partDescTB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 149);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Part Info";
            // 
            // partIDTB
            // 
            this.partIDTB.BackColor = System.Drawing.SystemColors.Control;
            this.partIDTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.partIDTB.Enabled = false;
            this.partIDTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partIDTB.Location = new System.Drawing.Point(123, 32);
            this.partIDTB.Name = "partIDTB";
            this.partIDTB.ReadOnly = true;
            this.partIDTB.Size = new System.Drawing.Size(209, 22);
            this.partIDTB.TabIndex = 5;
            this.partIDTB.Text = "PART_ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "ID:";
            // 
            // partNameTB
            // 
            this.partNameTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.partNameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partNameTB.Location = new System.Drawing.Point(123, 66);
            this.partNameTB.Name = "partNameTB";
            this.partNameTB.Size = new System.Drawing.Size(209, 22);
            this.partNameTB.TabIndex = 12;
            this.partNameTB.Text = "PART_NAME";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Description:";
            // 
            // partDescTB
            // 
            this.partDescTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.partDescTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partDescTB.Location = new System.Drawing.Point(123, 104);
            this.partDescTB.Name = "partDescTB";
            this.partDescTB.Size = new System.Drawing.Size(257, 22);
            this.partDescTB.TabIndex = 13;
            this.partDescTB.Text = "PART_DESCRIPTION";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Part Name:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.JobList);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(512, 654);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Jobs";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Jobs";
            // 
            // JobList
            // 
            this.JobList.BackColor = System.Drawing.Color.Transparent;
            this.JobList.Location = new System.Drawing.Point(6, 3);
            this.JobList.Name = "JobList";
            this.JobList.Size = new System.Drawing.Size(497, 613);
            this.JobList.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.ChildrenList);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(512, 654);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Children";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(16, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 16);
            this.label12.TabIndex = 1;
            this.label12.Text = "Children";
            // 
            // ChildrenList
            // 
            this.ChildrenList.BackColor = System.Drawing.Color.Transparent;
            this.ChildrenList.Location = new System.Drawing.Point(-4, 3);
            this.ChildrenList.Name = "ChildrenList";
            this.ChildrenList.Size = new System.Drawing.Size(507, 613);
            this.ChildrenList.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.NotesRemoveAll);
            this.tabPage5.Controls.Add(this.NotesRemove);
            this.tabPage5.Controls.Add(this.NotesAdd);
            this.tabPage5.Controls.Add(this.NotesList);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(512, 654);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Notes";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // NotesRemoveAll
            // 
            this.NotesRemoveAll.Location = new System.Drawing.Point(168, 13);
            this.NotesRemoveAll.Name = "NotesRemoveAll";
            this.NotesRemoveAll.Size = new System.Drawing.Size(75, 23);
            this.NotesRemoveAll.TabIndex = 3;
            this.NotesRemoveAll.Text = "Remove All";
            this.NotesRemoveAll.UseVisualStyleBackColor = true;
            // 
            // NotesRemove
            // 
            this.NotesRemove.Location = new System.Drawing.Point(87, 13);
            this.NotesRemove.Name = "NotesRemove";
            this.NotesRemove.Size = new System.Drawing.Size(75, 23);
            this.NotesRemove.TabIndex = 2;
            this.NotesRemove.Text = "Remove Selected";
            this.NotesRemove.UseVisualStyleBackColor = true;
            // 
            // NotesAdd
            // 
            this.NotesAdd.Location = new System.Drawing.Point(6, 13);
            this.NotesAdd.Name = "NotesAdd";
            this.NotesAdd.Size = new System.Drawing.Size(75, 23);
            this.NotesAdd.TabIndex = 1;
            this.NotesAdd.Text = "Add";
            this.NotesAdd.UseVisualStyleBackColor = true;
            // 
            // NotesList
            // 
            this.NotesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.NotesList.FullRowSelect = true;
            this.NotesList.GridLines = true;
            this.NotesList.Location = new System.Drawing.Point(6, 52);
            this.NotesList.Name = "NotesList";
            this.NotesList.Size = new System.Drawing.Size(503, 564);
            this.NotesList.TabIndex = 0;
            this.NotesList.UseCompatibleStateImageBehavior = false;
            this.NotesList.View = System.Windows.Forms.View.Details;
            // 
            // PartViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 679);
            this.Controls.Add(this.tab4);
            this.Name = "PartViewer";
            this.Text = "PartViewer";
            this.tab4.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab4;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox partBoxDirTB;
        private System.Windows.Forms.ComboBox partBoxTypeCB;
        private System.Windows.Forms.TextBox partFlagsStringTB;
        private System.Windows.Forms.TextBox partBoxCountTB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox partParentIDTb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox partParentNameTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox partParentDescTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox partIDTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox partNameTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox partDescTB;
        private System.Windows.Forms.Label label2;
        private Controls.ListWithSearch JobList;
        private Controls.ListWithSearch ChildrenList;
        private System.Windows.Forms.ListView NotesList;
        private System.Windows.Forms.Button NotesAdd;
        private System.Windows.Forms.Button NotesRemove;
        private System.Windows.Forms.Button NotesRemoveAll;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
    }
}