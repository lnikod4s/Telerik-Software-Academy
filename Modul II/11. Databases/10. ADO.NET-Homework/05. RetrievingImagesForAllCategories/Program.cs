namespace RetrievingImagesForAllCategories
{
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;

    internal class Program
    {
        private static SqlConnection dbConnection;

        private static void Main()
        {
            EstablishConnectionToDb();
            using (dbConnection)
            {
                var cmd = new SqlCommand(GlobalConstants.SqlCommand, dbConnection);
                RetrieveImagesFromDatabase(cmd);
            }
        }

        private static void EstablishConnectionToDb()
        {
            var dbConnectionString = ConfigurationManager.ConnectionStrings["SQLDB"];
            dbConnection = new SqlConnection(dbConnectionString.ConnectionString);
            dbConnection.Open();
        }

        private static void RetrieveImagesFromDatabase(SqlCommand cmd)
        {
            var reader = cmd.ExecuteReader();
            using (reader)
            {
                var index = 1;
                while (reader.Read())
                {
                    var picture = (byte[]) reader["Picture"];
                    StorePicturesAsJpegFiles(GlobalConstants.FileName + index, picture, GlobalConstants.FileExtension);
                    index++;
                }
            }
        }

        private static void StorePicturesAsJpegFiles(string fileName, byte[] imgBinaryData, string fileExtension)
        {
            const int oleMetaPictStartPosition = 78;
            var memoryStream =
                new MemoryStream(imgBinaryData, oleMetaPictStartPosition,
                    imgBinaryData.Length - oleMetaPictStartPosition);
            using (memoryStream)
            {
                using (var image = Image.FromStream(memoryStream, true, true))
                {
                    image.Save(fileName + fileExtension);
                }
            }
        }
    }
}