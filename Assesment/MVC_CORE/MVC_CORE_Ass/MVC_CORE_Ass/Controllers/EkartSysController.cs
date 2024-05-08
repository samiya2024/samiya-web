using Assessment1.Repository;
using Microsoft.AspNetCore.Mvc;
using MVC_CORE_Ass.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assessment1.Controllers
{
    public class EkartSysController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public EkartSysController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Place Order
        [HttpPost]
        public IActionResult PlaceOrder(Order order)
        {
            _orderRepository.PlaceOrder(order);
            return RedirectToAction("OrderDetails", new { orderId = order.OrderId });
            if (ModelState.IsValid)
            {

            }
            return View(order);
        }


        //Show the orders

        [HttpPost]
        public IActionResult OrderDetails(int orderId)
        {
            var order = _orderRepository.GetOrderDetails(orderId);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        //Display Bill
        public IActionResult DisplayBill(int orderId)
        {
            var billAmount = _orderRepository.DisplayBill(orderId);
            ViewBag.OrderId = orderId;
            ViewBag.BillAmount = billAmount;
            return View();
        }

        //Customer_Details by Order Date
        public IActionResult CustomerDetailsByOrderDate(string orderDate)
        {
            var orders = _orderRepository.GetOrdersByDate(orderDate);

            return View(orders);
        }

        //Display the customer who placed the highest order
        public IActionResult CustomerWithHighestOrder()
        {
            var customer = _orderRepository.GetCustomerWithHighestOrder();
            return View(customer);
        }
    }
}