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

namespace PackerControlPanel.InventoryWin.Windows
{
    public partial class PartEditorForm : Form
    {
        private IPartRepository PartCollection;
        private Part part;

        /// <summary>
        /// Initializes a new instance of the <see cref="PartEditorForm"/> class.
        /// </summary>
        /// <param name="partCollection"></param>
        /// <param name="part"></param>
        public PartEditorForm(IPartRepository partCollection, Part part)
        {
            this.PartCollection = partCollection;

            InitializeComponent();

            var PackageTypes = Enum.GetNames(typeof(PackageType));
            for (int i = 0; i < PackageTypes.Count(); i++)
            {
                // Get the original type.
                PackageType pType = (PackageType)Enum.Parse(typeof(PackageType), PackageTypes[i]);

                this.partBoxTypeCB.Items.Add(new PackageTypeItem(i, pType));
            }

            this.LoadPart(part);
        }

        /// <summary>
        /// Get the part loaded.
        /// </summary>
        public Part GetPart
        {
            get { return this.part; }
        }

        /// <summary>
        /// Take the part information and replace UI values.
        /// </summary>
        /// <param name="part"></param>
        protected virtual void LoadPart(Part part)
        {
            this.part = part;

            this.partIDTB.Text = part.ID.ToString();
            this.partNameTB.Text = part.Name;
            this.partDescTB.Text = part.Description;

            if (part.Parent != null)
            {
                this.partParentIDTb.Text = part.ParentID.ToString();
                this.partParentNameTB.Text = part.Parent.Name;
                this.partParentDescTB.Text = part.Parent.Description;
            }
            else
            {
                this.partParentIDTb.Text = "Null";
                this.partParentNameTB.Text = "No parent.";
                this.partParentDescTB.Text = "No parent.";
            }

            this.partBoxCountTB.Text = part.DefaultBoxCount.ToString();
            this.partBoxTypeCB.SelectedIndex = Array.IndexOf(Enum.GetValues(part.PackingInfo.BoxType.GetType()), part.PackingInfo.BoxType);
            this.partBoxDirTB.Text = part.PackingInfo.BoxingDirections;
        }

        /// <summary>
        /// Save the part to the collection.
        /// </summary>
        protected virtual void SavePart()
        {
            Part part = PartCollection.Get(int.Parse(this.partIDTB.Text));

            part.Name = partNameTB.Text;
            part.Description = partDescTB.Text;
            part.DefaultBoxCount = int.Parse(partBoxCountTB.Text);

            if (partParentIDTb.Text != "Null")
                part.ParentID = int.Parse(partParentIDTb.Text);

            var selectedItem = (PackageTypeItem)this.partBoxTypeCB.SelectedItem;
            if (selectedItem == null)
                throw new ArgumentNullException("Failed to get selected box type.");

            part.PackingInfo.BoxType = selectedItem.PackageType;
            part.PackingInfo.BoxingDirections = partBoxDirTB.Text;

            PartCollection.Edit(part);
        }

        /// <summary>
        /// Save the part info and close the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acceptFBTN_Click(object sender, EventArgs e)
        {
            this.SavePart();
            this.Close();
        }

        /// <summary>
        /// Cancel and save nothing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelFBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
