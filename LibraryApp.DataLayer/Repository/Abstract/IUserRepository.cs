using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.DataLayer
{
    public interface IUserRepository : IRepository<ENTUser>
    {
        public ENTUser GetByUsername(string username);
      
    }
}
