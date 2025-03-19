using Core.Domain.Entities;

namespace Application.Interfaces;

public interface IUserRepository
{
    List<User> GetAll();
    User? GetUserByIdOrNull(int id);
    User AddUser(User user);
    bool UpdateUser(int id, User user);
    bool DeleteUser(int id);
}