using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.InventoryWin.Forms
{
    public partial class PartParentEditor : Form
    {
        private IPartRepository _parts;
        private Part part;
        private Part selectedParent;

        public PartParentEditor(IPartRepository parts, Part part)
        {
            InitializeComponent();

            this._parts = parts;
            this.part = part;

            this.PartID.Text = part.ID.ToString();
            this.PartName.Text = part.Name;

            this.ParentID.Text = part.ParentID.ToString();
            this.ParentName.Text = part.Parent != null ? part.Parent.Name : "";

            this.ParentID.LostFocus += LoadParent;
            this.ParentName.LostFocus += LoadParent;
        }

        private void LoadParent(object sender, EventArgs e)
        {
            bool SetByID = true;
            TextBox tb = (TextBox)sender;

            if (tb.Name == "ParentName")
                SetByID = false;

            if (tb.Text != "")
            {
                if (SetByID)
                {
                    int num = 0;

                    // Make sure user supplied a number.
                    if (Int32.TryParse(tb.Text, out num))
                    {
                        this.selectedParent = _parts.Get((Int32.Parse(tb.Text)));
                        if (this.selectedParent == null)
                        {
                            MessageBox.Show("Failed to find a part by that ID. Please set an existing ID.");
                            tb.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to convert value to an Int32. Please supply a number.");
                        tb.Focus();
                    }
                }
                else
                {
                    this.selectedParent = _parts.FirstOrDefault(p => p.Name == tb.Text);
                    if (this.selectedParent == null)
                    {
                        MessageBox.Show("Failed to find a part by that name. Please supply an existing part name.");
                        tb.Focus();
                    }
                }
            }

            if (this.selectedParent != null)
            {
                ParentID.Text = this.selectedParent.ID.ToString();
                ParentName.Text = this.selectedParent.Name;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.part.ParentID = this.selectedParent.ID;
            this._parts.Edit(this.part);

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
