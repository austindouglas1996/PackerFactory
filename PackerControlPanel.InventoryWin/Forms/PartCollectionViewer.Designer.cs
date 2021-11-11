namespace PackerControlPanel.InventoryWin.Forms
{
    partial class PartCollectionViewer
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
            this.PartCollection = new PackerControlPanel.InventoryWin.Controls.ListWithSearch();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RemoveSelected = new System.Windows.Forms.Button();
            this.ViewSelected = new System.Windows.Forms.Button();
            this.AddNew = new System.Windows.Forms.Button();
            this.RemoveAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PartCollection
            // 
            this.PartCollection.BackColor = System.Drawing.Color.Transparent;
            this.PartCollection.Location = new System.Drawing.Point(1, 2);
            this.PartCollection.Name = "PartCollection";
            this.PartCollection.Size = new System.Drawing.Size(643, 663);
            this.PartCollection.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RemoveSelected);
            this.groupBox1.Controls.Add(this.ViewSelected);
            this.groupBox1.Location = new System.Drawing.Point(441, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 49);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Item";
            // 
            // RemoveSelected
            // 
            this.RemoveSelected.Location = new System.Drawing.Point(92, 19);
            this.RemoveSelected.Name = "RemoveSelected";
            this.RemoveSelected.Size = new System.Drawing.Size(75, 23);
            this.RemoveSelected.TabIndex = 1;
            this.RemoveSelected.Text = "Remove";
            this.RemoveSelected.UseVisualStyleBackColor = true;
            this.RemoveSelected.Click += new System.EventHandler(this.RemoveSelected_Click);
            // 
            // ViewSelected
            // 
            this.ViewSelected.Location = new System.Drawing.Point(6, 19);
            this.ViewSelected.Name = "ViewSelected";
            this.ViewSelected.Size = new System.Drawing.Size(75, 23);
            this.ViewSelected.TabIndex = 0;
            this.ViewSelected.Text = "View";
            this.ViewSelected.UseVisualStyleBackColor = true;
            this.ViewSelected.Click += new System.EventHandler(this.ViewSelected_Click);
            // 
            // AddNew
            // 
            this.AddNew.Location = new System.Drawing.Point(325, 21);
            this.AddNew.Name = "AddNew";
            this.AddNew.Size = new System.Drawing.Size(93, 23);
            this.AddNew.TabIndex = 2;
            this.AddNew.Text = "Add New Part";
            this.AddNew.UseVisualStyleBackColor = true;
            this.AddNew.Click += new System.EventHandler(this.AddNew_Click);
            // 
            // RemoveAll
            // 
            this.RemoveAll.Location = new System.Drawing.Point(325, 50);
            this.RemoveAll.Name = "RemoveAll";
            this.RemoveAll.Size = new System.Drawing.Size(93, 23);
            this.RemoveAll.TabIndex = 3;
            this.RemoveAll.Text = "Remove All Parts";
            this.RemoveAll.UseVisualStyleBackColor = true;
            this.RemoveAll.Click += new System.EventHandler(this.RemoveAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Part Collection";
            // 
            // PartCollectionViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 667);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RemoveAll);
            this.Controls.Add(this.AddNew);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PartCollection);
            this.Name = "PartCollectionViewer";
            this.Text = "PartCollectionViewer";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ListWithSearch PartCollection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ViewSelected;
        private System.Windows.Forms.Button RemoveSelected;
        private System.Windows.Forms.Button AddNew;
        private System.Windows.Forms.Button RemoveAll;
        private System.Windows.Forms.Label label1;
    }
}