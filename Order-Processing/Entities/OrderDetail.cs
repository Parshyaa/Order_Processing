using Order_Processing.Entities.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Processing.Entities
{
    public class OrderDetail : IOrderDetail
    {
        public long OrderDetailId { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }

        public long ProductId { get; set; }
        [ForeignKey("ProductId")]
        public ProductType ProductDetail { get; set; }

        public int Quantity { get; set; }
    }
}
