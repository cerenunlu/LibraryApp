﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.DTOs
{
    public class BookDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int FK_AuthorID { get; set; }
        public int PublishedYear { get; set; }
        public string Cover { get; set; }

    }
}
