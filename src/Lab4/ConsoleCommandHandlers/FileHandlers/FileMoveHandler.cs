using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.FileHandlers;

public class FileMoveHandler : BaseHandler
{
    public FileMoveHandler(Context context)
    : base(context)
    {
        NextHandler = new FileCopyHandler(context);
    }

    public override void Handle()
    {
        if (Context is null || Context.Info is null || Context.Parser is null)
        {
            throw new ArgumentException("Context object is not initialized properly");
        }

        if (!CanHandle())
        {
            if (NextHandler is null)
                throw new ArgumentException("Can not do the command");
            NextHandler.Handle();
            return;
        }

        Context.Parser.MoveForward();
        string sourcePath = Context.Parser.Current;
        sourcePath = sourcePath.Substring(1, sourcePath.Length - 2);
        Context.Info.Path1 = sourcePath;
        Context.Parser.MoveForward();
        string destinationPath = Context.Parser.Current;
        destinationPath = destinationPath.Substring(1, destinationPath.Length - 2);
        Context.Info.Path2 = destinationPath;
        if (sourcePath.Length == 0)
            throw new ArgumentException("You need to specify source path for 'file move'");
        if (destinationPath.Length == 0)
            throw new ArgumentException("You need to specify destination path for 'file move'");
        if (Context.FileSystem is null)
            throw new ArgumentException("You need to connect to FS first");
        Context.FileSystem.FileMove(Context);
    }

    public override bool CanHandle()
    {
        if (Context is null || Context.Info is null)
            throw new ArgumentException("Context object is not initialized properly");
        return Context.Info.Subcommand == "move";
    }
}