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

            result = _userService.Login(username);

            if (result == LoginResult.Success)
            {
                System.Console.WriteLine("Successful login");
                break;
            }

            System.Console.WriteLine();
            System.Console.WriteLine("User with given name does not exist");
            System.Console.WriteLine("Press 1 to exit application");
            System.Console.WriteLine("Press 2 to register new user with name given");
            choice = System.Console.ReadLine();

            switch (choice)
            {
                case null:
                    System.Console.WriteLine("Incorrect choice");
                    break;
                case "1":
                    break;
                case "2":
                    result = _userService.Register(username);
                    if (result == LoginResult.Success) System.Console.WriteLine("Registration is successful");
                    else System.Console.WriteLine("Registration has failed");
                    break;
            }
        }
        while ((choice != "2" && result != LoginResult.Success) || choice != "1");
    }
}