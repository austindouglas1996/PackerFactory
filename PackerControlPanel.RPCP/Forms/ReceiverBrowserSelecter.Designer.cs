using PackerControlPanel.RPCP.Controls;

namespace PackerControlPanel.RPCP.Forms
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
            this.label7 = new System.Windows.Forms.Label();
            this.AcceptBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LvSearch = new PackerControlPanel.RPCP.Controls.ListWithSearch();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(28, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Receiver Browser";
            // 
            // AcceptBtn
            // 
            this.AcceptBtn.Location = new System.Drawing.Point(627, 541);
            this.AcceptBtn.Name = "AcceptBtn";
            this.AcceptBtn.Size = new System.Drawing.Size(85, 30);
            this.AcceptBtn.TabIndex = 9;
            this.AcceptBtn.Text = "Load";
            this.AcceptBtn.UseVisualStyleBackColor = true;
            this.AcceptBtn.Click += new System.EventHandler(this.AcceptBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Load an existing Receiver document.";
            // 
            // LvSearch
            // 
            this.LvSearch.BackColor = System.Drawing.Color.Transparent;
            this.LvSearch.Location = new System.Drawing.Point(7, 12);
            this.LvSearch.Name = "LvSearch";
            this.LvSearch.Size = new System.Drawing.Size(724, 530);
            this.LvSearch.TabIndex = 10;
            // 
            // ReceiverBrowserSelecter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 588);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LvSearch);
            this.Controls.Add(this.AcceptBtn);
            this.Controls.Add(this.label7);
            this.Name = "ReceiverBrowserSelecter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ReceiverBrowser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button AcceptBtn;
        private ListWithSearch LvSearch;
        private System.Windows.Forms.Label label1;
    }
}