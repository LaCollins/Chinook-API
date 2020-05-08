using Chinook_API.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Chinook_API.Data
{
    public class CustomerRepository
    {
        const string ConnectionString = "Server=localhost\\SQLEXPRESS;Database=Chinook;Trusted_Connection=True";

        public List<Customer> GetByCountry(string country)
        {
            var sql = @"
                SELECT
                    FirstName,
                    LastName,
                    CustomerId,
                    Country
                FROM Customer
                WHERE Customer.Country = @Country";

            using (var db = new SqlConnection(ConnectionString))
            {
                db.Open();

                var cmd = db.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("Country", country);

                var reader = cmd.ExecuteReader();
                var customers = new List<Customer>();
                while (reader.Read())
                {
                    var customer = new Customer
                    {
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        CustomerId = (int)reader["CustomerId"],
                        Country = (string)reader["Country"]
                    };

                    customers.Add(customer);
                }

                return customers;
            }

        }

        //Provide a query showing Customers(just their full names, customer ID and country) who are not in the US.
        public List<Customer> GetByAllCountriesExcept(string country)
        {
            var sql = @"
                            SELECT CustomerId, FirstName, LastName, Country
                            FROM Customer
                            WHERE NOT Customer.Country = @Country";

            using (var db = new SqlConnection(ConnectionString))
            {
                db.Open();

                var cmd = db.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("Country", country);

                var reader = cmd.ExecuteReader();
                var customers = new List<Customer>();
                while (reader.Read())
                {
                    var customer = new Customer
                    {
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        CustomerId = (int)reader["CustomerId"],
                        Country = (string)reader["Country"]
                    };

                    customers.Add(customer);
                }

                return customers;
            }
        }
    }
}
