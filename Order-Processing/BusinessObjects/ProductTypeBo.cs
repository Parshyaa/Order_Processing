using Order_Processing.BusinessObjects.Interfae;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Processing.BusinessObjects
{
    public class ProductTypeBo : IProductTypeBo
    {
        public long ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public double ProductWidth { get; set; }
    }
}
