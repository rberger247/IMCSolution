using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMCTaxCalculater.Application.Services;
using IMCTaxCalculator.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IMCTaxCalculater.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxCalculator : ControllerBase
    {
 
        private readonly ILogger<TaxCalculator> _logger;
       public TaxCalculator(ILogger<TaxCalculator> logger)
        {
            
            _logger = logger;
        }

        [HttpGet]
        public float GetTaxJarTaxRate(Location location)
        {

           
          TaxJarCalculater txjCalc = new TaxJarCalculater();
            float taxRate = 0;          
           //taxRate = txjCalc.GetTaxRate(location.ZipCode);
           return taxRate;
        }
    }
}
