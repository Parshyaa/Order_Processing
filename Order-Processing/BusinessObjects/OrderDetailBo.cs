using Order_Processing.BusinessObjects.Interfae;

namespace Order_Processing.BusinessObjects
{
    public class OrderDetailBo : IOrderDetailBo
    {
        public long OrderDetailId { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public IProductTypeBo ProductDetail { get; set; }
        public int Quantity { get; set; }
    }
}
