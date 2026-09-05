using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserSystem.Domain.Interface;
using UserSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using UserSystem.Infrastructure.Data;
using System.Runtime.CompilerServices;



namespace UserSystem.Infrastructure.Repository
{
  public class UserRepository : IUserRepository
  {
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

    public async Task<User> CreateUserAsync(User user)
    {
      _context.Users.Add(user);
      await _context.SaveChangesAsync();
      return user;
    }

    public async Task<bool> DeleteUserAsync(int UserId)
    {
      var user = await _context.Users.FindAsync(UserId);
      if(user == null) return false;

      _context.Users.Remove(user);
      await _context.SaveChangesAsync();
      return true;
    }

    public async Task<IEnumerable<User>> GetAllUserAsync()
    {
      return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(int userId)
    {
      return await _context.Users.FindAsync(userId);
    }

    public async Task<User> UpdateUserAsync(User user)
    {
      var existing = await _context.Users.FindAsync(user.UserId);
      if(existing == null) return null;

      _context.Entry(existing).CurrentValues.SetValues(user);
      await _context.SaveChangesAsync();
      return existing;
    }
  }
}