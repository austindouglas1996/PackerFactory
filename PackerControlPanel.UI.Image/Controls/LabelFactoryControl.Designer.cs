namespace PackerControlPanel.UI.Image.Controls
{
    partial class LabelFactoryControl
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
            this.EditPartBtn = new System.Windows.Forms.Button();
            this.RunLabelsBtn = new System.Windows.Forms.Button();
            this.EditJobBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.LotOrderTb = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.PackerNameTb = new System.Windows.Forms.TextBox();
            this.ResetFieldsBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MfrDatesTb = new System.Windows.Forms.TextBox();
            this.ShiftsLb = new System.Windows.Forms.Label();
            this.ShiftsTb = new System.Windows.Forms.TextBox();
            this.OrderNumLb = new System.Windows.Forms.Label();
            this.OrderNumTb = new System.Windows.Forms.TextBox();
            this.BoxCountsLb = new System.Windows.Forms.Label();
            this.BoxCountTb = new System.Windows.Forms.TextBox();
            this.BoxesLb = new System.Windows.Forms.Label();
            this.BoxesTb = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.PartNameTb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // EditPartBtn
            // 
            this.EditPartBtn.Enabled = false;
            this.EditPartBtn.Location = new System.Drawing.Point(249, 52);
            this.EditPartBtn.Name = "EditPartBtn";
            this.EditPartBtn.Size = new System.Drawing.Size(39, 21);
            this.EditPartBtn.TabIndex = 49;
            this.EditPartBtn.Text = "Edit";
            this.EditPartBtn.UseVisualStyleBackColor = true;
            // 
            // RunLabelsBtn
            // 
            this.RunLabelsBtn.BackColor = System.Drawing.Color.Red;
            this.RunLabelsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RunLabelsBtn.Location = new System.Drawing.Point(190, 366);
            this.RunLabelsBtn.Name = "RunLabelsBtn";
            this.RunLabelsBtn.Size = new System.Drawing.Size(98, 30);
            this.RunLabelsBtn.TabIndex = 40;
            this.RunLabelsBtn.Text = "Confirm";
            this.RunLabelsBtn.UseVisualStyleBackColor = false;
            this.RunLabelsBtn.Click += new System.EventHandler(this.RunLabelsBtn_Click);
            // 
            // EditJobBtn
            // 
            this.EditJobBtn.Enabled = false;
            this.EditJobBtn.Location = new System.Drawing.Point(249, 130);
            this.EditJobBtn.Name = "EditJobBtn";
            this.EditJobBtn.Size = new System.Drawing.Size(39, 21);
            this.EditJobBtn.TabIndex = 48;
            this.EditJobBtn.Text = "Edit";
            this.EditJobBtn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Lot Order:";
            // 
            // LotOrderTb
            // 
            this.LotOrderTb.Location = new System.Drawing.Point(93, 156);
            this.LotOrderTb.Name = "LotOrderTb";
            this.LotOrderTb.Size = new System.Drawing.Size(150, 20);
            this.LotOrderTb.TabIndex = 36;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(15, 328);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(65, 13);
            this.linkLabel1.TabIndex = 46;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "What\'s this?";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(93, 29);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(51, 17);
            this.checkBox1.TabIndex = 29;
            this.checkBox1.Text = "Save";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // PackerNameTb
            // 
            this.PackerNameTb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.PackerNameTb.Location = new System.Drawing.Point(93, 3);
            this.PackerNameTb.Name = "PackerNameTb";
            this.PackerNameTb.Size = new System.Drawing.Size(150, 20);
            this.PackerNameTb.TabIndex = 28;
            // 
            // ResetFieldsBtn
            // 
            this.ResetFieldsBtn.Location = new System.Drawing.Point(4, 372);
            this.ResetFieldsBtn.Name = "ResetFieldsBtn";
            this.ResetFieldsBtn.Size = new System.Drawing.Size(73, 24);
            this.ResetFieldsBtn.TabIndex = 42;
            this.ResetFieldsBtn.Text = "Reset";
            this.ResetFieldsBtn.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Packer Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Manufacture dates.";
            // 
            // MfrDatesTb
            // 
            this.MfrDatesTb.Location = new System.Drawing.Point(15, 238);
            this.MfrDatesTb.Multiline = true;
            this.MfrDatesTb.Name = "MfrDatesTb";
            this.MfrDatesTb.Size = new System.Drawing.Size(254, 83);
            this.MfrDatesTb.TabIndex = 39;
            // 
            // ShiftsLb
            // 
            this.ShiftsLb.AutoSize = true;
            this.ShiftsLb.Location = new System.Drawing.Point(12, 186);
            this.ShiftsLb.Name = "ShiftsLb";
            this.ShiftsLb.Size = new System.Drawing.Size(36, 13);
            this.ShiftsLb.TabIndex = 43;
            this.ShiftsLb.Text = "Shifts:";
            // 
            // ShiftsTb
            // 
            this.ShiftsTb.Location = new System.Drawing.Point(93, 182);
            this.ShiftsTb.Name = "ShiftsTb";
            this.ShiftsTb.Size = new System.Drawing.Size(150, 20);
            this.ShiftsTb.TabIndex = 38;
            // 
            // OrderNumLb
            // 
            this.OrderNumLb.AutoSize = true;
            this.OrderNumLb.Location = new System.Drawing.Point(12, 134);
            this.OrderNumLb.Name = "OrderNumLb";
            this.OrderNumLb.Size = new System.Drawing.Size(65, 13);
            this.OrderNumLb.TabIndex = 41;
            this.OrderNumLb.Text = "Work Order:";
            // 
            // OrderNumTb
            // 
            this.OrderNumTb.Location = new System.Drawing.Point(93, 130);
            this.OrderNumTb.Name = "OrderNumTb";
            this.OrderNumTb.Size = new System.Drawing.Size(150, 20);
            this.OrderNumTb.TabIndex = 35;
            // 
            // BoxCountsLb
            // 
            this.BoxCountsLb.AutoSize = true;
            this.BoxCountsLb.Location = new System.Drawing.Point(12, 108);
            this.BoxCountsLb.Name = "BoxCountsLb";
            this.BoxCountsLb.Size = new System.Drawing.Size(61, 13);
            this.BoxCountsLb.TabIndex = 37;
            this.BoxCountsLb.Text = "BoxCounts:";
            // 
            // BoxCountTb
            // 
            this.BoxCountTb.Location = new System.Drawing.Point(93, 104);
            this.BoxCountTb.Name = "BoxCountTb";
            this.BoxCountTb.Size = new System.Drawing.Size(150, 20);
            this.BoxCountTb.TabIndex = 33;
            // 
            // BoxesLb
            // 
            this.BoxesLb.AutoSize = true;
            this.BoxesLb.Location = new System.Drawing.Point(12, 82);
            this.BoxesLb.Name = "BoxesLb";
            this.BoxesLb.Size = new System.Drawing.Size(39, 13);
            this.BoxesLb.TabIndex = 34;
            this.BoxesLb.Text = "Boxes:";
            // 
            // BoxesTb
            // 
            this.BoxesTb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.BoxesTb.Location = new System.Drawing.Point(93, 78);
            this.BoxesTb.Name = "BoxesTb";
            this.BoxesTb.Size = new System.Drawing.Size(150, 20);
            this.BoxesTb.TabIndex = 31;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(12, 56);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(60, 13);
            this.label32.TabIndex = 32;
            this.label32.Text = "Part Name:";
            // 
            // PartNameTb
            // 
            this.PartNameTb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.PartNameTb.Location = new System.Drawing.Point(93, 52);
            this.PartNameTb.Name = "PartNameTb";
            this.PartNameTb.Size = new System.Drawing.Size(150, 20);
            this.PartNameTb.TabIndex = 30;
            // 
            // LabelFactoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EditPartBtn);
            this.Controls.Add(this.RunLabelsBtn);
            this.Controls.Add(this.EditJobBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LotOrderTb);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.PackerNameTb);
            this.Controls.Add(this.ResetFieldsBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MfrDatesTb);
            this.Controls.Add(this.ShiftsLb);
            this.Controls.Add(this.ShiftsTb);
            this.Controls.Add(this.OrderNumLb);
            this.Controls.Add(this.OrderNumTb);
            this.Controls.Add(this.BoxCountsLb);
            this.Controls.Add(this.BoxCountTb);
            this.Controls.Add(this.BoxesLb);
            this.Controls.Add(this.BoxesTb);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.PartNameTb);
            this.Name = "LabelFactoryControl";
            this.Size = new System.Drawing.Size(295, 405);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EditPartBtn;
        private System.Windows.Forms.Button RunLabelsBtn;
        private System.Windows.Forms.Button EditJobBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LotOrderTb;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox PackerNameTb;
        private System.Windows.Forms.Button ResetFieldsBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MfrDatesTb;
        private System.Windows.Forms.Label ShiftsLb;
        private System.Windows.Forms.TextBox ShiftsTb;
        private System.Windows.Forms.Label OrderNumLb;
        private System.Windows.Forms.TextBox OrderNumTb;
        private System.Windows.Forms.Label BoxCountsLb;
        private System.Windows.Forms.TextBox BoxCountTb;
        private System.Windows.Forms.Label BoxesLb;
        private System.Windows.Forms.TextBox BoxesTb;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox PartNameTb;
    }
}
