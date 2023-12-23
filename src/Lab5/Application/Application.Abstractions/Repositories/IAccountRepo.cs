using Application.DomainModel;

namespace Application.Abstractions.Repositories;

public interface IAccountRepo
{
    public void Add(long userId);
    public void Update(Account account);
    public IEnumerable<Account> GetAllAccountsByUserId(long userId);
}