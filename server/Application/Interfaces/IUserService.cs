using Application.Models.Dtos.User;
using Core.Domain.Entities;

namespace Application.Interfaces;

public interface IUserService
{
    List<User> GetAll();
    User? GetUserById(string email);
    UpdateUserResponseDto UpdateUser(UpdateUserDto user);
    bool DeleteUser(string userId);
}