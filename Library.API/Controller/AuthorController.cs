using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.DTOs;
using LibraryApp.Business;
using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApp.API.Controller
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        //#region Constructor 
        //public AuthorController(IConfiguration conf, IMemoryCache cache) : base(conf, cache)
        //{

        //}

        //#endregion


        // GET: api/<AuthorController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet("GetAuthor")]
        public ApiResponseDto<List<AuthorDto>> GetAuthor()
        {
            var author = BAuthor.GetAuthor();
            if (author == null)
            {
                return ApiResponseDto<List<AuthorDto>>.FailedResponse("basarisiz");
            }
            return ApiResponseDto<List<AuthorDto>>.SuccessResponse(author, "basarili");
        }


        //[HttpGet("CheckAuthor/{authorDto}")]
        //public ApiResponseDto<AuthorDto> CheckAuthor(AuthorDto authorDto)
        //{
        //    var author = BAuthor.CheckAuthor(authorDto);
        //    if (author == null)
        //    {
        //        return ApiResponseDto<AuthorDto>.FailedResponse("basarisiz");
        //    }
        //    return ApiResponseDto<AuthorDto>.SuccessResponse(author, "basarili");

        //}

        [HttpPost("CreateAuthor")]
        public ApiResponseDto<AuthorDto> CreateAuthor(AuthorDto authorDto)
        {
            var author = BAuthor.CreateAuthor(authorDto);
            if (author == null) //yazar varmış 
            {
                var getAuthor = BAuthor.GetAuthorByName(authorDto.Name);
                return ApiResponseDto<AuthorDto>.FailedResponseData(getAuthor, "basarili");
            }
            else
            {
                return ApiResponseDto<AuthorDto>.SuccessResponse(author, "basarili");
            }
           

        }




        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("DeleteAuthor/{id}")]
        public void Delete(int id)
        {
            BAuthor.DelAuthor(id);
        }
    }
}
