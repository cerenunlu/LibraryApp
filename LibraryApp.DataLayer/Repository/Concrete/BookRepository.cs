using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryApp.DataLayer
{
    public class BookRepository : Repository<ENTBook>, IBookRepository
    {
        #region Constracter
        private LibraryAppContext _libraryAppContext { get { return _context as LibraryAppContext; } }
        public BookRepository(LibraryAppContext library) : base(library)
        {

        }

        public void DeleteAuthorsBook()
        {
            throw new NotImplementedException();
        }
        #endregion

        public void DeleteAuthorsBook(int id)
        {
            var rp = _libraryAppContext.Book.Where(a => a.FK_AuthorID == id).ToList();
            RemoveRange(rp);
        }
    }
}
