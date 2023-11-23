using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.TreeHandlers.TreeListHandler;

public class TreeListHandler : BaseHandler
{
    private readonly IHandler _chainOfFlagHandlers = new SelectionDepthFlagHandler();

    public override void Handle(string request, string path)
    {
        if (!CanHandle(request))
        {
            if (NextHandler is null)
                throw new ArgumentException("Can not do the command");
            NextHandler.Handle(request, string.Empty);
        }

        string? flag = Parser?.SearchForFlag();
        if (flag is not null)
        {
            if (flag.Length == 0)
                throw new ArgumentException("Flag is not specified");
            _chainOfFlagHandlers.Handle(flag, string.Empty);
        }
    }

    public override bool CanHandle(string request)
    {
        return request == "list";
    }
}