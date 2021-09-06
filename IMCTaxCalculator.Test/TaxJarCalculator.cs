using NUnit.Framework;
using IMCTaxCalculator.Application;
using IMCTaxCalculator.Application.Services;
using IMCTaxCalculator.Domain.Models;

namespace IMCTaxCalculator.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async System.Threading.Tasks.Task TestTaxForOrderAsync()
        {
            var ExpectedtaxRate = 1;
            TaxService taxService = new TaxService();
            CustOrder order = new CustOrder();
            order.shipping = 10;
            order.amount = 5;
            float expected = 0;
            float actual = 0;
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
             actual = await taxService.GetTaxForOrder("taxJarCust", order);
            Assert.AreEqual(ExpectedtaxRate, actual, 0.001, "");
            Assert.Pass();
        }
        [Test]
        public async System.Threading.Tasks.Task TestTaxRateAsync()
        {
            var ExpectedtaxRate = 1;
            TaxService taxService = new TaxService();
            CustOrder order = new CustOrder();
            float expected = 0;
            float actual = 0;       
            actual = await taxService.GetTaxRate("taxJarCust", "");
            Assert.AreEqual(ExpectedtaxRate, actual, 0.001, "");
            Assert.Pass();
        }
    }
}