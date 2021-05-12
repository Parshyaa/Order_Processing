using Order_Processing.BusinessObjects.Interfae;
using System.ComponentModel.DataAnnotations;

namespace Order_Processing.ViewModels
{
    public class OrderDetailVm : IOrderDetailBo
    {
        public long OrderDetailId { get; set; }
        public long OrderId { get; set; }

        [Required]
        public long ProductId { get; set; }
        public IProductTypeBo ProductDetail { get; set; }

        public int Quantity { get; set; }
    }
}
