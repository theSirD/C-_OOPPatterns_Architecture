namespace Itmo.ObjectOrientedProgramming.Lab2;

public abstract class ComputerComponent
{
    protected ComputerComponent(string name) => Name = name;

    public string? Name { get; init; }

    public ComputerComponent? Clone()
    {
        return MemberwiseClone() as ComputerComponent;
    }
}