using Order_Processing.Entities;
using Order_Processing.Entities.Interface;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Processing.Repository.Interface
{
    public interface IOrderProcessingRepository
    {
        Task<long> Create(Order order);

        IOrder Get(long orderId);

        IOrderedQueryable<IOrder> GetAll();

        IOrderedQueryable<IProductType> GetAllProductType();

    }
}
