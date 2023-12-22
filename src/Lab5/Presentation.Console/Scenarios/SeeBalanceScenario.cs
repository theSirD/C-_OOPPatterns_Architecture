using Application.Contracts.Accounts;
using Application.Contracts.Users;
using Application.DomainModel;

namespace Presentation.Console.Scenarios;

public class SeeBalanceScenario : IScenario
{
    private readonly IUserService _userService;

    public SeeBalanceScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Check Balance";

    public void Run()
    {
        GetAccountResponse result = _userService.GetAccounts();
        if (result.Response == AccountOperationsResult.NotAuthorized)
            System.Console.WriteLine("You need to log in before creating account");

        if (result.Account == null)
            throw new ArgumentException("Account list should not be null");

        foreach (Account account in result.Account)
        {
            System.Console.WriteLine($"ID: {account.Id}, Balance: {account.Balance}");
        }
    }
}