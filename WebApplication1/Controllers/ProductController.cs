using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using WebAPIRetailProduct.Model;
using WebAPIRetailProduct.Repository;

namespace WebAPIRetailProduct.Controllers
{
    [ApiController]
    
    public class ProductController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ProductController> _logger;

        private readonly IProductService _ProductService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _ProductService = productService;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public ActionResult<IEnumerable<string>> Getvalue()
        {
            return new string[] { "value1","value2" };
        }

        [HttpPost]
        [Route("api/[controller]/SaveProduct")]
        public ResponseData SaveProductDetails(TblProductDetails indtls)
        {
            ResponseData lstout = new ResponseData();
            lstout = _ProductService.SaveProductDetails(indtls);

            return lstout;
        }

        [HttpPost]
        [Route("api/[controller]/UpdateProduct")]
        public ResponseData UpdateProductDetails(TblProductDetails indtls)
        {
            ResponseData lstout = new ResponseData();
            lstout = _ProductService.UpdateProductDetails(indtls);

            return lstout;
        }

        [HttpPost]
        [Route("api/[controller]/DeleteProduct")]
        public ResponseData DeleteProductDetails(TblProductDetails indtls)
        {
            ResponseData lstout = new ResponseData();
            lstout = _ProductService.DeleteProductDetails(indtls.ProductId);

            return lstout;
        }

    }
}
