using Order_Processing.BusinessObjects;
using Order_Processing.BusinessObjects.Interfae;
using System.Collections.Generic;

namespace Order_Processing.ViewModels
{
    public class OrderVm : IOrderBo
    {
        public OrderVm()
        {
            this.OrderDetails = new List<OrderDetailBo>();
        }

        public long OrderId { get; set; }
        public double MinimumBoxSize { get; set; }

        public IEnumerable<IOrderDetailBo> OrderDetails { get; set; }
    }
}
