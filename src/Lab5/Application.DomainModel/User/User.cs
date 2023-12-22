namespace Application.DomainModel.User;

public class User
{
    public User(long id, string name, UserRole role)
    {
        Id = id;
        Username = name;
        Role = role;
    }

    public long Id { get; set; }
    public string Username { get; set; }
    public UserRole Role { get; set; }
}