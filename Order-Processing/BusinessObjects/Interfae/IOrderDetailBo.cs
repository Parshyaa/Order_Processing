namespace Order_Processing.BusinessObjects.Interfae
{
    public interface IOrderDetailBo
    {
        long OrderDetailId { get; set; }
        long OrderId { get; set; }
        long ProductId { get; set; }
        IProductTypeBo ProductDetail { get; set; }
        int Quantity { get; set; }
    }
}
