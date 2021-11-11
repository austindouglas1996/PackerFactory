﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Core.UI
{
    public interface IView<TModel> : IView
        where TModel : class
    {
        TModel Model { get; set; }
    }
}
