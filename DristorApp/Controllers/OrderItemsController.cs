using System;
using DristorApp.Data.DTOs.Orderitem;
using DristorApp.Data.Models;
using DristorApp.Repositories.BaseRepository;
using DristorApp.Repositories.OrderRepository;
using Microsoft.AspNetCore.Mvc;

namespace DristorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IRepository<OrderItem, int> _orderItemRepository;
        private readonly IRepository<ProductVariant, int> _productVariantRepository;

        public OrderItemsController(
            IOrderRepository orderRepository,
            IRepository<OrderItem, int> orderItemRepository,
            IRepository<ProductVariant, int> productVariantRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _productVariantRepository = productVariantRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems()
        {
            return await _orderItemRepository.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<OrderItem>> GetOrderItem(int id)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(id);
            if (orderItem is null)
            {
                return NotFound();
            }

            return Ok(orderItem);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<OrderItem>> PutOrderItem(int id, OrderItemUpdateDTO dto)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(id);
            if (orderItem is null)
            {
                return NotFound();
            }

            var order = await _orderRepository.GetByIdAsync(dto.Order);
            if (order is null)
            {
                return NotFound();
            }

            var productVariant = await _productVariantRepository.GetByIdAsync(dto.ProductVariant);
            if (productVariant is null)
            {
                return NotFound();
            }

            orderItem.Quantity = dto.Quantity;
            orderItem.Order = order;
            orderItem.ProductVariant = productVariant;

            await _orderItemRepository.UpdateAsync(orderItem);

            return Ok(orderItem);
        }

        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem(OrderItemCreateDTO dto)
        {
            var order = await _orderRepository.GetByIdAsync(dto.Order);
            if (order is null)
            {
                return NotFound();
            }

            var productVariant = await _productVariantRepository.GetByIdAsync(dto.ProductVariant);
            if (productVariant is null)
            {
                return NotFound();
            }

            var orderItem = new OrderItem
            {
                Quantity = dto.Quantity,
                Order = order,
                ProductVariant = productVariant
            };

            await _orderItemRepository.CreateAsync(orderItem);

            return Ok(orderItem);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(id);
            if (orderItem is null)
            {
                return NotFound();
            }

            await _orderItemRepository.DeleteAsync(orderItem);

            return Ok();
        }
    }
}