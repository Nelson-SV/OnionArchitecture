using Application.Interfaces;
using Core.Domain.Entities;
using Infrastructure.Postgres.Scaffolding;

namespace Infrastructure.PostGres.PostgresSQL.Data;

public class UserRepository(AppDbContext ctx) : IUserRepository
{
    public List<User> GetAll()
    {
        return ctx.Users.ToList();
    }

    public User? GetUserByIdOrNull(int id)
    {
        return ctx.Users.FirstOrDefault(u => u.Id == id);
    }

    public User AddUser(User user)
    {
        ctx.Users.Add(user);
        ctx.SaveChanges();
        return user;
    }

    public bool UpdateUser(int id, User user)
    {
        ctx.Users.Update(user);
        return ctx.SaveChanges() > 0;
    }

    public bool DeleteUser(int id)
    {
        User? user = GetUserByIdOrNull(id);
        if (user == null)
        {
            return false;
        } 
        ctx.Users.Remove(user);
        ctx.SaveChanges();
        return true;
    }
}
