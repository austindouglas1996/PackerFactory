namespace PackerControlPanel.InventoryWin.Controls
{
    partial class ListWithSearch
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
            this.components = new System.ComponentModel.Container();
            this.ListView1 = new System.Windows.Forms.ListView();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.DescendingBTN = new System.Windows.Forms.RadioButton();
            this._SearchTB = new System.Windows.Forms.TextBox();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.AscendingBTN = new System.Windows.Forms.RadioButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListView1
            // 
            this.ListView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListView1.FullRowSelect = true;
            this.ListView1.GridLines = true;
            this.ListView1.Location = new System.Drawing.Point(10, 85);
            this.ListView1.Name = "ListView1";
            this.ListView1.Size = new System.Drawing.Size(701, 566);
            this.ListView1.TabIndex = 12;
            this.ListView1.UseCompatibleStateImageBehavior = false;
            this.ListView1.View = System.Windows.Forms.View.Details;
            // 
            // searchPanel
            // 
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(429, 57);
            this.searchPanel.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.DescendingBTN);
            this.panel1.Controls.Add(this._SearchTB);
            this.panel1.Controls.Add(this.SearchLabel);
            this.panel1.Controls.Add(this.AscendingBTN);
            this.panel1.Location = new System.Drawing.Point(340, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 76);
            this.panel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search Type:";
            // 
            // DescendingBTN
            // 
            this.DescendingBTN.AutoSize = true;
            this.DescendingBTN.Location = new System.Drawing.Point(93, 47);
            this.DescendingBTN.Name = "DescendingBTN";
            this.DescendingBTN.Size = new System.Drawing.Size(82, 17);
            this.DescendingBTN.TabIndex = 3;
            this.DescendingBTN.Text = "Descending";
            this.DescendingBTN.UseVisualStyleBackColor = true;
            // 
            // _SearchTB
            // 
            this._SearchTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._SearchTB.Location = new System.Drawing.Point(201, 38);
            this._SearchTB.Name = "_SearchTB";
            this._SearchTB.Size = new System.Drawing.Size(153, 26);
            this._SearchTB.TabIndex = 2;
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchLabel.Location = new System.Drawing.Point(197, 18);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(64, 20);
            this.SearchLabel.TabIndex = 1;
            this.SearchLabel.Text = "Search:";
            // 
            // AscendingBTN
            // 
            this.AscendingBTN.AutoSize = true;
            this.AscendingBTN.Checked = true;
            this.AscendingBTN.Location = new System.Drawing.Point(12, 47);
            this.AscendingBTN.Name = "AscendingBTN";
            this.AscendingBTN.Size = new System.Drawing.Size(75, 17);
            this.AscendingBTN.TabIndex = 0;
            this.AscendingBTN.TabStop = true;
            this.AscendingBTN.Text = "Ascending";
            this.AscendingBTN.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ListViewWithSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ListView1);
            this.Name = "ListViewWithSearch";
            this.Size = new System.Drawing.Size(724, 663);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView ListView1;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton AscendingBTN;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.TextBox _SearchTB;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.RadioButton DescendingBTN;
        private System.Windows.Forms.Label label1;
    }
}
