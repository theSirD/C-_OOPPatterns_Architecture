using Application.DomainModel.User;

namespace Application.Abstractions.Repositories;

public interface IUserRepo
{
    public void Add(User user);
    public User? GetById(string id);
    public User? GetByName(string userName);
    public void Remove(string id);
    public void Update(User user);
    public IEnumerable<User> GetAll();
}