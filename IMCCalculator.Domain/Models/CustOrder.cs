using System;
using System.Collections.Generic;
using System.Text;

namespace IMCTaxCalculator.Domain.Models
{
    public class CustOrder
    {

        public string to_street { get; set; }
        public float amount { get; set; }
        public string from_country { get; set; }
        public string from_zip { get; set; }
        public string from_state { get; set; }
        public string from_city { get; set; }
        public string from_street { get; set; }
        public string to_country { get; set; }
        public string to_state { get; set; }
        public string to_city { get; set; }
        public string to_zip { get; set; }
        public float shipping { get; set; }
        public float amount_to_collect { get; set; }
        public string[] line_items { get; set; }
    }
}
