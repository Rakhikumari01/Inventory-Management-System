﻿using InventoryManagementSystem.Domain;
using InventoryManagementSystem.IRepository;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Exceptions;

namespace InventoryManagementSystem.Service
{
    public class OrderService : Interface.IOrderService
    {

        public IRepository<Order> _orderservice;
        public IRepository<Product> _productservice;

        public OrderService(IRepository<Order> orderservice, IRepository<Product> productservice)
        {
            _orderservice = orderservice;
            _productservice = productservice;
        }

        public void AddOrder(OrderDto orderDto)
        {
            var p = orderDto.Quantity;
            if (p < 0)
            {
                throw new CustomException("quantity entered is invalid");
            }
            var order = new Order()
            {
                Quantity = orderDto.Quantity,
                Status = orderDto.Status,
                CustomerId = orderDto.CustomerId,
                ProductId = orderDto.ProductId,
            };

             UpdateProductQuantity(orderDto.ProductId, orderDto.Quantity);
            _orderservice.Add(order);

        }

        public void DeleteOrder(int id)
        {
            if (CheckException(id))
            {
                _orderservice.Delete(id);

            }
            else throw new CustomException("Order id not found");

        }

        public ViewOrderDto GetOrder(int id)
        {
            if(CheckException(id))
            {
                return new ViewOrderDto(_orderservice.Get(id), _productservice);
            }

            else throw new CustomException("Order id not found");
        }
        public void UpdateProductQuantity(int productId, int quantityChange)
        {
            var product = _productservice.Get(productId);

            if (product != null)
            {
                // Ensure the quantity doesn't go below zero
                product.Quantity = Math.Max(0, product.Quantity - quantityChange);
                _productservice.Update(product);
            }
        }

        public void Upadte(int id,OrderDto orderDto)
        {
            var updateOrder = new Order()
            {
                Id = id,
                Quantity = orderDto.Quantity,
                Status = orderDto.Status,
                ProductId= orderDto.ProductId,
                CustomerId= orderDto.CustomerId,

            };
            _orderservice.Update(updateOrder);

        }


        public bool CheckException(int id)
        {
            var order = _orderservice.Get(id);
            if (order != null)
            {
                return true;
            }

            return false;
        }

    }

}
