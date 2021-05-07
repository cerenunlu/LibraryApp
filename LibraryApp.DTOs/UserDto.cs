using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.DTOs
{
    public class UserDto
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Description { get; set; }
        public int Role { get; set; }
        public Guid TokenID { get; set; }
    }
}
