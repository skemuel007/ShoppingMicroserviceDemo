using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Data.Repository.v1
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> GetPaidOrdersAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<Order> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken = default(CancellationToken));

        Task<List<Order>> GetOrderByCustomerGuidAsync(Guid customerId, CancellationToken cancellationToken = default(CancellationToken));
    }
}
