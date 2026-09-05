using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserSystem.Domain.Entities
{
    public class User
    {
        public int UserId {get; private set;}
        public string FirstName {get; private set;}
        public string LastName {get; private set;}
        public bool IsDelete {get; set;}

    }
}