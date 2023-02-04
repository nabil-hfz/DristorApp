using System;
using DristorApp.Data.DTOs.OrderStatusUpdate;
using DristorApp.Data.Models;
using DristorApp.Repositories.BaseRepository;
using DristorApp.Repositories.OrderRepository;
using Microsoft.AspNetCore.Mvc;

namespace DristorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusUpdatesController : ControllerBase
    {
        private readonly IRepository<OrderStatusUpdate, int> _orderStatusUpdateRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderStatusUpdatesController(IRepository<OrderStatusUpdate, int> orderStatusUpdateRepository , IOrderRepository orderRepository)
        {
            _orderStatusUpdateRepository = orderStatusUpdateRepository;
            _orderRepository = orderRepository;
        }

        // GET: api/OrderStatusUpdates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderStatusUpdate>>> GetOrderStatusUpdate()
        {
            return await _orderStatusUpdateRepository.GetAllAsync();
        }

        // GET: api/OrderStatusUpdates/3
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderStatusUpdate>> GetOrderStatusUpdate(int id)
        {
            var orderStatusUpdate = await _orderStatusUpdateRepository.GetByIdAsync(id);

            if (orderStatusUpdate == null)
            {
                return NotFound();
            }

            var order = await _orderRepository.GetByIdAsync(orderStatusUpdate.OrderId);

            if (order == null)
            {
                return NotFound("Order not found");
            }
            orderStatusUpdate.Order = order;

            return orderStatusUpdate;
        }

        // PUT: api/OrderStatusUpdates/3
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderStatusUpdate(int id, OrderStatusUpdateCreateDTO orderStatusUpdateUDTO)
        {
            if (id != orderStatusUpdateUDTO.Id)
            {
                return BadRequest();
            }

            var order = await _orderRepository.GetByIdAsync(orderStatusUpdateUDTO.OrderId);

            if (order == null)
            {
                return NotFound("Order not found");
            }

            var osu = new OrderStatusUpdate
            {
                TimesTamp = orderStatusUpdateUDTO.TimesTamp,
                Status = orderStatusUpdateUDTO.Status,
                OrderId = order.Id,
                Order = order
            };

            await _orderStatusUpdateRepository.UpdateAsync(osu);

            return NoContent();
        }

        // POST: api/OrderStatusUpdates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderStatusUpdate>> PostOrderStatusUpdate(OrderStatusUpdateCreateDTO orderStatusUpdateDTO)
        {

            var order = await _orderRepository.GetByIdAsync(orderStatusUpdateDTO.OrderId);

            if (order == null)
            {
                return NotFound("Order not found");
            }

            var osu = new OrderStatusUpdate
            {
                TimesTamp = orderStatusUpdateDTO.TimesTamp,
                Status = orderStatusUpdateDTO.Status,
                OrderId = order.Id,
                Order = order
            };
            await _orderStatusUpdateRepository.CreateAsync(osu);

            return CreatedAtAction("GetOrderStatusUpdate", new { id = osu.Id }, osu);
        }

        // DELETE: api/OrderStatusUpdates/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderStatusUpdate(int id)
        {
            var orderStatusUpdate = await _orderStatusUpdateRepository.GetByIdAsync(id);
            if (orderStatusUpdate == null)
            {
                return NotFound();
            }

            await _orderStatusUpdateRepository.DeleteAsync(orderStatusUpdate);

            return NoContent();
        }


    }
}