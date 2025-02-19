namespace OpenableProject.Controller;

using Microsoft.AspNetCore.Mvc;
using OpenableProject.Model;
using OpenableProject.Services;
using System;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Order>> GetOrders()
    {
        var orders = _orderService.GetAllOrders();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public ActionResult<Order> GetOrder(int id)
    {
        var order = _orderService.GetOrderById(id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }
    

    [HttpPost("create")]
    public ActionResult<Order> CreateOrder(CreateOrderRequest request)
    {
        try
        {
            var order = new Order
            {
                RestaurantId = request.RestaurantId,
                Items = new List<OrderItem>()
            };

            foreach (var itemRequest in request.Items)
            {
                order.Items.Add(new OrderItem
                {
                    MenuId = itemRequest.MenuId,
                    Quantity = itemRequest.Quantity
                });
            }

            var createdOrder = _orderService.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrder), new { id = createdOrder.OrderId }, createdOrder);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}/complete")]
    public ActionResult<Order> CompleteOrder(int id)
    {
        try
        {
            var completedOrder = _orderService.CompleteOrder(id);
            return Ok(completedOrder);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }


}