using System;
using System.Collections.Generic;

#nullable disable

namespace Kanini.Service
{
    public partial class Book
    {
        public Book()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        public int BookId { get; set; }
        public string BookTitle { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
