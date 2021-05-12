using System.Collections.Generic;

namespace Order_Processing.Entities.Interface
{
    public interface IOrder
    {
        long OrderId { get; set; }
        double MinimumBoxSize { get; set; }

        ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
