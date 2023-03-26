﻿using Microsoft.EntityFrameworkCore;
using OrderApi.Data.Database;
using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Data.Repository.v1
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext orderContext) : base(orderContext)
        {
        }

        public async Task<List<Order>> GetOrderByCustomerGuidAsync(Guid customerId, CancellationToken cancellationToken = default)
        {
            return await _orderContext.Orders.Where(x => x.OrderState == 2).ToListAsync(cancellationToken);
        }

        public async Task<Order> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken = default) =>
            await _orderContext.Orders.FirstOrDefaultAsync(x => x.Id == orderId, cancellationToken);

        public async Task<List<Order>> GetPaidOrdersAsync(CancellationToken cancellationToken = default)
        {
            return await _orderContext.Orders.Where(x => x.OrderState == 2).ToListAsync(cancellationToken);
        }
    }
}
