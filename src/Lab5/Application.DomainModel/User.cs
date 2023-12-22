namespace Application.Domain;

public class User
{
    private int _id;
    private string _name;

    public User(string name, int id)
    {
        _name = name;
        _id = id;
    }
}