using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.FileHandlers.FileShowHandler;

public class FileShowHandler : BaseHandler
{
    private readonly IHandler _chainOfFlagHandlers = new FileOutputModeFlagHandler();

    public FileShowHandler()
    {
        NextHandler = new FileMoveHandler();
    }

    public override void Handle(string request, string path)
    {
        if (Parser is null)
            throw new ArgumentException("You need to pass a parser first");
        if (!CanHandle(request))
        {
            if (NextHandler is null)
                throw new ArgumentException("Can not do the command");
            NextHandler.Handle(request, string.Empty);
            return;
        }

        Parser.MoveForward();
        string address = Parser.Current;
        address = address.Substring(1, address.Length - 2);
        Info.Path1 = address;
        Parser.MoveForward();
        string flag = Parser.Current;
        Info.Flag = flag;
        if (address.Length == 0)
            throw new ArgumentException("Address for 'file show' is required");
        _chainOfFlagHandlers.Handle(flag, address);
    }

    public override bool CanHandle(string request)
    {
        return request == "show";
    }
}