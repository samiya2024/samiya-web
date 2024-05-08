using System.Collections.Generic;
using System.Linq;
using MVC_CORE_Ass.Models;
//using MVC_CORE_Ass.Repository;

namespace Assessment1.Repository
{
    public class OrderRepo : IOrderRepository
    {
        private readonly NorthwindContext _context;

        public int TotalAmount { get; set; }
        public OrderRepo(NorthwindContext context)
        {
            _context = context;
        }

        public void PlaceOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public Order GetOrderDetails(int orderId)
        {
            return _context.Orders.FirstOrDefault(o => o.OrderId == orderId);
        }



        public decimal DisplayBill(int orderId)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order != null)
            {

                decimal totalAmount = order.OrderDetails.Sum(od => od.Quantity * od.UnitPrice);
                return totalAmount;
            }
            return 0;
        }

        public List<Order> GetOrdersByDate(string orderDate)
        {
            DateTime date = DateTime.Parse(orderDate);

            return _context.Orders.Where(o => o.OrderDate == date.Date).ToList();
        }

        public Customer GetCustomerWithHighestOrder()
        {
            return _context.Customers.OrderByDescending(c => c.Orders.Sum(o => o.OrderId)).FirstOrDefault();
        }


    }
}
