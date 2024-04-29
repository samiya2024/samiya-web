using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Assessment_1.Models;

namespace MVC_Assessment_1.Controllers
{
    public class CodeController : Controller
    {
        private masterEntities db = new masterEntities();

        // Action method to return all customers residing in Germany
        public ActionResult CustomersInGermany()
        {
            var customersInGermany = db.Customers.Where(c => c.Country == "Germany").ToList();
            return View(customersInGermany);
        }

        // Action method to return customer details with orderId==10248
        public ActionResult CustomerDetailsForOrderId()
        {
            var customerDetails = db.Orders.Where(o => o.OrderID == 10248).Select(o => o.Customer).FirstOrDefault();
            return View(customerDetails);
        }
    }

}