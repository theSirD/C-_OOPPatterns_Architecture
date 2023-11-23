using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.FileHandlers.FileShowHandler;

public class FileOutputModeFlagHandler : BaseHandler
{
    public override void Handle(string request, string path)
    {
        if (!CanHandle(request))
        {
            if (NextHandler is null)
                throw new ArgumentException("Unknown flag");
            NextHandler.Handle(request, string.Empty);
        }

        string? flagArgument = Parser?.SearchForFlagArgument();
        if (flagArgument is not null)
        {
            if (flagArgument.Length == 0)
                throw new ArgumentException("Flag argument after flag was not specified for 'file show -m'");
            if (FileSystem is null)
                throw new ArgumentException("You need to connect to FS first");
            FileSystem.FileShow(flagArgument, path);
        }
    }

    public override bool CanHandle(string request)
    {
        return request == "-m";
    }
}