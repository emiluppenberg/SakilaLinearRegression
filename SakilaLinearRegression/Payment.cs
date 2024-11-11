using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakilaLinearRegression
{
    internal class Payment
    {
        [Key]
        public int payment_id { get; set; }
        public int customer_id { get; set; }
        public byte staff_id { get; set; }
        public int? rental_id { get; set; }
        public decimal amount { get; set; }
        public DateTime payment_date { get; set; }
        public DateTime last_update { get; set; }
    }
}
