using Application.Abstractions.Repositories;
using Application.DomainModel;

namespace Infrustructure.Database;

public class AccountRepo : IAccountRepo
{
    public void Add(Account account)
    {
        throw new NotImplementedException();
    }

    public Account? GetById(string id)
    {
        throw new NotImplementedException();
    }

    public void Remove(string id)
    {
        throw new NotImplementedException();
    }

    public void Update(Account account)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Account> GetAll()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Account> GetAllByUserId()
    {
        throw new NotImplementedException();
    }
}