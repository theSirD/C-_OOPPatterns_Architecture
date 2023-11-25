using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.ConnectHandler;

public class ConnectionModeFlagHandler : BaseHandler
{
    public override void Handle(string request, string path)
    {
        if (Parser is null)
        {
            throw new ArgumentException("You need to pass a parser first");
        }

        if (path is null)
            throw new ArgumentException("You need to specify path first");

        if (!CanHandle(request))
        {
            if (NextHandler is not null)
            {
                NextHandler.Handle(request, path);
                return;
            }
            else
            {
                throw new ArgumentException("Unknown connection mode flag");
            }
        }

        Parser.MoveForward();
        string flagArgument = Parser.Current;
        if (flagArgument.Length == 0)
            throw new ArgumentException("Connection mode after flag is not specified");
        if (flagArgument == "local")
        {
            if (FileSystem is not null)
                throw new ArgumentException("You are already connected to a local file system");
            FileSystem = new LocalFileSystem(path);
            Console.WriteLine("Successfully connected");
        }
        else
        {
            throw new ArgumentException($"This type of connection is not supported {flagArgument}");
        }
    }

    public override bool CanHandle(string request)
    {
        return request == "-m";
    }
}