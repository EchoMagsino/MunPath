using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MunPath.Application.DTOs
{
    public class CreateRequestStudentDto
    {
        [Required]
        public string FirstName {get; set;} = string.Empty;

        [Required]
        public string LastName {get; set;} = string.Empty;
        [Required]
        public string UserName {get; set;} = string.Empty;
        [Required]
        [MinLength(6)]
        public string Password {get; set;} = string.Empty;
        [Required]
        [EmailAddress]
        public string Email {get; set;} = string.Empty;
        
        

    }

    public class CreateResponseStudentDto
    {
        public int Id {get; set;}
        public string FirstName {get; set;} = string.Empty;
        public string LastName {get; set;} = string.Empty;
        public string Email {get; set;} = string.Empty;
        public string UserName {get; set;} = string.Empty;
    }
}