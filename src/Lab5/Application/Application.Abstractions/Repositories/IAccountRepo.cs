using Application.DomainModel;

namespace Application.Abstractions.Repositories;

public interface IAccountRepo
{
    public void Add(Account account);
    public Account? GetById(string id);
    public void Remove(string id);
    public void Update(Account account);
    public IEnumerable<Account> GetAll();
    public IEnumerable<Account> GetAllByUserId();
}