using LibraryApp.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryApp.DataLayer;
using System.Linq;

namespace LibraryApp.Business
{
    public class BBook : IBBook
    {

        public List<BookDto> GetBook()
        {
            using (var uow = new UnitOfWork())
            {
                List<ENTBook> entBookList = uow.BookRepository.GetAll().ToList();
                List<BookDto> bookDtoList = new List<BookDto>();
                BookDto bookDto = null;
                foreach (var item in entBookList)
                {
                    bookDto = new BookDto()
                    {
                        ID = item.ID,
                        Name = item.Name,
                        FK_AuthorID = item.FK_AuthorID,
                        PublishedYear = item.PublishedYear,
                        Cover = item.Cover
                    };
                    bookDtoList.Add(bookDto);
                }
                return bookDtoList;
            }
        }


        public UserBookDto AddtoMyLib(int bookID, int UserID)
        {
            using (var uow = new UnitOfWork())
            {
                var book = uow.BookRepository.GetByID(bookID);

                ENTUserBook eNTUserBook = new ENTUserBook()
                {
                    FK_BookID = bookID,
                    FK_UserID = UserID
                };
                uow.UserBookRepository.Add(eNTUserBook);
                UserBookDto userBookDto = new UserBookDto()
                {
                    FK_BookID = eNTUserBook.FK_BookID,
                    FK_UserID = eNTUserBook.FK_UserID,
                };
                return userBookDto;
            }
        }

        public BookDto NewBook(BookDto newBookdto)
        {
            using (var uow = new UnitOfWork())
            {
                ENTBook book = new ENTBook();

                book.Name = newBookdto.Name;
                book.FK_AuthorID = newBookdto.FK_AuthorID;
                book.PublishedYear = newBookdto.PublishedYear;
                uow.BookRepository.Add(book);
                newBookdto.ID = book.ID;
                
                return newBookdto;
            }


        }

        public static void DeleteBook(int id)
        {
            using (var uow = new UnitOfWork())
            {
                uow.BookRepository.Remove(id);
            }
        }

        public static void UpdateBook(BookAuthorDto book)
        {
            using (var uow = new UnitOfWork())
            {
                if (book == null || DBNull.Value.Equals(book))
                {
                    return;
                }
                else
                {
                    var BookInfo = uow.BookRepository.GetByID(book.ID);
                    var author = uow.AuthorRepository.GetByID(BookInfo.FK_AuthorID);
                    if (book != null & book.ID == BookInfo.ID & BookInfo.FK_AuthorID==author.ID)
                    {
                        BookInfo.ID = book.ID;
                        BookInfo.Name = book.BookName;
                        BookInfo.PublishedYear = book.PublishedYear;
                        BookInfo.FK_AuthorID = author.ID;
                        
                    }

                    uow.BookRepository.Save(BookInfo);
                }

            }
        }
    }
}
