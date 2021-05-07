using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private LibraryAppContext _libraryAppContext;
        #region Repos
        public IUserRepository UserRepository { get; set; }
        public IBookRepository BookRepository { get; set; }
        public IAuthorRepository AuthorRepository { get; set; }

        public IUserBookRepository UserBookRepository { get; set; }
        #endregion

        public UnitOfWork()
        {
            _libraryAppContext = new LibraryAppContext();
            #region Initialize Repos
            UserRepository = new UserRepository(_libraryAppContext);
            BookRepository = new BookRepository(_libraryAppContext);
            AuthorRepository = new AuthorRepository(_libraryAppContext);
            UserBookRepository = new UserBookRepository(_libraryAppContext);
            #endregion
        }

        public int Complete()
        {
            return _libraryAppContext.SaveChanges();
        }

        public void Dispose()
        {
            _libraryAppContext.Dispose();
        }


    }
}
