namespace PackerControlPanel.Image.DescMan
{
    partial class ConfigSelector
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
            this.label1 = new System.Windows.Forms.Label();
            this.Xml_Cb = new System.Windows.Forms.CheckBox();
            this.Db_Cb = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.path_tb = new System.Windows.Forms.TextBox();
            this.browse_btn = new System.Windows.Forms.Button();
            this.accept = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dbConnectionString = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select the type of repository you\'re wanting to open:";
            // 
            // Xml_Cb
            // 
            this.Xml_Cb.AutoSize = true;
            this.Xml_Cb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Xml_Cb.Location = new System.Drawing.Point(27, 68);
            this.Xml_Cb.Name = "Xml_Cb";
            this.Xml_Cb.Size = new System.Drawing.Size(141, 24);
            this.Xml_Cb.TabIndex = 1;
            this.Xml_Cb.Text = "XML Repository";
            this.Xml_Cb.UseVisualStyleBackColor = true;
            this.Xml_Cb.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // Db_Cb
            // 
            this.Db_Cb.AutoSize = true;
            this.Db_Cb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Db_Cb.Location = new System.Drawing.Point(27, 98);
            this.Db_Cb.Name = "Db_Cb";
            this.Db_Cb.Size = new System.Drawing.Size(183, 24);
            this.Db_Cb.TabIndex = 2;
            this.Db_Cb.Text = "Database Connection";
            this.Db_Cb.UseVisualStyleBackColor = true;
            this.Db_Cb.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "File path:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "For XML repository: Give a direct path to the file.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Yellow;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 298);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(352, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "For Database Connection . Give a direct path to the DB configuration file.";
            // 
            // path_tb
            // 
            this.path_tb.Location = new System.Drawing.Point(26, 325);
            this.path_tb.Name = "path_tb";
            this.path_tb.Size = new System.Drawing.Size(304, 20);
            this.path_tb.TabIndex = 6;
            // 
            // browse_btn
            // 
            this.browse_btn.Location = new System.Drawing.Point(336, 323);
            this.browse_btn.Name = "browse_btn";
            this.browse_btn.Size = new System.Drawing.Size(75, 23);
            this.browse_btn.TabIndex = 7;
            this.browse_btn.Text = "Browse";
            this.browse_btn.UseVisualStyleBackColor = true;
            this.browse_btn.Click += new System.EventHandler(this.BrowseClick);
            // 
            // accept
            // 
            this.accept.Location = new System.Drawing.Point(255, 362);
            this.accept.Name = "accept";
            this.accept.Size = new System.Drawing.Size(75, 23);
            this.accept.TabIndex = 8;
            this.accept.Text = "Accept";
            this.accept.UseVisualStyleBackColor = true;
            this.accept.Click += new System.EventHandler(this.AcceptClick);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(336, 362);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 9;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.CancelClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dbConnectionString);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(27, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 83);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database Connection String";
            // 
            // dbConnectionString
            // 
            this.dbConnectionString.Location = new System.Drawing.Point(17, 35);
            this.dbConnectionString.Name = "dbConnectionString";
            this.dbConnectionString.Size = new System.Drawing.Size(304, 26);
            this.dbConnectionString.TabIndex = 11;
            // 
            // ConfigSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 398);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.accept);
            this.Controls.Add(this.browse_btn);
            this.Controls.Add(this.path_tb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Db_Cb);
            this.Controls.Add(this.Xml_Cb);
            this.Controls.Add(this.label1);
            this.Name = "ConfigSelector";
            this.Text = "ConfigSelector";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox Xml_Cb;
        private System.Windows.Forms.CheckBox Db_Cb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox path_tb;
        private System.Windows.Forms.Button browse_btn;
        private System.Windows.Forms.Button accept;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox dbConnectionString;
    }
}