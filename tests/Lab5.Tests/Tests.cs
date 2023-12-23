using Application.Abstractions.Repositories;
using Application.Contracts.Accounts;
using Application.Contracts.Transactions;
using Application.Contracts.Users;
using Application.DomainModel;
using Application.DomainServices;
using Infrustructure.Database;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class Tests
{
    [Fact]

    public void Login()
    {
        string connectionString = "Host=localhost:5432;" +
                                  "Username=postgres;" +
                                  "Password=theSirD;" +
                                  "Database=Bank";

        IUserRepo userRepo = new UserRepo(connectionString);
        IAccountRepo accountRepo = new AccountRepo(connectionString);
        ITransactionsRepo transactionsRepo = new TransactionsRepo(connectionString);
        var currentUserManager = new CurrentUserManager();

        IUserService userService = new UserService(userRepo, accountRepo, transactionsRepo, currentUserManager);

        LoginResult result = userService.Login("Dan", "123");

        Assert.True(result == LoginResult.Success);
    }

    [Fact]
    public void CreateAccount()
    {
        string connectionString = "Host=localhost:5432;" +
                                  "Username=postgres;" +
                                  "Password=theSirD;" +
                                  "Database=Bank";

        IUserRepo userRepo = new UserRepo(connectionString);
        IAccountRepo accountRepo = new AccountRepo(connectionString);
        ITransactionsRepo transactionsRepo = new TransactionsRepo(connectionString);
        var currentUserManager = new CurrentUserManager();

        IUserService userService = new UserService(userRepo, accountRepo, transactionsRepo, currentUserManager);
        LoginResult result1 = userService.Login("Dan", "123");

        AccountOperationsResult result2 = userService.CreateAccount();

        Assert.True(result1 == LoginResult.Success && result2 == AccountOperationsResult.Success);
    }

    [Fact]
    public void ChangeBalance()
    {
        string connectionString = "Host=localhost:5432;" +
                                  "Username=postgres;" +
                                  "Password=theSirD;" +
                                  "Database=Bank";

        IUserRepo userRepo = new UserRepo(connectionString);
        IAccountRepo accountRepo = new AccountRepo(connectionString);
        ITransactionsRepo transactionsRepo = new TransactionsRepo(connectionString);
        var currentUserManager = new CurrentUserManager();

        IUserService userService = new UserService(userRepo, accountRepo, transactionsRepo, currentUserManager);
        LoginResult result1 = userService.Login("Dan", "123");

        AccountOperationsResult result2 = userService.CreateAccount();

        AccountOperationsResult result3 = userService.RemoveMoneyFromAccount(new Account(1, 1, 0), 100);

        Assert.True(result1 == LoginResult.Success && result2 == AccountOperationsResult.Success
        && result3 == AccountOperationsResult.Success);
    }

    [Fact]
    public void SeeHistoryOfTransactions()
    {
        string connectionString = "Host=localhost:5432;" +
                                  "Username=postgres;" +
                                  "Password=theSirD;" +
                                  "Database=Bank";

        IUserRepo userRepo = new UserRepo(connectionString);
        IAccountRepo accountRepo = new AccountRepo(connectionString);
        ITransactionsRepo transactionsRepo = new TransactionsRepo(connectionString);
        var currentUserManager = new CurrentUserManager();

        IUserService userService = new UserService(userRepo, accountRepo, transactionsRepo, currentUserManager);
        LoginResult result1 = userService.Login("Dan", "123");

        AccountOperationsResult result2 = userService.CreateAccount();

        AccountOperationsResult result3 = userService.RemoveMoneyFromAccount(new Account(1, 1, 0), 100);

        GetTransactionResponse result4 = userService.GetTransactions();

        Assert.True(result1 == LoginResult.Success && result2 == AccountOperationsResult.Success
                                                   && result3 == AccountOperationsResult.Success
                                                   && result4.Response == AccountOperationsResult.Success);
    }
}