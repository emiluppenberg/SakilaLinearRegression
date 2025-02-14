using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakilaLinearRegression.Models
{
    internal class PaymentJson
    {
        public int payment_id { get; set; }
        public decimal amount { get; set; }
        public int customer_id { get; set; }
    }
}
