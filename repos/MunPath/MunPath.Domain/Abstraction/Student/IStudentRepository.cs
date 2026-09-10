using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MunPath.Domain.Entities;

namespace MunPath.Domain.Abstraction
{
    public interface IStudentRepository
    {
        public Task<Student> CreateStudent(Student student);

        public Task<Student?> GetStudentByIdAsync(int? id);

        public Task<Student> UpdateStudent(Student student);

        public Task<Student> DeleteStudent(Student student);

    }
}