using Application.Abstractions.Repositories;
using Application.Contracts.Users;
using Application.DomainServices;
using Infrustructure.Database;
using Presentation.Console;
using Presentation.Console.Scenarios;
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
        var currentUserManager = new CurrentUserManager();

        IUserService userService = new UserService(userRepo, accountRepo, currentUserManager);
        IScenario loginScenarion = new LoginScenario(userService);

        loginScenarion.Run();

        IScenario createAccountScenario = new CreateAccountScenario(userService);
        createAccountScenario.Run();

        IScenario seeBalanceScenario = new SeeBalanceScenario(userService);
        seeBalanceScenario.Run();
    }
}