using IMCTaxCalculator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMCTaxCalculator.Application.Services
{
    public  class TaxService
    {
        private static float taxAmount;
        private TaxJarCalculater taxJarCalculater = new TaxJarCalculater();
        public  async Task<float> GetTaxRate(string customer ,string zip)
        {
            switch (customer)
            {
                case "taxJarCust":
                    taxAmount = await taxJarCalculater.GetTaxRate(zip);
                    break;
                default:
                    Console.WriteLine("not TaxJar");
                    break;
            }      
            return  taxAmount;
        }
        public  async Task<float> GetTaxForOrder(string customer , CustOrder custOrder)
        {
            switch (customer)
            {
                case "taxJarCust":
                       taxAmount = await taxJarCalculater.GetOrderTax(custOrder);
                    break;
                default:
                   taxAmount = 0;             
                    break;
            }
            
            return taxAmount;
        }
    }
}
