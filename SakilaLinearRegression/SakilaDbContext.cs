using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakilaLinearRegression
{
    class SakilaDbContext : DbContext
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sakila;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public List<decimal> DataPerCost(int customerId)
        {
            return Database
                .SqlQueryRaw<decimal>("select amount from payment where customer_id = @p0", customerId)
                .ToList();
        }

        internal List<string> DataPerFilmRating(int customerId)
        {
            return Database
                .SqlQueryRaw<string>(
                "select f.rating " +
                "from film f " +
                "inner join inventory i on i.film_id = f.film_id " +
                "inner join rental r on r.inventory_id = i.inventory_id " +
                "where r.customer_id = @p0", customerId)
                .ToList();
        }
    }
}
