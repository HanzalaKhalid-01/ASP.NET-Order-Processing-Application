using Microsoft.AspNetCore.Mvc;
using ASP.NET_Order_Processing_Application.Models;

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
            decimal finalAmount = orderAmount;
            DiscountCalculator dc  = new DiscountCalculator();
            var discount  = dc.CalculateDiscount(orderAmount, customerType);
            if (discount > 0)
            {
                finalAmount-=discount;
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
