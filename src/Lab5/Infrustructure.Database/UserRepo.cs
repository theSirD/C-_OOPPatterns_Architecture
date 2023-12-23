using Application.Abstractions.Repositories;
using Application.DomainModel.User;
using Npgsql;

namespace Infrustructure.Database;

public class UserRepo : IUserRepo
{
    private readonly string _connectionString;

    public UserRepo(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Add(User user)
    {
        throw new NotImplementedException();
    }

    public User? GetById(string id)
    {
        throw new NotImplementedException();
    }

    public User? GetByName(string userName)
    {
        User result;
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var cmd = new NpgsqlCommand(
            """
            SELECT *
            FROM "BankingSystem"."Users"
            WHERE "name" = @name
            Order by "id"
            """,
            connection);
        cmd.Parameters.AddWithValue("name", userName);
        using NpgsqlDataReader reader = cmd.ExecuteReader();
        reader.Read();

        int id = reader.GetInt32(0);
        string name = reader.GetString(1);
        string role = reader.GetString(2);
        switch (role)
        {
            case "Admin":
                result = new User(id, name, UserRole.Admin);
                break;
            case "Customer":
                result = new User(id, name, UserRole.Customer);
                break;
            default:
                throw new ArgumentException("There is a user with incorrect role in database");
        }

        return result;
    }

    public void Remove(string id)
    {
        throw new NotImplementedException();
    }

    public void Update(User user)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetAll()
    {
        throw new NotImplementedException();
    }
}