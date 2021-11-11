using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackerControlPanel.RPCP.Controls
{
    public partial class ListWithSearch : UserControl
    {
        /// <summary>
        /// Tells whether the user is currently using the search functions.
        /// </summary>
        private bool _IsSearching = false;

        /// <summary>
        /// The last column index clicked. #0 is normally used for ID so use #1 as default.
        /// </summary>
        private int SelectedColumn = 0;

        /// <summary>
        /// Holds a list of items before search is conducted.
        /// </summary>
        private List<ListViewItem> OriginalItems = new List<ListViewItem>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ListWithSearch"/> class.
        /// </summary>
        public ListWithSearch()
        {
            InitializeComponent();

            this.ListView.ColumnClick += ListView_ColumnClick;

            // On 'Enter' key start a new search.
            this._SearchTB.KeyDown += SearchTb_KeyDown;
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
            get { return this.listView1; }
            set
            {
                if (this._IsSearching)
                    throw new InvalidOperationException("Unable to set listview when a search is active.");

                this.listView1 = value;
            }
        }

        public TextBox SearchTB
        {
            get { return this._SearchTB; }
            set { this._SearchTB = value; }
        }

        /// <summary>
        /// Return a boolean telling if a search is in progress.
        /// </summary>
        public bool IsSearching
        {
            get { return _IsSearching; }
        }

        /// <summary>
        /// Start a new search.
        /// </summary>
        /// <param name="text"></param>
        public void Search(string text)
        {
            if (_IsSearching == false)
            {
                // Set original items.
                this.OriginalItems.Clear();
                foreach (ListViewItem item in this.listView1.Items)
                    this.OriginalItems.Add(item);

                // We're searching now.
                this._IsSearching = true;
            }

            if (SelectedColumn == -1)
                SelectedColumn = 0;

            // Clear listview.
            this.listView1.Items.Clear();

            // Total amount of items found.
            int total = 0;

            foreach (ListViewItem item in this.OriginalItems)
            {
                if (item.SubItems[SelectedColumn].Text.ToLower().Contains(text.ToLower()))
                {
                    this.listView1.Items.Add((ListViewItem)item.Clone());
                    total += 1;
                }
            }

            // Show no results found.
            ZeroResultsPanel.Visible = (total == 0 ? true : false);

            this.OnSearchCalled(EventArgs.Empty);
        }

        /// <summary>
        /// Cancel the current search if one is running.
        /// </summary>
        public void CancelSearch()
        {
            if (this._IsSearching == true)
            {
                // Reset search text.
                this._SearchTB.Text = "";

                // Done.
                this._IsSearching = false;

                // Hide if visible.
                ZeroResultsPanel.Visible = false;

                // Reset items.
                this.listView1.Items.Clear();
                foreach (var item in this.OriginalItems)
                    this.listView1.Items.Add(item);

                this.OnSearchCancelled(EventArgs.Empty);
            }
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

            if (searchEmpty && _IsSearching)
                this.CancelSearch();
        }

        /// <summary>
        /// Set the selected column.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SelectedColumn = e.Column;
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

        /// <summary>
        /// Change window and child elements.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WinSizeChanged(object sender, EventArgs e)
        {
            int hBuffer = 10;

            this.SearchTB.Location = new Point(
                0 + this.Width - this.SearchTB.Width -hBuffer, 5);

            this.SearchLabel.Location = new Point(
                0 + (int)(this.Width * 0.8) - this.SearchTB.Width, 
                (this.SearchTB.Location.Y + (this.SearchTB.Height / 2)) / 2);

            this.listView1.Location = new Point(5, (int)(this.SearchTB.Height * 1.7) + hBuffer);

            this.listView1.Width = this.Width - hBuffer;
            this.listView1.Height = this.Height -60;
        }
    }
}
