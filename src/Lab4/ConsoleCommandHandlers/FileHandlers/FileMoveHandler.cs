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
        string sourcePath = Parser.Current;
        sourcePath = sourcePath.Substring(1, sourcePath.Length - 2);
        Parser.MoveForward();
        string destinationPath = Parser.Current;
        destinationPath = destinationPath.Substring(1, destinationPath.Length - 2);
        if (sourcePath.Length == 0)
            throw new ArgumentException("You need to specify source path for 'file move'");
        if (destinationPath.Length == 0)
            throw new ArgumentException("You need to specify destination path for 'file move'");
        if (FileSystem is null)
            throw new ArgumentException("You need to connect to FS first");
        FileSystem.FileMove(sourcePath, destinationPath);
    }

    public override bool CanHandle(string request)
    {
        return request == "move";
    }
}