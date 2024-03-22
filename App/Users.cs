namespace App;

using MySql.Data.MySqlClient;

public class Users
{
    public static void Post(MySqlConnection db)
    {
        MySqlCommand command = new("INSERT INTO users(username,email,password) values(@username,@email,@password)", db);

        Console.WriteLine("Please enter username");
        string username = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Please enter email");
        string email = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Please enter password");
        string password = Console.ReadLine() ?? string.Empty;

        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@email", email);
        command.Parameters.AddWithValue("@password", password);

        command.ExecuteNonQuery();
    }

    public static void Single(MySqlConnection db)
    {
        MySqlCommand command = new("SELECT email FROM users WHERE username = @input", db);

        Console.WriteLine("Please enter the username you want the email of");
        string input = Console.ReadLine() ?? string.Empty;

        command.Parameters.AddWithValue("@input", input);

        var email = command.ExecuteScalar();

        if (email is string s)
        {
            Console.WriteLine(s);
        }
    }

    public static void All(MySqlConnection db)
    {
        MySqlCommand command = new("SELECT * FROM users", db);

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32("id");
            string username = reader.GetString("username");
            Console.WriteLine($"{username} has id: {id}");
        }
    }
}