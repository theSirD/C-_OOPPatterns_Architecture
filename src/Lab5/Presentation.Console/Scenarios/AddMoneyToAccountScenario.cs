using Application.Contracts.Accounts;
using Application.Contracts.Users;
using Application.DomainModel;

namespace Presentation.Console.Scenarios;

public class AddMoneyToAccountScenario : IScenario
{
    private readonly IUserService _userService;

    public AddMoneyToAccountScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Add Money";

    public void Run()
    {
        GetAccountResponse result = _userService.GetAccounts();
        if (result.Response == AccountOperationsResult.NotAuthorized)
            System.Console.WriteLine("You need to log in before creating account");

        if (result.Account == null)
            throw new ArgumentException("Account list should not be null");

        System.Console.WriteLine("Choose an account by ID to add money");
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

            System.Console.WriteLine("Input an amount of money to add");
            string? amountOfMoney = System.Console.ReadLine();
            if (amountOfMoney is null) throw new ArgumentException("AmountOfMoney is null");

            if (int.TryParse(amountOfMoney, out int intAmountOfMoney))
            {
                Account accountToAddMoneyTo = enumerable.First();
                AccountOperationsResult result2 = _userService.RemoveMoneyFromAccount(accountToAddMoneyTo, intAmountOfMoney);

                if (result2 == AccountOperationsResult.Success)
                {
                    System.Console.WriteLine($"You have removed {amountOfMoney} " +
                                             $"money from account {accountToAddMoneyTo.Id}");
                }
                else
                {
                    System.Console.WriteLine("Failed to remove money");
                }
            }
        }
        else
        {
            System.Console.WriteLine("Unable to parse id");
        }
    }
}