namespace WorkingWithSQLite
{
    using System;
    using System.Data.SQLite;
    using WorkingWithMySQL;

    internal class Program
    {
        private static readonly Library Library = new Library();
        private static SQLiteConnection mySqlConnection;

        private static void Main()
        {
            try
            {
                ConnectToDatabase();

                AddBooks();
                FindBooksByName("The Shining");
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

            var mySqlCommand = new SQLiteCommand(@"INSERT INTO Books (Title, Author, PublishDate, ISBN)
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

            var mySqlCommand = new SQLiteCommand(@"SELECT Title, Author, PublishDate, ISBN
                                                             FROM Books
                                                             WHERE CHARINDEX(@substring, Title)", mySqlConnection);

            mySqlCommand.Parameters.AddWithValue("@substring", substring);

            using (var reader = mySqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var title = reader["Title"].ToString();
                    var author = reader["Author"].ToString();
                    var publishDate = (DateTime) reader["PublishDate"];
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

            var mySqlCommand = new SQLiteCommand(@"SELECT Title, Author, PublishDate, ISBN
                                                             FROM Books", mySqlConnection);

            using (var reader = mySqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var title = reader["Title"].ToString();
                    var author = reader["Author"].ToString();
                    var publishDate = (DateTime) reader["PublishDate"];
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

            var mySqlCommand = new SQLiteCommand(@"DELETE FROM Books
                                                             WHERE BookId > 0", mySqlConnection);

            var queryResult = mySqlCommand.ExecuteNonQuery();

            Console.WriteLine("    ({0} row(s) affected)\n", queryResult);
        }

        private static void ConnectToDatabase()
        {
            mySqlConnection = new SQLiteConnection(Connection.Default.SqLite);
            mySqlConnection.Open();
        }

        private static void DisconnectFromDatabase()
        {
            mySqlConnection?.Close();
        }
    }
}