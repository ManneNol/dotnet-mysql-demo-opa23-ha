using App;
using MySql.Data.MySqlClient;

MySqlConnection? db = null;
// change this to whatever database connection information you need
string connectionString = "server=localhost;uid=root;pwd=password;database=cs_demo;port=3307";

try
{
    db = new(connectionString);
    db.Open();

    Users.All(db);
    Users.Single(db);
    Users.Post(db);
}
catch (MySqlException e)
{
    Console.WriteLine(e);
}
finally
{
    db?.Close();
}