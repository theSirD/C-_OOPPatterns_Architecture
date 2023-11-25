using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.ConnectHandler;

public class ConnectHandler : BaseHandler
{
    private IHandler _chainOfFlagHandlers;

    public ConnectHandler(Context context)
        : base(context)
    {
        _chainOfFlagHandlers = new ConnectionModeFlagHandler(context);
        NextHandler = new DisconnectHandler(context);
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

        Context.Parser.MoveForward();
        string address = Context.Parser.Current;
        if (address.Length == 0)
            throw new ArgumentException("Address is not specified");
        address = address.Substring(1, address.Length - 2);
        Context.Info.Path1 = address;

        Context.Parser.MoveForward();
        string flag = Context.Parser.Current;
        Context.Info.Flag = flag;
        if (flag.Length == 0)
            throw new ArgumentException("Flag is not specified");
        _chainOfFlagHandlers.Handle(flag, address);
    }

    public override bool CanHandle(string request)
    {
        return request == "connect";
    }
}