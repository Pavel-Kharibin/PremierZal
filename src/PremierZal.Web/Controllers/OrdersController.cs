using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PremierZal.Common.Models;
using PremierZal.Service.Interfaces;
using ControllerBase = PremierZal.Web.Common.Bases.ControllerBase;

namespace PremierZal.Web.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        public OrdersController(IPrimierZalService servive) : base(servive)
        {
        }

        public async Task<IEnumerable<Order>> Get()
        {
            var orders = await Service.OrdersGetAllWithSessionAsync();

            return orders;
        }


        [HttpPost]
        public async Task<Order> Add([FromBody] Order order)
        {
            await Service.OrderAddAsync(order);

            return order;
        }
    }
}