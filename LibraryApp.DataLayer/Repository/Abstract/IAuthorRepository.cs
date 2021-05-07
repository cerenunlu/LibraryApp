using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.DataLayer
{
    public interface IAuthorRepository : IRepository<ENTAuthor>
    {
        ENTAuthor GetByName(string name);
       
    }
}
