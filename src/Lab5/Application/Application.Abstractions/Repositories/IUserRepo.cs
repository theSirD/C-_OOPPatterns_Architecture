using Application.DomainModel.User;

namespace Application.Abstractions.Repositories;

public interface IUserRepo
{
    public User? GetByName(string userName);
}