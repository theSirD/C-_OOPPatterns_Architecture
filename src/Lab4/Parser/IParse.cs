namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public interface IParse
{
    public string SearchForCommand();
    public string SearchForPath();
    public string SearchForFlag();
    public string SearchForFlagArgument();
}