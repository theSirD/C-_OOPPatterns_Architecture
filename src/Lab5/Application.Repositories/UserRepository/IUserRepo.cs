using Application.Domain;

namespace Application.Repositories.UserRepository;

public interface IUserRepo
{
    public void Add(User user);
    public User GetById(string id);
    public User GetByName(string user);
    public void Remove(string id);
    public void Update(User user);
}