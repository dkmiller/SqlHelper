using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SqlWrapperLite
{
    public static class SqlWrapper
    {
        /// <summary>
        /// Creates a connection to a SQL server using the given connection
        /// string, executes the given query, and then returns the results
        /// transformed via the given function.
        /// </summary>
        public static IEnumerable<T> Query<T>(string connectionString, string query, Func<SqlDataReader, T> load)
        {
            using (var connection = new SqlConnection(connectionString))
                return Query(connection, query, load);
        }

        /// <summary>
        /// Executes the given query using the SQL connection, then returns the
        /// results transformed via the given function. This does not dispose
        /// the connection.
        /// </summary>
        public static IEnumerable<T> Query<T>(SqlConnection connection, string query, Func<SqlDataReader, T> load)
        {
            var command = new SqlCommand(query, connection);

            var result = new List<T>();

            using (var reader = command.ExecuteReader())
                if (reader.HasRows)
                    while (reader.Read())
                        result.Add(load(reader));
            return result;
        }
    }
}
