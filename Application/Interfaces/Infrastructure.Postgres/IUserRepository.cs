using Core.Domain.Entities;

namespace Application.Interfaces.Infrastructure.Postgres;

public interface IUserRepository
{
    List<User> GetAll();
    User? GetUserByIdOrNull(string email);
    User AddUser(User user);
    bool UpdateUser(string id, User user);
    bool DeleteUser(User user);
}