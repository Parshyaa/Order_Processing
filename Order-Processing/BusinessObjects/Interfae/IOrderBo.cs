using System.Collections.Generic;

namespace Order_Processing.BusinessObjects.Interfae
{
    public interface IOrderBo
    {
        long OrderId { get; set; }
        double MinimumBoxSize { get; set; }
        IEnumerable<IOrderDetailBo> OrderDetails { get; set; }
    }
}
