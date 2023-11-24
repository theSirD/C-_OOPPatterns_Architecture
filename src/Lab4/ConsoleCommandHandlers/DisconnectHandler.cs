using System;
using Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.TreeHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers;

public class DisconnectHandler : BaseHandler
{
    public DisconnectHandler()
    {
        NextHandler = new TreeHandler();
    }

    public override void Handle(string request, string path)
    {
        if (!CanHandle(request))
        {
            if (NextHandler is null)
                throw new ArgumentException("Can not do the command");
            else
                NextHandler.Handle(request, string.Empty);
        }

        if (FileSystem is null)
            throw new ArgumentException("You are not connected to FS yet");
        FileSystem.Disconnect();
    }

    public override bool CanHandle(string request)
    {
        return request == "disconnect";
    }
}