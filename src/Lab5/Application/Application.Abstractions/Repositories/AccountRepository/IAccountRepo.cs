using Application.DomainModel;

namespace Application.Abstractions.Repositories.AccountRepository;

public interface IAccountRepo
{
    public void Add(Account account);
    public Account GetById(string id);
    public void Remove(string id);
    public void Update(Account account);
}