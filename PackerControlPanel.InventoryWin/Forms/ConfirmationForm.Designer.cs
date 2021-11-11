namespace PackerControlPanel.UI.Forms
{
    partial class ConfirmationForm
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
            this.PrintBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FilePrintCb = new System.Windows.Forms.CheckBox();
            this.PrinterOptions = new System.Windows.Forms.ComboBox();
            this.ReceiveBox = new System.Windows.Forms.GroupBox();
            this.ReceiverChooseBtn = new System.Windows.Forms.Button();
            this.ReceiverNameTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ActiveReceivers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.PrintCb = new System.Windows.Forms.CheckBox();
            this.ReceiveCb = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.PrintBox.SuspendLayout();
            this.ReceiveBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrintBox
            // 
            this.PrintBox.Controls.Add(this.label3);
            this.PrintBox.Controls.Add(this.FilePrintCb);
            this.PrintBox.Controls.Add(this.PrinterOptions);
            this.PrintBox.Enabled = false;
            this.PrintBox.Location = new System.Drawing.Point(16, 108);
            this.PrintBox.Name = "PrintBox";
            this.PrintBox.Size = new System.Drawing.Size(236, 126);
            this.PrintBox.TabIndex = 0;
            this.PrintBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Printer";
            // 
            // FilePrintCb
            // 
            this.FilePrintCb.AutoSize = true;
            this.FilePrintCb.Location = new System.Drawing.Point(136, 74);
            this.FilePrintCb.Name = "FilePrintCb";
            this.FilePrintCb.Size = new System.Drawing.Size(82, 17);
            this.FilePrintCb.TabIndex = 2;
            this.FilePrintCb.Text = "Print To File";
            this.FilePrintCb.UseVisualStyleBackColor = true;
            // 
            // PrinterOptions
            // 
            this.PrinterOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PrinterOptions.FormattingEnabled = true;
            this.PrinterOptions.Location = new System.Drawing.Point(18, 47);
            this.PrinterOptions.Name = "PrinterOptions";
            this.PrinterOptions.Size = new System.Drawing.Size(200, 21);
            this.PrinterOptions.TabIndex = 1;
            // 
            // ReceiveBox
            // 
            this.ReceiveBox.Controls.Add(this.button3);
            this.ReceiveBox.Controls.Add(this.ReceiverChooseBtn);
            this.ReceiveBox.Controls.Add(this.ReceiverNameTxt);
            this.ReceiveBox.Controls.Add(this.label5);
            this.ReceiveBox.Controls.Add(this.label4);
            this.ReceiveBox.Controls.Add(this.ActiveReceivers);
            this.ReceiveBox.Enabled = false;
            this.ReceiveBox.Location = new System.Drawing.Point(16, 273);
            this.ReceiveBox.Name = "ReceiveBox";
            this.ReceiveBox.Size = new System.Drawing.Size(351, 150);
            this.ReceiveBox.TabIndex = 1;
            this.ReceiveBox.TabStop = false;
            // 
            // ReceiverChooseBtn
            // 
            this.ReceiverChooseBtn.Location = new System.Drawing.Point(236, 19);
            this.ReceiverChooseBtn.Name = "ReceiverChooseBtn";
            this.ReceiverChooseBtn.Size = new System.Drawing.Size(99, 23);
            this.ReceiverChooseBtn.TabIndex = 9;
            this.ReceiverChooseBtn.Text = "Find Receiver...";
            this.ReceiverChooseBtn.UseVisualStyleBackColor = true;
            this.ReceiverChooseBtn.Click += new System.EventHandler(this.ReceiverChooseBtn_Click);
            // 
            // ReceiverNameTxt
            // 
            this.ReceiverNameTxt.Location = new System.Drawing.Point(133, 112);
            this.ReceiverNameTxt.Name = "ReceiverNameTxt";
            this.ReceiverNameTxt.ReadOnly = true;
            this.ReceiverNameTxt.Size = new System.Drawing.Size(202, 20);
            this.ReceiverNameTxt.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Chosen Receiver";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Active Receivers";
            // 
            // ActiveReceivers
            // 
            this.ActiveReceivers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ActiveReceivers.FormattingEnabled = true;
            this.ActiveReceivers.Location = new System.Drawing.Point(18, 72);
            this.ActiveReceivers.Name = "ActiveReceivers";
            this.ActiveReceivers.Size = new System.Drawing.Size(200, 21);
            this.ActiveReceivers.TabIndex = 2;
            this.ActiveReceivers.SelectedIndexChanged += new System.EventHandler(this.ActiveReceiver_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Confirmation And Action Options";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(211, 439);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Accept";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(292, 439);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PrintCb
            // 
            this.PrintCb.AutoSize = true;
            this.PrintCb.Location = new System.Drawing.Point(16, 85);
            this.PrintCb.Name = "PrintCb";
            this.PrintCb.Size = new System.Drawing.Size(77, 17);
            this.PrintCb.TabIndex = 0;
            this.PrintCb.Text = "Print labels";
            this.PrintCb.UseVisualStyleBackColor = true;
            this.PrintCb.CheckedChanged += new System.EventHandler(this.Cb_CheckChanged);
            // 
            // ReceiveCb
            // 
            this.ReceiveCb.AutoSize = true;
            this.ReceiveCb.Location = new System.Drawing.Point(16, 250);
            this.ReceiveCb.Name = "ReceiveCb";
            this.ReceiveCb.Size = new System.Drawing.Size(100, 17);
            this.ReceiveCb.TabIndex = 1;
            this.ReceiveCb.Text = "Receive Labels";
            this.ReceiveCb.UseVisualStyleBackColor = true;
            this.ReceiveCb.CheckedChanged += new System.EventHandler(this.Cb_CheckChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(131, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Create new...";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Select actions to do with the created array of labels.";
            // 
            // ConfirmationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 477);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ReceiveCb);
            this.Controls.Add(this.PrintCb);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReceiveBox);
            this.Controls.Add(this.PrintBox);
            this.Name = "ConfirmationForm";
            this.Text = "ConfirmationForm";
            this.PrintBox.ResumeLayout(false);
            this.PrintBox.PerformLayout();
            this.ReceiveBox.ResumeLayout(false);
            this.ReceiveBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox PrintBox;
        private System.Windows.Forms.GroupBox ReceiveBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox PrintCb;
        private System.Windows.Forms.CheckBox ReceiveCb;
        private System.Windows.Forms.CheckBox FilePrintCb;
        private System.Windows.Forms.ComboBox PrinterOptions;
        private System.Windows.Forms.ComboBox ActiveReceivers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ReceiverNameTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ReceiverChooseBtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
    }
}