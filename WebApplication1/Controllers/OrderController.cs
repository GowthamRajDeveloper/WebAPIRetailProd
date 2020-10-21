using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIRetailProduct.Model;
using WebAPIRetailProduct.Repository;

namespace WebAPIRetailProduct.Controllers
{
    
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _OrderService;

        public OrderController(IOrderService orderService)
        {

            _OrderService = orderService;
        }

        [HttpPost]
        [Route("api/[controller]/SaveOrder")]
        public ResponseData SaveOrderDetails(TblProductOrderEntry indtls)
        {
            ResponseData lstout = new ResponseData();
            lstout = _OrderService.SaveOrderDetails(indtls);

            return lstout;
        }


    }
}
