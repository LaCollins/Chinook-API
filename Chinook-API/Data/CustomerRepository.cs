using Chinook_API.Model;
using Dapper;
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

        //Provide a query showing the Invoices of customers who are from Brazil.The resultant table should show the customer's full name, Invoice ID, Date of the invoice and billing country.

        public IEnumerable<InvoiceByCountry> GetInvoiceByCountry(string country)
        {
            var query = @"
                        SELECT Customer.FirstName + ' ' + Customer.LastName AS CustomerName, Invoice.InvoiceId, Invoice.InvoiceDate, Invoice.BillingCountry
                        FROM Customer
	                        JOIN Invoice
		                        on Customer.CustomerId = Invoice.CustomerId
                        WHERE Country = @Country";

            using (var db = new SqlConnection(ConnectionString))
            {
                var parameters = new { Country = country };

                var invoice = db.Query<InvoiceByCountry>(query, parameters);

                return invoice;
            }
        }

        public IEnumerable<UniqueBillingCountry> GetUniqueCountries()
        {
            var query = "SELECT DISTINCT BillingCountry FROM Invoice";

            using (var db = new SqlConnection(ConnectionString))
            {
                var countries = db.Query<UniqueBillingCountry>(query);

                return countries;
            }
        }
    }
}
