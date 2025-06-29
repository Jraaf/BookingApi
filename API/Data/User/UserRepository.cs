using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.User;

public class UserRepository : IUserRepository
{
    private readonly RoomsContext _context;

    public UserRepository(RoomsContext context)
    {
        _context = context;
    }
    public async Task<bool> Create(User user)
    {
        _context.Users.Add(user);
        return (await _context.SaveChangesAsync()) > 0;
    }

    public async Task<bool> Exists(string Username)
    {
        return await _context.Users.AnyAsync(u => u.Username == Username);
    }

    public async Task<User?> GetByName(string username)
    {
        return await _context.Users
            .Where(u => u.Username == username)
            .FirstOrDefaultAsync();
    }
}
