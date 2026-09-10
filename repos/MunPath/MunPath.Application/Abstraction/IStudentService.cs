using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MunPath.Application.DTOs;

namespace MunPath.Application.Abstraction
{
    public interface IStudentService
    {
        public Task<CreateResponseStudentDto> CreateStudentAsync(CreateRequestStudentDto studentDto);

        public Task<CreateResponseStudentDto?> GetStudentByIdAsync(int id);
    }
}