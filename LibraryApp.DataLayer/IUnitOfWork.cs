using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.DataLayer
{
    public interface IUnitOfWork : IDisposable
    {
        public int Complete();
    }
}
