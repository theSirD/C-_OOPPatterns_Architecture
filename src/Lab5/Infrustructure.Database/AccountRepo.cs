using Application.Abstractions.Repositories;
using Application.DomainModel;
using Npgsql;

namespace Infrustructure.Database;

public class AccountRepo : IAccountRepo
{
    private readonly string _connectionString;

    public AccountRepo(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Add(long userId)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var cmd = new NpgsqlCommand(
            """
                    INSERT INTO "BankingSystem"."Account" ("userId", "balance")
                    VALUES (@userId, 0)
            """,
            connection);
        cmd.Parameters.AddWithValue("userId", userId);
        using NpgsqlDataReader reader = cmd.ExecuteReader();
    }

    public Account? GetById(string id)
    {
        throw new NotImplementedException();
    }

    public void Remove(string id)
    {
        throw new NotImplementedException();
    }

    public void Update(Account account)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Account> GetAll()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Account> GetAllByUserId()
    {
        throw new NotImplementedException();
    }
}