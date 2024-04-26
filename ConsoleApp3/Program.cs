// using CsvHelper;
// using OfficeOpenXml;
// using System.Data.SqlClient;
// using System.Globalization;
// class Program
// {
//     static void Main()
//     {
//         ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
//         string connectionString = "Server=.;Database=GourmetDataBase;Trusted_Connection=true;TrustServerCertificate=true;";

//         string excelFilePath = "ingredients.xlsx";
//         string csvFilePath = "02_Ingredients.csv";
//         string jsonFilePath = "train.json";

//         // اتصال به دیتابیس SQL Server
//         using (SqlConnection connection = new SqlConnection(connectionString))
//         {
//             connection.Open();

//             // ایجاد جدول ingredients اگر وجود نداشته باشد
//             //string createTableQuery = @"
//             //    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ingredients')
//             //    BEGIN
//             //        CREATE TABLE ingredients (
//             //            id INT PRIMARY KEY IDENTITY,
//             //            ingredient NVARCHAR(100)
//             //        )
//             //    END";
//             //SqlCommand createTableCommand = new SqlCommand(createTableQuery, connection);
//             //createTableCommand.ExecuteNonQuery();

//             // خواندن اطلاعات از فایل JSON

//             List<string> list = new List<string>();

//             // وارد کردن اطلاعات به دیتابیس
//             using (var reader = new StreamReader(csvFilePath))
//             using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
//             {
//                 //csv.Configuration.HasHeaderRecord = false;

//                 while (csv.Read())
//                 {
//                     var record = csv.GetRecord<dynamic>() as IDictionary<string, object>;
//                     if (record.ContainsKey("Name") )
//                     {
//                         string Name = record["Name"]?.ToString();
//                         //string unit=record["unit"]?.ToString();
//                         try
//                         {
//                             if (!list.Contains(Name))
//                             {
//                                 Guid id = new Guid();
//                                 // اجرای دستور SQL برای وارد کردن هر ماده اولیه به دیتابیس
//                                 //string insertQuery = "INSERT INTO ingredients (Id,Name) VALUES (id,@Ingredient)";
//                                 string insertQuery = "INSERT INTO Foods (Id, Name) VALUES (NEWID(), @name)";

//                                 using (SqlCommand command = new SqlCommand(insertQuery, connection))
//                                 {
//                                     command.Parameters.AddWithValue("@name", Name);
//                                     //command.Parameters.AddWithValue("@unit", unit);
//                                     command.ExecuteNonQuery();
//                                 }
//                                 list.Add(Name);
//                             }
//                         }
//                         catch (Exception ex)
//                         {
//                             Console.WriteLine("Error inserting food into database: " + ex.Message);
//                         }
//                     }
//                     else{
//                         Console.WriteLine("Data inserted not successfully.");
//                     }
//                 }

//                 Console.WriteLine("Data inserted successfully.");
//             }
//         }
//     }
// }







//*************************************************************************//
// using CsvHelper;
// using OfficeOpenXml;
// using System.ComponentModel;
// using System.Data.SqlClient;
// using System.Formats.Asn1;
// using System.Globalization;
// class Program
// {
//     static void Main()
//     {
//         ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
//         string connectionString = "Server=.;Database=GourmetDataBase;Trusted_Connection=true;TrustServerCertificate=true;";

//         string excelFilePath = "ingredients.xlsx";
//         string csvFilePath = "02_Food.csv";
//         string jsonFilePath = "train.json";

//         // اتصال به دیتابیس SQL Server
//         using (SqlConnection connection = new SqlConnection(connectionString))
//         {
//             connection.Open();

//             // ایجاد جدول ingredients اگر وجود نداشته باشد
//             //string createTableQuery = @"
//             //    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ingredients')
//             //    BEGIN
//             //        CREATE TABLE ingredients (
//             //            id INT PRIMARY KEY IDENTITY,
//             //            ingredient NVARCHAR(100)
//             //        )
//             //    END";
//             //SqlCommand createTableCommand = new SqlCommand(createTableQuery, connection);
//             //createTableCommand.ExecuteNonQuery();

//             // خواندن اطلاعات از فایل JSON

//             List<string> list = new List<string>();

//             // وارد کردن اطلاعات به دیتابیس
//             using (var reader = new StreamReader(csvFilePath))
//             using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
//             {
//                 //csv.Configuration.HasHeaderRecord = false;

//                 while (csv.Read())
//                 {
//                     var record = csv.GetRecord<dynamic>() as IDictionary<string, object>;
//                     if (record.ContainsKey("Name") )
//                     {
//                         string ingredient = record["Name"]?.ToString();
//                         string unit = record["Image"]?.ToString();
//                         try
//                         {
//                             if (!list.Contains(ingredient))
//                             {
//                                 Guid id = new Guid();
//                                 // اجرای دستور SQL برای وارد کردن هر ماده اولیه به دیتابیس
//                                 //string insertQuery = "INSERT INTO ingredients (Id,Name) VALUES (id,@Ingredient)";
//                                 string insertQuery = "INSERT INTO Foods (Id, Name,ImgeUrl) VALUES (NEWID(), @ingredient,@unit)";

//                                 using (SqlCommand command = new SqlCommand(insertQuery, connection))
//                                 {
//                                     command.Parameters.AddWithValue("@ingredient", ingredient);
//                                     command.Parameters.AddWithValue("@unit", unit);
//                                     command.ExecuteNonQuery();
//                                 }
//                                 list.Add(ingredient);
//                             }
//                         }
//                         catch (Exception ex)
//                         {
//                             Console.WriteLine("Error inserting food into database: " + ex.Message);
//                         }
//                     }
//                     else
//                     {
//                         Console.WriteLine("Data inserted not successfully.");
//                     }
//                 }

//                 Console.WriteLine("Data inserted successfully.");
//             }
//         }
//     }
// }
using CsvHelper;
using OfficeOpenXml;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Formats.Asn1;
using System.Globalization;
class Program
{
    static void Main()
    {
        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        string connectionString = @"Server = 0.0.0.0,1403; Database = Master; User Id = SA; Password = Gourmet2334";

        string excelFilePath = "ingredients.xlsx";
        string csvFilePath = "02_PSOI.csv";
        string jsonFilePath = "train.json";

        // اتصال به دیتابیس SQL Server
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // ایجاد جدول ingredients اگر وجود نداشته باشد
            //string createTableQuery = @"
            //    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ingredients')
            //    BEGIN
            //        CREATE TABLE ingredients (
            //            id INT PRIMARY KEY IDENTITY,
            //            ingredient NVARCHAR(100)
            //        )
            //    END";
            //SqlCommand createTableCommand = new SqlCommand(createTableQuery, connection);
            //createTableCommand.ExecuteNonQuery();

            // خواندن اطلاعات از فایل JSON

            List<string> list = new List<string>();

            // وارد کردن اطلاعات به دیتابیس
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                //csv.Configuration.HasHeaderRecord = false;

                while (csv.Read())
                {
                    var record = csv.GetRecord<dynamic>() as IDictionary<string, object>;
                    if (record.ContainsKey("Name") )
                    {
                        string ingredient = record["Name"]?.ToString();
                        string unit = record["Image"]?.ToString();
                        try
                        {
                            if (!list.Contains(ingredient))
                            {
                                Guid id = new Guid();
                                // اجرای دستور SQL برای وارد کردن هر ماده اولیه به دیتابیس
                                //string insertQuery = "INSERT INTO ingredients (Id,Name) VALUES (id,@Ingredient)";
                                string insertQuery = "INSERT INTO PSOIs (Id, Name,ImageUrl) VALUES (NEWID(), @ingredient,@unit)";

                                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                                {
                                    command.Parameters.AddWithValue("@ingredient", ingredient);
                                    command.Parameters.AddWithValue("@unit", unit);
                                    command.ExecuteNonQuery();
                                }
                                list.Add(ingredient);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error inserting food into database: " + ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Data inserted not successfully.");
                    }
                }

                Console.WriteLine("Data inserted successfully.");
            }
        }
    }
}
