namespace PackerControlPanel.RPCP.Forms
{
    partial class TransferWin
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MsCreateNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MsLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.MsClose = new System.Windows.Forms.ToolStripMenuItem();
            this.MsTransferDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.TransferNameTb = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.CreationDateTb = new System.Windows.Forms.TextBox();
            this.MsPool = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MsPoolAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.MsDoc = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MsDocView = new System.Windows.Forms.ToolStripMenuItem();
            this.MsDocEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MsDocRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.MsDocNotes = new System.Windows.Forms.ToolStripMenuItem();
            this.sqLiteCommandBuilder1 = new System.Data.SQLite.SQLiteCommandBuilder();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.DocView = new PackerControlPanel.RPCP.Controls.ListWithSearch();
            this.PoolView = new PackerControlPanel.RPCP.Controls.ListWithSearch();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.MsPool.SuspendLayout();
            this.MsDoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.transferToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1054, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // transferToolStripMenuItem
            // 
            this.transferToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MsCreateNew,
            this.MsLoad,
            this.MsClose,
            this.MsTransferDelete});
            this.transferToolStripMenuItem.Name = "transferToolStripMenuItem";
            this.transferToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.transferToolStripMenuItem.Text = "Transfer";
            // 
            // MsCreateNew
            // 
            this.MsCreateNew.Name = "MsCreateNew";
            this.MsCreateNew.Size = new System.Drawing.Size(180, 22);
            this.MsCreateNew.Text = "Create New";
            this.MsCreateNew.Click += new System.EventHandler(this.MsCreate_Clicked);
            // 
            // MsLoad
            // 
            this.MsLoad.Name = "MsLoad";
            this.MsLoad.Size = new System.Drawing.Size(180, 22);
            this.MsLoad.Text = "Load Existing";
            this.MsLoad.Click += new System.EventHandler(this.MsLoad_Click);
            // 
            // MsClose
            // 
            this.MsClose.Name = "MsClose";
            this.MsClose.Size = new System.Drawing.Size(180, 22);
            this.MsClose.Text = "Close";
            this.MsClose.Click += new System.EventHandler(this.MsClose_Click);
            // 
            // MsTransferDelete
            // 
            this.MsTransferDelete.Name = "MsTransferDelete";
            this.MsTransferDelete.Size = new System.Drawing.Size(180, 22);
            this.MsTransferDelete.Text = "Delete";
            this.MsTransferDelete.Click += new System.EventHandler(this.MsTransferDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Transfer Pool";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.TransferNameTb);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.CreationDateTb);
            this.groupBox1.Location = new System.Drawing.Point(476, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 92);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Document Options";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Yellow;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(473, 57);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 22;
            this.button3.Text = "Complete";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.TransferComplete_Click);
            // 
            // TransferNameTb
            // 
            this.TransferNameTb.Location = new System.Drawing.Point(111, 30);
            this.TransferNameTb.Name = "TransferNameTb";
            this.TransferNameTb.Size = new System.Drawing.Size(129, 20);
            this.TransferNameTb.TabIndex = 16;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(473, 27);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 14;
            this.button9.Text = "Extract";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.Extract_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Name";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(246, 54);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(33, 23);
            this.button4.TabIndex = 21;
            this.button4.Text = "Set";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.DocSet_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Creation Date";
            // 
            // CreationDateTb
            // 
            this.CreationDateTb.Location = new System.Drawing.Point(111, 56);
            this.CreationDateTb.Name = "CreationDateTb";
            this.CreationDateTb.ReadOnly = true;
            this.CreationDateTb.Size = new System.Drawing.Size(129, 20);
            this.CreationDateTb.TabIndex = 18;
            // 
            // MsPool
            // 
            this.MsPool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MsPoolAdd});
            this.MsPool.Name = "MsPool";
            this.MsPool.Size = new System.Drawing.Size(144, 26);
            // 
            // MsPoolAdd
            // 
            this.MsPoolAdd.Name = "MsPoolAdd";
            this.MsPoolAdd.Size = new System.Drawing.Size(143, 22);
            this.MsPoolAdd.Text = "Add Selected";
            this.MsPoolAdd.Click += new System.EventHandler(this.MsAdd_Clicked);
            // 
            // MsDoc
            // 
            this.MsDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MsDocView,
            this.MsDocEdit,
            this.MsDocRemove,
            this.MsDocNotes});
            this.MsDoc.Name = "MsDoc";
            this.MsDoc.Size = new System.Drawing.Size(181, 92);
            // 
            // MsDocView
            // 
            this.MsDocView.Name = "MsDocView";
            this.MsDocView.Size = new System.Drawing.Size(180, 22);
            this.MsDocView.Text = "View Selected";
            // 
            // MsDocEdit
            // 
            this.MsDocEdit.Name = "MsDocEdit";
            this.MsDocEdit.Size = new System.Drawing.Size(180, 22);
            this.MsDocEdit.Text = "Edit Stored Location";
            this.MsDocEdit.Click += new System.EventHandler(this.MsDocEdit_Click);
            // 
            // MsDocRemove
            // 
            this.MsDocRemove.Name = "MsDocRemove";
            this.MsDocRemove.Size = new System.Drawing.Size(180, 22);
            this.MsDocRemove.Text = "Remove Selected";
            this.MsDocRemove.Click += new System.EventHandler(this.MsDoc_DeleteClick);
            // 
            // MsDocNotes
            // 
            this.MsDocNotes.Name = "MsDocNotes";
            this.MsDocNotes.Size = new System.Drawing.Size(180, 22);
            this.MsDocNotes.Text = "View Notes";
            this.MsDocNotes.Click += new System.EventHandler(this.MsDocNotes_Click);
            // 
            // sqLiteCommandBuilder1
            // 
            this.sqLiteCommandBuilder1.DataAdapter = null;
            this.sqLiteCommandBuilder1.QuoteSuffix = "]";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Part Name";
            this.columnHeader10.Width = 93;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Job Name";
            this.columnHeader11.Width = 107;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Total";
            this.columnHeader12.Width = 99;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Received Location";
            this.columnHeader13.Width = 127;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Part Name";
            this.columnHeader1.Width = 93;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Job Name";
            this.columnHeader2.Width = 107;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Total";
            this.columnHeader3.Width = 99;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Received Location";
            this.columnHeader4.Width = 127;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Stored Location";
            this.columnHeader14.Width = 127;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Extract Pool";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(23, 70);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(387, 62);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "The left container is the pool that contains receiver entries that are waiting to" +
    " be moved to their permanent home. The right container will contain the transfer" +
    " document you are creating.";
            // 
            // DocView
            // 
            this.DocView.BackColor = System.Drawing.Color.Transparent;
            this.DocView.Location = new System.Drawing.Point(476, 150);
            this.DocView.Name = "DocView";
            this.DocView.Size = new System.Drawing.Size(571, 646);
            this.DocView.TabIndex = 11;
            this.DocView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DocView_MouseUp);
            // 
            // PoolView
            // 
            this.PoolView.BackColor = System.Drawing.Color.Transparent;
            this.PoolView.Location = new System.Drawing.Point(12, 150);
            this.PoolView.Name = "PoolView";
            this.PoolView.Size = new System.Drawing.Size(458, 646);
            this.PoolView.TabIndex = 10;
            this.PoolView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DocView_MouseUp);
            // 
            // TransferWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 808);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DocView);
            this.Controls.Add(this.PoolView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TransferWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TransferForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.MsPool.ResumeLayout(false);
            this.MsDoc.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox TransferNameTb;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CreationDateTb;
        private System.Windows.Forms.ToolStripMenuItem MsCreateNew;
        private System.Windows.Forms.ToolStripMenuItem MsLoad;
        private System.Windows.Forms.ToolStripMenuItem MsClose;
        private System.Windows.Forms.ContextMenuStrip MsPool;
        private System.Windows.Forms.ToolStripMenuItem MsPoolAdd;
        private System.Windows.Forms.ContextMenuStrip MsDoc;
        private System.Windows.Forms.ToolStripMenuItem MsDocView;
        private System.Windows.Forms.ToolStripMenuItem MsDocEdit;
        private System.Windows.Forms.ToolStripMenuItem MsDocRemove;
        private System.Windows.Forms.ToolStripMenuItem MsTransferDelete;
        private System.Windows.Forms.ToolStripMenuItem MsDocNotes;
        private System.Data.SQLite.SQLiteCommandBuilder sqLiteCommandBuilder1;
        private Controls.ListWithSearch PoolView;
        private Controls.ListWithSearch DocView;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}