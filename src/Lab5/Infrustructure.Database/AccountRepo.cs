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

    public void Update(Account account)
    {
        if (account is null) throw new AggregateException("Account is null");
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var cmd = new NpgsqlCommand(
            """
            Update "BankingSystem"."Account"
            set "balance" = @balance
            Where "id" = @id
            """,
            connection);
        cmd.Parameters.AddWithValue("balance", account.Balance);
        cmd.Parameters.AddWithValue("id", account.Id);
        cmd.ExecuteReader();
    }

    public IEnumerable<Account> GetAllAccountsByUserId(long userId)
    {
        var result = new List<Account>();

        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var cmd = new NpgsqlCommand(
            """
            SELECT *
            FROM "BankingSystem"."Account"
            WHERE "userId" = @userId
            Order by "id"
            """,
            connection);
        cmd.Parameters.AddWithValue("userId", userId);
        using NpgsqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            long uId = reader.GetInt32(1);
            int balance = reader.GetInt32(2);
            result.Add(new Account(id, userId, balance));
        }

        return result;
    }
}