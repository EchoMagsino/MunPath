using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using MunPath.Application.Abstraction;
using MunPath.Application.DTOs;
using MunPath.Domain.Entities;
using System.IO;
using Microsoft.AspNetCore.Mvc.Routing;

namespace MunPath.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
     
    [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateRequestStudentDto dto)
        {
        
            var created = await _studentService.CreateStudentAsync(dto);
            return Ok(created);
        }

    [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);

            if(student == null)
            {
                return NotFound($"Student with ID {id} not found");
            }

            return Ok(student);
            
        }
}


    }