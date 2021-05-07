using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.DTOs
{
    public class LoginRequestDto
    {
      
        public string UserName { get; set; }
       
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
