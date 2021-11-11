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
    public partial class PartCreator : Form
    {
        private Part newPart;
        private IPartRepository parts;

        public PartCreator(IPartRepository parts)
        {
            InitializeComponent();

            var PackageTypes = Enum.GetNames(typeof(PackageType));
            for (int i = 0; i < PackageTypes.Count(); i++)
            {
                // Get the original type.
                PackageType pType = (PackageType)Enum.Parse(typeof(PackageType), PackageTypes[i]);

                this.partBoxTypeCB.Items.Add(new PackageTypeItem(i, pType));
            }

            this.parts = parts;

            partCountTb.LostFocus += PartCountTb_LostFocus;
        }

        public Part GetPart()
        {
            return this.newPart;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newPart = new Part();
            newPart.Name = partNameTB.Text;
            newPart.Description = partDescTb.Text;
            newPart.DefaultBoxCount = Int32.Parse(partCountTb.Text);

            var selectedItem = (PackageTypeItem)this.partBoxTypeCB.SelectedItem;
            if (selectedItem == null)
                throw new ArgumentNullException("Failed to get selected box type.");

            newPart.PackingInfo.BoxType = selectedItem.PackageType;
            newPart.PackingInfo.BoxingDirections = partBoxDirTB.Text;

            parts.Add(newPart);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PartCountTb_LostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            Int32 num = 0;
            bool result = Int32.TryParse(tb.Text, out num);

            if (result == false)
            {
                MessageBox.Show("Value must represent a Int32.");
                tb.Focus();
            }
        }
    }
}
