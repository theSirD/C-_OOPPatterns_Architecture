using System;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.ConnectHandler;

public class ConnectHandler : BaseHandler
{
    private readonly IHandler _chainOfFlagHandlers = new ConnectionModeFlagHandler();

    public ConnectHandler(IParse parser)
    {
        if (parser is null)
            throw new ArgumentException("Given parser is null");
        Parser = parser;
        NextHandler = new DisconnectHandler();
    }

    public override void Handle(string request, string path)
    {
        if (Parser is null)
        {
            throw new ArgumentException("You need to pass a parser first");
        }

        if (!CanHandle(request))
        {
            if (NextHandler is null)
                throw new ArgumentException("Can not do the command");
            else
                NextHandler.Handle(request, string.Empty);
        }

        Parser.MoveForward();
        string address = Parser.Current;
        if (address.Length == 0)
            throw new ArgumentException("Address is not specified");
        address = address.Substring(0, address.Length - 1);

        Parser.MoveForward();
        string flag = Parser.Current;
        if (flag.Length == 0)
            throw new ArgumentException("Flag is not specified");
        _chainOfFlagHandlers.Handle(flag, address);
    }

    public override bool CanHandle(string request)
    {
        return request == "connect";
    }
}