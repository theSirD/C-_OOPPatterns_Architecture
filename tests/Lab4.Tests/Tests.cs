using Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.ConnectHandler;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Tests
{
    [Fact]

    public void TestConnect()
    {
        var info = new InfoAboutExecutedCommand();
        IFileSystem localFileSystem = new LocalFileSystem();
        IParse parser = new ConsoleCommandParser();
        var context = new Context(info, parser, localFileSystem);
        IHandler chainOfHandlers = new ConnectHandler(context);

        string input = @"connect ""/Users/danielisaev/Desktop/U/Университет/2 курс/ООП/test"" -m local";
        parser.SetInput(input);
        parser.MoveForward();
        string command = parser.Current;
        info.Command = command;
        chainOfHandlers.Handle(command, string.Empty);

        Assert.True(info.Command == "connect" &&
                    info.Path1 == "/Users/danielisaev/Desktop/U/Университет/2 курс/ООП/test" &&
                    info.Flag == "-m" &&
                    info.FlagArgument == "local");
    }

    [Fact]

    public void TestTreeList()
    {
        var info = new InfoAboutExecutedCommand();
        IFileSystem localFileSystem = new LocalFileSystem();
        IParse parser = new ConsoleCommandParser();
        var context = new Context(info, parser, localFileSystem);
        IHandler chainOfHandlers = new ConnectHandler(context);

        string input = @"connect ""/Users/danielisaev/Desktop/U/Университет/2 курс/ООП/test"" -m local";
        parser.SetInput(input);
        parser.MoveForward();
        string command = parser.Current;
        chainOfHandlers.Handle(command, string.Empty);

        input = @"tree list ""/Users/danielisaev/Desktop/U/Университет/2 курс/ООП/test"" -d 2";
        if (string.IsNullOrEmpty(input)) return;
        parser.SetInput(input);
        parser.MoveForward();
        command = parser.Current;
        info.Command = command;
        chainOfHandlers.Handle(command, string.Empty);

        Assert.True(info.Command == "tree" &&
                    info.Subcommand == "list" &&
                    info.Path1 == "/Users/danielisaev/Desktop/U/Университет/2 курс/ООП/test" &&
                    info.Flag == "-d" &&
                    info.FlagArgument == "2");
    }

    [Fact]

    public void TestTreeGoTo()
    {
        var info = new InfoAboutExecutedCommand();
        IFileSystem localFileSystem = new LocalFileSystem();
        IParse parser = new ConsoleCommandParser();
        var context = new Context(info, parser, localFileSystem);
        IHandler chainOfHandlers = new ConnectHandler(context);

        string input = @"connect ""/Users/danielisaev/Desktop/U/Университет/2 курс/ООП/test"" -m local";
        parser.SetInput(input);
        parser.MoveForward();
        string command = parser.Current;
        chainOfHandlers.Handle(command, string.Empty);

        input = @"tree goto ""innerTest1""";
        parser.SetInput(input);
        parser.MoveForward();
        command = parser.Current;
        info.Command = command;
        chainOfHandlers.Handle(command, string.Empty);

        Assert.True(info.Command == "tree" &&
                    info.Subcommand == "goto" &&
                    info.Path1 == "innerTest1");
    }

    [Fact]

    public void FileShow()
    {
        var info = new InfoAboutExecutedCommand();
        IFileSystem localFileSystem = new LocalFileSystem();
        IParse parser = new ConsoleCommandParser();
        var context = new Context(info, parser, localFileSystem);
        IHandler chainOfHandlers = new ConnectHandler(context);

        string input = @"connect ""/Users/danielisaev/Desktop/U/Университет/2 курс/ООП/test"" -m local";
        parser.SetInput(input);
        parser.MoveForward();
        string command = parser.Current;
        chainOfHandlers.Handle(command, string.Empty);

        input = @"file show ""/Users/danielisaev/Desktop/U/Университет/2 курс/ООП/test/file1.txt"" -m console";
        parser.SetInput(input);
        parser.MoveForward();
        command = parser.Current;
        info.Command = command;
        chainOfHandlers.Handle(command, string.Empty);

        Assert.True(info.Command == "file" &&
                    info.Subcommand == "show" &&
                    info.Path1 == "/Users/danielisaev/Desktop/U/Университет/2 курс/ООП/test/file1.txt" &&
                    info.Flag == "-m" &&
                    info.FlagArgument == "console");
    }
}