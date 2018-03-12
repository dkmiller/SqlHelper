using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SqlHelper
{
    public class SqlHelper
    {
        public static IEnumerable<T> Query<T>(string connectionString, string query, Func<SqlDataReader> load)
        {
            throw new NotImplementedException();
        }
    }
}
