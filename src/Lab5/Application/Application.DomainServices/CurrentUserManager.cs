using Application.Contracts.Users;
using Application.DomainModel.User;

namespace Application.DomainServices;

public class CurrentUserManager : ICurrentUserService
{
    public User? User { get; set; }
}