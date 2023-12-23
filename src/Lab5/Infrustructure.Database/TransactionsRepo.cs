using Application.Abstractions.Repositories;
using Application.DomainModel.Transactions;
using Npgsql;

namespace Infrustructure.Database;

public class TransactionsRepo : ITransactionsRepo
{
    private readonly string _connectionString;

    public TransactionsRepo(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Add(Transaction transaction)
    {
        if (transaction is null) throw new ArgumentException("transaction is null");
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var cmd = new NpgsqlCommand(
            """
                    INSERT INTO "BankingSystem"."Transaction" ("accountId", "operation", "amountOfMoney")
                    VALUES (@accId, @operation, @money)
            """,
            connection);
        cmd.Parameters.AddWithValue("accId", transaction.AccountId);
        cmd.Parameters.AddWithValue("operation", transaction.Operation.ToString());
        cmd.Parameters.AddWithValue("money", transaction.AmountOfMoney);
        using NpgsqlDataReader reader = cmd.ExecuteReader();
    }

    public IEnumerable<Transaction> GetAllTransactionsByUserId(long userId)
    {
        var result = new List<Transaction>();

        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var cmd = new NpgsqlCommand(
            """
            SELECT *
            FROM "BankingSystem"."Transaction"
            WHERE "userId" = @userId
            Order by "id"
            """,
            connection);
        cmd.Parameters.AddWithValue("userId", userId);
        using NpgsqlDataReader reader = cmd.ExecuteReader();

        Transaction transaction;
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            long accId = reader.GetInt32(1);
            string operationString = reader.GetString(2);
            int amountOfMoney = reader.GetInt32(3);

            switch (operationString)
            {
                case "Refill":
                    transaction = new Transaction(id, accId, TypeOfTranscations.Refill, amountOfMoney);
                    break;
                case "Removal":
                    transaction = new Transaction(id, accId, TypeOfTranscations.Removal, amountOfMoney);
                    break;
                default:
                    throw new ArgumentException("There is a user with incorrect role in database");
            }

            result.Add(transaction);
        }

        return result;
    }
}