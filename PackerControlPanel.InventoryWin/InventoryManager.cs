using PackerControlPanel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PackerControlPanel.InventoryWin
{
    public class InventoryManager
    {
        private bool connected = false;
        private PackerContext _Context;
        private PackerUnitOfWork _Worker;

        /// <summary>
        /// Gets the repository context.
        /// </summary>
        public PackerContext Context
        {
            get
            {
                if (!connected)
                    throw new InvalidOperationException("Not connected.");

                return this._Context;
            }
        }

        /// <summary>
        /// Gets the repository worker.
        /// </summary>
        public PackerUnitOfWork Worker
        {
            get
            {
                if (!connected)
                    throw new InvalidOperationException("Not connected.");

                return this._Worker;
            }
        }

        /// <summary>
        /// Create a connection.
        /// </summary>
        /// <param name="connectionString"></param>
        public void CreateConnection(string connectionString)
        {
            this._Context = new PackerContext(connectionString);
            this._Worker = new PackerUnitOfWork(this._Context);
            this.connected = true;
        }
    }
}
