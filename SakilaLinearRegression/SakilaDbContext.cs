using Microsoft.EntityFrameworkCore;
using SakilaLinearRegression.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SakilaLinearRegression
{
    class SakilaDbContext : DbContext
    {
        //private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sakila;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        private readonly string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\");

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(connectionString);
        //}

        public List<decimal> DataPerCost(int customerId)
        {
            //return Database
            //    .SqlQueryRaw<decimal>("select amount from payment where customer_id = @p0", customerId)
            //    .ToList();

            var json = System.IO.File.ReadAllLines(path + "payments.json");
            var payments = json
                .Select(x => JsonSerializer.Deserialize<PaymentJson>(x)).ToList();

            var data = (from p in payments
                        where p.customer_id == customerId
                        select p.amount).ToList();

            return data;
        }

        internal List<string> DataPerFilmRating(int customerId)
        {
            //return Database
            //    .SqlQueryRaw<string>(
            //    "select f.rating " +
            //    "from film f " +
            //    "inner join inventory i on i.film_id = f.film_id " +
            //    "inner join rental r on r.inventory_id = i.inventory_id " +
            //    "where r.customer_id = @p0", customerId)
            //    .ToList();

            var json = System.IO.File.ReadAllLines(path + "films.json");
            var films = json
                .Select(x => JsonSerializer.Deserialize<FilmJson>(x)).ToList();

            json = System.IO.File.ReadAllLines(path + "inventorys.json");
            var inventorys = json
                .Select(x => JsonSerializer.Deserialize<InventoryJson>(x)).ToList();

            json = System.IO.File.ReadAllLines(path + "rentals.json");
            var rentals = json
                .Select(x => JsonSerializer.Deserialize<RentalJson>(x)).ToList();

            return (from f in films
                       join i in inventorys on f.film_id equals i.film_id
                       join r in rentals on i.inventory_id equals r.inventory_id
                       where r.customer_id == customerId
                       select f.rating).ToList();
        }
    }
}
