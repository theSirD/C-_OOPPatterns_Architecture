using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.FileHandlers;

public class FileRenameHandler : BaseHandler
{
    public FileRenameHandler(Context context)
    : base(context)
    { }

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
        string pathOfFileToRename = Context.Parser.Current;
        pathOfFileToRename = pathOfFileToRename.Substring(1, pathOfFileToRename.Length - 2);
        Context.Info.Path1 = pathOfFileToRename;
        Context.Parser.MoveForward();
        string newFileName = Context.Parser.Current;
        newFileName = newFileName.Substring(1, newFileName.Length - 2);
        Context.Info.Path2 = newFileName;

        if (pathOfFileToRename.Length == 0)
            throw new ArgumentException("You need to specify path for 'file rename'");
        if (newFileName.Length == 0)
            throw new ArgumentException("You need to specify new file name for 'file rename'");
        if (Context.FileSystem is null)
            throw new ArgumentException("You need to connect to FS first");
        Context.FileSystem.FileRename(Context);
    }

    public override bool CanHandle()
    {
        if (Context is null || Context.Info is null)
            throw new ArgumentException("Context object is not initialized properly");
        return Context.Info.Subcommand == "rename";
    }
}