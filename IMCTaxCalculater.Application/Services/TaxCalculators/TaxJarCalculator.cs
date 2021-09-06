
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Newtonsoft.Json;

using IMCTaxCalculator.Domain.Interfaces;
using IMCTaxCalculator.Domain.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace IMCTaxCalculator.Application.Services
{
    public  class TaxJarCalculater : ITaxCalculator
    {
        private readonly string baseUrl = "https://api.taxjar.com/v2/";
        private static HttpClient client;
        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions();
        public TaxJarCalculater()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer 5da2f821eee4035db4771edab942a4cc");


        }
        public async Task<float> GetOrderTax(CustOrder custOrder){ 
                        
            float orderTax = 0;                                    
            try {
          
                var jsonString = JsonConvert.SerializeObject(custOrder);
                var res = await client.PostAsync(baseUrl + "taxes", new StringContent(jsonString, Encoding.UTF8, "application/json")).ConfigureAwait(false);                     
                    if (res.IsSuccessStatusCode) {                                
                        var deserializedTax = JsonConvert.DeserializeObject<JObject>(res.Content.ReadAsStringAsync().Result);                
                        if (deserializedTax != null)
                        {
                           orderTax = (float)deserializedTax["tax"]["amount_to_collect"];

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
                var res = await client.GetAsync(baseUrl + "rates/" + zipCode).ConfigureAwait(false);
                if (res.IsSuccessStatusCode)
                {
                    var deserializedTax = JsonConvert.DeserializeObject<JObject>(res.Content.ReadAsStringAsync().Result);
                    if (deserializedTax != null)
                    {
                        taxRate = (float)deserializedTax["rate"]["combined_rate"];

                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return taxRate;
        }
    }
}
