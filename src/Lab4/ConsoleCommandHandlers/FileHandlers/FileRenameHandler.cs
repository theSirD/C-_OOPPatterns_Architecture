using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.FileHandlers;

public class FileRenameHandler : BaseHandler
{
    public override void Handle(string request, string path)
    {
        if (!CanHandle(request))
        {
            if (NextHandler is null)
                throw new ArgumentException("Can not do the command");
            NextHandler.Handle(request, string.Empty);
        }

        string? pathOfFileToRename = Parser?.SearchForPath();
        string? newFileName = Parser?.SearchForPath();
        if (pathOfFileToRename is not null && newFileName is not null)
        {
            if (pathOfFileToRename.Length == 0)
                throw new ArgumentException("You need to specify path for 'file rename'");
            if (newFileName.Length == 0)
                throw new ArgumentException("You need to specify new file name for 'file rename'");
            if (FileSystem is null)
                throw new ArgumentException("You need to connect to FS first");
            FileSystem.FileRename(pathOfFileToRename, newFileName);
        }
    }

    public override bool CanHandle(string request)
    {
        return request == "rename";
    }
}