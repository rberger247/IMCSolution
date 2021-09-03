using System;
using System.Collections.Generic;
using System.Text;

namespace IMCTaxCalculator.Domain.Models
{
    public class Items
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string ProductTaxCode { get; set; }
        public double unit_price { get; set; }
        public string product_tax_code { get; set; }

    }
}
