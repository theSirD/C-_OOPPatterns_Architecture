using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers;

public abstract class BaseHandler : IHandler
{
    protected BaseHandler(Context context)
    {
        if (context is null)
            throw new ArgumentException("Context is null");
        Context = context;
    }

    public Context? Context { get; private set; }

    public IHandler? NextHandler { get; protected set; }
    public abstract void Handle();
    public abstract bool CanHandle();
}