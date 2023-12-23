using Application.Abstractions.Repositories;
using Application.Contracts.Accounts;
using Application.Contracts.Transactions;
using Application.Contracts.Users;
using Application.DomainModel;
using Application.DomainModel.Transactions;
using Application.DomainModel.User;
using Application.DomainServices.Loggers;

namespace Application.DomainServices;

public class UserService : IUserService
{
    private readonly IUserRepo _userRepo;
    private readonly IAccountRepo _accountRepo;
    private readonly ITransactionsRepo _transactionsRepo;
    private readonly ILogger _logger;

    private readonly CurrentUserManager _currentUserManager;

    public UserService(IUserRepo userRepo, IAccountRepo accountRepo, ITransactionsRepo transactionsRepo, CurrentUserManager currentUserManager)
    {
        _userRepo = userRepo;
        _accountRepo = accountRepo;
        _transactionsRepo = transactionsRepo;
        _currentUserManager = currentUserManager;
        _logger = new Logger(transactionsRepo);
    }

    public LoginResult Login(string username, string password)
    {
        User? user = _userRepo.GetByName(username);

        if (user is null)
        {
            return LoginResult.NotFound;
        }

        if (password != user.Password)
        {
            return LoginResult.IncorrectPassword;
        }

        _currentUserManager.User = user;
        return LoginResult.Success;
    }

    public AccountOperationsResult CreateAccount()
    {
        if (_currentUserManager.User is null) return AccountOperationsResult.NotAuthorized;
        _accountRepo.Add(_currentUserManager.User.Id);

        return AccountOperationsResult.Success;
    }

    public GetAccountResponse GetAccounts()
    {
        if (_currentUserManager.User is null) return new GetAccountResponse(AccountOperationsResult.NotAuthorized, null);

        IEnumerable<Account> userAccountsList = _accountRepo.GetAllAccountsByUserId(_currentUserManager.User.Id);
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
        var transaction = new Application.DomainModel.Transactions.Transaction(0, account.Id, TypeOfTranscations.Removal, amountOfMoney);
        _logger.Log(transaction);

        return AccountOperationsResult.Success;
    }

    public AccountOperationsResult RefillMoneyOnAccount(Account account, int amountOfMoney)
    {
        if (account is null) throw new ArgumentException("Account is null");
        var newAccount = new Account(
            account.Id,
            account.UserId,
            account.Balance + amountOfMoney);

        _accountRepo.Update(newAccount);

        var transaction = new Application.DomainModel.Transactions.Transaction(0, account.Id, TypeOfTranscations.Removal, amountOfMoney);
        _logger.Log(transaction);

        return AccountOperationsResult.Success;
    }

    public GetTransactionResponse GetTransactions()
    {
        if (_currentUserManager.User is null) return new GetTransactionResponse(AccountOperationsResult.NotAuthorized, null);

        IEnumerable<Transaction> userTransactionsList = _transactionsRepo.GetAllTransactionsByUserId(_currentUserManager.User.Id);
        return new GetTransactionResponse(AccountOperationsResult.Success, userTransactionsList);
    }
}
