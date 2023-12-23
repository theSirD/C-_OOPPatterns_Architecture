using Application.Contracts.Accounts;
using Application.Contracts.Transactions;
using Application.Contracts.Users;
using Application.DomainModel.Transactions;

namespace Presentation.Console.Scenarios;

public class SeeHistoryOfTransactionsScenario : IScenario
{
    private readonly IUserService _userService;

    public SeeHistoryOfTransactionsScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "See History";

    public void Run()
    {
        GetTransactionResponse result = _userService.GetTransactions();
        if (result.Response == AccountOperationsResult.NotAuthorized)
            System.Console.WriteLine("You need to log in before seeing balance");

        if (result.Transactions == null)
            throw new ArgumentException("Account list should not be null");

        foreach (Transaction transaction in result.Transactions)
        {
            System.Console.WriteLine($"ID: {transaction.Id}, AccountId: {transaction.AccountId}, Operation: {transaction.Operation}, Money: {transaction.AmountOfMoney}");
        }
    }
}