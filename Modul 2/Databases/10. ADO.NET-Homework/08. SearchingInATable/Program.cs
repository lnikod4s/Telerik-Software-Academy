namespace SearchingInATable
{
    using System;
    using System.Data.SqlClient;

    internal class Program
    {
        private static void Main()
        {
            Console.Write("Please enter a serch word: ");
            var searchWord = Console.ReadLine();

            FindProductByGivenSearchWord(searchWord);
        }

        private static void FindProductByGivenSearchWord(string searchWord)
        {
            using (var dbConnection = new SqlConnection(Connection.Default.DbConnection))
            {
                dbConnection.Open();
                var cmd = GetSearchByPatternSqlCommand(dbConnection, searchWord);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var productName = reader["ProductName"];
                        Console.WriteLine(" - " + productName);
                    }
                }
            }
        }

        private static SqlCommand GetSearchByPatternSqlCommand(SqlConnection sqlConnection, string pattern)
        {
            var cmd = new SqlCommand(@"SELECT ProductName
                                                     FROM Products
                                                     WHERE CHARINDEX(@pattern, ProductName) > 0", sqlConnection);
            cmd.Parameters.AddWithValue("@pattern", pattern);
            return cmd;
        }
    }
}