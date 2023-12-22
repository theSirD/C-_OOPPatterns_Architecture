using Application.Contracts.Accounts;
using Application.DomainModel;

namespace Application.Contracts.Users;

public interface IAdminService
{
    public LoginResult Login(string username);
    public GetAccountResponse GetAccounts();
    public AccountOperationsResult RemoveMoneyFromAccount(Account account, int amountOfMoney);
    public AccountOperationsResult RefillMoneyOnAccount(Account account, int amountOfMoney);
}