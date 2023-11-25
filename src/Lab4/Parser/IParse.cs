namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public interface IParse
{
    public string Current { get; set; }
    public void SetInput(string input);
    public void MoveForward();
}