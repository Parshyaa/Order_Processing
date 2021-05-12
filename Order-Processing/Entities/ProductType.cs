using Order_Processing.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Processing.Entities
{
    public class ProductType : IProductType
    {
        public long ProductTypeId { get; set; }
        public double ProductWidth { get; set; }
        public string ProductTypeName { get; set; }

        public OrderDetail OrderDetail { get; set; }

    }
}
