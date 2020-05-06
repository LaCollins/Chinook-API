using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chinook_API.Model
{
    public class Customer
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public int CustomerId { get; internal set; }
        public string Country { get; internal set; }
    }
}
