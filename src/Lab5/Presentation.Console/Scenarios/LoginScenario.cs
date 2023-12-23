using Application.Contracts.Users;

namespace Presentation.Console.Scenarios;

public class LoginScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Login";

    public void Run()
    {
        string? choice;
        LoginResult result;
        do
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Enter your username");
            string? username = System.Console.ReadLine();
            if (username is null)
                throw new ArgumentException("Given name is null");

            System.Console.WriteLine("Enter your password");
            string? password = System.Console.ReadLine();
            if (password is null)
                throw new ArgumentException("Given password is null");

            result = _userService.Login(username, password);

            if (result == LoginResult.Success)
            {
                System.Console.WriteLine("Successful login");
                break;
            }

            System.Console.WriteLine();
            System.Console.WriteLine("User with given name does not exist");
            System.Console.WriteLine("Press 1 to exit application");
            choice = System.Console.ReadLine();

            switch (choice)
            {
                case null:
                    System.Console.WriteLine("Incorrect choice");
                    break;
                case "1":
                    break;
                default:
                    throw new ArgumentException("Wrong command");
            }
        }
        while ((choice != "2" && result != LoginResult.Success) || choice != "1");
    }
}