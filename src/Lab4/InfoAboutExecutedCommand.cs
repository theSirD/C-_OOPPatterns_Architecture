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
        FlagArgument = string.Empty;
    }

    public string Command { get; set; }
    public string Subcommand { get; set; }
    public string? Path1 { get; set; }
    public string Path2 { get; set; }
    public string Flag { get; set; }
    public string FlagArgument { get; set; }
}