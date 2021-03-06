﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using DotnetCoreInfra.SeedWork;

using Ordering.Domain.AggregateModels;
using Ordering.Domain.Enums;
using Ordering.DomainService.Interfaces;
using Ordering.Infrastructure.Entities;
using Ordering.Infrastructure.Repos;

namespace Ordering.DomainService.Implements
{
    public class OrderSercvice : BaseService
        , IOrderService
    {
        public OrderSercvice(IOrderRepository orderRepository
            , IMapper mapper
            , IUnitOfWork unitOfWork) : base(orderRepository, mapper, unitOfWork)
        {
        }

        public async Task<Order> CreateAsync(Order model)
        {
            OrderEntity order = mapper.Map<OrderEntity>(model);
            order.Created = DateTime.Now;
            order.Edited = DateTime.Now;
            order.Id = Guid.NewGuid().ToString();
            order.Status = OrderStatus.Inactived;
            repository.Create(order);

            foreach (var item in model.Details)
            {
                OrderDetailEntity orderDetail = new OrderDetailEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    OrderId = order.Id,
                    GoodsId = item.GoodsId,
                    GoodsName = item.GoodsName,
                    Number = item.Number,
                    Created = DateTime.Now,
                    Edited = DateTime.Now
                };
                repository.CreateDetail(orderDetail);
            }
            await unitOfWork.Commit();
            return mapper.Map<Order>(order);
        }

        public Task<Order> UpdateAsync(Order model)
        {
            throw new NotImplementedException();
        }
    }
}
