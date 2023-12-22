using Application.Abstractions.Repositories;
using Application.Contracts.Accounts;
using Application.Contracts.Users;
using Application.DomainModel;
using Application.DomainModel.User;

namespace Application.DomainServices;

public class UserService : IUserService
{
    private readonly IUserRepo _userRepo;
    private readonly IAccountRepo _accountRepo;

    private readonly CurrentUserManager _currentUserManager;

    public UserService(IUserRepo userRepo, IAccountRepo accountRepo, CurrentUserManager currentUserManager)
    {
        _userRepo = userRepo;
        _accountRepo = accountRepo;
        _currentUserManager = currentUserManager;
    }

    public LoginResult Login(string username)
    {
        User? user = _userRepo.GetByName(username);

        if (user is null)
        {
            return LoginResult.NotFound;
        }

        _currentUserManager.User = user;
        return LoginResult.Success;
    }

    public LoginResult Register(string username)
    {
        System.Console.WriteLine("Enter your role (1 - admin, 2 - customer)");
        string? input = System.Console.ReadLine();
        if (input is null)
            throw new ArgumentException("Given role is null");

        UserRole role;
        switch (input)
        {
            case "1":
                role = UserRole.Admin;
                break;
            case "2":
                role = UserRole.Customer;
                break;
            default:
                role = UserRole.Customer;
                break;
        }

        var user = new User(?, username, role);
        _userRepo.Add(user);
        _currentUserManager.User = user;

        return LoginResult.Success;
    }

    public AccountOperationsResult CreateAccount()
    {
        if (_currentUserManager.User is null) return AccountOperationsResult.NotAuthorized;

        var account = new Account(?, _currentUserManager.User.Id, 0);
        _accountRepo.Add(account);

        return AccountOperationsResult.Success;
    }

    public GetAccountResponse GetAccounts()
    {
        if (_currentUserManager.User is null) return new GetAccountResponse(AccountOperationsResult.NotAuthorized, null);

        IEnumerable<Account> userAccountsList = _accountRepo.GetAllByUserId();
        return new GetAccountResponse(AccountOperationsResult.Success, userAccountsList);
    }

    public AccountOperationsResult RemoveMoneyFromAccount(Account account, int amountOfMoney)
    {
        if (account is null) throw new ArgumentException("Account is null");
        var newAccount = new Account(
            account.Id,
            account.UserId,
            account.Balance - amountOfMoney);

        _accountRepo.Update(newAccount);

        return AccountOperationsResult.Success;
    }

    public AccountOperationsResult RefillMoneyOnAccount(Account account, int amountOfMoney)
    {
        if (account is null) throw new ArgumentException("Account is null");
        var newAccount = new Account(
            account.Id,
            account.UserId,
            account.Balance - amountOfMoney);

        _accountRepo.Update(newAccount);

        return AccountOperationsResult.Success;
    }
}
