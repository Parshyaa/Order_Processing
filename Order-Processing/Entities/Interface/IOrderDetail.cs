namespace Order_Processing.Entities.Interface
{
    public interface IOrderDetail
    {
        long OrderDetailId { get; set; }
        long OrderId { get; set; }
        Order Order { get; set; }
        long ProductId { get; set; }
        ProductType ProductDetail { get; set; }
        int Quantity { get; set; }      
    }
}
