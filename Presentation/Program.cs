using IMCTaxCalculater.Application.Services;
using IMCTaxCalculator.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Presentation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            TaxJarCalculater txjCalc = new TaxJarCalculater();
            CustOrder order = new CustOrder();
           
            float taxRate;
            order.from_country = "US";
            order.from_zip = "92093";
            order.from_state = "CA";
            order.from_city = "La Jolla";
            order.from_street = "9500 Gilman Drive";
            order.to_country = "US";
            order.to_zip = "90002";
            order.to_state = "CA";
            order.to_city = "Los Angeles";
            order.to_street = "1335 E 103rd St";
            order.amount = 15;
            order.shipping = 2;
            taxRate = await txjCalc.GetOrderTax(order);
            Console.WriteLine(taxRate);
            Console.ReadLine();
        }
    }
}
