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
        if (!CanHandle(request))
        {
            if (NextHandler is null)
                throw new ArgumentException("Can not do the command");
            NextHandler.Handle(request, string.Empty);
        }

        string? address = Parser?.SearchForPath();
        if (address is not null)
        {
            if (address.Length == 0)
                throw new ArgumentException("Address for 'file show' is required");
            _chainOfFlagHandlers.Handle(string.Empty, address);
        }
    }

    public override bool CanHandle(string request)
    {
        return request == "show";
    }
}