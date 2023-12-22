using Application.Contracts.Accounts;
using Application.DomainModel;

namespace Application.Contracts.Users;

public interface IUserService
{
    public LoginResult Login(string username);
    public LoginResult Register(string username);
    public AccountOperationsResult CreateAccount();
    public GetAccountResponse GetAccounts();
    public AccountOperationsResult RemoveMoneyFromAccount(Account account, int amountOfMoney);
    public AccountOperationsResult RefillMoneyOnAccount(Account account, int amountOfMoney);
}