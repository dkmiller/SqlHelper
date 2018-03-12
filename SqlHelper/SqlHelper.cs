using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SqlHelper
{
    public class SqlHelper
    {
        /// <summary>
        /// Creates a connection to a SQL server using the given connection
        /// string, executes the given query, and then returns the results
        /// transformed via the given function.
        /// </summary>
        public static IEnumerable<T> Query<T>(string connectionString, string query, Func<SqlDataReader, T> load)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                    if (reader.HasRows)
                        while (reader.Read())
                            yield return load(reader);
            }
        }
    }
}
