namespace ReadingExcelFile
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Text;

    internal class Program
    {
        private static void Main()
        {
            ReadExcelData();
        }

        private static void ReadExcelData()
        {
            var connectionString = GetConnectionString();
            using (var oleDbConnection = new OleDbConnection(connectionString))
            {
                oleDbConnection.Open();
                var sheetName = GetSheetName(oleDbConnection);
                var cmd = GetOleDbCommand(sheetName, oleDbConnection);

                using (var oleDbAdapter = new OleDbDataAdapter(cmd))
                {
                    var dataSet = new DataSet();
                    oleDbAdapter.Fill(dataSet);

                    using (var reader = dataSet.CreateDataReader())
                    {
                        while (reader.Read())
                        {
                            var name = reader["Name"];
                            var score = reader["Score"];
                            Console.WriteLine("{0}: {1}", name, score);
                        }
                    }
                }
            }
        }

        private static OleDbCommand GetOleDbCommand(string sheetName, OleDbConnection oleDbConnection)
        {
            var oleDbCommand =
                new OleDbCommand("SELECT * FROM [" + sheetName + "]", oleDbConnection);
            return oleDbCommand;
        }

        private static string GetSheetName(OleDbConnection oleDbConnection)
        {
            var excelSchema = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            var sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();
            return sheetName;
        }

        private static string GetConnectionString()
        {
            // XLSX - Excel 2007, 2010, 2012, 2013
            var props = new Dictionary<string, string>
            {
                ["Provider"] = "Microsoft.ACE.OLEDB.12.0",
                ["Extended Properties"] = "Excel 12.0 XML",
                ["Data Source"] = "../../../trainers.xlsx"
            };

            // XLS - Excel 2003 and Older
            //props["Provider"] = "Microsoft.Jet.OLEDB.4.0";
            //props["Extended Properties"] = "Excel 8.0";
            //props["Data Source"] = "../../trainers.xlsx";

            var sb = new StringBuilder();
            foreach (var prop in props)
            {
                sb.Append(prop.Key);
                sb.Append('=');
                sb.Append(prop.Value);
                sb.Append(';');
            }

            return sb.ToString();
        }
    }
}