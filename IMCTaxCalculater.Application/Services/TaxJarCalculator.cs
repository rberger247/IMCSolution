using IMCTaxCalculator.Domain.Interfaces;
using IMCTaxCalculator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore;

namespace IMCTaxCalculater.Application.Services
{
    public class TaxJarCalculater : ITaxCalculator
    {
        private readonly string baseUrl = "https://api.taxjar.com/v2/";
        private static HttpClient client;
        public TaxJarCalculater()
        {
            client = new HttpClient();
            

        }
        public async Task<float> GetOrderTax(CustOrder custOrder )
            {             
             float orderTax = 0;                      
            try{
                custOrder.from_country = "US";
                custOrder.from_zip = "92093";
                custOrder.from_state = "CA";
                custOrder.from_city = "La Jolla";
                custOrder.from_street = "9500 Gilman Drive";
                custOrder.to_country = "US";
                custOrder.to_zip = "90002";
                custOrder.to_state = "CA";
                custOrder.to_city = "Los Angeles";
                custOrder.to_street = "1335 E 103rd St";
                custOrder.amount = 15;
                custOrder.shipping = 2;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer 5da2f821eee4035db4771edab942a4cc");
                string jsonString = JsonSerializer.Serialize(custOrder);    
                var res = await client.PostAsync(baseUrl + "taxes", new StringContent(jsonString, Encoding.UTF8, "application/json"));             
                if (res.IsSuccessStatusCode){
                 var result=   JsonSerializer.Deserialize<CustOrder>(  res.Content.ReadAsStringAsync().ToString());               
                  if (result != null)
                    {
                        orderTax = result.amount_to_collect;
                    }
                }
   
    }
            catch (Exception ex)
            {

                throw ex;
            }
           return orderTax;
        }

        public async Task<float> GetTaxRate(string zipCode)
        {
            float taxRate = 0;
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            return taxRate;
        }
    }
}
