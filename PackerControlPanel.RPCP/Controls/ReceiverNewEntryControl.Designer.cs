namespace PackerControlPanel.RPCP.Controls
{
    partial class ReceiverNewEntryControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.PartNameTb = new System.Windows.Forms.TextBox();
            this.DescriptionTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BoxCountTb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BoxTypeCb = new System.Windows.Forms.ComboBox();
            this.BoxesTb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BoxCountsTb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PartSaveInfoBtn = new System.Windows.Forms.Button();
            this.PartEditCancelBtn = new System.Windows.Forms.Button();
            this.PartEditBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.WorkOrderTb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PackerTb = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Part Name:";
            // 
            // PartNameTb
            // 
            this.PartNameTb.Location = new System.Drawing.Point(116, 29);
            this.PartNameTb.Name = "PartNameTb";
            this.PartNameTb.Size = new System.Drawing.Size(163, 20);
            this.PartNameTb.TabIndex = 2;
            this.PartNameTb.Leave += new System.EventHandler(this.PartFocusLost);
            // 
            // DescriptionTb
            // 
            this.DescriptionTb.Enabled = false;
            this.DescriptionTb.Location = new System.Drawing.Point(117, 32);
            this.DescriptionTb.Name = "DescriptionTb";
            this.DescriptionTb.Size = new System.Drawing.Size(163, 20);
            this.DescriptionTb.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Box Type:";
            // 
            // BoxCountTb
            // 
            this.BoxCountTb.Enabled = false;
            this.BoxCountTb.Location = new System.Drawing.Point(117, 84);
            this.BoxCountTb.Name = "BoxCountTb";
            this.BoxCountTb.Size = new System.Drawing.Size(163, 20);
            this.BoxCountTb.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Box Count:";
            // 
            // BoxTypeCb
            // 
            this.BoxTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BoxTypeCb.Enabled = false;
            this.BoxTypeCb.FormattingEnabled = true;
            this.BoxTypeCb.Location = new System.Drawing.Point(117, 58);
            this.BoxTypeCb.Name = "BoxTypeCb";
            this.BoxTypeCb.Size = new System.Drawing.Size(163, 21);
            this.BoxTypeCb.TabIndex = 8;
            // 
            // BoxesTb
            // 
            this.BoxesTb.Location = new System.Drawing.Point(116, 231);
            this.BoxesTb.Name = "BoxesTb";
            this.BoxesTb.Size = new System.Drawing.Size(163, 20);
            this.BoxesTb.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Boxes:";
            // 
            // BoxCountsTb
            // 
            this.BoxCountsTb.Location = new System.Drawing.Point(116, 257);
            this.BoxCountsTb.Name = "BoxCountsTb";
            this.BoxCountsTb.Size = new System.Drawing.Size(163, 20);
            this.BoxCountsTb.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Box Counts:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PartSaveInfoBtn);
            this.groupBox1.Controls.Add(this.PartEditCancelBtn);
            this.groupBox1.Controls.Add(this.PartEditBtn);
            this.groupBox1.Controls.Add(this.DescriptionTb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.BoxCountTb);
            this.groupBox1.Controls.Add(this.BoxTypeCb);
            this.groupBox1.Location = new System.Drawing.Point(2, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 158);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Part Information";
            // 
            // PartSaveInfoBtn
            // 
            this.PartSaveInfoBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.PartSaveInfoBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PartSaveInfoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PartSaveInfoBtn.Location = new System.Drawing.Point(202, 124);
            this.PartSaveInfoBtn.Name = "PartSaveInfoBtn";
            this.PartSaveInfoBtn.Size = new System.Drawing.Size(75, 23);
            this.PartSaveInfoBtn.TabIndex = 11;
            this.PartSaveInfoBtn.Text = "Save";
            this.PartSaveInfoBtn.UseVisualStyleBackColor = false;
            this.PartSaveInfoBtn.Visible = false;
            this.PartSaveInfoBtn.Click += new System.EventHandler(this.OnSavePartClick);
            // 
            // PartEditCancelBtn
            // 
            this.PartEditCancelBtn.BackColor = System.Drawing.Color.Tomato;
            this.PartEditCancelBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PartEditCancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PartEditCancelBtn.Location = new System.Drawing.Point(121, 124);
            this.PartEditCancelBtn.Name = "PartEditCancelBtn";
            this.PartEditCancelBtn.Size = new System.Drawing.Size(75, 23);
            this.PartEditCancelBtn.TabIndex = 10;
            this.PartEditCancelBtn.Text = "Cancel";
            this.PartEditCancelBtn.UseVisualStyleBackColor = false;
            this.PartEditCancelBtn.Visible = false;
            this.PartEditCancelBtn.Click += new System.EventHandler(this.OnCancelPartClick);
            // 
            // PartEditBtn
            // 
            this.PartEditBtn.BackColor = System.Drawing.Color.Gray;
            this.PartEditBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PartEditBtn.Enabled = false;
            this.PartEditBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PartEditBtn.Location = new System.Drawing.Point(202, 124);
            this.PartEditBtn.Name = "PartEditBtn";
            this.PartEditBtn.Size = new System.Drawing.Size(75, 23);
            this.PartEditBtn.TabIndex = 9;
            this.PartEditBtn.Text = "Edit";
            this.PartEditBtn.UseVisualStyleBackColor = false;
            this.PartEditBtn.Click += new System.EventHandler(this.OnEditPartClick);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DodgerBlue;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(204, 336);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Create";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.OnAction);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Tomato;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(123, 336);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Reset";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.OnResetClicked);
            // 
            // WorkOrderTb
            // 
            this.WorkOrderTb.Location = new System.Drawing.Point(116, 283);
            this.WorkOrderTb.Name = "WorkOrderTb";
            this.WorkOrderTb.Size = new System.Drawing.Size(163, 20);
            this.WorkOrderTb.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 286);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Work Order:";
            // 
            // PackerTb
            // 
            this.PackerTb.Location = new System.Drawing.Point(116, 3);
            this.PackerTb.Name = "PackerTb";
            this.PackerTb.Size = new System.Drawing.Size(163, 20);
            this.PackerTb.TabIndex = 1;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(8, 6);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(72, 13);
            this.label58.TabIndex = 19;
            this.label58.Text = "Packer Name";
            // 
            // ReceiverNewEntryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PackerTb);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.WorkOrderTb);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BoxCountsTb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BoxesTb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PartNameTb);
            this.Controls.Add(this.label1);
            this.Name = "ReceiverNewEntryControl";
            this.Size = new System.Drawing.Size(311, 367);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PartNameTb;
        private System.Windows.Forms.TextBox DescriptionTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BoxCountTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox BoxTypeCb;
        private System.Windows.Forms.TextBox BoxesTb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox BoxCountsTb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button PartEditBtn;
        private System.Windows.Forms.Button PartEditCancelBtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button PartSaveInfoBtn;
        private System.Windows.Forms.TextBox WorkOrderTb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox PackerTb;
        private System.Windows.Forms.Label label58;
    }
}
