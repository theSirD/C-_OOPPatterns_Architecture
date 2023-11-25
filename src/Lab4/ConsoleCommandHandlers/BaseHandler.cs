using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers;

public abstract class BaseHandler : IHandler
{
    public static IParse? Parser { get; set; }

    public IHandler? NextHandler { get; protected set; }
    protected static IFileSystem? FileSystem { get; set; }

    public abstract void Handle(string request, string path);

    public abstract bool CanHandle(string request);
}