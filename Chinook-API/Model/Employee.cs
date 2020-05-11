using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chinook_API.Model
{
    public class Employee
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string Title { get; internal set; }
    }
}
