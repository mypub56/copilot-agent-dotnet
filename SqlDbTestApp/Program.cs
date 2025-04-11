using System;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Server=localhost;Database=MyTEst;User Id=sa;Password=YourStrong@Password;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Create a table
            string createTableQuery = @"CREATE TABLE TestTable (
                Id INT PRIMARY KEY IDENTITY(1,1),
                Name NVARCHAR(50) NOT NULL
            );";

            using (SqlCommand createTableCommand = new SqlCommand(createTableQuery, connection))
            {
                createTableCommand.ExecuteNonQuery();
                Console.WriteLine("Table 'TestTable' created successfully.");
            }

            // Insert data into the table
            string insertQuery = "INSERT INTO TestTable (Name) VALUES (@Name);";
            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
            {
                insertCommand.Parameters.AddWithValue("@Name", "TestName");
                insertCommand.ExecuteNonQuery();
                Console.WriteLine("Data inserted successfully.");
            }

            // Read data from the table
            string selectQuery = "SELECT Id, Name FROM TestTable;";
            using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
            using (SqlDataReader reader = selectCommand.ExecuteReader())
            {
                Console.WriteLine("Data from 'TestTable':");
                while (reader.Read())
                {
                    Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}");
                }
            }
        }
    }
}
