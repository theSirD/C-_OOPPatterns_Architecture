using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.ConnectHandler;

public class ConnectionModeFlagHandler : BaseHandler
{
    public ConnectionModeFlagHandler(Context context)
        : base(context)
    {
    }

    public override void Handle(string request, string path)
    {
        if (Context is null || Context.Info is null || Context.Parser is null || Context.FileSystem is null)
        {
            throw new ArgumentException("Context object is not properly initialized");
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

        Context.Parser.MoveForward();
        string flagArgument = Context.Parser.Current;
        Context.Info.FlagArgument = flagArgument;
        if (flagArgument.Length == 0)
            throw new ArgumentException("Connection mode after flag is not specified");
        if (flagArgument == "local")
        {
            if (Context.FileSystem.IsConnected)
                throw new ArgumentException("You are already connected to a local file system");
            Context.FileSystem = new LocalFileSystem(path);
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