namespace ASP.NET_Order_Processing_Application.Models
{
    public class DiscountCalculator
    {
        public decimal CalculateDiscount(decimal orderAmount, string customerType)
        {
            if (orderAmount >= 100 && customerType == "Loyal")
            {
                return orderAmount * 0.10M; // 10% discount
            }

            return 0; // No discount
        }
    }

}
