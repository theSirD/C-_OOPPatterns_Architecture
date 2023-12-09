using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class InfoAboutExecutedCommand
{
    public InfoAboutExecutedCommand()
    {
        Command = string.Empty;
        Subcommand = string.Empty;
        Path1 = string.Empty;
        Path2 = string.Empty;
        Flag = string.Empty;
        FlagArguments = new Dictionary<string, string>();
        VisitedFlagHandlersList = new Dictionary<string, bool>();
    }

    public string Command { get; set; }
    public string Subcommand { get; set; }
    public string Path1 { get; set; }
    public string Path2 { get; set; }
    public string Flag { get; set; }
    public Dictionary<string, string> FlagArguments { get; private set; }
    public Dictionary<string, bool> VisitedFlagHandlersList { get; private set; }

    public void ClearInfo()
    {
        Command = string.Empty;
        Subcommand = string.Empty;
        Path1 = string.Empty;
        Path2 = string.Empty;
        Flag = string.Empty;
        FlagArguments = new Dictionary<string, string>();
        VisitedFlagHandlersList = new Dictionary<string, bool>();
    }
}