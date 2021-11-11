using System.Windows.Forms;

namespace PackerControlPanel.InventoryWin.Windows
{
    partial class PartEditorForm : Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.partIDTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.partNameTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.partDescTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.partParentIDTb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.partParentNameTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.partParentDescTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.partBoxDirTB = new System.Windows.Forms.TextBox();
            this.partBoxTypeCB = new System.Windows.Forms.ComboBox();
            this.partFlagsStringTB = new System.Windows.Forms.TextBox();
            this.partBoxCountTB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cancelFBTN = new System.Windows.Forms.Button();
            this.acceptFBTN = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.openHistoryBTN = new System.Windows.Forms.Button();
            this.partDeleteBTN = new System.Windows.Forms.Button();
            this.openEntriesBTN = new System.Windows.Forms.Button();
            this.openNotesBTN = new System.Windows.Forms.Button();
            this.openJobsBTN = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Part Editor";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.partIDTB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.partNameTB);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.partDescTB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(27, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 149);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Part Info";
            // 
            // partIDTB
            // 
            this.partIDTB.BackColor = System.Drawing.SystemColors.Control;
            this.partIDTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.partIDTB.Enabled = false;
            this.partIDTB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partIDTB.Location = new System.Drawing.Point(123, 32);
            this.partIDTB.Name = "partIDTB";
            this.partIDTB.ReadOnly = true;
            this.partIDTB.Size = new System.Drawing.Size(209, 26);
            this.partIDTB.TabIndex = 5;
            this.partIDTB.Text = "PART_ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "ID:";
            // 
            // partNameTB
            // 
            this.partNameTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.partNameTB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partNameTB.Location = new System.Drawing.Point(123, 66);
            this.partNameTB.Name = "partNameTB";
            this.partNameTB.Size = new System.Drawing.Size(209, 26);
            this.partNameTB.TabIndex = 12;
            this.partNameTB.Text = "PART_NAME";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Description:";
            // 
            // partDescTB
            // 
            this.partDescTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.partDescTB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partDescTB.Location = new System.Drawing.Point(123, 104);
            this.partDescTB.Name = "partDescTB";
            this.partDescTB.Size = new System.Drawing.Size(257, 26);
            this.partDescTB.TabIndex = 13;
            this.partDescTB.Text = "PART_DESCRIPTION";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Part Name:";
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
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(27, 250);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 172);
            this.groupBox2.TabIndex = 14;
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
            // 
            // partParentIDTb
            // 
            this.partParentIDTb.BackColor = System.Drawing.SystemColors.Control;
            this.partParentIDTb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.partParentIDTb.Enabled = false;
            this.partParentIDTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partParentIDTb.Location = new System.Drawing.Point(123, 32);
            this.partParentIDTb.Name = "partParentIDTb";
            this.partParentIDTb.ReadOnly = true;
            this.partParentIDTb.Size = new System.Drawing.Size(209, 26);
            this.partParentIDTb.TabIndex = 5;
            this.partParentIDTb.Text = "PARENT_ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "ID:";
            // 
            // partParentNameTB
            // 
            this.partParentNameTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.partParentNameTB.Enabled = false;
            this.partParentNameTB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partParentNameTB.Location = new System.Drawing.Point(123, 66);
            this.partParentNameTB.Name = "partParentNameTB";
            this.partParentNameTB.Size = new System.Drawing.Size(209, 26);
            this.partParentNameTB.TabIndex = 12;
            this.partParentNameTB.Text = "PARENT_NAME";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Description:";
            // 
            // partParentDescTB
            // 
            this.partParentDescTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.partParentDescTB.Enabled = false;
            this.partParentDescTB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partParentDescTB.Location = new System.Drawing.Point(123, 104);
            this.partParentDescTB.Name = "partParentDescTB";
            this.partParentDescTB.Size = new System.Drawing.Size(257, 26);
            this.partParentDescTB.TabIndex = 13;
            this.partParentDescTB.Text = "PART_DESCRIPTION";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 18);
            this.label7.TabIndex = 10;
            this.label7.Text = "Part Name:";
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
            this.groupBox3.Location = new System.Drawing.Point(27, 432);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(465, 271);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Boxing Info:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 18);
            this.label8.TabIndex = 8;
            this.label8.Text = "Boxing Directions:";
            // 
            // partBoxDirTB
            // 
            this.partBoxDirTB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partBoxDirTB.Location = new System.Drawing.Point(173, 134);
            this.partBoxDirTB.Multiline = true;
            this.partBoxDirTB.Name = "partBoxDirTB";
            this.partBoxDirTB.Size = new System.Drawing.Size(257, 112);
            this.partBoxDirTB.TabIndex = 7;
            // 
            // partBoxTypeCB
            // 
            this.partBoxTypeCB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partBoxTypeCB.FormattingEnabled = true;
            this.partBoxTypeCB.Location = new System.Drawing.Point(173, 61);
            this.partBoxTypeCB.Name = "partBoxTypeCB";
            this.partBoxTypeCB.Size = new System.Drawing.Size(257, 26);
            this.partBoxTypeCB.TabIndex = 6;
            // 
            // partFlagsStringTB
            // 
            this.partFlagsStringTB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partFlagsStringTB.Location = new System.Drawing.Point(173, 91);
            this.partFlagsStringTB.Name = "partFlagsStringTB";
            this.partFlagsStringTB.Size = new System.Drawing.Size(257, 26);
            this.partFlagsStringTB.TabIndex = 5;
            // 
            // partBoxCountTB
            // 
            this.partBoxCountTB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partBoxCountTB.Location = new System.Drawing.Point(173, 27);
            this.partBoxCountTB.Name = "partBoxCountTB";
            this.partBoxCountTB.Size = new System.Drawing.Size(257, 26);
            this.partBoxCountTB.TabIndex = 3;
            this.partBoxCountTB.Text = "PART_BOXCOUNT";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 18);
            this.label9.TabIndex = 2;
            this.label9.Text = "Box Count:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 18);
            this.label10.TabIndex = 0;
            this.label10.Text = "Box Type:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(15, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 18);
            this.label11.TabIndex = 1;
            this.label11.Text = "Flags:";
            // 
            // cancelFBTN
            // 
            this.cancelFBTN.BackColor = System.Drawing.SystemColors.Control;
            this.cancelFBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelFBTN.Location = new System.Drawing.Point(313, 709);
            this.cancelFBTN.Name = "cancelFBTN";
            this.cancelFBTN.Size = new System.Drawing.Size(82, 33);
            this.cancelFBTN.TabIndex = 17;
            this.cancelFBTN.Text = "Cancel";
            this.cancelFBTN.UseVisualStyleBackColor = false;
            this.cancelFBTN.Click += new System.EventHandler(this.cancelFBTN_Click);
            // 
            // acceptFBTN
            // 
            this.acceptFBTN.BackColor = System.Drawing.SystemColors.Control;
            this.acceptFBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptFBTN.Location = new System.Drawing.Point(410, 709);
            this.acceptFBTN.Name = "acceptFBTN";
            this.acceptFBTN.Size = new System.Drawing.Size(82, 33);
            this.acceptFBTN.TabIndex = 16;
            this.acceptFBTN.Text = "Accept";
            this.acceptFBTN.UseVisualStyleBackColor = false;
            this.acceptFBTN.Click += new System.EventHandler(this.acceptFBTN_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.openHistoryBTN);
            this.groupBox4.Controls.Add(this.partDeleteBTN);
            this.groupBox4.Controls.Add(this.openEntriesBTN);
            this.groupBox4.Controls.Add(this.openNotesBTN);
            this.groupBox4.Controls.Add(this.openJobsBTN);
            this.groupBox4.Location = new System.Drawing.Point(441, 86);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(158, 336);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Options";
            // 
            // openHistoryBTN
            // 
            this.openHistoryBTN.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openHistoryBTN.Location = new System.Drawing.Point(24, 130);
            this.openHistoryBTN.Name = "openHistoryBTN";
            this.openHistoryBTN.Size = new System.Drawing.Size(102, 33);
            this.openHistoryBTN.TabIndex = 10;
            this.openHistoryBTN.Text = "Edit History";
            this.openHistoryBTN.UseVisualStyleBackColor = true;
            // 
            // partDeleteBTN
            // 
            this.partDeleteBTN.BackColor = System.Drawing.Color.LightCoral;
            this.partDeleteBTN.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partDeleteBTN.Location = new System.Drawing.Point(24, 230);
            this.partDeleteBTN.Name = "partDeleteBTN";
            this.partDeleteBTN.Size = new System.Drawing.Size(102, 33);
            this.partDeleteBTN.TabIndex = 0;
            this.partDeleteBTN.Text = "Delete";
            this.partDeleteBTN.UseVisualStyleBackColor = false;
            // 
            // openEntriesBTN
            // 
            this.openEntriesBTN.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openEntriesBTN.Location = new System.Drawing.Point(24, 80);
            this.openEntriesBTN.Name = "openEntriesBTN";
            this.openEntriesBTN.Size = new System.Drawing.Size(102, 34);
            this.openEntriesBTN.TabIndex = 8;
            this.openEntriesBTN.Text = "Entries";
            this.openEntriesBTN.UseVisualStyleBackColor = true;
            // 
            // openNotesBTN
            // 
            this.openNotesBTN.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openNotesBTN.Location = new System.Drawing.Point(24, 180);
            this.openNotesBTN.Name = "openNotesBTN";
            this.openNotesBTN.Size = new System.Drawing.Size(102, 33);
            this.openNotesBTN.TabIndex = 7;
            this.openNotesBTN.Text = "Notes";
            this.openNotesBTN.UseVisualStyleBackColor = true;
            // 
            // openJobsBTN
            // 
            this.openJobsBTN.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openJobsBTN.Location = new System.Drawing.Point(24, 30);
            this.openJobsBTN.Name = "openJobsBTN";
            this.openJobsBTN.Size = new System.Drawing.Size(102, 33);
            this.openJobsBTN.TabIndex = 4;
            this.openJobsBTN.Text = "Jobs";
            this.openJobsBTN.UseVisualStyleBackColor = true;
            // 
            // PartEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(612, 770);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.cancelFBTN);
            this.Controls.Add(this.acceptFBTN);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "PartEditorForm";
            this.Text = "PartEditor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox partIDTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox partDescTB;
        private System.Windows.Forms.TextBox partNameTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox partParentIDTb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox partParentNameTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox partParentDescTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox partBoxDirTB;
        private System.Windows.Forms.ComboBox partBoxTypeCB;
        private System.Windows.Forms.TextBox partFlagsStringTB;
        private System.Windows.Forms.TextBox partBoxCountTB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button cancelFBTN;
        private System.Windows.Forms.Button acceptFBTN;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button openHistoryBTN;
        private System.Windows.Forms.Button partDeleteBTN;
        private System.Windows.Forms.Button openEntriesBTN;
        private System.Windows.Forms.Button openNotesBTN;
        private System.Windows.Forms.Button openJobsBTN;
    }
}