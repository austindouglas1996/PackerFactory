using PackerControlPanel.Data;
using PackerControlPanel.Tests.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");
            var inventory = new PackerUnitOfWork(new PackerContext());
            var p = inventory.Parts.GetAll();
            
            DbTest_FakeData.FillFakeData(inventory, 20);
        }
    }
}
