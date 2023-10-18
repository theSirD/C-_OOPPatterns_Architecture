namespace Itmo.ObjectOrientedProgramming.Lab2;

public interface IComputerComponent<T>
{
    public T? Clone();
}