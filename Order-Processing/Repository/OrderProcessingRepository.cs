using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Order_Processing.Context;
using Order_Processing.Entities;
using Order_Processing.Entities.Interface;
using Order_Processing.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Processing.Repository
{
    public class OrderProcessingRepository : IOrderProcessingRepository
    {
        private readonly IServiceScope _scope;
        private readonly OrderDbContext _databaseContext;
        public OrderProcessingRepository(IServiceProvider services)
        {
            _scope = services.CreateScope();
            _databaseContext = _scope.ServiceProvider.GetRequiredService<OrderDbContext>();
            _databaseContext.Database.EnsureCreated();
        }

        public async Task<long> Create(Order order)
        {
            var newOrder = new Order
            {
                MinimumBoxSize = order.MinimumBoxSize,
            };
            _databaseContext.OrderSet.Add(newOrder);
            var numberOfItemsCreated = await _databaseContext.SaveChangesAsync();
            var orderId = newOrder.OrderId;
            if (orderId != 0)
            {
                AddOrderDetails(order.OrderDetails, orderId);
            }

            return orderId;
        }

        public IOrder Get(long orderId)
        {
            var r = GetAllOrderDetail();
            var result = _databaseContext.OrderSet
                                          .Include(x => x.OrderDetails)
                                          .ThenInclude(c => c.ProductDetail)
                                          .Where(x => x.OrderId == orderId).FirstOrDefault();

            return result;
        }

        public IOrderedQueryable<IOrder> GetAll()
        {
            return _databaseContext.OrderSet.Include(x => x.OrderDetails).OrderByDescending(x => x.OrderId);
        }

        public IOrderedQueryable<IProductType> GetAllProductType()
        {
            return _databaseContext.ProductTypeSet.OrderBy(x => x.ProductTypeId);
        }

        public IOrderedQueryable<IOrderDetail> GetAllOrderDetail()
        {
            return _databaseContext.OrderDetailSet.OrderBy(x => x.OrderDetailId);
        }

        private void AddOrderDetails(IEnumerable<IOrderDetail> details, long orderId) {
            details.ToList().ForEach(d => d.OrderId = orderId);
            foreach (var item in _databaseContext.OrderDetailSet)
            {
                _databaseContext.Entry(item).State = EntityState.Detached;
            }
            _databaseContext.OrderDetailSet.AddRange((IEnumerable<OrderDetail>)details);
            _databaseContext.SaveChanges();
        }
    }
}
