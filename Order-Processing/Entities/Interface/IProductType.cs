namespace Order_Processing.Entities.Interface
{
    public interface IProductType
    {
        long ProductTypeId { get; set; }

        string ProductTypeName { get; set; }

        double ProductWidth { get; set; }

        OrderDetail OrderDetail { get; set; }

    }
}
