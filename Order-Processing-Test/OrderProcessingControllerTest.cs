using Microsoft.AspNetCore.Mvc;
using Moq;
using Order_Processing.BLL.Interface;
using Order_Processing.BusinessObjects;
using Order_Processing.BusinessObjects.Interfae;
using Order_Processing.Controllers;
using Order_Processing.Repository.Interface;
using Order_Processing.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Order_Processing_Test
{
    public class OrderProcessingControllerTest
    {
        private Mock<IOrderProcessingBll> _orderProcessingBll;
        private readonly IEnumerable<IOrderBo> _orderList;
        private OrderProcessingController _orderProcessingController;


        public OrderProcessingControllerTest()
        {
            _orderList = new List<OrderBo>() {
            new OrderBo{ OrderId = 123, MinimumBoxSize = 153 ,
                OrderDetails = new List<OrderDetailBo>(){ new OrderDetailBo { OrderDetailId =1, OrderId =123 , ProductId= 1, Quantity =1},
                                                        new OrderDetailBo { OrderDetailId =2, OrderId =123 , ProductId= 2, Quantity =2},
                                                        new OrderDetailBo { OrderDetailId =3, OrderId =123 , ProductId= 5, Quantity =2},
            } },
            new OrderBo{ OrderId = 456, MinimumBoxSize = 133 ,
                OrderDetails = new List<OrderDetailBo>(){ new OrderDetailBo { OrderDetailId =4, OrderId =456 , ProductId= 2, Quantity =2},
                                                        new OrderDetailBo { OrderDetailId =5, OrderId =456 , ProductId= 3, Quantity =1},
                                                        new OrderDetailBo { OrderDetailId =6, OrderId =456 , ProductId= 5, Quantity =4},
            } },
            new OrderBo{ OrderId = 789, MinimumBoxSize = 133 ,
                OrderDetails = new List<OrderDetailBo>(){ new OrderDetailBo { OrderDetailId =7, OrderId =789 , ProductId= 1, Quantity =2},
                                                        new OrderDetailBo { OrderDetailId =8, OrderId =789 , ProductId= 3, Quantity =2},
                                                        new OrderDetailBo { OrderDetailId =9, OrderId =789 , ProductId= 4, Quantity =4},
            } }
            };

            Setup();
        }

        private void Setup()
        {
            _orderProcessingBll = new Mock<IOrderProcessingBll>();

            _orderProcessingBll.Setup(o => o.GetAll()).Returns(_orderList);
            _orderProcessingBll.Setup(t => t.Get(123)).Returns(_orderList.ToList().FirstOrDefault(t => t.OrderId == 123));

            _orderProcessingController = new OrderProcessingController(_orderProcessingBll.Object);
        }

        [Fact]
        public void GetAllOrders_WhenCalled_ReturnsOkResult()
        {
            var okResult = _orderProcessingController.GetAll();

            _orderProcessingBll.Verify(s => s.GetAll(), Times.Once());
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsAllOrders()
        {
            var okResult = _orderProcessingController.GetAll() as OkObjectResult;

            var items = Assert.IsType<List<OrderBo>>(okResult.Value);
            _orderProcessingBll.Verify(s => s.GetAll(), Times.Once());

            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void Get_WhenCalledwithOrderId_ReturnsOrder()
        {
            var okResult = _orderProcessingController.GetById(123) as OkObjectResult;

            var items = Assert.IsType<OrderBo>(okResult.Value);
            _orderProcessingBll.Verify(s => s.Get(123), Times.Once());

            Assert.Equal(123, items.OrderId);
        }

        [Fact]
        public void Create_WhenCalled_ReturnsBadRequest()
        {
            var badObject = _orderProcessingController.Create(null);
            var badResult = badObject.Result as BadRequestObjectResult;

            var items = Assert.IsType<string>(badResult.Value);
            _orderProcessingBll.Verify(s => s.Create(null), Times.Never());

            Assert.Equal("Orders list can't be null!", items);
            Assert.Equal(400, badResult.StatusCode);
        }

        [Fact]
        public void Create_WhenCalledWithProductTypeNull_ReturnsBadRequest()
        {
            var orderDetailsVm = new OrderDetailVm[] { new OrderDetailVm { Quantity = 2 } };
            var badObject = _orderProcessingController.Create(orderDetailsVm);
            var badResult = badObject.Result as BadRequestObjectResult;

            var items = Assert.IsType<string>(badResult.Value);
            _orderProcessingBll.Verify(s => s.Create(null), Times.Never());

            Assert.Equal("Product Id and Quantity can't be 0!", items);
            Assert.Equal(400, badResult.StatusCode);
        }
    }
}
