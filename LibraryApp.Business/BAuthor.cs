using System;
using System.Collections.Generic;
using System.Text;
using LibraryApp.DTOs;
using LibraryApp.DataLayer;
using System.Linq;

namespace LibraryApp.Business
{
    public class BAuthor
    {
        public static List<AuthorDto> GetAuthor()
        {
            using (var uow = new UnitOfWork())
            {
                List<ENTAuthor> entAuthorList = uow.AuthorRepository.GetAll().ToList();
                List<AuthorDto> authorDtoList = new List<AuthorDto>();
                AuthorDto authorDto = null;
                foreach (var item in entAuthorList)
                {
                    authorDto = new AuthorDto()
                    {
                        ID = item.ID,
                        Name = item.Name,

                    };
                    authorDtoList.Add(authorDto);
                }
                return authorDtoList;
            }
        }

        public static AuthorDto GetAuthorByID(int ID)
        {

            using (var uow = new UnitOfWork())
            {
                ENTAuthor nTAuthors = uow.AuthorRepository.GetByID(ID);
                AuthorDto author = new AuthorDto();
                author.ID = nTAuthors.ID;
                author.Name = nTAuthors.Name;
                return author;
            }
        }

        public static AuthorDto GetAuthorByName(string name)
        {
            using (var uow = new UnitOfWork())
            {
                ENTAuthor nTAuthors = uow.AuthorRepository.GetByName(name);
                if (nTAuthors == null)
                {
                    return null;
                }
                AuthorDto author = new AuthorDto()
                {
                    ID = nTAuthors.ID,
                    Name = nTAuthors.Name
                };
                return author;

            }
        }

        public static AuthorDto CreateAuthor(AuthorDto authorDto)
        {
            using(var uow=new UnitOfWork())
            {
                ENTAuthor nTAuthors = uow.AuthorRepository.GetByName(authorDto.Name);
                if (nTAuthors == null)// yazar yoksa
                {
                    ENTAuthor entAuthor = new ENTAuthor();
                    entAuthor.Name = authorDto.Name;
                    uow.AuthorRepository.Add(entAuthor);
                    authorDto.ID = entAuthor.ID;
                    if (entAuthor != null)
                    {
                        AuthorDto newAuthor = new AuthorDto()
                        {
                            ID = entAuthor.ID,
                            Name = entAuthor.Name
                        };
                        return newAuthor;
                    }
                    return null;

                }
                else
                {
                    AuthorDto author = new AuthorDto()
                    {
                        ID = nTAuthors.ID,
                        Name = nTAuthors.Name,

                    };
                    return null;
                }
                
            }

        }

        public static void DelAuthor(int id)
        {
            using (var uow = new UnitOfWork())
            {
              uow.BookRepository.DeleteAuthorsBook(id);
                uow.AuthorRepository.Remove(id);
            }
        }
    }
}
