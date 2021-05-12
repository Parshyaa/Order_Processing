using Order_Processing.BusinessObjects.Interfae;
using System.Collections.Generic;

namespace Order_Processing.BusinessObjects
{
    public class OrderBo : IOrderBo
    {
        public long OrderId { get; set; }
        public double MinimumBoxSize { get; set; }
        public IEnumerable<IOrderDetailBo> OrderDetails { get; set; }
    }
}
