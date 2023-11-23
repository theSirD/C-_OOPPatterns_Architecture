using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.ConnectHandler;

public class ConnectionModeFlagHandler : BaseHandler
{
    public override void Handle(string request, string path)
    {
        if (CanHandle(request))
        {
            string? flagArgument = Parser?.SearchForFlagArgument();
            if (flagArgument is null)
                throw new ArgumentException("Connection mode after flag is not specified");
            if (flagArgument == "local")
            {
                if (FileSystem is null)
                    FileSystem = new LocalFileSystem(path);
                throw new ArgumentException("You are already connected to a local file system");
            }
        }
        else
        {
            if (NextHandler is not null)
                NextHandler.Handle(request, path);
            else
                throw new ArgumentException("Unknown connection mode flag");
        }
    }

    public override bool CanHandle(string request)
    {
        return request == "-m";
    }
}