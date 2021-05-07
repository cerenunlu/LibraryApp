using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.DTOs
{
    public class BookAuthorDto
    {
        public int ID { get; set; }
        public string BookName { get; set; }
        public int PublishedYear { get; set; }
        public string AuthorName { get; set; }
        public string Cover { get; set; }

    }
}
