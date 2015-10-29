namespace RetrievingNumberOfRowsInCertainTable
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
                var categoriesCount = (int) cmd.ExecuteScalar();
                Console.WriteLine(GlobalConstants.CategoriesCount, categoriesCount);
                Console.WriteLine();
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