using Order_Processing.Entities.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order_Processing.Entities
{
    public class Order : IOrder
    {
        public long OrderId { get; set ; }
        public double MinimumBoxSize { get; set; }

        [ForeignKey("OrderId")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
