using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessingTests
{
    using ASP.NET_Order_Processing_Application.Models;
    using Xunit;

    public class DiscountCalculatorTests
    {
        [Fact]
        public void CalculateDiscount_LoyalCustomerWithHighOrder_Returns10PercentDiscount()
        {
            // Arrange
            var calculator = new DiscountCalculator();
            decimal orderAmount = 150;
            string customerType = "Loyal";

            // Act
            var result = calculator.CalculateDiscount(orderAmount, customerType);

            // Assert
            Assert.Equal(15, result); // 10% of 150 is 15
        }

        [Fact]
        public void CalculateDiscount_NewCustomerWithHighOrder_ReturnsNoDiscount()
        {
            // Arrange
            var calculator = new DiscountCalculator();
            decimal orderAmount = 150;
            string customerType = "New";

            // Act
            var result = calculator.CalculateDiscount(orderAmount, customerType);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculateDiscount_LoyalCustomerWithLowOrder_ReturnsNoDiscount()
        {
            // Arrange
            var calculator = new DiscountCalculator();
            decimal orderAmount = 50;
            string customerType = "Loyal";

            // Act
            var result = calculator.CalculateDiscount(orderAmount, customerType);

            // Assert
            Assert.Equal(0, result);
        }
    }

}
