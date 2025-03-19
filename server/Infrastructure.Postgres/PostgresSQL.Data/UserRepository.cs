using Application.Interfaces.Infrastructure.Postgres;
using Core.Domain.Entities;
using Infrastructure.Postgres.Scaffolding;

namespace Infrastructure.PostGres.PostgresSQL.Data;

public class UserRepository(AppDbContext ctx) : IUserRepository
{
    public List<User> GetAll()
    {
        return ctx.Users.ToList();
    }

    public User? GetUserByIdOrNull(string email)
    {
        return ctx.Users.FirstOrDefault(u => u.Email == email);
    }

    public User AddUser(User user)
    {
        ctx.Users.Add(user);
        ctx.SaveChanges();
        return user;
    }

    public bool UpdateUser(string id, User user)
    {
        ctx.Users.Update(user);
        return ctx.SaveChanges() > 0;
    }

    public bool DeleteUser(User user)
    {
        ctx.Users.Remove(user);
        return ctx.SaveChanges() > 0;
    }
}
