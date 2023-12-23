using Application.Contracts.Accounts;
using Application.Contracts.Users;

namespace Presentation.Console.Scenarios;

public class CreateAccountScenario : IScenario
{
    private readonly IUserService _userService;

    public CreateAccountScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Create Account";

    public ScenarioResults Run()
    {
        AccountOperationsResult result = _userService.CreateAccount();

        switch (result)
        {
            case AccountOperationsResult.NotAuthorized:
                System.Console.WriteLine("You need to log in before creating account");
                return ScenarioResults.NotAuthorized;
            case AccountOperationsResult.Success:
                System.Console.WriteLine("You have created new account");
                return ScenarioResults.NewAccountCreated;
            default:
                return ScenarioResults.ScenarioFailed;
        }
    }
}