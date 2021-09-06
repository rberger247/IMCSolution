using IMCTaxCalculator.Application.Services;
using IMCTaxCalculator.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Presentation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            TaxService taxService = new TaxService();
            CustOrder order = new CustOrder();
            order.shipping = 10;
            order.amount = 5;
            float taxRate = 0;
            float taxForOrder = 0;
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
                          // var taxfunction = args[0];
            var taxfunction = "TaxForOrder";
            switch (taxfunction)
            {
                case "TaxRate": 
                    taxRate = await taxService.GetTaxRate("taxJarCust", "48237");
                    break;
                case "TaxForOrder":
                   taxRate = await taxService.GetTaxForOrder("taxJarCust", order);
                    break;
                default:
                    Console.WriteLine("Please Select a function");
                    break;
            }
  
            Console.WriteLine(taxRate + " ");
            Console.ReadLine();
        }
    }
}
