using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MunPath.Domain.Entities
{
    public class Student
    {
        public int Id {get; set;}
        public string FirstName {get; set;} = string.Empty;
        public string LastName {get; set;} = string.Empty;
        public string UserName {get; set;} = string.Empty;
        public string Password {get; set;} = string.Empty;
        public string Email {get; set;} = string.Empty;
        
    }
}