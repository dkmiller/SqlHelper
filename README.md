# SqlHelper

[![Build Status](https://travis-ci.org/dkmiller/SqlHelper.svg?branch=master)](https://travis-ci.org/dkmiller/SqlHelper)

This package is published as: [SqlWrapperLite](https://www.nuget.org/packages/SqlWrapperLite/).

Lightweight wrapper around one-off SQL queries. This is _not_ heavily
optimized, and should not be used for production scenarios which are grabbing
massive amounts of data, or making hundreds of queries.

On the other hand, if you just want to make a simple query and grab a few
strings, it's easy to write code like the following.

```csharp
using SqlWrapperLite;

var connStr = "<your connection string>";

// Grab a few strings.
IEnumerable<string> myStrings = SqlWrapper.Query<string>(connStr, "SELECT TOP 20 Name FROM RandomTable");

// Grab some strongly typed pairs.
IEnumerable<(string, int)> result = SqlWrapper.Query<string, int>(connStr, "SELECT Name, Age FROM OtherTable");

// Extension method for SQL connections.
using (var conn = new SqlConnection(connStr))
{
    var otherResult = conn.Query<(double?, int)>(connStr, "SELECT B, Age FROM OtherTable");
}
```
