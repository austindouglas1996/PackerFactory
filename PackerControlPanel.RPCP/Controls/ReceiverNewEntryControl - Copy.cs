using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PackerControlPanel.ReceivingLabelMaker.Common;
using PackerControlPanel.Core.Domain;
using PackerControlPanel.Data;
using PackerControlPanel.ReceivingLabelMaker.Forms;
using PackerControlPanel.Image;
using PackerControlPanel.Image.Views;

namespace PackerControlPanel.ReceivingLabelMaker.Controls
{
    public partial class ReceiverNewEntryControl : UserControl, ILabelFactoryBaseView
    {
        /// <summary>
        /// Manager of inventory.
        /// </summary>
        private PackerUnitOfWork Worker;

        /// <summary>
        /// Manages the creation of all labels and receiver entries..
        /// </summary>
        private LabelFactoryProcessor<LabelOrder> _Processor;

        /// <summary>
        /// Currently selected part for receiver entry.
        /// </summary>
        private Part ActivePart;

        public ReceiverNewEntryControl(PackerUnitOfWork worker, LabelFactoryProcessor<LabelOrder> processor)
        {
            this.Worker = worker;
            this._Processor = processor;

            InitializeComponent();

            // Set box types.
            this.BoxTypeCb.Items.AddRange(PackageInfo.BoxTypes);
        }

        /// <summary>
        /// Part information changed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPartChange(object sender, EventArgs e)
        {
            LoadPartInfo(this.PartNameTb.Text);
        }

        /// <summary>
        /// Load part information or ask the user to create it.
        /// </summary>
        /// <param name="partName"></param>
        private void LoadPartInfo(string partName)
        {
            // Reset the part information.
            if (partName == "")
            {
                this.DescriptionTb.Text = "";
                this.BoxCountsTb.Text = "";
                this.BoxTypeCb.SelectedIndex = 0;

                // Disable part editing.
                this.PartEditBtn.Enabled = false;
                this.PartEditBtn.BackColor = Color.SlateGray;
            }
            else
            {
                // Retrieve the part.
                ActivePart = Worker.Parts.Get(partName);

                // Part not found. Let's create it?
                if (ActivePart == null)
                {
                    NewPartForm newPart = new NewPartForm(Worker, partName);
                    DialogResult result = newPart.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        Worker.Parts.Add(newPart.NewPart);
                        ActivePart = newPart.NewPart;
                    }
                    else
                        return;
                }

                // Set part information.
                this.DescriptionTb.Text = ActivePart.Description;
                this.BoxCountTb.Text = ActivePart.DefaultBoxCount.ToString();
                this.BoxTypeCb.SelectedIndex = this.BoxTypeCb.FindStringExact(ActivePart.PackingInfo.BoxType.ToString());

                // Enable edit box.
                this.PartEditBtn.Enabled = true;
                this.PartEditBtn.BackColor = Color.DodgerBlue;
            }
        }

        /// <summary>
        /// Allow part editing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEditPartClick(object sender, EventArgs e)
        {
            this.PartEditCancelBtn.Visible = true;
            this.PartEditBtn.Visible = false;
            this.PartSaveInfoBtn.Visible = true;

            this.BoxTypeCb.Enabled = true;
            this.BoxCountTb.Enabled = true;
        }

        /// <summary>
        /// Cancel part editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancelPartClick(object sender, EventArgs e)
        {
            this.PartEditCancelBtn.Visible = false;
            this.PartEditBtn.Visible = true;
            this.PartSaveInfoBtn.Visible = false;

            this.BoxTypeCb.Enabled = false;
            this.BoxCountTb.Enabled = false;
        }

        /// <summary>
        /// Reset part form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnResetClicked(object sender, EventArgs e)
        {
            this.LoadPartInfo("");
            this.PartNameTb.Clear();
            this.BoxCountsTb.Clear();
            this.BoxesTb.Clear();
            this.MfrDatesTb.Clear();
        }

        /// <summary>
        /// Save part information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSavePartClick(object sender, EventArgs e)
        {
            if (ActivePart == null)
                return;

            if (this.BoxCountTb.Text == "")
            {
                MessageBox.Show("Failed to save part information: BoxCount was empty or null.");
                return;
            }

            ActivePart.DefaultBoxCount = Convert.ToInt32(this.BoxCountTb.Text);
            ActivePart.PackingInfo.BoxType = this.BoxTypeCb.Text;

            Worker.Parts.Edit(ActivePart);

            this.OnCancelPartClick(sender, e);
        }

        private void OnCreateClicked(object sender, EventArgs e)
        {
            
        }
    }
}
