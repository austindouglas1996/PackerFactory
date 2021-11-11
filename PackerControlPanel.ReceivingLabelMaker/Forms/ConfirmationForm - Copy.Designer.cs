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
            this.EntryList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.PrintBox.Location = new System.Drawing.Point(16, 87);
            this.PrintBox.Name = "PrintBox";
            this.PrintBox.Size = new System.Drawing.Size(236, 126);
            this.PrintBox.TabIndex = 0;
            this.PrintBox.TabStop = false;
            this.PrintBox.Text = "Printing Options";
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
            this.ReceiveBox.Controls.Add(this.ReceiverChooseBtn);
            this.ReceiveBox.Controls.Add(this.ReceiverNameTxt);
            this.ReceiveBox.Controls.Add(this.label5);
            this.ReceiveBox.Controls.Add(this.label4);
            this.ReceiveBox.Controls.Add(this.ActiveReceivers);
            this.ReceiveBox.Enabled = false;
            this.ReceiveBox.Location = new System.Drawing.Point(258, 87);
            this.ReceiveBox.Name = "ReceiveBox";
            this.ReceiveBox.Size = new System.Drawing.Size(351, 126);
            this.ReceiveBox.TabIndex = 1;
            this.ReceiveBox.TabStop = false;
            this.ReceiveBox.Text = "Receiving Options";
            // 
            // ReceiverChooseBtn
            // 
            this.ReceiverChooseBtn.Location = new System.Drawing.Point(236, 42);
            this.ReceiverChooseBtn.Name = "ReceiverChooseBtn";
            this.ReceiverChooseBtn.Size = new System.Drawing.Size(99, 23);
            this.ReceiverChooseBtn.TabIndex = 9;
            this.ReceiverChooseBtn.Text = "Other Receiver";
            this.ReceiverChooseBtn.UseVisualStyleBackColor = true;
            this.ReceiverChooseBtn.Click += new System.EventHandler(this.ReceiverChooseBtn_Click);
            // 
            // ReceiverNameTxt
            // 
            this.ReceiverNameTxt.Location = new System.Drawing.Point(133, 84);
            this.ReceiverNameTxt.Name = "ReceiverNameTxt";
            this.ReceiverNameTxt.ReadOnly = true;
            this.ReceiverNameTxt.Size = new System.Drawing.Size(202, 20);
            this.ReceiverNameTxt.TabIndex = 8;
            this.ReceiverNameTxt.TextChanged += new System.EventHandler(this.ReceiverNameChange);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Chosen Receiver";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Active Receivers";
            // 
            // ActiveReceivers
            // 
            this.ActiveReceivers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ActiveReceivers.FormattingEnabled = true;
            this.ActiveReceivers.Location = new System.Drawing.Point(19, 44);
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
            this.button1.Location = new System.Drawing.Point(453, 558);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Accept";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(534, 558);
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
            this.PrintCb.Location = new System.Drawing.Point(30, 55);
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
            this.ReceiveCb.Location = new System.Drawing.Point(113, 55);
            this.ReceiveCb.Name = "ReceiveCb";
            this.ReceiveCb.Size = new System.Drawing.Size(100, 17);
            this.ReceiveCb.TabIndex = 1;
            this.ReceiveCb.Text = "Receive Labels";
            this.ReceiveCb.UseVisualStyleBackColor = true;
            this.ReceiveCb.CheckedChanged += new System.EventHandler(this.Cb_CheckChanged);
            // 
            // EntryList
            // 
            this.EntryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader7,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader8,
            this.columnHeader9});
            this.EntryList.HideSelection = false;
            this.EntryList.Location = new System.Drawing.Point(16, 219);
            this.EntryList.Name = "EntryList";
            this.EntryList.Size = new System.Drawing.Size(593, 333);
            this.EntryList.TabIndex = 7;
            this.EntryList.UseCompatibleStateImageBehavior = false;
            this.EntryList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "EntryID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "RID";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Part Name";
            // 
            // columnHeader7
            // 
            this.columnHeader7.DisplayIndex = 6;
            this.columnHeader7.Text = "Description";
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 3;
            this.columnHeader4.Text = "Job Name";
            // 
            // columnHeader5
            // 
            this.columnHeader5.DisplayIndex = 4;
            this.columnHeader5.Text = "Lot #";
            // 
            // columnHeader6
            // 
            this.columnHeader6.DisplayIndex = 5;
            this.columnHeader6.Text = "Box Count";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Shift";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Mfr. Dates";
            // 
            // ConfirmationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 592);
            this.Controls.Add(this.EntryList);
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
        private System.Windows.Forms.ListView EntryList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}