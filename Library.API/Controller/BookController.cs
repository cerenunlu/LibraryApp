using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Text;
using LibraryApp.Business;
using LibraryApp.DataLayer;
using LibraryApp.DTOs;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using System.Threading.Tasks;





// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApp.API.Controller
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly LibraryAppContext _context;
        private readonly IBBook _bookService;

        public BookController(IBBook bookService)
        {
            _bookService = bookService;
        }


        ////GET: api/<BookController>
        //[HttpGet]
        //public async Task<List<string>> Get()
        //{
        //    return new List<string>() { "value1", "value2" };
        //}



        [HttpGet("GetBook")]
        public ApiResponseDto<List<BookAuthorDto>> GetBook()
        {
            var book = _bookService.GetBook();
            List<BookAuthorDto> bookAuthorDtoList = new List<BookAuthorDto>();
            BookAuthorDto bookAuthorDtos;
            if (book != null)
            {
                foreach (var item in book)
                {
                    var author = BAuthor.GetAuthorByID(item.FK_AuthorID);
                    bookAuthorDtos = new BookAuthorDto()
                    {
                        ID = item.ID,
                        BookName = item.Name,
                        PublishedYear = item.PublishedYear,
                        Cover = item.Cover,
                        AuthorName = author.Name

                    };
                    bookAuthorDtoList.Add(bookAuthorDtos);
                }
                return ApiResponseDto<List<BookAuthorDto>>.SuccessResponse(bookAuthorDtoList, "basarili");
            }

            return ApiResponseDto<List<BookAuthorDto>>.FailedResponse("basarisiz");
        }

        [HttpPost("NewBook")]
        public ApiResponseDto<BookDto> NewBook(BookDto newBookdto)
        {
            if (newBookdto == null)
            {
                return ApiResponseDto<BookDto>.FailedResponse("basarisiz");
            }
            var book = _bookService.NewBook(newBookdto);
            return ApiResponseDto<BookDto>.SuccessResponse(book, "basarili");
        }


        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //POST api/<BookController>
        [HttpPost("AddtoMyLib")]
        public ApiResponseDto<UserBookDto> AddtoMyLib(UserBookDto user)
        {

            if (user == null)
            {
                return ApiResponseDto<UserBookDto>.FailedResponse("basarisiz");
            }
            var book = _bookService.AddtoMyLib(user.FK_BookID, user.FK_UserID);
            return ApiResponseDto<UserBookDto>.SuccessResponse(book, "basarili");
        }

        // PUT api/<BookController>/5
        [HttpPut("UpdateBook")]
        public void UpdateBook(BookAuthorDto book)
        {
            BBook.UpdateBook(book);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("DeleteBook/{id}")]
        public void DeleteBook(int id)
        {
            BBook.DeleteBook(id);
        }
    }
}
