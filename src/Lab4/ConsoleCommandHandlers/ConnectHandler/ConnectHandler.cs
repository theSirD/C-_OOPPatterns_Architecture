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
        if (CanHandle(request))
        {
            string? address = Parser?.SearchForPath();
            if (address is not null)
            {
                string? flag = Parser?.SearchForFlag();
                if (flag is not null)
                {
                    _chainOfFlagHandlers.Handle(flag, address);
                }
                else
                {
                    throw new ArgumentException("Flag is not specified");
                }
            }
            else
            {
                throw new ArgumentException("Address is not specified");
            }
        }
        else
        {
            if (NextHandler is null)
                Console.WriteLine("Can not do the command");
            else
                NextHandler.Handle(request, string.Empty);
        }
    }

    public override bool CanHandle(string request)
    {
        return request == "connect";
    }
}