using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMCTaxCalculator.Application.Services;
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

   
    }
}
