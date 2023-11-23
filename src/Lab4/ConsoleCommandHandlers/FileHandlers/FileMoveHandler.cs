using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.FileHandlers;

public class FileMoveHandler : BaseHandler
{
    public FileMoveHandler()
    {
        NextHandler = new FileCopyHandler();
    }

    public override void Handle(string request, string path)
    {
        if (!CanHandle(request))
        {
            if (NextHandler is null)
                throw new ArgumentException("Can not do the command");
            NextHandler.Handle(request, string.Empty);
        }

        string? sourcePath = Parser?.SearchForPath();
        string? destinationPath = Parser?.SearchForPath();
        if (sourcePath is not null && destinationPath is not null)
        {
            if (sourcePath.Length == 0)
                throw new ArgumentException("You need to specify source path for 'file move'");
            if (destinationPath.Length == 0)
                throw new ArgumentException("You need to specify destination path for 'file move'");
            if (FileSystem is null)
                throw new ArgumentException("You need to connect to FS first");
            FileSystem.FileMove(sourcePath, destinationPath);
        }
    }

    public override bool CanHandle(string request)
    {
        return request == "move";
    }
}