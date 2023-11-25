using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.TreeHandlers.TreeListHandler;

public class SelectionDepthFlagHandler : BaseHandler
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
            throw new ArgumentException("Flag argument is not specified after flag");
        if (FileSystem is null)
            throw new ArgumentException("You need to connect to FS first");
        FileSystem.TreeList(flagArgument);
    }

    public override bool CanHandle(string request)
    {
        return request == "-d";
    }
}