using Application.Contracts.Accounts;
using Application.Contracts.Users;
using Application.DomainModel;

namespace Presentation.Console.Scenarios;

public class RemoveMoneyFromAccountScenario : IScenario
{
    private readonly IUserService _userService;

    public RemoveMoneyFromAccountScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Remove Money";

    public ScenarioResults Run()
    {
        GetAccountResponse result = _userService.GetAccounts();
        if (result.Response == AccountOperationsResult.NotAuthorized)
            System.Console.WriteLine("You need to log in before creating account");

        if (result.Account == null)
            throw new ArgumentException("Account list should not be null");

        System.Console.WriteLine("Choose an account by ID to remove money");
        foreach (Account acc in result.Account)
        {
            System.Console.WriteLine($"ID: {acc.Id}, Balance: {acc.Balance}");
        }

        string? choice = System.Console.ReadLine();
        if (choice is null) throw new ArgumentException("Choice is null");

        if (int.TryParse(choice, out int intChoice))
        {
            IEnumerable<Account> account = result.Account.Where(a => a.Id == intChoice);
            IEnumerable<Account> enumerable = account as Account[] ?? account.ToArray();
            if (!enumerable.Any()) System.Console.WriteLine("Given ID is incorrect");

            System.Console.WriteLine("Input an amount of money to remove");
            string? amountOfMoney = System.Console.ReadLine();
            if (amountOfMoney is null) throw new ArgumentException("AmountOfMoney is null");

            if (int.TryParse(amountOfMoney, out int intAmountOfMoney))
            {
                Account accountToRemoveMoneyFrom = enumerable.First();
                AccountOperationsResult result2 = _userService.RemoveMoneyFromAccount(accountToRemoveMoneyFrom, intAmountOfMoney);

                if (result2 == AccountOperationsResult.Success)
                {
                    System.Console.WriteLine($"You have removed {amountOfMoney} " +
                                             $"money from account {accountToRemoveMoneyFrom.Id}");
                    return ScenarioResults.MoneyWasRemoved;
                }
                else
                {
                    System.Console.WriteLine("Failed to remove money");
                    return ScenarioResults.ScenarioFailed;
                }
            }
        }
        else
        {
            System.Console.WriteLine("Unable to parse id");
        }

        return ScenarioResults.ScenarioFailed;
    }
}