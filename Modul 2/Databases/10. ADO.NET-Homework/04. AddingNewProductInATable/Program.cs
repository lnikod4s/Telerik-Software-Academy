namespace AddingNewProductInATable
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
                var cmdInsertProduct = new SqlCommand(GlobalConstants.CommandInsert, dbConnection);
                ExecuteNonQueryAddingParametersWithValues(cmdInsertProduct);

                var insertedRecordId = GetInsertedRecordId();
                Console.WriteLine(GlobalConstants.NewProductId, insertedRecordId);
            }
        }

        private static int GetInsertedRecordId()
        {
            var cmdSelectIdentity = new SqlCommand(GlobalConstants.CommandSelectIdentity, dbConnection);
            var insertedRecordId = (int) (decimal) cmdSelectIdentity.ExecuteScalar();
            return insertedRecordId;
        }

        private static void ExecuteNonQueryAddingParametersWithValues(SqlCommand cmdInsertProduct)
        {
            cmdInsertProduct.Parameters.AddWithValue("@name", GlobalConstants.ProductName);
            cmdInsertProduct.Parameters.AddWithValue("@supplierId", GlobalConstants.SupplierId);
            cmdInsertProduct.Parameters.AddWithValue("@categoryId", GlobalConstants.CategoryId);
            cmdInsertProduct.Parameters.AddWithValue("@quantityPerUnit", GlobalConstants.QuantityPerUnit);
            cmdInsertProduct.Parameters.AddWithValue("@unitPrice", GlobalConstants.UnitPrice);
            cmdInsertProduct.Parameters.AddWithValue("@unitsInStock", GlobalConstants.UnitsInStock);
            cmdInsertProduct.Parameters.AddWithValue("@unitsInOrder", GlobalConstants.UnitsInOrder);
            cmdInsertProduct.Parameters.AddWithValue("@reorderLevel", GlobalConstants.ReorderLevel);
            cmdInsertProduct.Parameters.AddWithValue("@discontinued", GlobalConstants.Discontinued);
            cmdInsertProduct.ExecuteNonQuery();
        }

        private static void EstablishConnectionToDb()
        {
            var dbConnectionString = ConfigurationManager.ConnectionStrings["SQLDB"];
            dbConnection = new SqlConnection(dbConnectionString.ConnectionString);
            dbConnection.Open();
        }
    }
}