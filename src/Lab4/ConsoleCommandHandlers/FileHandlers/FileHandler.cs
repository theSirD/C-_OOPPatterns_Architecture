using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.FileHandlers;

public class FileHandler : BaseHandler
{
    private BaseHandler _chainOfSubcommandHandlers = new FileShowHandler.FileShowHandler();

    public override void Handle(string request, string path)
    {
        if (!CanHandle(request))
        {
            if (NextHandler is null)
                throw new ArgumentException("Can not do the command");
            NextHandler.Handle(request, string.Empty);
        }

        string? subcommand = Parser?.SearchForPath();
        if (subcommand is not null)
        {
            if (subcommand.Length == 0)
                throw new ArgumentException("For 'file' command subcommand is required");
            _chainOfSubcommandHandlers.Handle(subcommand, string.Empty);
        }
    }

    public override bool CanHandle(string request)
    {
        return request == "file";
    }
}