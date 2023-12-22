using Application.Abstractions.Repositories;
using Application.DomainModel.User;

namespace Infrustructure.Database;

public class UserRepo : IUserRepo
{
    public void Add(User user)
    {
        throw new NotImplementedException();
    }

    public User? GetById(string id)
    {
        throw new NotImplementedException();
    }

    public User? GetByName(string user)
    {
        throw new NotImplementedException();
    }

    public void Remove(string id)
    {
        throw new NotImplementedException();
    }

    public void Update(User user)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetAll()
    {
        throw new NotImplementedException();
    }
}