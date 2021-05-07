using LibraryApp.DataLayer;
using LibraryApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LibraryApp.Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CurrentUserDto> CurrentUserInfo()
        {
            var result = await _httpClient.GetFromJsonAsync<CurrentUserDto>("auth/currentuserinfo");
            return result;
        }
        public async Task Login(LoginRequestDto loginRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("auth/Login", loginRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }
        public async Task Logout()
        {
            var result = await _httpClient.PostAsync("auth/logout", null);
            result.EnsureSuccessStatusCode();
        }
        public async Task Register(RegisterRequestDto registerRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("auth/Register", registerRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }
    }
}
