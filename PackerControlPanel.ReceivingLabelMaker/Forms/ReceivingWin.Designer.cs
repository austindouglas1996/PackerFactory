namespace PackerControlPanel.RPCP.Forms
{
    partial class ReceivingWin
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
            this.ReceiverEntryGroup = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MsReceiverCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.MsReceiverLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.MsReceiverClose = new System.Windows.Forms.ToolStripMenuItem();
            this.MsReceiverDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.MsReceiverExtract = new System.Windows.Forms.ToolStripMenuItem();
            this.ReceiverOptionsGroup = new System.Windows.Forms.GroupBox();
            this.ReceiverCompleteBtn = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ReceiverNameTb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CreationDateTb = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MsViewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MsEditLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.MsDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.ReceiverOptionsGroup.SuspendLayout();
            this.ItemMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReceiverEntryGroup
            // 
            this.ReceiverEntryGroup.Enabled = false;
            this.ReceiverEntryGroup.Location = new System.Drawing.Point(457, 196);
            this.ReceiverEntryGroup.Name = "ReceiverEntryGroup";
            this.ReceiverEntryGroup.Size = new System.Drawing.Size(346, 410);
            this.ReceiverEntryGroup.TabIndex = 1;
            this.ReceiverEntryGroup.TabStop = false;
            this.ReceiverEntryGroup.Text = "New Entry";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(817, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MsReceiverCreate,
            this.MsReceiverLoad,
            this.MsReceiverClose,
            this.MsReceiverDelete,
            this.MsReceiverExtract});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(63, 20);
            this.toolStripMenuItem1.Text = "Receiver";
            // 
            // MsReceiverCreate
            // 
            this.MsReceiverCreate.Name = "MsReceiverCreate";
            this.MsReceiverCreate.Size = new System.Drawing.Size(180, 22);
            this.MsReceiverCreate.Text = "Create New";
            this.MsReceiverCreate.Click += new System.EventHandler(this.OnReceiver_CreateNew);
            // 
            // MsReceiverLoad
            // 
            this.MsReceiverLoad.Name = "MsReceiverLoad";
            this.MsReceiverLoad.Size = new System.Drawing.Size(180, 22);
            this.MsReceiverLoad.Text = "Load Existing";
            this.MsReceiverLoad.Click += new System.EventHandler(this.OnReceiver_Load);
            // 
            // MsReceiverClose
            // 
            this.MsReceiverClose.Name = "MsReceiverClose";
            this.MsReceiverClose.Size = new System.Drawing.Size(180, 22);
            this.MsReceiverClose.Text = "Close";
            this.MsReceiverClose.Click += new System.EventHandler(this.OnReceiver_Close);
            // 
            // MsReceiverDelete
            // 
            this.MsReceiverDelete.Name = "MsReceiverDelete";
            this.MsReceiverDelete.Size = new System.Drawing.Size(180, 22);
            this.MsReceiverDelete.Text = "Delete";
            this.MsReceiverDelete.Click += new System.EventHandler(this.OnReceiver_Delete);
            // 
            // MsReceiverExtract
            // 
            this.MsReceiverExtract.Name = "MsReceiverExtract";
            this.MsReceiverExtract.Size = new System.Drawing.Size(180, 22);
            this.MsReceiverExtract.Text = "Extract";
            this.MsReceiverExtract.Click += new System.EventHandler(this.OnReceiver_Extract);
            // 
            // ReceiverOptionsGroup
            // 
            this.ReceiverOptionsGroup.Controls.Add(this.ReceiverCompleteBtn);
            this.ReceiverOptionsGroup.Controls.Add(this.button9);
            this.ReceiverOptionsGroup.Controls.Add(this.label5);
            this.ReceiverOptionsGroup.Controls.Add(this.ReceiverNameTb);
            this.ReceiverOptionsGroup.Controls.Add(this.label6);
            this.ReceiverOptionsGroup.Controls.Add(this.CreationDateTb);
            this.ReceiverOptionsGroup.Controls.Add(this.button1);
            this.ReceiverOptionsGroup.Enabled = false;
            this.ReceiverOptionsGroup.Location = new System.Drawing.Point(457, 37);
            this.ReceiverOptionsGroup.Name = "ReceiverOptionsGroup";
            this.ReceiverOptionsGroup.Size = new System.Drawing.Size(346, 153);
            this.ReceiverOptionsGroup.TabIndex = 24;
            this.ReceiverOptionsGroup.TabStop = false;
            this.ReceiverOptionsGroup.Text = "Receiver Name And Options";
            // 
            // ReceiverCompleteBtn
            // 
            this.ReceiverCompleteBtn.BackColor = System.Drawing.Color.Yellow;
            this.ReceiverCompleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReceiverCompleteBtn.Location = new System.Drawing.Point(256, 81);
            this.ReceiverCompleteBtn.Name = "ReceiverCompleteBtn";
            this.ReceiverCompleteBtn.Size = new System.Drawing.Size(75, 23);
            this.ReceiverCompleteBtn.TabIndex = 13;
            this.ReceiverCompleteBtn.Text = "Complete";
            this.ReceiverCompleteBtn.UseVisualStyleBackColor = false;
            this.ReceiverCompleteBtn.Click += new System.EventHandler(this.Reciever_CompleteClick);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(256, 29);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 3;
            this.button9.Text = "Extract";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.OnReceiver_Extract);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Name";
            // 
            // ReceiverNameTb
            // 
            this.ReceiverNameTb.Location = new System.Drawing.Point(109, 31);
            this.ReceiverNameTb.Name = "ReceiverNameTb";
            this.ReceiverNameTb.Size = new System.Drawing.Size(129, 20);
            this.ReceiverNameTb.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Creation Date";
            // 
            // CreationDateTb
            // 
            this.CreationDateTb.Location = new System.Drawing.Point(109, 57);
            this.CreationDateTb.Name = "CreationDateTb";
            this.CreationDateTb.ReadOnly = true;
            this.CreationDateTb.Size = new System.Drawing.Size(129, 20);
            this.CreationDateTb.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(205, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnReceiver_Save);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 37);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(439, 569);
            this.listView1.TabIndex = 28;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseUp);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Part Name";
            this.columnHeader3.Width = 104;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Job Name";
            this.columnHeader4.Width = 81;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Boxes";
            this.columnHeader5.Width = 67;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Box Counts";
            this.columnHeader6.Width = 79;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Stored Bin";
            this.columnHeader7.Width = 99;
            // 
            // ItemMenuStrip
            // 
            this.ItemMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MsViewItem,
            this.addNoteToolStripMenuItem,
            this.MsEditLocation,
            this.MsDeleteItem});
            this.ItemMenuStrip.Name = "ItemMenuStrip";
            this.ItemMenuStrip.Size = new System.Drawing.Size(155, 92);
            this.ItemMenuStrip.Text = "Options";
            // 
            // MsViewItem
            // 
            this.MsViewItem.Name = "MsViewItem";
            this.MsViewItem.Size = new System.Drawing.Size(154, 22);
            this.MsViewItem.Text = "View Item";
            this.MsViewItem.Click += new System.EventHandler(this.OnEntry_View);
            // 
            // addNoteToolStripMenuItem
            // 
            this.addNoteToolStripMenuItem.Name = "addNoteToolStripMenuItem";
            this.addNoteToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.addNoteToolStripMenuItem.Text = "Notes (Max 1)";
            this.addNoteToolStripMenuItem.Click += new System.EventHandler(this.addNoteToolStripMenuItem_Click);
            // 
            // MsEditLocation
            // 
            this.MsEditLocation.Name = "MsEditLocation";
            this.MsEditLocation.Size = new System.Drawing.Size(154, 22);
            this.MsEditLocation.Text = "Edit Location";
            this.MsEditLocation.Click += new System.EventHandler(this.OnEntry_SetLocation);
            // 
            // MsDeleteItem
            // 
            this.MsDeleteItem.Name = "MsDeleteItem";
            this.MsDeleteItem.Size = new System.Drawing.Size(154, 22);
            this.MsDeleteItem.Text = "Delete Selected";
            this.MsDeleteItem.Click += new System.EventHandler(this.OnEntry_Delete);
            // 
            // ReceivingWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 617);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.ReceiverOptionsGroup);
            this.Controls.Add(this.ReceiverEntryGroup);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ReceivingWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RPCP Receiver Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ReceiverOptionsGroup.ResumeLayout(false);
            this.ReceiverOptionsGroup.PerformLayout();
            this.ItemMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox ReceiverEntryGroup;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox ReceiverOptionsGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ReceiverNameTb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CreationDateTb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MsReceiverCreate;
        private System.Windows.Forms.ToolStripMenuItem MsReceiverLoad;
        private System.Windows.Forms.ToolStripMenuItem MsReceiverClose;
        private System.Windows.Forms.ToolStripMenuItem MsReceiverDelete;
        private System.Windows.Forms.ToolStripMenuItem MsReceiverExtract;
        private RPCP.Controls.ReceiverNewEntryControl NewEntryController;
        private System.Windows.Forms.Button ReceiverCompleteBtn;
        private System.Windows.Forms.ContextMenuStrip ItemMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MsViewItem;
        private System.Windows.Forms.ToolStripMenuItem MsEditLocation;
        private System.Windows.Forms.ToolStripMenuItem MsDeleteItem;
        private System.Windows.Forms.ToolStripMenuItem addNoteToolStripMenuItem;
    }
}

