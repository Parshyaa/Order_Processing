using AutoMapper;
using Order_Processing.BLL.Interface;
using Order_Processing.BLL.Type;
using Order_Processing.BusinessObjects.Interfae;
using Order_Processing.Entities;
using Order_Processing.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Processing.BLL
{
    public class OrderProcessingBll : IOrderProcessingBll
    {
        private readonly IMapper _mapper;
        private readonly IOrderProcessingRepository _repository;

        public OrderProcessingBll(IOrderProcessingRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<long> Create(IOrderBo order)
        {
            order.MinimumBoxSize = this.CalculateMinimumBoxSize(order);
            var orderDe = _mapper.Map<Order>(order);
            var orderId = await _repository.Create(orderDe);

            return orderId;
        }

        public IOrderBo Get(long orderId)
        {
            var result = _repository.Get(orderId);

            return _mapper.Map<IOrderBo>(result);
        }

        public IEnumerable<IOrderBo> GetAll()
        {
            var result = _repository.GetAll();

            return _mapper.Map<IEnumerable<IOrderBo>>(result);
        }

        public IEnumerable<IProductTypeBo> GetAllProductType()
        {
            var result = _repository.GetAllProductType();

            return _mapper.Map<IEnumerable<IProductTypeBo>>(result);
        }

        private double CalculateMinimumBoxSize(IOrderBo order)
        {
            var productList = GetAllProductType();

            double sum = 0;
            foreach (var item in order.OrderDetails)
            {
                int count;
                if (item.ProductId == (int)ProductTypeEnum.Mug)
                {
                    count = (item.Quantity % 4 == 0) ? (item.Quantity / 4) : ((item.Quantity / 4) + 1);
                }
                else
                {
                    count = item.Quantity;
                }
                sum += (count * productList.Where(p=>p.ProductTypeId == item.ProductId).Select(p=>p.ProductWidth).FirstOrDefault());
            }
            return sum;
        }
    }
}
