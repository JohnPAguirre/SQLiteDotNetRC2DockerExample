using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace SQLiteTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var connection = new SqliteConnection("" +
                new SqliteConnectionStringBuilder
            {
                DataSource = "hello2 .db"
            }))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var createTableCommand = connection.CreateCommand();
                    createTableCommand.Transaction = transaction;
                    createTableCommand.CommandText = "CREATE TABLE IF NOT EXISTS message([text] text)";
                    try
                    {
                        createTableCommand.ExecuteNonQuery();
                    }
                    catch(Exception e)
                    {
                        throw e;
                    }
                    

                    var insertCommand = connection.CreateCommand();
                    insertCommand.Transaction = transaction;
                    insertCommand.CommandText = "INSERT INTO message ( text ) VALUES ( $text )";
                    insertCommand.Parameters.AddWithValue("$text", "Hello, World!");
                    try
                    {
                        insertCommand.ExecuteNonQuery();
                    }
                    catch(Exception e)
                    {
                        throw e;
                    }

                    var selectCommand = connection.CreateCommand();
                    selectCommand.Transaction = transaction;
                    selectCommand.CommandText = "SELECT text FROM message";
                    using (var reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var message = reader.GetString(0);
                            Console.WriteLine(message);
                        }
                    }

                    transaction.Commit();
                }
            }
            Console.ReadKey(true);
        }
    }
}
