using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order_Processing.BLL.Interface;
using Order_Processing.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Processing.Controllers
{
    [Route("api/[controller]")]
    public class OrderProcessingController : Controller
    {
        private readonly IOrderProcessingBll _orderProcessingBll;

        public OrderProcessingController(IOrderProcessingBll orderProcessingBll)
        {
            this._orderProcessingBll = orderProcessingBll;
        }

        [HttpGet("getall")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            try
            {
                var result = _orderProcessingBll.GetAll();

                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retireving  data to the database");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetById(long id)
        {
            try
            {
                if (id != 0)
                {
                    var result = _orderProcessingBll.Get(id);

                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retireving  data to the database");
            }
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] OrderDetailVm[] orderDetails)
        {
            try
            {
                if (orderDetails == null || orderDetails.Length == 0)
                {
                    return BadRequest("Orders list can't be null!");
                }
                if (orderDetails.Any(x=>x.ProductId==0) || orderDetails.Any(x => x.Quantity == 0))
                {
                    return BadRequest("Product Id and Quantity can't be 0!");
                }
                var order = new OrderVm()
                {
                    OrderDetails = orderDetails
                };
                var newOrderId  = await _orderProcessingBll.Create(order);
                var result = _orderProcessingBll.Get(newOrderId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in saving  data to the database " + ex);
            }
        }
    }
}
