using MunPath.Application.Abstraction;
using MunPath.Application.DTOs;
using MunPath.Domain.Abstraction;
using MunPath.Domain.Entities;

namespace MunPath.Application.Service
{
  public class StudentService : IStudentService
  {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

    public async Task<CreateResponseStudentDto> CreateStudentAsync(CreateRequestStudentDto studentDto)
    {

            try
            {
                if(string.IsNullOrWhiteSpace(studentDto.FirstName))
                {
                    throw new Exception("First name cannot be empty");
                }

                if(string.IsNullOrWhiteSpace(studentDto.LastName))
                {
                    throw new Exception("Last name cannot be empty");
                }

                if(string.IsNullOrWhiteSpace(studentDto.UserName))
                {
                    throw new Exception("Username cannot be empty");
                }

                if(string.IsNullOrWhiteSpace(studentDto.Password))
                {
                    throw new Exception("Password cannot be empty");
                }
                
                if(string.IsNullOrWhiteSpace(studentDto.Email))
                {
                    throw new Exception("Email cannot be empty");
                }
                
                if(!studentDto.Email.Contains("@"))
                {
                    throw new Exception("Email should contain @");
                }

            var student = new Student
            {
                FirstName = studentDto.FirstName, 
                LastName = studentDto.LastName, 
                UserName = studentDto.UserName, 
                Password = studentDto.Password, 
                Email = studentDto.Email
            };

            await _studentRepository.CreateStudent(student);
            

            return new CreateResponseStudentDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                UserName = student.UserName,
                Email = student.Email
            };
            
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
    }

    public async Task<CreateResponseStudentDto?> GetStudentByIdAsync(int id)
    {
            try
            {
                var student = await _studentRepository.GetStudentByIdAsync(id);

                if(student == null)
                {
                    throw new Exception("student with this ID does not exist");
                }

                return new CreateResponseStudentDto
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    UserName = student.UserName,
                    Email = student.Email     
                };
            }
            catch
            {
                throw;
            }
    }
  }
}