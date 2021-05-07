using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryApp.DataLayer
{
    public class UserRepository : Repository<ENTUser> , IUserRepository
    {
        #region Constracter
        private LibraryAppContext _libraryAppContext { get { return _context as LibraryAppContext; } }
        public UserRepository(LibraryAppContext library) : base(library)
        {

        }
        #endregion
        public ENTUser GetByUsername(string Username)
        {
            return _libraryAppContext.User.Where(m => m.UserName == Username).SingleOrDefault();
        }

       
    }
}
