using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserSystem.Domain.ValueObjects
{
    public class Name
    {
        public string FirstName {get;}
        public string LastName {get;}

        public Name(string fname, string lname)
        {
            if(string.IsNullOrWhiteSpace(fname))
            {
                throw new ArgumentException("First name cannot be empty");
            }
            
            if(string.IsNullOrWhiteSpace(lname))
            {
                throw new ArgumentException("Last name cannot be empty");
            }

            FirstName = fname;
            LastName = lname;
        }
    }
}