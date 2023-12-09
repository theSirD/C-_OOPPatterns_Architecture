using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.FileHandlers;

public class FileDeleteHandler : BaseHandler
{
    public FileDeleteHandler(Context context)
    : base(context)
    {
        NextHandler = new FileRenameHandler(context);
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
        string pathOfFileToDelete = Context.Parser.Current;
        pathOfFileToDelete = pathOfFileToDelete.Substring(1, pathOfFileToDelete.Length - 2);
        Context.Info.Path1 = pathOfFileToDelete;

        if (pathOfFileToDelete.Length == 0)
            throw new ArgumentException("You need to specify source path for 'file delete'");
        if (Context.FileSystem is null)
            throw new ArgumentException("You need to connect to FS first");
        Context.FileSystem.FileDelete(Context);
    }

    public override bool CanHandle()
    {
        if (Context is null || Context.Info is null)
            throw new ArgumentException("Context object is not initialized properly");
        return Context.Info.Subcommand == "delete";
    }
}