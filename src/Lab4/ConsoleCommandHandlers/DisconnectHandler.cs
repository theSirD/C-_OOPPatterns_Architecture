using System;
using Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.TreeHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers;

public class DisconnectHandler : BaseHandler
{
    public DisconnectHandler(Context context)
    : base(context)
    {
        NextHandler = new TreeHandler(context);
    }

    public override void Handle(string request, string path)
    {
        if (Context is null || Context.Info is null || Context.Parser is null)
        {
            throw new ArgumentException("Context object is not initialized properly");
        }

        if (!CanHandle(request))
        {
            if (NextHandler is null)
                throw new ArgumentException("Can not do the command");
            NextHandler.Handle(request, string.Empty);
            return;
        }

        if (Context.FileSystem is null)
            throw new ArgumentException("You are not connected to FS yet");
        Context.FileSystem.Disconnect();
    }

    public override bool CanHandle(string request)
    {
        return request == "disconnect";
    }
}