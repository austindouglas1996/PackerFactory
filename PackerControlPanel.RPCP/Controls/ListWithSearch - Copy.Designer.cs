namespace PackerControlPanel.RPCP.Controls
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
            this.searchPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this._SearchTB = new System.Windows.Forms.TextBox();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.panel1.Controls.Add(this._SearchTB);
            this.panel1.Controls.Add(this.SearchLabel);
            this.panel1.Location = new System.Drawing.Point(221, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 46);
            this.panel1.TabIndex = 13;
            // 
            // _SearchTB
            // 
            this._SearchTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this._SearchTB.Location = new System.Drawing.Point(267, 17);
            this._SearchTB.Name = "_SearchTB";
            this._SearchTB.Size = new System.Drawing.Size(220, 20);
            this._SearchTB.TabIndex = 2;
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.SearchLabel.Location = new System.Drawing.Point(197, 23);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(44, 13);
            this.SearchLabel.TabIndex = 1;
            this.SearchLabel.Text = "Search:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(10, 55);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(698, 459);
            this.listView1.TabIndex = 14;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ListWithSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Name = "ListWithSearch";
            this.Size = new System.Drawing.Size(724, 532);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.TextBox _SearchTB;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ListView listView1;
    }
}
