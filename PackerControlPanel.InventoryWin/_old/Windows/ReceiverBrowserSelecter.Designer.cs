namespace PackerControlPanel.InventoryWin.Windows
{
    partial class ReceiverBrowserSelecter
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
            this.LvSearch = new PackerControlPanel.InventoryWin.Controls.ListWithSearch();
            this.label7 = new System.Windows.Forms.Label();
            this.AcceptBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LvSearch
            // 
            this.LvSearch.BackColor = System.Drawing.Color.Transparent;
            this.LvSearch.Location = new System.Drawing.Point(-9, -1);
            this.LvSearch.Name = "LvSearch";
            this.LvSearch.Size = new System.Drawing.Size(724, 480);
            this.LvSearch.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(246, 33);
            this.label7.TabIndex = 8;
            this.label7.Text = "Receiver Browser";
            // 
            // AcceptBtn
            // 
            this.AcceptBtn.Location = new System.Drawing.Point(619, 499);
            this.AcceptBtn.Name = "AcceptBtn";
            this.AcceptBtn.Size = new System.Drawing.Size(75, 23);
            this.AcceptBtn.TabIndex = 9;
            this.AcceptBtn.Text = "Accept";
            this.AcceptBtn.UseVisualStyleBackColor = true;
            this.AcceptBtn.Click += new System.EventHandler(this.AcceptBtn_Click);
            // 
            // ReceiverBrowserSelecter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 534);
            this.Controls.Add(this.AcceptBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LvSearch);
            this.Name = "ReceiverBrowserSelecter";
            this.Text = "ReceiverBrowser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ListWithSearch LvSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button AcceptBtn;
    }
}