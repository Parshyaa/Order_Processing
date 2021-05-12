using Order_Processing.BusinessObjects.Interfae;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Order_Processing.BLL.Interface
{
    public interface IOrderProcessingBll
    {
        Task<long> Create(IOrderBo order);

        IOrderBo Get(long orderId);

        IEnumerable<IOrderBo> GetAll();

        IEnumerable<IProductTypeBo> GetAllProductType();
    }
}
