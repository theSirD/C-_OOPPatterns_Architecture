using Application.Abstractions.Repositories;
using Application.Contracts.Accounts;
using Application.Contracts.Users;
using Application.DomainModel;
using Application.DomainModel.User;

namespace Application.DomainServices;

public class AdminService : IAdminService
{
    private readonly IUserRepo _userRepo;
    private readonly IAccountRepo _accountRepo;

    private readonly CurrentUserManager _currentUserManager;

    public AdminService(IUserRepo userRepo, IAccountRepo accountRepo, CurrentUserManager currentUserManager)
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

    public GetAccountResponse GetAccounts()
    {
        throw new NotImplementedException();
    }

    public AccountOperationsResult RemoveMoneyFromAccount(Account account, int amountOfMoney)
    {
        throw new NotImplementedException();
    }

    public AccountOperationsResult RefillMoneyOnAccount(Account account, int amountOfMoney)
    {
        throw new NotImplementedException();
    }
}