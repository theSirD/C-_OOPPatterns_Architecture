using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.FileHandlers;

public class FileRenameHandler : BaseHandler
{
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
        string pathOfFileToRename = Parser.Current;
        pathOfFileToRename = pathOfFileToRename.Substring(1, pathOfFileToRename.Length - 2);
        Info.Path1 = pathOfFileToRename;
        Parser.MoveForward();
        string newFileName = Parser.Current;
        newFileName = newFileName.Substring(1, newFileName.Length - 2);
        Info.Path2 = newFileName;

        if (pathOfFileToRename.Length == 0)
            throw new ArgumentException("You need to specify path for 'file rename'");
        if (newFileName.Length == 0)
            throw new ArgumentException("You need to specify new file name for 'file rename'");
        if (FileSystem is null)
            throw new ArgumentException("You need to connect to FS first");
        FileSystem.FileRename(pathOfFileToRename, newFileName);
    }

    public override bool CanHandle(string request)
    {
        return request == "rename";
    }
}