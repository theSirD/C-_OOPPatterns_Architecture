using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.FileHandlers;

public class FileCopyHandler : BaseHandler
{
    public FileCopyHandler()
    {
        NextHandler = new FileDeleteHandler();
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
            throw new ArgumentException("You need to specify source path for 'file copy'");
        if (destinationPath.Length == 0)
            throw new ArgumentException("You need to specify destination path for 'file copy'");
        if (FileSystem is null)
            throw new ArgumentException("You need to connect to FS first");
        FileSystem.FileCopy(sourcePath, destinationPath);
    }

    public override bool CanHandle(string request)
    {
        return request == "copy";
    }
}