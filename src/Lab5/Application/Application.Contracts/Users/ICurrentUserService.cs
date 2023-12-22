using Application.DomainModel.User;

namespace Application.Contracts.Users;

public interface ICurrentUserService
{
    User? User { get; }
}