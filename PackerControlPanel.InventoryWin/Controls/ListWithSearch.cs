using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.Receiving.Controls
{
    public partial class ListWithSearch : UserControl
    {
        /// <summary>
        /// Tells whether the user is currently using the search functions.
        /// </summary>
        private bool IsSearching = false;

        /// <summary>
        /// Contains the items that match the user search.
        /// </summary>
        private ListView SearchLV = new ListView();

        /// <summary>
        /// Handles the sorting by column.
        /// </summary>
        private ListViewColumnSorter LvColumnSorter;
       
        /// <summary>
        /// Initializes a new instance of the <see cref="ListWithSearch"/> class.
        /// </summary>
        public ListWithSearch()
        {
            InitializeComponent();

            // Create column sorter.
            this.LvColumnSorter = new ListViewColumnSorter();
            this.ListView.ListViewItemSorter = this.LvColumnSorter;
            this.ListView.ColumnClick += ListView1_ColumnClick;

            // Create search.
            this.SearchLV = new ListView();
            this.SearchLV.ListViewItemSorter = this.LvColumnSorter;
            this.SearchLV.GridLines = true;
            this.SearchLV.ColumnClick += ListView1_ColumnClick;
            this.SearchLV.Size = this.ListView.Size;
            this.SearchLV.Location = this.ListView.Location;
            this.SearchLV.HeaderStyle = this.ListView.HeaderStyle;
            this.SearchLV.View = this.ListView.View;
            this.SearchLV.Visible = false;
            this.Controls.Add(this.SearchLV);

            // On 'Enter' key start a new search.
            this._SearchTB.KeyDown += SearchTb_KeyDown;

            // Resize all elements on size change.
            this.SizeChanged += ListViewWithSearch_SizeChanged;
        }

        /// <summary>
        /// Invokes when a new search is called.
        /// </summary>
        public event EventHandler SearchCalled;

        /// <summary>
        /// Invokes when a search is cancelled and everything is restored.
        /// </summary>
        public event EventHandler SearchCancelled;

        public ListView ListView
        {
            get { return this.ListView1; }
            set
            {
                if (this.IsSearching)
                    throw new InvalidOperationException("Unable to set listview when a search is active.");

                this.ListView1 = value;
            }
        }

        public ListView SearchListView
        {
            get { return this.SearchLV; }
            set { this.SearchLV = value; }
        }

        public TextBox SearchTB
        {
            get { return this._SearchTB; }
            set { this._SearchTB = value; }
        }

        /// <summary>
        /// Start a new search.
        /// </summary>
        /// <param name="text"></param>
        public void Search(string text)
        {
            if (IsSearching == false)
            {
                this.SearchLV.Columns.Clear();

                foreach (ColumnHeader column in this.ListView.Columns)
                    this.SearchLV.Columns.Add((ColumnHeader)column.Clone());

                // Make search visible, hide default.
                this.SearchLV.Visible = true;
                this.ListView.Visible = false;

                // We're searching now.
                this.IsSearching = true;
            }
            else
            {
                this.SearchLV.Items.Clear();
            }

            foreach (ListViewItem item in this.ListView.Items)
            {
                if (item.SubItems[0].Text.Contains(text))
                {
                    this.SearchLV.Items.Add((ListViewItem)item.Clone());
                }
            }

            this.OnSearchCalled(EventArgs.Empty);
        }

        /// <summary>
        /// Cancel the current search if one is running.
        /// </summary>
        public void CancelSearch()
        {
            if (this.IsSearching == true)
            {
                // Clear and restore collection.
                this.SearchLV.Items.Clear();

                // Hide search.
                this.SearchLV.Visible = false;
                this.ListView.Visible = true;

                // Reset search text.
                this._SearchTB.Text = "";

                // Done.
                this.IsSearching = false;

                this.OnSearchCancelled(EventArgs.Empty);
            }
        }

        private void ListViewWithSearch_SizeChanged(object sender, EventArgs e)
        {
            int top = (this.panel1.Top + this.panel1.Height);

            this.ListView.Width = this.Width - 20;
            this.ListView.Height = (this.Height - top- 10);
            this.ListView.Top = (this.panel1.Top + this.panel1.Height + 10);

            this.SearchLV.Width = this.ListView.Width;
            this.SearchLV.Height = this.ListView.Height;
            this.SearchLV.Top = this.ListView.Top;
            this.SearchLV.Height = this.ListView.Height;

            //this.panel1.Left = this.Width - this.panel1.Width - 10;
        }

        private void ListView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.LvColumnSorter.SortColumn = e.Column;

            if (IsSearching)
                this.SearchLV.Sort();
            else
                this.ListView.Sort();
        }

        /// <summary>
        /// On Key 'Enter' start a new search.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTb_KeyDown(object sender, KeyEventArgs e)
        {
            bool searchEmpty = string.IsNullOrEmpty(this._SearchTB.Text);

            if (e.KeyCode == Keys.Enter && !searchEmpty)
            {
                this.Search(this._SearchTB.Text);

                e.SuppressKeyPress = true;
            }

            if (searchEmpty && IsSearching)
                this.CancelSearch();
        }

        /// <summary>
        /// Invoke the <see cref="SearchCalled"/> event.
        /// </summary>
        /// <param name="e"></param>
        private void OnSearchCalled(EventArgs e)
        {
            if (this.SearchCalled != null)
                this.SearchCalled(this, e);
        }

        /// <summary>
        /// Invoke the <see cref="SearchCancelled"/> event.
        /// </summary>
        /// <param name="e"></param>
        private void OnSearchCancelled(EventArgs e)
        {
            if (this.SearchCancelled != null)
                this.SearchCancelled(this, e);
        }
    }
}
