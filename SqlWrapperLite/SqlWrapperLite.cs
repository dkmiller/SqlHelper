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
        public static IList<T> Query<T>(string connectionString, string query, Func<SqlDataReader, T> load)
        {
            IList<T> result;
            using (var connection = new SqlConnection(connectionString))
            {
                result = Query<T>(connection, query, load);
            }
            return result;
        }

        public static IList<T> Query<T>(string connectionString, string query) =>
            Query<T>(connectionString, query, r => (T)r.GetValue(0));

        public static IList<(T1, T2)> Query<T1, T2>(string connectionString, string query) =>
            Query<(T1, T2)>(connectionString, query, r => ((T1)r.GetValue(0), (T2)r.GetValue(1)));

        /// <summary>
        /// Executes the given query using the SQL connection, then returns the
        /// results transformed via the given function. This does not dispose
        /// the connection.
        /// </summary>
        public static IList<T> Query<T>(this SqlConnection connection, string query, Func<SqlDataReader, T> load)
        {
            var result = new List<T>();
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result.Add(load(reader));
                        }
                    }
                }
            }
            return result;
        }

        public static IList<T> Query<T>(this SqlConnection connection, string query) =>
            connection.Query<T>(query, r => (T)r.GetValue(0));

        public static IList<(T1, T2)> Query<T1, T2>(this SqlConnection connection, string query) =>
            connection.Query<(T1, T2)>(query, r => ((T1)r.GetValue(0), (T2)r.GetValue(1)));
    }
}
