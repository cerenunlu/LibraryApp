using LibraryApp.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Business
{
    public interface IBBook
    {
        public List<BookDto> GetBook();
        public UserBookDto AddtoMyLib(int ID, int UserID);
        public BookDto NewBook(BookDto bookDto);
    }
}
