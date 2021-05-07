using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.DTOs
{
    public class RegisterRequestDto
    {

        public string UserName { get; set; }


        public string Name { get; set; }


        public string Surname { get; set; }

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }
    }
}
