namespace WorkingWithMySQL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Library
    {
        private readonly Book[] books =
        {
            new Book
            {
                Title = "The Shining",
                Author = "Stephen King",
                PublishDate = new DateTime(2012, 6, 26),
                Isbn = "978-0307743657"
            },
            new Book
            {
                Title = "Life After Life: A Novel",
                Author = "Kate Atkinson",
                PublishDate = new DateTime(2014, 1, 7),
                Isbn = "978-0316176491"
            },
            new Book
            {
                Title = "The Lord of the Rings",
                Author = "J.R.R. Tolkien",
                PublishDate = new DateTime(2012, 8, 14),
                Isbn = "978-0544003415"
            },
            new Book
            {
                Title = "All the President's Men",
                Author = "Bob Woodward",
                PublishDate = new DateTime(1994, 6, 16),
                Isbn = "978-0671894412"
            }
        };

        public ICollection<Book> Books => this.books.ToList();
    }
}