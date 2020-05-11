using Chinook_API.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Chinook_API.Data
{
    public class EmployeeRepository
    {
        const string ConnectionString = "Server=localhost\\SQLEXPRESS;Database=Chinook;Trusted_Connection=True";

        public IEnumerable<Employee> GetSalesAgents()
        {
            var query = @"SELECT *
                        FROM Employee
                        WHERE Title like '%Agent'";

            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Query<Employee>(query);
            }
        }
    }
}
