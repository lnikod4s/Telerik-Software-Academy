namespace RetrievingProductsAndCategoriesInTwoTables
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
                while (reader.Read())
                {
                    var product = (string) reader["Product"];
                    var category = (string) reader["Category"];
                    Console.WriteLine(GlobalConstants.ProductAndCategory, product, category);
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