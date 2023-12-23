namespace Application.DomainModel.User;

public class User
{
    public User(long id, string name, UserRole role, string password)
    {
        Id = id;
        Username = name;
        Role = role;
        Password = password;
    }

    public long Id { get; set; }
    public string Username { get; set; }
    public UserRole Role { get; set; }
    public string Password { get; set; }
}