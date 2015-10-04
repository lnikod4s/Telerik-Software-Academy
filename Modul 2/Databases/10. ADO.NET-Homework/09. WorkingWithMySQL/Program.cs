namespace WorkingWithMySQL
{
    using System;
    using MySql.Data.MySqlClient;

    internal class Program
    {
        private static readonly Library Library = new Library();
        private static MySqlConnection mySqlConnection = new MySqlConnection(Connection.Default.MySqlConnection);

        private static void Main()
        {
            // In order to work with your local MySQL Database, you must change username and password in Connection.settings
            try
            {
                ConnectToDatabase();

                AddBooks();
                FindBooksByName("Nulla");
                ListingAllBooks();
                DeleteAllRecords();
            }
            finally
            {
                DisconnectFromDatabase();
            }
        }

        private static void AddBooks()
        {
            Console.WriteLine("Adding books: ");

            var mySqlCommand = new MySqlCommand(@"INSERT INTO Books (Title, Author, PublishDate, ISBN)
                                                           VALUES (@title, @author, @publishDate, @isbn)",
                mySqlConnection);

            foreach (var book in Library.Books)
            {
                var title = book.Title;
                var author = book.Author;
                var publishDate = book.PublishDate;
                var isbn = book.Isbn;

                mySqlCommand.Parameters.AddWithValue("@title", title);
                mySqlCommand.Parameters.AddWithValue("@author", author);
                mySqlCommand.Parameters.AddWithValue("@publishDate", publishDate);
                mySqlCommand.Parameters.AddWithValue("@isbn", isbn);

                var queryResult = mySqlCommand.ExecuteNonQuery();
                mySqlCommand.Parameters.Clear();

                Console.WriteLine("    ({0} row(s) affected)", queryResult);
            }
        }

        private static void FindBooksByName(string substring)
        {
            Console.WriteLine("\nFinding books by name '{0}':", substring);

            var mySqlCommand = new MySqlCommand(@"SELECT Title, Author, PublishDate, ISBN
                                                           FROM Books
                                                           WHERE LOCATE(@substring, Title)", mySqlConnection);

            mySqlCommand.Parameters.AddWithValue("@substring", substring);

            using (var reader = mySqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var title = reader["Title"].ToString();
                    var author = reader["Author"].ToString();
                    var publishDate = DateTime.Parse(reader["PublishDate"].ToString());
                    var isbn = reader["ISBN"].ToString();

                    var book = new Book
                    {
                        Title = title,
                        Author = author,
                        PublishDate = publishDate,
                        Isbn = isbn
                    };

                    Console.WriteLine(book);
                }
            }
        }

        private static void ListingAllBooks()
        {
            Console.WriteLine("Listing all books: ");

            var mySqlCommand = new MySqlCommand(@"SELECT Title, Author, PublishDate, ISBN
                                                           FROM Books", mySqlConnection);

            using (var reader = mySqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var title = reader["Title"].ToString();
                    var author = reader["Author"].ToString();
                    var publishDate = DateTime.Parse(reader["PublishDate"].ToString());
                    var isbn = reader["ISBN"].ToString();

                    var book = new Book
                    {
                        Title = title,
                        Author = author,
                        PublishDate = publishDate,
                        Isbn = isbn
                    };

                    Console.WriteLine(book);
                }
            }
        }

        private static void DeleteAllRecords()
        {
            Console.WriteLine("Deleting all books: ");

            var mySqlCommand = new MySqlCommand(@"DELETE FROM Books
                                                           WHERE Id > 0", mySqlConnection);
            var queryResult = mySqlCommand.ExecuteNonQuery();
            Console.WriteLine("    ({0} row(s) affected)\n", queryResult);
        }

        private static void ConnectToDatabase()
        {
            mySqlConnection = new MySqlConnection(Connection.Default.MySqlConnection);
            mySqlConnection.Open();
        }

        private static void DisconnectFromDatabase()
        {
            mySqlConnection?.Close();
        }
    }
}