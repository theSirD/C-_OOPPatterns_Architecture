namespace Presentation.Console;

public interface IScenario
{
    public string Name { get; }

    void Run();
}