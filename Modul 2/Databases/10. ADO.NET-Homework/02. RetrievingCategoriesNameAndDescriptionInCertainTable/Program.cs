namespace RetrievingCategoriesNameAndDescriptionInCertainTable
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    internal class Program
    {
        private static SqlConnection dbConnection;

        private static void Main()
        {
            EstablishConnectionToDb();
            using (dbConnection)
            {
                var cmd = new SqlCommand(GlobalConstants.SqlCommand, dbConnection);
                ExecuteSqlDataReader(cmd);
            }
        }

        private static void ExecuteSqlDataReader(SqlCommand cmd)
        {
            var reader = cmd.ExecuteReader();
            using (reader)
            {
                Console.WriteLine(GlobalConstants.Categories);
                while (reader.Read())
                {
                    var categoryName = (string) reader["CategoryName"];
                    var categoryDescription = (string) reader["Description"];
                    Console.WriteLine(GlobalConstants.CategoryName, categoryName);
                    Console.WriteLine(GlobalConstants.CategoryDescription, categoryDescription);
                    Console.WriteLine(new string('-', 70));
                }
            }
        }

        private static void EstablishConnectionToDb()
        {
            var dbConnectionString = ConfigurationManager.ConnectionStrings["SQLDB"];
            dbConnection = new SqlConnection(dbConnectionString.ConnectionString);
            dbConnection.Open();
        }
    }
}