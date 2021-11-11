﻿using EntityRepository;
using PackerControlPanel.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Core.Repository
{
    public interface IDateEntryRepository : IRepository<ReceiverEntryDateEntry>
    {
        List<ReceiverEntryDateEntry> GetEntriesFromDate(DateTime date);
    }
}
