using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryApp.DataLayer
{
    public class AuthorRepository : Repository<ENTAuthor>, IAuthorRepository
    {
        #region Constracter
        private LibraryAppContext _libraryAppContext { get { return _context as LibraryAppContext; } }
        public AuthorRepository(LibraryAppContext library) : base(library)
        {

        }
        #endregion


        public ENTAuthor GetByName(string Name)
        {
           
              return _libraryAppContext.Author.Where(a => a.Name == Name).FirstOrDefault();

            
        }
       
    }
}
