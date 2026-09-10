using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MunPath.Domain.Abstraction;
using MunPath.Domain.Entities;
using Microsoft.AspNetCore.Identity;


namespace MunPath.Infrastructure.Repositories
{
  public class StudentRepository : IStudentRepository
  {
    private readonly ApplicationDbContext _context;
    private readonly IPasswordHasher<Student> _passwordHasher;

    public StudentRepository(ApplicationDbContext context, IPasswordHasher<Student> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

    public async Task<Student> CreateStudent(Student student)
    {
      student.Password = _passwordHasher.HashPassword(student, student.Password);
      _context.Students.Add(student);
      await _context.SaveChangesAsync();
      return student;
      
    }

    public async Task<Student?> GetStudentByIdAsync(int? id)
    {
      return await _context.Students.FirstOrDefaultAsync(s => s.Id == id); 
    }


    public async Task<Student> UpdateStudent(Student student)
    {
      _context.Students.Update(student);
      await _context.SaveChangesAsync();
      return student;    
    }

    public async Task<Student> DeleteStudent(Student student)
    {
      _context.Students.Remove(student);
      await _context.SaveChangesAsync();
      return student;
    }


  }
}