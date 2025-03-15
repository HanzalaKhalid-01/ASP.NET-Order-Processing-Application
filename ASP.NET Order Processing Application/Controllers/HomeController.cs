using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Order_Processing_Application.Controllers;

public class HomeController : Controller
{
    public ActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Index(decimal orderAmount, string customerType)
    {
        if (orderAmount > 0 && !string.IsNullOrEmpty(customerType))
        {
            decimal discount = 0;
            decimal finalAmount = orderAmount;

            // Calculate discount accurately
            if (orderAmount >= 100 && customerType.Contains("Loyal"))
            {
                discount = orderAmount * 0.10M; // 10% discount
                finalAmount = orderAmount - discount;
            }

            // Pass data to the Result page through TempData 
            TempData["OrderAmount"] = orderAmount.ToString("F2");
            TempData["CustomerType"] = customerType;
            TempData["Discount"] = discount.ToString();
            TempData["FinalAmount"] = finalAmount.ToString("F2");

            return RedirectToAction("Result");
        }
        ViewBag.ErrorMessage = "Please provide valid inputs.";
        return View();
    }

    public ActionResult Result()
    {
        // Retrieve data from TempData
        ViewBag.OrderAmount = TempData["OrderAmount"];
        ViewBag.CustomerType = TempData["CustomerType"];
        ViewBag.Discount = TempData["Discount"];
        ViewBag.FinalAmount = TempData["FinalAmount"];

        return View();
    }
}
