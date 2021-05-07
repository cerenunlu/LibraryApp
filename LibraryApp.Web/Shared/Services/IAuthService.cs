using LibraryApp.DataLayer;
using LibraryApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Web.Services
{
    public interface IAuthService
    {
        Task Login(LoginRequestDto loginRequest);
        Task Register(RegisterRequestDto registerRequest);
        Task Logout();
        Task<CurrentUserDto> CurrentUserInfo();
    }
}
