using Order_Processing.BusinessObjects.Interfae;

namespace Order_Processing.ViewModels
{
    public class ProductTypeVm : IProductTypeBo
    {
        public long ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public double ProductWidth { get; set; }
    }
}
