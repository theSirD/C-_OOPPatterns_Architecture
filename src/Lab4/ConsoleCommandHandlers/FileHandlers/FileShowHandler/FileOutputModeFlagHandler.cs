using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.FileHandlers.FileShowHandler;

public class FileOutputModeFlagHandler : BaseHandler
{
    public override void Handle(string request, string path)
    {
        if (Parser is null)
            throw new ArgumentException("You need to pass a parser first");
        if (!CanHandle(request))
        {
            if (NextHandler is null)
                throw new ArgumentException("Unknown flag");
            NextHandler.Handle(request, string.Empty);
            return;
        }

        Parser.MoveForward();
        string flagArgument = Parser.Current;
        if (flagArgument.Length == 0)
            throw new ArgumentException("Flag argument after flag was not specified for 'file show -m'");
        if (FileSystem is null)
            throw new ArgumentException("You need to connect to FS first");
        FileSystem.FileShow(flagArgument, path);
    }

    public override bool CanHandle(string request)
    {
        return request == "-m";
    }
}