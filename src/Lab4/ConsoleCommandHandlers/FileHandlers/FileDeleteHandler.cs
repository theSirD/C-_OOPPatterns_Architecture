using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.FileHandlers;

public class FileDeleteHandler : BaseHandler
{
    public FileDeleteHandler()
    {
        NextHandler = new FileRenameHandler();
    }

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
        string pathOfFileToDelete = Parser.Current;
        pathOfFileToDelete = pathOfFileToDelete.Substring(1, pathOfFileToDelete.Length - 2);

        if (pathOfFileToDelete.Length == 0)
            throw new ArgumentException("You need to specify source path for 'file delete'");
        if (FileSystem is null)
            throw new ArgumentException("You need to connect to FS first");
        FileSystem.FileDelete(pathOfFileToDelete);
    }

    public override bool CanHandle(string request)
    {
        return request == "delete";
    }
}