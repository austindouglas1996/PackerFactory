using System;
using System.Collections.Generic;
using System.Text;

namespace EntityRepository
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}
