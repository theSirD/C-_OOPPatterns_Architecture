using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Context
{
    public Context(InfoAboutExecutedCommand info, IParse parser, IFileSystem system)
    {
        if (parser is null)
            throw new ArgumentException("Parser is null");
        if (info is null)
            throw new ArgumentException("info is null");
        if (system is null)
            throw new ArgumentException("system is null");
        Parser = parser;
        Info = info;
        FileSystem = system;
    }

    public IParse? Parser { get; set; }

    public IFileSystem? FileSystem { get; set; }

    public InfoAboutExecutedCommand? Info { get; set; }
}