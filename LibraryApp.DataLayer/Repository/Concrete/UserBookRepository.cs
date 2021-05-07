using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.DataLayer
{
    public class UserBookRepository : Repository<ENTUserBook>, IUserBookRepository
    {
        #region Constracter
        private LibraryAppContext _libraryAppContext { get { return _context as LibraryAppContext; } }
        public UserBookRepository(LibraryAppContext library) : base(library)
        {

        }
        #endregion
    }
}
