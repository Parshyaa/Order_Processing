namespace Order_Processing.BusinessObjects.Interfae
{
    public interface IProductTypeBo
    {
        long ProductTypeId { get; set; }

        string ProductTypeName { get; set; }

        double ProductWidth { get; set; }
    }
}
