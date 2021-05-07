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



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApp.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost("Login")]
        [AllowAnonymous]
        public ApiResponseDto<LoginRequestDto> Login(LoginRequestDto requestDto)
        {
            try
            {
                var user = BUser.LoginResponse(requestDto);

                if (user != null)
                {


                    LoginRequestDto loginResponse = new LoginRequestDto()
                    {

                        UserName = user.UserName,
                        Password = user.Password

                    };


                    return ApiResponseDto<LoginRequestDto>.SuccessResponse(loginResponse, "basarili");



                }

                return ApiResponseDto<LoginRequestDto>.FailedResponse("basarisiz");

            }
            catch
            {
                return ApiResponseDto<LoginRequestDto>.FailedResponse("basarisiz");
            }

        }


        [HttpPost("Register")]
        public ApiResponseDto<RegisterRequestDto> Register(UserDto registerDto)
        {

            var user = BUser.RegisterRequest(registerDto);
            if (user != null)
            {
                RegisterRequestDto login = new RegisterRequestDto()
                {

                    Name = user.Name,
                    Surname = user.Surname,
                    UserName = user.UserName,
                    Password = user.Password,
                    PasswordConfirm = user.ConfirmPassword

                };
                return ApiResponseDto<RegisterRequestDto>.SuccessEmpty();
            }
            return ApiResponseDto<RegisterRequestDto>.FailedResponse("basarisiz");
        }

        [HttpGet("GetUser")]
        public ApiResponseDto<List<UserDto>> GetUser()
        {
            var user = BUser.GetUserInfo();
            if (user != null)
            {
                return ApiResponseDto<List<UserDto>>.SuccessResponse(user, "basarili");
            }
            return ApiResponseDto<List<UserDto>>.FailedResponse("basarisiz");
        }



        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("UpdateUser")]
        public void UpdateUser(UserDto userDto)
        {
            BUser.UpdateUser(userDto);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("DeleteUser/{id}")]
        public void DeleteUser(int id)
        {
            BUser.DeleteUser(id);
        }
    }
}
