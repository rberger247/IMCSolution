using IMCTaxCalculator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMCTaxCalculator.Application.Services
{

    public class TaxJarCalculator : ITaxCalculator
    {
        public float GetOrderTax(int orderID)
        {
            throw new NotImplementedException();
        }

        public float GetOrderTax(float orderAmount)
        {
            throw new NotImplementedException();
        }


        public float GetTaxRate(string zipCode)
        {
            throw new NotImplementedException();
        }
    }
}
