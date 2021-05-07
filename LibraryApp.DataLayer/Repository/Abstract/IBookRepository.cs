using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.DataLayer
{
    public interface IBookRepository : IRepository<ENTBook>
    {
        void DeleteAuthorsBook(int id);
    }
}
