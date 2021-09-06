using IMCTaxCalculator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMCTaxCalculator.Domain.Interfaces
{
  public interface ITaxCalculator
    {
        Task<float> GetTaxRate(string zipCode);
        Task<float> GetOrderTax(CustOrder order);
    }
}
