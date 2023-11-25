using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.FileHandlers.FileShowHandler;

public class FileOutputModeFlagHandler : BaseHandler
{
    public FileOutputModeFlagHandler(Context context)
    : base(context)
    {
    }

    public override void Handle(string request, string path)
    {
        if (Context is null || Context.Info is null || Context.Parser is null)
        {
            throw new ArgumentException("Context object is not initialized properly");
        }

        if (!CanHandle(request))
        {
            if (NextHandler is null)
                throw new ArgumentException("Unknown flag");
            NextHandler.Handle(request, string.Empty);
            return;
        }

        Context.Parser.MoveForward();
        string flagArgument = Context.Parser.Current;
        Context.Info.FlagArgument = flagArgument;
        if (flagArgument.Length == 0)
            throw new ArgumentException("Flag argument after flag was not specified for 'file show -m'");
        if (Context.FileSystem is null)
            throw new ArgumentException("You need to connect to FS first");
        Context.FileSystem.FileShow(flagArgument, path);
    }

    public override bool CanHandle(string request)
    {
        return request == "-m";
    }
}