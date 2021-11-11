using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.InventoryWin.Helpers
{
    internal static class Helper
    {
        public static ColumnHeader[] PartColumnHeader
        {
            get
            {
                return new ColumnHeader[]
                {
                    CreateHeader("ID"),
                    CreateHeader("Name", 100),
                    CreateHeader("Box Count", 100),
                    CreateHeader("Box Type", 100),
                    CreateHeader("Description", 200),
                    CreateHeader("Creation Date", 100)
                };
            }
        }

        public static ColumnHeader[] JobColumnHeader
        {
            get
            {
                return new ColumnHeader[]
                {
                    CreateHeader("ID"),
                    CreateHeader("Name"),
                    CreateHeader("Part Name", 150),
                    CreateHeader("Collected Amount", 75),
                    CreateHeader("Current State", 150),
                    CreateHeader("Creation Date", 100),
                    CreateHeader("Completeion Date", 100)
                };
            }
        }

        public static ColumnHeader[] ReceiverEntryColumnHeader
        {
            get
            {
                return new ColumnHeader[]
                {
                    CreateHeader("ID"),
                    CreateHeader("Receiver Name",100),
                    CreateHeader("Job Name",100),
                    CreateHeader("Total Received",100),
                    CreateHeader("Box Count",70),
                    CreateHeader("Boxes",70),
                    CreateHeader("Manufacture Dates",200),
                    CreateHeader("Creation Time",100)
                };
            }
        }

        public static ColumnHeader[] NoteColumnHeader
        {
            get
            {
                return new ColumnHeader[]
                {
                    CreateHeader("ID"),
                    CreateHeader("Message", 300),
                    CreateHeader("Creation Date", 100)
                };
            }
        }

        private static ColumnHeader CreateHeader(string text, int width = -1, HorizontalAlignment alignment = HorizontalAlignment.Left)
        {
            var header = new ColumnHeader();
            header.Text = text;
            header.Width = width;
            header.TextAlign = alignment;

            return header;
        }
    }
}
